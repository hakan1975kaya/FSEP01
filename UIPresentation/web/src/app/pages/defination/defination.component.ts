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
import { DefinationService } from 'src/app/services/defination/defination.service';
import { Defination } from 'src/app/models/defination/defination';
@Component({
  selector: 'app-defination',
  templateUrl: './defination.component.html',
  styleUrls: ['./defination.component.css'],
  providers: [DefinationService],
})
export class DefinationComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private definationService: DefinationService,
    private alertifyService: AlertifyService,
    private orderService: OrderService
  ) { }
  searchForm!: FormGroup;
  filterModel!: FilterModel;
  definations!: Defination[];
  currentPage: number = 1;
  itemsPerPage: number = 10;
  displayDefinationModal: string = 'none';
  definationForm!: FormGroup;
  saveType!: SaveTypeEnum;
  defination!: Defination;
  selectedDefinationId!: string;
  fileName = 'defination';
  displayConfirmModal: string = 'none';
  locationDefault = "";
  statusDefault = "";
  ngOnInit() {
    this.createSearchForm();
    this.createDefinationForm();
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
        this.definationService
          .search(this.filterModel)
          .subscribe((dataResult) => {
            if (dataResult) {
              if (dataResult.success) {
                if (dataResult.data) {
                  this.definations = dataResult.data;
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
    this.orderService.order(this.definations, columnName, OrderTypeEnum.Asc);
  }

  orderDesc(columnName: string) {
    this.orderService.order(this.definations, columnName, OrderTypeEnum.Desc);
  }

  clear() {
    this.searchForm.controls['filter'].setValue('');
  }

  exportToExcel() {
    const ws: xlsx.WorkSheet = xlsx.utils.json_to_sheet(this.definations);
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

  createDefinationForm() {
    this.definationForm = this.formBuilder.group({
      id: [''],
      messageId: ['', [Validators.required, Validators.min(0), Validators.max(2147483647)]],
      telegramType: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(30)]],
      telegramLength: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(5)]],
      sender: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(10)]],
      reciever: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(10)]],
      telegramSequenceNumber:['', [Validators.required, Validators.min(0), Validators.max(2147483647)]],
      timeStamp: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10)]],
      ackReq: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(3)]],
    });
  }


  getById(definationId: string) {
    this.definationService.getById(definationId).subscribe((dataResult) => {
      if (dataResult) {
        if (dataResult.success) {
          if (dataResult.data) {
            this.definationForm.controls['messageId'].setValue(dataResult.data.messageId);
            this.definationForm.controls['telegramType'].setValue(dataResult.data.telegramType);
            this.definationForm.controls['telegramLength'].setValue(dataResult.data.telegramLength);
            this.definationForm.controls['sender'].setValue(dataResult.data.sender);
            this.definationForm.controls['reciever'].setValue(dataResult.data.reciever);
            this.definationForm.controls['telegramSequenceNumber'].setValue(dataResult.data.telegramSequenceNumber);
            this.definationForm.controls['timeStamp'].setValue(dataResult.data.timeStamp);
            this.definationForm.controls['ackReq'].setValue(dataResult.data.ackReq);
          }
        }
      }
    });
  }

  openDefinationModal(definationId?: string) {
    this.displayDefinationModal = 'block';
    if (definationId) {
      this.selectedDefinationId = definationId;
      this.saveType = SaveTypeEnum.Update;
      this.getById(definationId);
    } else {
      this.saveType = SaveTypeEnum.Add;
    }
  }

  closeDefinationModal() {
    this.displayDefinationModal = 'none';
    this.resetDefinationModal();
  }

  resetDefinationModal() {
    this.definationForm.controls['messageId'].setValue('');
    this.definationForm.controls['telegramType'].setValue('');
    this.definationForm.controls['telegramLength'].setValue('');
    this.definationForm.controls['sender'].setValue('');
    this.definationForm.controls['reciever'].setValue('');
    this.definationForm.controls['telegramSequenceNumber'].setValue('');
    this.definationForm.controls['timeStamp'].setValue('');
    this.definationForm.controls['ackReq'].setValue('');
    this.displayConfirmModal = 'none';
    this.displayDefinationModal = 'none';
  }

  openConfirmModal(id: string) {
    this.displayConfirmModal = 'block';
    this.selectedDefinationId = id;
  }

  closeConfirmModal() {
    this.displayConfirmModal = 'none';
  }

  delete(definationId: string) {
    this.definationService.delete(definationId).subscribe((result) => {
      if (result) {
        if (result.success) {
          this.alertifyService.success(result.message);
          this.search();
        } else {
          this.alertifyService.error(result.message);
        }
      }
    });
    this.resetDefinationModal();
  }

  deleteFromConfirm() {
    this.delete(this.selectedDefinationId);
    this.closeConfirmModal();
  }

  save() {
    if (this.definationForm.valid) {
      this.defination = Object.assign({}, this.definationForm.value);
      if (this.defination) {
        if (this.saveType == SaveTypeEnum.Add) {
          this.defination.id = UUID.UUID();
          this.defination.optime = new Date();
          this.defination.isActive = true;
          this.definationService.add(this.defination).subscribe((result) => {
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
          this.defination.id = this.selectedDefinationId;
          this.defination.optime = new Date();
          this.defination.isActive = true;
          this.definationService
            .update(this.defination)
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
    this.resetDefinationModal();
  }
}
