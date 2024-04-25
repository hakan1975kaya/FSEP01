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
import { EventService } from 'src/app/services/event/event.service';
import { Event } from 'src/app/models/event/event';
@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css'],
  providers: [EventService],
})
export class EventComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private eventService: EventService,
    private alertifyService: AlertifyService,
    private orderService: OrderService
  ) { }
  searchForm!: FormGroup;
  filterModel!: FilterModel;
  events!: Event[];
  currentPage: number = 1;
  itemsPerPage: number = 10;
  displayEventModal: string = 'none';
  eventForm!: FormGroup;
  saveType!: SaveTypeEnum;
  event!: Event;
  selectedEventId!: string;
  fileName = 'event';
  displayConfirmModal: string = 'none';
  locationDefault = "";
  statusDefault = "";
  ngOnInit() {
    this.createSearchForm();
    this.createEventForm();
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
        this.eventService
          .search(this.filterModel)
          .subscribe((dataResult) => {
            if (dataResult) {
              if (dataResult.success) {
                if (dataResult.data) {
                  this.events = dataResult.data;
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
    this.orderService.order(this.events, columnName, OrderTypeEnum.Asc);
  }

  orderDesc(columnName: string) {
    this.orderService.order(this.events, columnName, OrderTypeEnum.Desc);
  }

  clear() {
    this.searchForm.controls['filter'].setValue('');
  }

  exportToExcel() {
    const ws: xlsx.WorkSheet = xlsx.utils.json_to_sheet(this.events);
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

  createEventForm() {
    this.eventForm = this.formBuilder.group({
      id: [''],
      tNumber: ['', [Validators.required, Validators.min(0), Validators.max(2147483647)]],
      localId: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(20)]],
      tType: ['', [Validators.required, Validators.min(0), Validators.max(32767)]],
      iPara: ['', [Validators.required, Validators.min(0), Validators.max(2147483647)]],
    });
  }
  getById(eventId: string) {
    this.eventService.getById(eventId).subscribe((dataResult) => {
      if (dataResult) {
        if (dataResult.success) {
          if (dataResult.data) {
            this.eventForm.controls['tNumber'].setValue(dataResult.data.tNumber);
            this.eventForm.controls['localId'].setValue(dataResult.data.localId);
            this.eventForm.controls['tType'].setValue(dataResult.data.tType);
            this.eventForm.controls['iPara'].setValue(dataResult.data.iPara);
            this.eventForm.controls['fPara'].setValue(dataResult.data.fPara);
          }
        }
      }
    });
  }

  openEventModal(eventId?: string) {
    this.displayEventModal = 'block';
    if (eventId) {
      this.selectedEventId = eventId;
      this.saveType = SaveTypeEnum.Update;
      this.getById(eventId);
    } else {
      this.saveType = SaveTypeEnum.Add;
    }
  }

  closeEventModal() {
    this.displayEventModal = 'none';
    this.resetEventModal();
  }

  resetEventModal() {
    this.eventForm.controls['tNumber'].setValue('');
    this.eventForm.controls['localId'].setValue('');
    this.eventForm.controls['tType'].setValue('');
    this.eventForm.controls['iPara'].setValue('');
    this.eventForm.controls['fPara'].setValue('');
  }

  openConfirmModal(id: string) {
    this.displayConfirmModal = 'block';
    this.selectedEventId = id;
  }

  closeConfirmModal() {
    this.displayConfirmModal = 'none';
  }

  delete(eventId: string) {
    this.eventService.delete(eventId).subscribe((result) => {
      if (result) {
        if (result.success) {
          this.alertifyService.success(result.message);
          this.search();
        } else {
          this.alertifyService.error(result.message);
        }
      }
    });
    this.resetEventModal();
  }

  deleteFromConfirm() {
    this.delete(this.selectedEventId);
    this.closeConfirmModal();
  }

  save() {
    if (this.eventForm.valid) {
      this.event = Object.assign({}, this.eventForm.value);
      if (this.event) {
        if (this.saveType == SaveTypeEnum.Add) {
          this.event.id = UUID.UUID();
          this.event.optime = new Date();
          this.event.isActive = true;
          this.eventService.add(this.event).subscribe((result) => {
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
          this.event.id = this.selectedEventId;
          this.event.optime = new Date();
          this.event.isActive = true;
          this.eventService
            .update(this.event)
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
    this.resetEventModal();
  }
}
