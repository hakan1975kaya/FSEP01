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
import { ContactRollService } from 'src/app/services/contact-roll/contact-roll.service';
import { ContactRoll } from 'src/app/models/contact-roll/contact-roll';
@Component({
  selector: 'app-contact-roll',
  templateUrl: './contact-roll.component.html',
  styleUrls: ['./contact-roll.component.css'],
  providers: [ContactRollService],
})
export class ContactRollComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private contactRollService: ContactRollService,
    private alertifyService: AlertifyService,
    private orderService: OrderService
  ) { }
  searchForm!: FormGroup;
  filterModel!: FilterModel;
  contactRolls!: ContactRoll[];
  currentPage: number = 1;
  itemsPerPage: number = 10;
  displayContactRollModal: string = 'none';
  contactRollForm!: FormGroup;
  saveType!: SaveTypeEnum;
  contactRoll!: ContactRoll;
  selectedContactRollId!: string;
  fileName = 'contactRoll';
  displayConfirmModal: string = 'none';
  locationDefault = "";
  statusDefault = "";
  ngOnInit() {
    this.createSearchForm();
    this.createcontactRollForm();
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
        this.contactRollService
          .search(this.filterModel)
          .subscribe((dataResult) => {
            if (dataResult) {
              if (dataResult.success) {
                if (dataResult.data) {
                  this.contactRolls = dataResult.data;
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
    this.orderService.order(this.contactRolls, columnName, OrderTypeEnum.Asc);
  }

  orderDesc(columnName: string) {
    this.orderService.order(this.contactRolls, columnName, OrderTypeEnum.Desc);
  }

  clear() {
    this.searchForm.controls['filter'].setValue('');
  }

  exportToExcel() {
    const ws: xlsx.WorkSheet = xlsx.utils.json_to_sheet(this.contactRolls);
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

  createcontactRollForm() {
    this.contactRollForm = this.formBuilder.group({
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

  getById(contactRollId: string) {
    this.contactRollService.getById(contactRollId).subscribe((dataResult) => {
      if (dataResult) {
        if (dataResult.success) {
          if (dataResult.data) {
            this.contactRollForm.controls['rollNumber'].setValue(dataResult.data.rollNumber);
            this.contactRollForm.controls['rollDiameter'].setValue(dataResult.data.rollDiameter);
            this.contactRollForm.controls['groupName'].setValue(dataResult.data.groupName);
            this.contactRollForm.controls['rollName'].setValue(dataResult.data.rollName);
            this.contactRollForm.controls['hardness'].setValue(dataResult.data.hardness);
            this.contactRollForm.controls['roughness'].setValue(dataResult.data.roughness);
            this.contactRollForm.controls['status'].setValue(dataResult.data.status);
            this.contactRollForm.controls['location'].setValue(dataResult.data.location);
          }
        }
      }
    });
  }

  opencontactRollModal(contactRollId?: string) {
    this.displayContactRollModal = 'block';
    if (contactRollId) {
      this.selectedContactRollId = contactRollId;
      this.saveType = SaveTypeEnum.Update;
      this.getById(contactRollId);
    } else {
      this.saveType = SaveTypeEnum.Add;
    }
  }

  closecontactRollModal() {
    this.displayContactRollModal = 'none';
    this.resetcontactRollModal();
  }

  resetcontactRollModal() {
    this.contactRollForm.controls['rollNumber'].setValue('');
    this.contactRollForm.controls['rollDiameter'].setValue('');
    this.contactRollForm.controls['groupName'].setValue('');
    this.contactRollForm.controls['rollName'].setValue('');
    this.contactRollForm.controls['hardness'].setValue('');
    this.contactRollForm.controls['roughness'].setValue('');
    this.contactRollForm.controls['status'].setValue('');
    this.contactRollForm.controls['location'].setValue('');
    this.displayConfirmModal = 'none';
    this.displayContactRollModal = 'none';
  }

  openConfirmModal(id: string) {
    this.displayConfirmModal = 'block';
    this.selectedContactRollId = id;
  }

  closeConfirmModal() {
    this.displayConfirmModal = 'none';
  }

  delete(contactRollId: string) {
    this.contactRollService.delete(contactRollId).subscribe((result) => {
      if (result) {
        if (result.success) {
          this.alertifyService.success(result.message);
          this.search();
        } else {
          this.alertifyService.error(result.message);
        }
      }
    });
    this.resetcontactRollModal();
  }

  deleteFromConfirm() {
    this.delete(this.selectedContactRollId);
    this.closeConfirmModal();
  }

  save() {
    if (this.contactRollForm.valid) {
      this.contactRoll = Object.assign({}, this.contactRollForm.value);
      if (this.contactRoll) {
        if (this.saveType == SaveTypeEnum.Add) {
          this.contactRoll.id = UUID.UUID();
          this.contactRoll.optime = new Date();
          this.contactRoll.isActive = true;
          this.contactRollService.add(this.contactRoll).subscribe((result) => {
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
          this.contactRoll.id = this.selectedContactRollId;
          this.contactRoll.optime = new Date();
          this.contactRoll.isActive = true;
          this.contactRollService
            .update(this.contactRoll)
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
    this.resetcontactRollModal();
  }
}
