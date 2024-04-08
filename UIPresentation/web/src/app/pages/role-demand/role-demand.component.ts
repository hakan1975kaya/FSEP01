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
import { RoleDemandService } from 'src/app/services/role-demand/role-demand.service';
import { RoleDemand } from 'src/app/models/role-demand/role-demand';
import { DemandService } from 'src/app/services/demand/demand.service';
import { Demand } from 'src/app/models/demand/demand';
@Component({
  selector: 'app-role-demand',
  templateUrl: './role-demand.component.html',
  styleUrls: ['./role-demand.component.css'],
  providers: [RoleDemandService, RoleService, DemandService],
})
export class RoleDemandComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private roleDemandService: RoleDemandService,
    private roleService: RoleService,
    private demandService: DemandService,
    private alertifyService: AlertifyService,
    private orderService: OrderService
  ) { }

  searchForm!: FormGroup;
  filterModel!: FilterModel;
  roleDemands!: RoleDemand[];
  roles!: Role[];
  demands!: Demand[];
  currentPage: number = 1;
  itemsPerPage: number = 10
  displayRoleDemandModal: string = 'none';
  roleDemandForm!: FormGroup;
  saveType!: SaveTypeEnum
  roleDemand!: RoleDemand
  selectedRoleDemandId!: string
  fileName = 'roleDemand';
  displayConfirmModal: string = 'none';
  roleIdDefault = ''
  demandIdDefault = ''

  ngOnInit() {
    this.createSearchForm();
    this.createRoleDemandForm();
    this.getRoles()
    this.getDemands()
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
        this.roleDemandService.search(this.filterModel).subscribe((dataResult) => {
          if (dataResult) {
            if (dataResult.success) {
              if (dataResult.data) {
                this.roleDemands = dataResult.data;
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
    this.orderService.order(this.roleDemands, columnName, OrderTypeEnum.Asc)
  }

  orderDesc(columnName: string) {
    this.orderService.order(this.roleDemands, columnName, OrderTypeEnum.Desc)
  }

  clear() {
    this.searchForm.controls['filter'].setValue('');
  }

  exportToExcel() {
    const ws: xlsx.WorkSheet = xlsx.utils.json_to_sheet(this.roleDemands);
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

  createRoleDemandForm() {
    this.roleDemandForm = this.formBuilder.group({
      id: [''],
      roleId: ['', [Validators.required]],
      demandId: ['', [Validators.required]],
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

  getDemands() {
    this.demandService.getAll().subscribe(dataResult => {
      if (dataResult) {
        if (dataResult.success) {
          if (dataResult.data) {
            this.demands = dataResult.data
          }
        }
      }
    })
  }

  getById(roleDemandId: string) {
    this.roleDemandService.getById(roleDemandId).subscribe((dataResult) => {
      if (dataResult) {
        if (dataResult.success) {
          if (dataResult.data) {
            this.roleDemandForm.controls['id'].setValue(dataResult.data.id);
            this.roleDemandForm.controls['roleId'].setValue(dataResult.data.roleId);
            this.roleDemandForm.controls['demandId'].setValue(dataResult.data.demandId);
          }
        } else {
          this.alertifyService.error(dataResult.message);
        }
      }
    });
  }

  openRoleDemandModal(roleDemandId?: string) {
    this.displayRoleDemandModal = "block"
    if (roleDemandId) {
      this.selectedRoleDemandId = roleDemandId
      this.saveType = SaveTypeEnum.Update
      this.getById(roleDemandId)
    }
    else {
      this.saveType = SaveTypeEnum.Add
    }
  }

  closeRoleDemandModal() {
    this.displayRoleDemandModal = "none"
    this.resetRoleDemandModal()
  }

  resetRoleDemandModal() {
    this.roleDemandForm.controls['id'].setValue('');
    this.roleDemandForm.controls['roleId'].setValue('');
    this.roleDemandForm.controls['demandId'].setValue('');
    this.displayConfirmModal = "none"
    this.displayRoleDemandModal = "none"
  }

  openConfirmModal(id: string) {
    this.displayConfirmModal = 'block';
    this.selectedRoleDemandId = id
  }

  closeConfirmModal() {
    this.displayConfirmModal = "none"
  }

  delete(roleDemandId: string) {
    this.roleDemandService.delete(roleDemandId).subscribe((result) => {
      if (result) {
        if (result.success) {
          this.alertifyService.success(result.message);
          this.search()
        } else {
          this.alertifyService.error(result.message);
        }
      }
    });
    this.resetRoleDemandModal()
  }

  deleteFromConfirm() {
    this.delete(this.selectedRoleDemandId)
    this.closeConfirmModal()
  }

  save() {
    if (this.roleDemandForm.valid) {
      this.roleDemand = Object.assign({}, this.roleDemandForm.value)
      if (this.roleDemand) {
        if (this.saveType == SaveTypeEnum.Add) {

          this.roleDemand.id = UUID.UUID()
          this.roleDemand.optime = new Date()
          this.roleDemand.isActive = true
          this.roleDemandService.add(this.roleDemand).subscribe(result => {
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
          this.roleDemand.id = this.selectedRoleDemandId
          this.roleDemand.optime = new Date()
          this.roleDemand.isActive = true
          this.roleDemandService.update(this.roleDemand).subscribe(result => {
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
    this.resetRoleDemandModal()
  }









}
