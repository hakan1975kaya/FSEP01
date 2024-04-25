import { RollStatusEnum } from './../../enums/roll-status-enum.enum';
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
import { TramRollService } from 'src/app/services/tram-roll/tram-roll.service';
import { TramRoll } from 'src/app/models/tram-roll/tram-roll';
@Component({
  selector: 'app-tram-roll',
  templateUrl: './tram-roll.component.html',
  styleUrls: ['./tram-roll.component.css'],
  providers: [TramRollService],
})
export class TramRollComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private tramRollService: TramRollService,
    private alertifyService: AlertifyService,
    private orderService: OrderService
  ) { }
  searchForm!: FormGroup;
  filterModel!: FilterModel;
  tramRolls!: TramRoll[];
  currentPage: number = 1;
  itemsPerPage: number = 10;
  displayTramRollModal: string = 'none';
  tramRollForm!: FormGroup;
  saveType!: SaveTypeEnum;
  tramRoll!: TramRoll;
  selectedTramRollId!: string;
  fileName = 'tramRoll';
  displayConfirmModal: string = 'none';
  locationDefault = "";
  statusDefault = "";
  rollStatusEnum!:RollStatusEnum
  ngOnInit() {
    this.createSearchForm();
    this.createTramRollForm();
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
        this.tramRollService
          .search(this.filterModel)
          .subscribe((dataResult) => {
            if (dataResult) {
              if (dataResult.success) {
                if (dataResult.data) {
                  this.tramRolls = dataResult.data;
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
    this.orderService.order(this.tramRolls, columnName, OrderTypeEnum.Asc);
  }

  orderDesc(columnName: string) {
    this.orderService.order(this.tramRolls, columnName, OrderTypeEnum.Desc);
  }

  clear() {
    this.searchForm.controls['filter'].setValue('');
  }

  exportToExcel() {
    const ws: xlsx.WorkSheet = xlsx.utils.json_to_sheet(this.tramRolls);
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

  createTramRollForm() {
    this.tramRollForm = this.formBuilder.group({
      id: [''],
      rollNumber: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      rollDiameter: ['', [Validators.required, Validators.min(0), Validators.max(Number.MAX_VALUE)]],
      groupName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(60)]],
      rollName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(60)]],
      hardness: ['', [Validators.required, Validators.min(0), Validators.max( 32767)]],
      roughness: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      status: ['', [Validators.required, Validators.min(0), Validators.max(2147483647)]],
      location: ['', [Validators.required, Validators.min(0), Validators.max(2147483647)]],
    });
  }

  getById(tramRollId: string) {
    this.tramRollService.getById(tramRollId).subscribe((dataResult) => {
      if (dataResult) {
        if (dataResult.success) {
          if (dataResult.data) {
            this.tramRollForm.controls['rollNumber'].setValue(dataResult.data.rollNumber);
            this.tramRollForm.controls['rollDiameter'].setValue(dataResult.data.rollDiameter);
            this.tramRollForm.controls['groupName'].setValue(dataResult.data.groupName);
            this.tramRollForm.controls['rollName'].setValue(dataResult.data.rollName);
            this.tramRollForm.controls['tramCount'].setValue(dataResult.data.tramCount);
            this.tramRollForm.controls['status'].setValue(dataResult.data.status);
            this.tramRollForm.controls['location'].setValue(dataResult.data.location);
          }
        }
      }
    });
  }

  openTramRollModal(tramRollId?: string) {
    this.displayTramRollModal = 'block';
    if (tramRollId) {
      this.selectedTramRollId = tramRollId;
      this.saveType = SaveTypeEnum.Update;
      this.getById(tramRollId);
    } else {
      this.saveType = SaveTypeEnum.Add;
    }
  }

  closeTramRollModal() {
    this.displayTramRollModal = 'none';
    this.resetTramRollModal();
  }

  resetTramRollModal() {
    this.tramRollForm.controls['rollNumber'].setValue('');
    this.tramRollForm.controls['rollDiameter'].setValue('');
    this.tramRollForm.controls['groupName'].setValue('');
    this.tramRollForm.controls['rollName'].setValue('');
    this.tramRollForm.controls['tramCount'].setValue('');
    this.tramRollForm.controls['status'].setValue('');
    this.tramRollForm.controls['location'].setValue('');
    this.displayConfirmModal = 'none';
    this.displayTramRollModal = 'none';
  }

  openConfirmModal(id: string) {
    this.displayConfirmModal = 'block';
    this.selectedTramRollId = id;
  }

  closeConfirmModal() {
    this.displayConfirmModal = 'none';
  }

  delete(tramRollId: string) {
    this.tramRollService.delete(tramRollId).subscribe((result) => {
      if (result) {
        if (result.success) {
          this.alertifyService.success(result.message);
          this.search();
        } else {
          this.alertifyService.error(result.message);
        }
      }
    });
    this.resetTramRollModal();
  }

  deleteFromConfirm() {
    this.delete(this.selectedTramRollId);
    this.closeConfirmModal();
  }

  save() {
    if (this.tramRollForm.valid) {
      this.tramRoll = Object.assign({}, this.tramRollForm.value);
      if (this.tramRoll) {
        if (this.saveType == SaveTypeEnum.Add) {
          this.tramRoll.id = UUID.UUID();
          this.tramRoll.optime = new Date();
          this.tramRoll.isActive = true;
          this.tramRollService.add(this.tramRoll).subscribe((result) => {
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
          this.tramRoll.id = this.selectedTramRollId;
          this.tramRoll.optime = new Date();
          this.tramRoll.isActive = true;
          this.tramRollService
            .update(this.tramRoll)
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
    this.resetTramRollModal();
  }
}
