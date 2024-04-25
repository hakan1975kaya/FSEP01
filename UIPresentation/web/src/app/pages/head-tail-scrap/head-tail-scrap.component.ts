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
import { HeadTailScrapService } from 'src/app/services/head-tail-scrap/head-tail-scrap.service';
import { HeadTailScrap } from 'src/app/models/head-tail-scrap/head-tail-scrap';
@Component({
  selector: 'app-headTailScrap',
  templateUrl: './head-tail-scrap.component.html',
  styleUrls: ['./head-tail-scrap.component.css'],
  providers: [HeadTailScrapService],
})
export class HeadTailScrapComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private headTailScrapService: HeadTailScrapService,
    private alertifyService: AlertifyService,
    private orderService: OrderService
  ) { }
  searchForm!: FormGroup;
  filterModel!: FilterModel;
  headTailScraps!: HeadTailScrap[];
  currentPage: number = 1;
  itemsPerPage: number = 10;
  displayHeadTailScrapModal: string = 'none';
  headTailScrapForm!: FormGroup;
  saveType!: SaveTypeEnum;
  headTailScrap!: HeadTailScrap;
  selectedHeadTailScrapId!: string;
  fileName = 'headTailScrap';
  displayConfirmModal: string = 'none';
  locationDefault = "";
  statusDefault = "";
  ngOnInit() {
    this.createSearchForm();
    this.createHeadTailScrapForm();
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
        this.headTailScrapService
          .search(this.filterModel)
          .subscribe((dataResult) => {
            if (dataResult) {
              if (dataResult.success) {
                if (dataResult.data) {
                  this.headTailScraps = dataResult.data;
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
    this.orderService.order(this.headTailScraps, columnName, OrderTypeEnum.Asc);
  }

  orderDesc(columnName: string) {
    this.orderService.order(this.headTailScraps, columnName, OrderTypeEnum.Desc);
  }

  clear() {
    this.searchForm.controls['filter'].setValue('');
  }

  exportToExcel() {
    const ws: xlsx.WorkSheet = xlsx.utils.json_to_sheet(this.headTailScraps);
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

  createHeadTailScrapForm() {
    this.headTailScrapForm = this.formBuilder.group({
      id: [''],
      usageArea:['', [Validators.required, Validators.minLength(2), Validators.maxLength(30)]] ,
      previousLine:['', [Validators.required, Validators.minLength(2), Validators.maxLength(20)]] ,
      thicknessMinimum: ['', [Validators.required, Validators.min(0), Validators.max(9223372036854775807)]],
      thicknessMaximum: ['', [Validators.required, Validators.min(0), Validators.max(9223372036854775807)]],
      scrapValue: ['', [Validators.required, Validators.minLength(0), Validators.maxLength(	32767)]],
    });
  }

  getById(headTailScrapId: string) {
    this.headTailScrapService.getById(headTailScrapId).subscribe((dataResult) => {
      if (dataResult) {
        if (dataResult.success) {
          if (dataResult.data) {
            this.headTailScrapForm.controls['usageArea'].setValue(dataResult.data.usageArea);
            this.headTailScrapForm.controls['previousLine'].setValue(dataResult.data.previousLine);
            this.headTailScrapForm.controls['thicknessMinimum'].setValue(dataResult.data.thicknessMinimum);
            this.headTailScrapForm.controls['thicknessMaximum'].setValue(dataResult.data.thicknessMaximum);
            this.headTailScrapForm.controls['scrapValue'].setValue(dataResult.data.scrapValue);;
          }
        }
      }
    });
  }

  openHeadTailScrapModal(headTailScrapId?: string) {
    this.displayHeadTailScrapModal = 'block';
    if (headTailScrapId) {
      this.selectedHeadTailScrapId = headTailScrapId;
      this.saveType = SaveTypeEnum.Update;
      this.getById(headTailScrapId);
    } else {
      this.saveType = SaveTypeEnum.Add;
    }
  }

  closeHeadTailScrapModal() {
    this.displayHeadTailScrapModal = 'none';
    this.resetHeadTailScrapModal();
  }

  resetHeadTailScrapModal() {
    this.headTailScrapForm.controls['usageArea'].setValue('');
    this.headTailScrapForm.controls['previousLine'].setValue('');
    this.headTailScrapForm.controls['thicknessMinimum'].setValue('');
    this.headTailScrapForm.controls['thicknessMaximum'].setValue('');
    this.headTailScrapForm.controls['scrapValue'].setValue('');;
  }

  openConfirmModal(id: string) {
    this.displayConfirmModal = 'block';
    this.selectedHeadTailScrapId = id;
  }

  closeConfirmModal() {
    this.displayConfirmModal = 'none';
  }

  delete(headTailScrapId: string) {
    this.headTailScrapService.delete(headTailScrapId).subscribe((result) => {
      if (result) {
        if (result.success) {
          this.alertifyService.success(result.message);
          this.search();
        } else {
          this.alertifyService.error(result.message);
        }
      }
    });
    this.resetHeadTailScrapModal();
  }

  deleteFromConfirm() {
    this.delete(this.selectedHeadTailScrapId);
    this.closeConfirmModal();
  }

  save() {
    if (this.headTailScrapForm.valid) {
      this.headTailScrap = Object.assign({}, this.headTailScrapForm.value);
      if (this.headTailScrap) {
        if (this.saveType == SaveTypeEnum.Add) {
          this.headTailScrap.id = UUID.UUID();
          this.headTailScrap.optime = new Date();
          this.headTailScrap.isActive = true;
          this.headTailScrapService.add(this.headTailScrap).subscribe((result) => {
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
          this.headTailScrap.id = this.selectedHeadTailScrapId;
          this.headTailScrap.optime = new Date();
          this.headTailScrap.isActive = true;
          this.headTailScrapService
            .update(this.headTailScrap)
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
    this.resetHeadTailScrapModal();
  }
}
