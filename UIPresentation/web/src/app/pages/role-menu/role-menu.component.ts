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
import { RoleMenuService } from 'src/app/services/role-menu/role-menu.service';
import { RoleMenu } from 'src/app/models/role-menu/role-menu';
import { MenuService } from 'src/app/services/menu/menu.service';
import { Menu } from 'src/app/models/menu/menu';
@Component({
  selector: 'app-role-menu',
  templateUrl: './role-menu.component.html',
  styleUrls: ['./role-menu.component.css'],
  providers: [RoleMenuService, RoleService, MenuService],
})
export class RoleMenuComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private roleMenuService: RoleMenuService,
    private roleService: RoleService,
    private menuService: MenuService,
    private alertifyService: AlertifyService,
    private orderService: OrderService
  ) { }

  searchForm!: FormGroup;
  filterModel!: FilterModel;
  roleMenus!: RoleMenu[];
  roles!: Role[];
  menus!: Menu[];
  currentPage: number = 1;
  itemsPerPage: number = 10
  displayRoleMenuModal: string = 'none';
  roleMenuForm!: FormGroup;
  saveType!: SaveTypeEnum
  roleMenu!: RoleMenu
  selectedRoleMenuId!: string
  fileName = 'roleMenu';
  displayConfirmModal: string = 'none';
  roleIdDefault = ''
  menuIdDefault = ''

  ngOnInit() {
    this.createSearchForm();
    this.createRoleMenuForm();
    this.getRoles()
    this.getMenus()
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
        this.roleMenuService.search(this.filterModel).subscribe((dataResult) => {
          if (dataResult) {
            if (dataResult.success) {
              if (dataResult.data) {
                this.roleMenus = dataResult.data;
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
    this.orderService.order(this.roleMenus, columnName, OrderTypeEnum.Asc)
  }

  orderDesc(columnName: string) {
    this.orderService.order(this.roleMenus, columnName, OrderTypeEnum.Desc)
  }

  clear() {
    this.searchForm.controls['filter'].setValue('');
  }

  exportToExcel() {
    const ws: xlsx.WorkSheet = xlsx.utils.json_to_sheet(this.roleMenus);
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

  createRoleMenuForm() {
    this.roleMenuForm = this.formBuilder.group({
      id: [''],
      roleId: ['', [Validators.required]],
      menuId: ['', [Validators.required]],
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

  getMenus() {
    this.menuService.getAll().subscribe(dataResult => {
      if (dataResult) {
        if (dataResult.success) {
          if (dataResult.data) {
            this.menus = dataResult.data
          }
        }
      }
    })
  }

  getById(roleMenuId: string) {
    this.roleMenuService.getById(roleMenuId).subscribe((dataResult) => {
      if (dataResult) {
        if (dataResult.success) {
          if (dataResult.data) {
            this.roleMenuForm.controls['id'].setValue(dataResult.data.id);
            this.roleMenuForm.controls['roleId'].setValue(dataResult.data.roleId);
            this.roleMenuForm.controls['menuId'].setValue(dataResult.data.menuId);
          }
        } else {
          this.alertifyService.error(dataResult.message);
        }
      }
    });
  }

  openRoleMenuModal(roleMenuId?: string) {
    this.displayRoleMenuModal = "block"
    if (roleMenuId) {
      this.selectedRoleMenuId = roleMenuId
      this.saveType = SaveTypeEnum.Update
      this.getById(roleMenuId)
    }
    else {
      this.saveType = SaveTypeEnum.Add
    }
  }

  closeRoleMenuModal() {
    this.displayRoleMenuModal = "none"
    this.resetRoleMenuModal()
  }

  resetRoleMenuModal() {
    this.roleMenuForm.controls['id'].setValue('');
    this.roleMenuForm.controls['roleId'].setValue('');
    this.roleMenuForm.controls['menuId'].setValue('');
    this.displayConfirmModal = "none"
    this.displayRoleMenuModal = "none"
  }

  openConfirmModal(id: string) {
    this.displayConfirmModal = 'block';
    this.selectedRoleMenuId = id
  }

  closeConfirmModal() {
    this.displayConfirmModal = "none"
  }

  delete(roleMenuId: string) {
    this.roleMenuService.delete(roleMenuId).subscribe((result) => {
      if (result) {
        if (result.success) {
          this.alertifyService.success(result.message);
          this.search()
        } else {
          this.alertifyService.error(result.message);
        }
      }
    });
    this.resetRoleMenuModal()
  }

  deleteFromConfirm() {
    this.delete(this.selectedRoleMenuId)
    this.closeConfirmModal()
  }

  save() {
    if (this.roleMenuForm.valid) {
      this.roleMenu = Object.assign({}, this.roleMenuForm.value)
      if (this.roleMenu) {
        if (this.saveType == SaveTypeEnum.Add) {

          this.roleMenu.id = UUID.UUID()
          this.roleMenu.optime = new Date()
          this.roleMenu.isActive = true
          this.roleMenuService.add(this.roleMenu).subscribe(result => {
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
          this.roleMenu.id = this.selectedRoleMenuId
          this.roleMenu.optime = new Date()
          this.roleMenu.isActive = true
          this.roleMenuService.update(this.roleMenu).subscribe(result => {
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
    this.resetRoleMenuModal()
  }









}
