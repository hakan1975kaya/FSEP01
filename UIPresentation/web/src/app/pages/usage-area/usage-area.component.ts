import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UUID } from 'angular2-uuid';
import { SaveTypeEnum } from 'src/app/enums/save-type-enum.enum';
import { FilterModel } from 'src/app/models/general/filterModel';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import * as xlsx from 'xlsx';
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';
import { OrderTypeEnum } from 'src/app/enums/order-type-enum.enum';
import { OrderService } from 'src/app/services/general/order.service';
import { UsageAreaService } from 'src/app/services/usage-Area/usage-Area.service';
import { UsageArea } from 'src/app/models/usage-Area/usage-area';

@Component({
  selector: 'app-usage-area',
  templateUrl: './usage-area.component.html',
  styleUrls: ['./usage-area.component.css'],
  providers: [UsageAreaService],
})
export class UsageAreaComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private usageAreaService: UsageAreaService,
    private alertifyService: AlertifyService,
    private orderService: OrderService
  ) { }
  searchForm!: FormGroup;
  filterModel!: FilterModel;
  usageAreas!: UsageArea[];
  currentPage: number = 1;
  itemsPerPage: number = 10;
  displayUsageAreaModal: string = 'none';
  usageAreaForm!: FormGroup;
  saveType!: SaveTypeEnum;
  usageArea!: UsageArea;
  selectedUsageAreaId!: string;
  fileName = 'usageArea';
  displayConfirmModal: string = 'none';
  locationDefault = "";
  statusDefault = "";
  ngOnInit() {
    this.createSearchForm();
    this.createUsageAreaForm();
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
        this.usageAreaService
          .search(this.filterModel)
          .subscribe((dataResult) => {
            if (dataResult) {
              if (dataResult.success) {
                if (dataResult.data) {
                  this.usageAreas = dataResult.data;
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
    this.orderService.order(this.usageAreas, columnName, OrderTypeEnum.Asc);
  }

  orderDesc(columnName: string) {
    this.orderService.order(this.usageAreas, columnName, OrderTypeEnum.Desc);
  }

  clear() {
    this.searchForm.controls['filter'].setValue('');
  }

  exportToExcel() {
    const ws: xlsx.WorkSheet = xlsx.utils.json_to_sheet(this.usageAreas);
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

  createUsageAreaForm() {
    this.usageAreaForm = this.formBuilder.group({
      id: [''],
      value: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(30)]],
    });
  }


  getById(usageAreaId: string) {
    this.usageAreaService.getById(usageAreaId).subscribe((dataResult) => {
      if (dataResult) {
        if (dataResult.success) {
          if (dataResult.data) {
            this.usageAreaForm.controls['value'].setValue(dataResult.data.value);
          }
        }
      }
    });
  }

  openUsageAreaModal(usageAreaId?: string) {
    this.displayUsageAreaModal = 'block';
    if (usageAreaId) {
      this.selectedUsageAreaId = usageAreaId;
      this.saveType = SaveTypeEnum.Update;
      this.getById(usageAreaId);
    } else {
      this.saveType = SaveTypeEnum.Add;
    }
  }

  closeUsageAreaModal() {
    this.displayUsageAreaModal = 'none';
    this.resetUsageAreaModal();
  }

  resetUsageAreaModal() {
    this.usageAreaForm.controls['value'].setValue('');
  }

  openConfirmModal(id: string) {
    this.displayConfirmModal = 'block';
    this.selectedUsageAreaId = id;
  }

  closeConfirmModal() {
    this.displayConfirmModal = 'none';
  }

  delete(usageAreaId: string) {
    this.usageAreaService.delete(usageAreaId).subscribe((result) => {
      if (result) {
        if (result.success) {
          this.alertifyService.success(result.message);
          this.search();
        } else {
          this.alertifyService.error(result.message);
        }
      }
    });
    this.resetUsageAreaModal();
  }

  deleteFromConfirm() {
    this.delete(this.selectedUsageAreaId);
    this.closeConfirmModal();
  }

  save() {
    if (this.usageAreaForm.valid) {
      this.usageArea = Object.assign({}, this.usageAreaForm.value);
      if (this.usageArea) {
        if (this.saveType == SaveTypeEnum.Add) {
          this.usageArea.id = UUID.UUID();
          this.usageArea.optime = new Date();
          this.usageArea.isActive = true;
          this.usageAreaService.add(this.usageArea).subscribe((result) => {
            if (result) {
              if (result.success) {
                this.alertifyService.success(result.message);
                this.search();
              } else {
                this.alertifyService.error(result.message);
              }
            }
          });
        } else if ((this.saveType = SaveTypeEnum.Update)) {
          this.usageArea.id = this.selectedUsageAreaId;
          this.usageArea.optime = new Date();
          this.usageArea.isActive = true;
          this.usageAreaService
            .update(this.usageArea)
            .subscribe((result) => {
              if (result) {
                if (result.success) {
                  this.alertifyService.success(result.message);
                  this.search();
                } else {
                  this.alertifyService.error(result.message);
                }
              }
            });
        }
      }
    }
    this.resetUsageAreaModal();
  }
}
