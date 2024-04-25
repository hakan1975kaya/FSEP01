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
import { DensityService } from 'src/app/services/density/density.service';
import { Density } from 'src/app/models/density/density';
@Component({
  selector: 'app-density',
  templateUrl: './density.component.html',
  styleUrls: ['./density.component.css'],
  providers: [DensityService],
})
export class DensityComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private densityService: DensityService,
    private alertifyService: AlertifyService,
    private orderService: OrderService
  ) { }
  searchForm!: FormGroup;
  filterModel!: FilterModel;
  densitys!: Density[];
  currentPage: number = 1;
  itemsPerPage: number = 10;
  displayDensityModal: string = 'none';
  densityForm!: FormGroup;
  saveType!: SaveTypeEnum;
  density!: Density;
  selectedDensityId!: string;
  fileName = 'density';
  displayConfirmModal: string = 'none';
  locationDefault = "";
  statusDefault = "";
  ngOnInit() {
    this.createSearchForm();
    this.createDensityForm();
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
        this.densityService
          .search(this.filterModel)
          .subscribe((dataResult) => {
            if (dataResult) {
              if (dataResult.success) {
                if (dataResult.data) {
                  this.densitys = dataResult.data;
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
    this.orderService.order(this.densitys, columnName, OrderTypeEnum.Asc);
  }

  orderDesc(columnName: string) {
    this.orderService.order(this.densitys, columnName, OrderTypeEnum.Desc);
  }

  clear() {
    this.searchForm.controls['filter'].setValue('');
  }

  exportToExcel() {
    const ws: xlsx.WorkSheet = xlsx.utils.json_to_sheet(this.densitys);
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

  createDensityForm() {
    this.densityForm = this.formBuilder.group({
      id: [''],
      alloy: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(30)]],
      value: ['', [Validators.required, Validators.min(0), Validators.max(2147483647)]],
    });
  }


  getById(densityId: string) {
    this.densityService.getById(densityId).subscribe((dataResult) => {
      if (dataResult) {
        if (dataResult.success) {
          if (dataResult.data) {
            this.densityForm.controls['alloy'].setValue(dataResult.data.alloy);
            this.densityForm.controls['value'].setValue(dataResult.data.value);
          }
        }
      }
    });
  }

  openDensityModal(densityId?: string) {
    this.displayDensityModal = 'block';
    if (densityId) {
      this.selectedDensityId = densityId;
      this.saveType = SaveTypeEnum.Update;
      this.getById(densityId);
    } else {
      this.saveType = SaveTypeEnum.Add;
    }
  }

  closeDensityModal() {
    this.displayDensityModal = 'none';
    this.resetDensityModal();
  }

  resetDensityModal() {
    this.densityForm.controls['alloy'].setValue('');
    this.densityForm.controls['value'].setValue('');
  }

  openConfirmModal(id: string) {
    this.displayConfirmModal = 'block';
    this.selectedDensityId = id;
  }

  closeConfirmModal() {
    this.displayConfirmModal = 'none';
  }

  delete(densityId: string) {
    this.densityService.delete(densityId).subscribe((result) => {
      if (result) {
        if (result.success) {
          this.alertifyService.success(result.message);
          this.search();
        } else {
          this.alertifyService.error(result.message);
        }
      }
    });
    this.resetDensityModal();
  }

  deleteFromConfirm() {
    this.delete(this.selectedDensityId);
    this.closeConfirmModal();
  }

  save() {
    if (this.densityForm.valid) {
      this.density = Object.assign({}, this.densityForm.value);
      if (this.density) {
        if (this.saveType == SaveTypeEnum.Add) {
          this.density.id = UUID.UUID();
          this.density.optime = new Date();
          this.density.isActive = true;
          this.densityService.add(this.density).subscribe((result) => {
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
          this.density.id = this.selectedDensityId;
          this.density.optime = new Date();
          this.density.isActive = true;
          this.densityService
            .update(this.density)
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
    this.resetDensityModal();
  }
}
