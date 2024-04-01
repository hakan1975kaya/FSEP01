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
@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.css'],
  providers: [RoleService],
})
export class RoleComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private roleService: RoleService,
    private alertifyService: AlertifyService,
    private orderService:OrderService
  ) { }

  searchForm!: FormGroup;
  filterModel!: FilterModel;
  roles!: Role[];
  currentPage: number = 1;
  itemsPerPage: number = 10
  displayRoleModal: string = 'none';
  roleForm!: FormGroup;
  saveType!: SaveTypeEnum
  role!: Role
  selectedRoleId!: string
  fileName = 'role';
  displayConfirmModal: string = 'none';

  ngOnInit() {
    this.createSearchForm();
    this.createRoleForm();
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
        this.roleService.search(this.filterModel).subscribe((dataResult) => {
          if (dataResult) {
            if (dataResult.success) {
              if (dataResult.data) {
                this.roles = dataResult.data;
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
    this.orderService.order(this.roles, columnName, OrderTypeEnum.Asc)
  }

  orderDesc(columnName: string) {
    this.orderService.order(this.roles, columnName, OrderTypeEnum.Desc)
  }

  clear() {
    this.searchForm.controls['filter'].setValue('');
  }

  exportToExcel() {
    const ws: xlsx.WorkSheet = xlsx.utils.json_to_sheet(this.roles);
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

  createRoleForm() {
    this.roleForm = this.formBuilder.group({
      id: [""],
      roleName: ["", [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
    })
  }

  getById(roleId: string) {
    this.roleService.getById(roleId).subscribe(dataResult => {
      if (dataResult) {
        if (dataResult.success) {
          if (dataResult.data) {
              this.roleForm.controls["roleName"].setValue(dataResult.data.roleName)
          }
        }
      }
    })
  }

  openRoleModal(roleId?: string) {
    this.displayRoleModal = "block"
    if (roleId) {
      this.selectedRoleId = roleId
      this.saveType = SaveTypeEnum.Update
      this.getById(roleId)
    }
    else {
      this.saveType = SaveTypeEnum.Add
    }
  }

  closeRoleModal() {
    this.displayRoleModal = "none"
    this.resetRoleModal()
  }

  resetRoleModal() {
    this.roleForm.controls["roleName"].setValue("")
    this.displayConfirmModal="none"
    this.displayRoleModal="none"
  }

  openConfirmModal(id: string) {
    this.displayConfirmModal = 'block';
    this.selectedRoleId = id
  }

  closeConfirmModal()
  {
    this.displayConfirmModal="none"
  }

  delete(roleId: string) {
    this.roleService.delete(roleId).subscribe((result) => {
      if (result) {
        if (result.success) {
          this.alertifyService.success(result.message);
          this.search()
        } else {
          this.alertifyService.error(result.message);
        }
      }
    });
    this.resetRoleModal()
  }

  deleteFromConfirm() {
    this.delete(this.selectedRoleId)
    this.closeConfirmModal()
  }

  save() {
    if (this.roleForm.valid) {
      this.role = Object.assign({}, this.roleForm.value)
      if (this.role) {
        if (this.saveType == SaveTypeEnum.Add) {

          this.role.id = UUID.UUID()
          this.role.optime = new Date()
          this.role.isActive = true
          this.roleService.add(this.role).subscribe(result => {
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
          this.role.id = this.selectedRoleId
          this.role.optime = new Date()
          this.role.isActive = true
          this.roleService.update(this.role).subscribe(result => {
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
    this.resetRoleModal()
  }









}
