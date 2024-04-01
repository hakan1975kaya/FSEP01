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
import { UserRoleService } from 'src/app/services/user-role/user-role.service';
import { UserRole } from 'src/app/models/user-role/user-role';
import { UserService } from 'src/app/services/user/user.service';
import { RoleService } from 'src/app/services/role/role.service';
import { User } from 'src/app/models/user/user';
import { Role } from 'src/app/models/role/role';
@Component({
  selector: 'app-user-role',
  templateUrl: './user-role.component.html',
  styleUrls: ['./user-role.component.css'],
  providers: [UserRoleService, UserService, RoleService],
})
export class UserRoleComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private userRoleService: UserRoleService,
    private userService: UserService,
    private roleService: RoleService,
    private alertifyService: AlertifyService,
    private orderService: OrderService
  ) { }

  searchForm!: FormGroup;
  filterModel!: FilterModel;
  userRoles!: UserRole[];
  users!: User[];
  roles!: Role[];
  currentPage: number = 1;
  itemsPerPage: number = 10
  displayUserRoleModal: string = 'none';
  userRoleForm!: FormGroup;
  saveType!: SaveTypeEnum
  userRole!: UserRole
  selectedUserRoleId!: string
  fileName = 'userRole';
  displayConfirmModal: string = 'none';
  userIdDefault = ''
  roleIdDefault = ''

  ngOnInit() {
    this.createSearchForm();
    this.createUserRoleForm();
    this.getUsers()
    this.getRoles()
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
        this.userRoleService.search(this.filterModel).subscribe((dataResult) => {
          if (dataResult) {
            if (dataResult.success) {
              if (dataResult.data) {
                this.userRoles = dataResult.data;
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
    this.orderService.order(this.userRoles, columnName, OrderTypeEnum.Asc)
  }

  orderDesc(columnName: string) {
    this.orderService.order(this.userRoles, columnName, OrderTypeEnum.Desc)
  }

  clear() {
    this.searchForm.controls['filter'].setValue('');
  }

  exportToExcel() {
    const ws: xlsx.WorkSheet = xlsx.utils.json_to_sheet(this.userRoles);
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

  createUserRoleForm() {
    this.userRoleForm = this.formBuilder.group({
      id: [''],
      userId: ['', [Validators.required]],
      roleId: ['', [Validators.required]],
    });
  }

  getUsers() {
    this.userService.getAll().subscribe(dataResult => {
      if (dataResult) {
        if (dataResult.success) {
          if (dataResult.data) {
            this.users = dataResult.data
          }
        }
      }
    })
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


  getById(userRoleId: string) {
    this.userRoleService.getById(userRoleId).subscribe((dataResult) => {
      if (dataResult) {
        if (dataResult.success) {
          if (dataResult.data) {
            this.userRoleForm.controls['id'].setValue(dataResult.data.id);
            this.userRoleForm.controls['userId'].setValue(dataResult.data.userId);
            this.userRoleForm.controls['roleId'].setValue(dataResult.data.roleId);
          }
        } else {
          this.alertifyService.error(dataResult.message);
        }
      }
    });
  }

  openUserRoleModal(userRoleId?: string) {
    this.displayUserRoleModal = "block"
    if (userRoleId) {
      this.selectedUserRoleId = userRoleId
      this.saveType = SaveTypeEnum.Update
      this.getById(userRoleId)
    }
    else {
      this.saveType = SaveTypeEnum.Add
    }
  }

  closeUserRoleModal() {
    this.displayUserRoleModal = "none"
    this.resetUserRoleModal()
  }

  resetUserRoleModal() {
    this.userRoleForm.controls['id'].setValue('');
    this.userRoleForm.controls['userId'].setValue('');
    this.userRoleForm.controls['roleId'].setValue('');
    this.displayConfirmModal = "none"
    this.displayUserRoleModal = "none"
  }

  openConfirmModal(id: string) {
    this.displayConfirmModal = 'block';
    this.selectedUserRoleId = id
  }

  closeConfirmModal() {
    this.displayConfirmModal = "none"
  }

  delete(userRoleId: string) {
    this.userRoleService.delete(userRoleId).subscribe((result) => {
      if (result) {
        if (result.success) {
          this.alertifyService.success(result.message);
          this.search()
        } else {
          this.alertifyService.error(result.message);
        }
      }
    });
    this.resetUserRoleModal()
  }

  deleteFromConfirm() {
    this.delete(this.selectedUserRoleId)
    this.closeConfirmModal()
  }

  save() {
    if (this.userRoleForm.valid) {
      this.userRole = Object.assign({}, this.userRoleForm.value)
      if (this.userRole) {
        if (this.saveType == SaveTypeEnum.Add) {

          this.userRole.id = UUID.UUID()
          this.userRole.optime = new Date()
          this.userRole.isActive = true
          this.userRoleService.add(this.userRole).subscribe(result => {
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
          this.userRole.id = this.selectedUserRoleId
          this.userRole.optime = new Date()
          this.userRole.isActive = true
          this.userRoleService.update(this.userRole).subscribe(result => {
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
    this.resetUserRoleModal()
  }









}
