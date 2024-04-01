import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UUID } from 'angular2-uuid';
import { SaveTypeEnum } from 'src/app/enums/save-type-enum.enum';
import { Demand } from 'src/app/models/demand/demand';
import { FilterModel } from 'src/app/models/general/filterModel';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { DemandService } from 'src/app/services/demand/demand.service';
import * as xlsx from 'xlsx';
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';
import { OrderTypeEnum } from 'src/app/enums/order-type-enum.enum';
import { OrderService } from 'src/app/services/general/order.service';
@Component({
  selector: 'app-demand',
  templateUrl: './demand.component.html',
  styleUrls: ['./demand.component.css'],
  providers: [DemandService],
})
export class DemandComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private demandService: DemandService,
    private alertifyService: AlertifyService,
    private orderService:OrderService
  ) { }

  searchForm!: FormGroup;
  filterModel!: FilterModel;
  demands!: Demand[];
  currentPage: number = 1;
  itemsPerPage: number = 10
  displayDemandModal: string = 'none';
  demandForm!: FormGroup;
  saveType!: SaveTypeEnum
  demand!: Demand
  selectedDemandId!: string
  fileName = 'Demand';
  displayConfirmModal: string = 'none';

  ngOnInit() {
    this.createSearchForm();
    this.createDemandForm();
  }

  createSearchForm() {
    this.searchForm = this.formBuilder.group({
      filter: ['', [Validators.required, Validators.minLength(2)]],
    });
  }

  search() {
    if (this.searchForm.valid) {
      this.filterModel = Object.assign({}, this.searchForm.value);
      if (this.filterModel) {
        this.demandService.search(this.filterModel).subscribe((dataResult) => {
          if (dataResult) {
            if (dataResult.success) {
              if (dataResult.data) {
                this.demands = dataResult.data;
              }
            } else {
              this.alertifyService.error(dataResult.message);
            }
          }
        });
      }
    }
  }

  orderAsc(columnName: string) {
    this.orderService.order(this.demands, columnName, OrderTypeEnum.Asc)
  }

  orderDesc(columnName: string) {
    this.orderService.order(this.demands, columnName, OrderTypeEnum.Desc)
  }

  clear() {
    this.searchForm.controls['filter'].setValue('');
  }

  exportToExcel() {
    const ws: xlsx.WorkSheet = xlsx.utils.json_to_sheet(this.demands);
    const wb: xlsx.WorkBook = xlsx.utils.book_new();
    xlsx.utils.book_append_sheet(wb, ws, this.fileName);
    xlsx.writeFile(wb, this.fileName + '.xlsx');
  }

  exportToPdf() {
    let data: any = document.getElementById('divSerach');
    html2canvas(data).then((canvas) => {
      let fileWidth = 208;
      let fileHeight = (canvas.height * fileWidth) / canvas.width;
      const fileUri = canvas.toDataURL('image/png');
      let pdf = new jsPDF('p', 'mm', 'a4');
      let position = 0;
      pdf.addImage(fileUri, 'Png', 0, position, fileWidth, fileHeight);
      pdf.save(this.fileName + '.pdf');
    });
  }

  createDemandForm() {
    this.demandForm = this.formBuilder.group({
      id: [""],
      demandName: ["", [Validators.required, Validators.minLength(2), Validators.maxLength(50)]]
    })
  }

  getById(demandId: string) {
    this.demandService.getById(demandId).subscribe(dataResult => {
      if (dataResult) {
        if (dataResult.success) {
          if (dataResult.data) {
              this.demandForm.controls["demandName"].setValue(dataResult.data.demandName)
          }
        }
      }
    })
  }

  openDemandModal(demandId?: string) {
    this.displayDemandModal = "block"
    if (demandId) {
      this.selectedDemandId = demandId
      this.saveType = SaveTypeEnum.Update
      this.getById(demandId)
    }
    else {
      this.saveType = SaveTypeEnum.Add
    }
  }

  closeDemandModal() {
    this.displayDemandModal = "none"
    this.resetDemandModal()
  }

  resetDemandModal() {
    this.demandForm.controls["demandName"].setValue("")
    this.displayConfirmModal="none"
    this.displayDemandModal="none"
  }

  openConfirmModal(id: string) {
    this.displayConfirmModal = 'block';
    this.selectedDemandId = id
  }

  closeConfirmModal()
  {
    this.displayConfirmModal="none"
  }

  delete(demandId: string) {
    this.demandService.delete(demandId).subscribe((result) => {
      if (result) {
        if (result.success) {
          this.alertifyService.success(result.message);
          this.search()
        } else {
          this.alertifyService.error(result.message);
        }
      }
    });
    this.resetDemandModal()
  }

  deleteFromConfirm() {
    this.delete(this.selectedDemandId)
    this.closeConfirmModal()
  }

  save() {
    if (this.demandForm.valid) {
      this.demand = Object.assign({}, this.demandForm.value)
      if (this.demand) {
        if (this.saveType == SaveTypeEnum.Add) {

          this.demand.id = UUID.UUID()
          this.demand.optime = new Date()
          this.demand.isActive = true
          this.demandService.add(this.demand).subscribe(result => {
            if (result) {
              if (result.success) {
                this.alertifyService.success(result.message)
                this.search()
              }
              else {
                this.alertifyService.error(result.message)
              }
            }
          })
        }
        else if (this.saveType = SaveTypeEnum.Update) {
          this.demand.id = this.selectedDemandId
          this.demand.optime = new Date()
          this.demand.isActive = true
          this.demandService.update(this.demand).subscribe(result => {
            if (result) {
              if (result.success) {
                this.alertifyService.success(result.message)
                this.search()
              }
              else {
                this.alertifyService.error(result.message)
              }
            }
          })
        }
      }
    }
    this.resetDemandModal()
  }









}
