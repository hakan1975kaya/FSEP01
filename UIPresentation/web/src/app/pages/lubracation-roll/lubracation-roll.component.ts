import { LocationEnum } from 'src/app/enums/location-enum.enum';
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
import { LubracationRollService } from 'src/app/services/lubracation-roll/lubracation-roll.service';
import { LubracationRoll } from 'src/app/models/lubracation-roll/lubracation-roll';
@Component({
  selector: 'app-contact-roll',
  templateUrl: './lubracation-roll.component.html',
  styleUrls: ['./lubracation-roll.component.css'],
  providers: [LubracationRollService],
})
export class LubracationRollComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private lubracationRollService: LubracationRollService,
    private alertifyService: AlertifyService,
    private orderService: OrderService
  ) { }
  searchForm!: FormGroup;
  filterModel!: FilterModel;
  lubracationRolls!: LubracationRoll[];
  currentPage: number = 1;
  itemsPerPage: number = 10;
  displayLubracationRollModal: string = 'none';
  lubracationRollForm!: FormGroup;
  saveType!: SaveTypeEnum;
  lubracationRoll!: LubracationRoll;
  selectedLubracationRollId!: string;
  fileName = 'lubracationRoll';
  displayConfirmModal: string = 'none';
  locationDefault = "";
  statusDefault = "";
  ngOnInit() {
    this.createSearchForm();
    this.createLubracationRollForm();
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
        this.lubracationRollService
          .search(this.filterModel)
          .subscribe((dataResult) => {
            if (dataResult) {
              if (dataResult.success) {
                if (dataResult.data) {
                  this.lubracationRolls = dataResult.data;
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
    this.orderService.order(this.lubracationRolls, columnName, OrderTypeEnum.Asc);
  }

  orderDesc(columnName: string) {
    this.orderService.order(this.lubracationRolls, columnName, OrderTypeEnum.Desc);
  }

  clear() {
    this.searchForm.controls['filter'].setValue('');
  }

  exportToExcel() {
    const ws: xlsx.WorkSheet = xlsx.utils.json_to_sheet(this.lubracationRolls);
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

  createLubracationRollForm() {
    this.lubracationRollForm = this.formBuilder.group({
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

  getById(lubracationRollId: string) {
    this.lubracationRollService.getById(lubracationRollId).subscribe((dataResult) => {
      if (dataResult) {
        if (dataResult.success) {
          if (dataResult.data) {
            this.lubracationRollForm.controls['rollNumber'].setValue(dataResult.data.rollNumber);
            this.lubracationRollForm.controls['rollDiameter'].setValue(dataResult.data.rollDiameter);
            this.lubracationRollForm.controls['groupName'].setValue(dataResult.data.groupName);
            this.lubracationRollForm.controls['rollName'].setValue(dataResult.data.rollName);
            this.lubracationRollForm.controls['hardness'].setValue(dataResult.data.hardness);
            this.lubracationRollForm.controls['roughness'].setValue(dataResult.data.roughness);
            this.lubracationRollForm.controls['status'].setValue(dataResult.data.status);
            this.lubracationRollForm.controls['location'].setValue(dataResult.data.location);
          }
        }
      }
    });
  }

  openLubracationRollModal(lubracationRollId?: string) {
    this.displayLubracationRollModal = 'block';
    if (lubracationRollId) {
      this.selectedLubracationRollId = lubracationRollId;
      this.saveType = SaveTypeEnum.Update;
      this.getById(lubracationRollId);
    } else {
      this.saveType = SaveTypeEnum.Add;
    }
  }

  closeLubracationRollModal() {
    this.displayLubracationRollModal = 'none';
    this.resetLubracationRollModal();
  }

  resetLubracationRollModal() {
    this.lubracationRollForm.controls['rollNumber'].setValue('');
    this.lubracationRollForm.controls['rollDiameter'].setValue('');
    this.lubracationRollForm.controls['groupName'].setValue('');
    this.lubracationRollForm.controls['rollName'].setValue('');
    this.lubracationRollForm.controls['hardness'].setValue('');
    this.lubracationRollForm.controls['roughness'].setValue('');
    this.lubracationRollForm.controls['status'].setValue('');
    this.lubracationRollForm.controls['location'].setValue('');
    this.displayConfirmModal = 'none';
    this.displayLubracationRollModal = 'none';
  }

  openConfirmModal(id: string) {
    this.displayConfirmModal = 'block';
    this.selectedLubracationRollId = id;
  }

  closeConfirmModal() {
    this.displayConfirmModal = 'none';
  }

  delete(lubracationRollId: string) {
    this.lubracationRollService.delete(lubracationRollId).subscribe((result) => {
      if (result) {
        if (result.success) {
          this.alertifyService.success(result.message);
          this.search();
        } else {
          this.alertifyService.error(result.message);
        }
      }
    });
    this.resetLubracationRollModal();
  }

  deleteFromConfirm() {
    this.delete(this.selectedLubracationRollId);
    this.closeConfirmModal();
  }

  save() {
    if (this.lubracationRollForm.valid) {
      this.lubracationRoll = Object.assign({}, this.lubracationRollForm.value);
      if (this.lubracationRoll) {
        if (this.saveType == SaveTypeEnum.Add) {
          this.lubracationRoll.id = UUID.UUID();
          this.lubracationRoll.optime = new Date();
          this.lubracationRoll.isActive = true;
          this.lubracationRollService.add(this.lubracationRoll).subscribe((result) => {
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
          this.lubracationRoll.id = this.selectedLubracationRollId;
          this.lubracationRoll.optime = new Date();
          this.lubracationRoll.isActive = true;
          this.lubracationRollService
            .update(this.lubracationRoll)
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
    this.resetLubracationRollModal();
  }
}
