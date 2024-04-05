import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UUID } from 'angular2-uuid';
import { SaveTypeEnum } from 'src/app/enums/save-type-enum.enum';
import { ProcessStateL22PES } from 'src/app/models/ProcessStateL22PES/ProcessStateL22PES';
import { FilterModel } from 'src/app/models/general/filterModel';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { ProcessStateL22PESService } from 'src/app/services/ProcessStateL22PES/ProcessStateL22PES.service';
import * as xlsx from 'xlsx';
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';
import { OrderTypeEnum } from 'src/app/enums/order-type-enum.enum';
import { OrderService } from 'src/app/services/general/order.service';
@Component({
  selector: 'app-ProcessStateL22PES',
  templateUrl: './ProcessStateL22PES.component.html',
  styleUrls: ['./ProcessStateL22PES.component.css'],
  providers: [ProcessStateL22PESService],
})
export class ProcessStateL22PESComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private ProcessStateL22PESService: ProcessStateL22PESService,
    private alertifyService: AlertifyService,
    private orderService:OrderService
  ) { }

  searchForm!: FormGroup;
  filterModel!: FilterModel;
  ProcessStateL22PESs!: ProcessStateL22PES[];
  currentPage: number = 1;
  itemsPerPage: number = 10
  displayProcessStateL22PESModal: string = 'none';
  ProcessStateL22PESForm!: FormGroup;
  saveType!: SaveTypeEnum
  ProcessStateL22PES!: ProcessStateL22PES
  selectedProcessStateL22PESId!: string
  fileName = 'ProcessStateL22PES';
  displayConfirmModal: string = 'none';

  ngOnInit() {
    this.createSearchForm();
    this.createProcessStateL22PESForm();
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
        this.ProcessStateL22PESService.search(this.filterModel).subscribe((dataResult) => {
          if (dataResult) {
            if (dataResult.success) {
              if (dataResult.data) {
                this.ProcessStateL22PESs = dataResult.data;
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
    this.orderService.order(this.ProcessStateL22PESs, columnName, OrderTypeEnum.Asc)
  }

  orderDesc(columnName: string) {
    this.orderService.order(this.ProcessStateL22PESs, columnName, OrderTypeEnum.Desc)
  }

  clear() {
    this.searchForm.controls['filter'].setValue('');
  }

  exportToExcel() {
    const ws: xlsx.WorkSheet = xlsx.utils.json_to_sheet(this.ProcessStateL22PESs);
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

  createProcessStateL22PESForm() {
    this.ProcessStateL22PESForm = this.formBuilder.group({
      id: [""],
      ProcessStateL22PESName: ["", [Validators.required, Validators.minLength(2), Validators.maxLength(50)]]
    })
  }

  getById(ProcessStateL22PESId: string) {
    this.ProcessStateL22PESService.getById(ProcessStateL22PESId).subscribe(dataResult => {
      if (dataResult) {
        if (dataResult.success) {
          if (dataResult.data) {
              this.ProcessStateL22PESForm.controls["ProcessStateL22PESName"].setValue(dataResult.data.ProcessStateL22PESName)
          }
        }
      }
    })
  }

  openProcessStateL22PESModal(ProcessStateL22PESId?: string) {
    this.displayProcessStateL22PESModal = "block"
    if (ProcessStateL22PESId) {
      this.selectedProcessStateL22PESId = ProcessStateL22PESId
      this.saveType = SaveTypeEnum.Update
      this.getById(ProcessStateL22PESId)
    }
    else {
      this.saveType = SaveTypeEnum.Add
    }
  }

  closeProcessStateL22PESModal() {
    this.displayProcessStateL22PESModal = "none"
    this.resetProcessStateL22PESModal()
  }

  resetProcessStateL22PESModal() {
    this.ProcessStateL22PESForm.controls["ProcessStateL22PESName"].setValue("")
    this.displayConfirmModal="none"
    this.displayProcessStateL22PESModal="none"
  }

  openConfirmModal(id: string) {
    this.displayConfirmModal = 'block';
    this.selectedProcessStateL22PESId = id
  }

  closeConfirmModal()
  {
    this.displayConfirmModal="none"
  }

  delete(ProcessStateL22PESId: string) {
    this.ProcessStateL22PESService.delete(ProcessStateL22PESId).subscribe((result) => {
      if (result) {
        if (result.success) {
          this.alertifyService.success(result.message);
          this.search()
        } else {
          this.alertifyService.error(result.message);
        }
      }
    });
    this.resetProcessStateL22PESModal()
  }

  deleteFromConfirm() {
    this.delete(this.selectedProcessStateL22PESId)
    this.closeConfirmModal()
  }

  save() {
    if (this.ProcessStateL22PESForm.valid) {
      this.ProcessStateL22PES = Object.assign({}, this.ProcessStateL22PESForm.value)
      if (this.ProcessStateL22PES) {
        if (this.saveType == SaveTypeEnum.Add) {

          this.ProcessStateL22PES.id = UUID.UUID()
          this.ProcessStateL22PES.optime = new Date()
          this.ProcessStateL22PES.isActive = true
          this.ProcessStateL22PESService.add(this.ProcessStateL22PES).subscribe(result => {
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
          this.ProcessStateL22PES.id = this.selectedProcessStateL22PESId
          this.ProcessStateL22PES.optime = new Date()
          this.ProcessStateL22PES.isActive = true
          this.ProcessStateL22PESService.update(this.ProcessStateL22PES).subscribe(result => {
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
    this.resetProcessStateL22PESModal()
  }









}
