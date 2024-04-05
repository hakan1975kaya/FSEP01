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
import { RoleService } from 'src/app/services/role/role.service';
import { Role } from 'src/app/models/role/role';
import { RoleProcessStateL22PESService } from 'src/app/services/role-ProcessStateL22PES/role-ProcessStateL22PES.service';
import { RoleProcessStateL22PES } from 'src/app/models/role-ProcessStateL22PES/role-ProcessStateL22PES';
import { ProcessStateL22PESService } from 'src/app/services/ProcessStateL22PES/ProcessStateL22PES.service';
import { ProcessStateL22PES } from 'src/app/models/ProcessStateL22PES/ProcessStateL22PES';
@Component({
  selector: 'app-role-ProcessStateL22PES',
  templateUrl: './role-ProcessStateL22PES.component.html',
  styleUrls: ['./role-ProcessStateL22PES.component.css'],
  providers: [RoleProcessStateL22PESService, RoleService, ProcessStateL22PESService],
})
export class RoleProcessStateL22PESComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private roleProcessStateL22PESService: RoleProcessStateL22PESService,
    private roleService: RoleService,
    private ProcessStateL22PESService: ProcessStateL22PESService,
    private alertifyService: AlertifyService,
    private orderService: OrderService
  ) { }

  searchForm!: FormGroup;
  filterModel!: FilterModel;
  roleProcessStateL22PESs!: RoleProcessStateL22PES[];
  roles!: Role[];
  ProcessStateL22PESs!: ProcessStateL22PES[];
  currentPage: number = 1;
  itemsPerPage: number = 10
  displayRoleProcessStateL22PESModal: string = 'none';
  roleProcessStateL22PESForm!: FormGroup;
  saveType!: SaveTypeEnum
  roleProcessStateL22PES!: RoleProcessStateL22PES
  selectedRoleProcessStateL22PESId!: string
  fileName = 'roleProcessStateL22PES';
  displayConfirmModal: string = 'none';
  roleIdDefault = ''
  ProcessStateL22PESIdDefault = ''

  ngOnInit() {
    this.createSearchForm();
    this.createRoleProcessStateL22PESForm();
    this.getRoles()
    this.getProcessStateL22PESs()
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
        this.roleProcessStateL22PESService.search(this.filterModel).subscribe((dataResult) => {
          if (dataResult) {
            if (dataResult.success) {
              if (dataResult.data) {
                this.roleProcessStateL22PESs = dataResult.data;
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
    this.orderService.order(this.roleProcessStateL22PESs, columnName, OrderTypeEnum.Asc)
  }

  orderDesc(columnName: string) {
    this.orderService.order(this.roleProcessStateL22PESs, columnName, OrderTypeEnum.Desc)
  }

  clear() {
    this.searchForm.controls['filter'].setValue('');
  }

  exportToExcel() {
    const ws: xlsx.WorkSheet = xlsx.utils.json_to_sheet(this.roleProcessStateL22PESs);
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

  createRoleProcessStateL22PESForm() {
    this.roleProcessStateL22PESForm = this.formBuilder.group({
      id: [''],
      roleId: ['', [Validators.required]],
      ProcessStateL22PESId: ['', [Validators.required]],
    });
  }

  getRoles() {
    this.roleService.getAll().subscribe(dataResult => {
      if (dataResult) {
        if (dataResult.success) {
          if (dataResult.data) {
            this.roles = dataResult.data
          }
        }
      }
    })
  }

  getProcessStateL22PESs() {
    this.ProcessStateL22PESService.getAll().subscribe(dataResult => {
      if (dataResult) {
        if (dataResult.success) {
          if (dataResult.data) {
            this.ProcessStateL22PESs = dataResult.data
          }
        }
      }
    })
  }

  getById(roleProcessStateL22PESId: string) {
    this.roleProcessStateL22PESService.getById(roleProcessStateL22PESId).subscribe((dataResult) => {
      if (dataResult) {
        if (dataResult.success) {
          if (dataResult.data) {
            this.roleProcessStateL22PESForm.controls['id'].setValue(dataResult.data.id);
            this.roleProcessStateL22PESForm.controls['roleId'].setValue(dataResult.data.roleId);
            this.roleProcessStateL22PESForm.controls['ProcessStateL22PESId'].setValue(dataResult.data.ProcessStateL22PESId);
          }
        } else {
          this.alertifyService.error(dataResult.message);
        }
      }
    });
  }

  openRoleProcessStateL22PESModal(roleProcessStateL22PESId?: string) {
    this.displayRoleProcessStateL22PESModal = "block"
    if (roleProcessStateL22PESId) {
      this.selectedRoleProcessStateL22PESId = roleProcessStateL22PESId
      this.saveType = SaveTypeEnum.Update
      this.getById(roleProcessStateL22PESId)
    }
    else {
      this.saveType = SaveTypeEnum.Add
    }
  }

  closeRoleProcessStateL22PESModal() {
    this.displayRoleProcessStateL22PESModal = "none"
    this.resetRoleProcessStateL22PESModal()
  }

  resetRoleProcessStateL22PESModal() {
    this.roleProcessStateL22PESForm.controls['id'].setValue('');
    this.roleProcessStateL22PESForm.controls['roleId'].setValue('');
    this.roleProcessStateL22PESForm.controls['ProcessStateL22PESId'].setValue('');
    this.displayConfirmModal = "none"
    this.displayRoleProcessStateL22PESModal = "none"
  }

  openConfirmModal(id: string) {
    this.displayConfirmModal = 'block';
    this.selectedRoleProcessStateL22PESId = id
  }

  closeConfirmModal() {
    this.displayConfirmModal = "none"
  }

  delete(roleProcessStateL22PESId: string) {
    this.roleProcessStateL22PESService.delete(roleProcessStateL22PESId).subscribe((result) => {
      if (result) {
        if (result.success) {
          this.alertifyService.success(result.message);
          this.search()
        } else {
          this.alertifyService.error(result.message);
        }
      }
    });
    this.resetRoleProcessStateL22PESModal()
  }

  deleteFromConfirm() {
    this.delete(this.selectedRoleProcessStateL22PESId)
    this.closeConfirmModal()
  }

  save() {
    if (this.roleProcessStateL22PESForm.valid) {
      this.roleProcessStateL22PES = Object.assign({}, this.roleProcessStateL22PESForm.value)
      if (this.roleProcessStateL22PES) {
        if (this.saveType == SaveTypeEnum.Add) {

          this.roleProcessStateL22PES.id = UUID.UUID()
          this.roleProcessStateL22PES.optime = new Date()
          this.roleProcessStateL22PES.isActive = true
          this.roleProcessStateL22PESService.add(this.roleProcessStateL22PES).subscribe(result => {
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
          this.roleProcessStateL22PES.id = this.selectedRoleProcessStateL22PESId
          this.roleProcessStateL22PES.optime = new Date()
          this.roleProcessStateL22PES.isActive = true
          this.roleProcessStateL22PESService.update(this.roleProcessStateL22PES).subscribe(result => {
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
    this.resetRoleProcessStateL22PESModal()
  }









}
