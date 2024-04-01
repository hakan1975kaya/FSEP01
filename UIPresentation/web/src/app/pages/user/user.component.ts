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
import { UserService } from 'src/app/services/user/user.service';
import { User } from 'src/app/models/user/user';
import { UserModel } from 'src/app/models/user/user-model';
@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
  providers: [UserService],
})
export class UserComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService,
    private alertifyService: AlertifyService,
    private orderService: OrderService
  ) { }

  searchForm!: FormGroup;
  filterModel!: FilterModel;
  users!: User[];
  currentPage: number = 1;
  itemsPerPage: number = 10
  displayUserModal: string = 'none';
  userForm!: FormGroup;
  saveType!: SaveTypeEnum
  user!: User
  selectedUserId!: string
  fileName = 'user';
  displayConfirmModal: string = 'none';
  isPasswordRequired: boolean = false
  userModel!: UserModel
  ngOnInit() {
    this.createSearchForm();
    this.createUserForm();
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
        this.userService.search(this.filterModel).subscribe((dataResult) => {
          if (dataResult) {
            if (dataResult.success) {
              if (dataResult.data) {
                this.users = dataResult.data;
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
    this.orderService.order(this.users, columnName, OrderTypeEnum.Asc)
  }

  orderDesc(columnName: string) {
    this.orderService.order(this.users, columnName, OrderTypeEnum.Desc)
  }

  clear() {
    this.searchForm.controls['filter'].setValue('');
  }

  exportToExcel() {
    const ws: xlsx.WorkSheet = xlsx.utils.json_to_sheet(this.users);
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

  createUserForm() {
    this.userForm = this.formBuilder.group({
      id: [""],
      registrationNumber: ["", [Validators.required, Validators.min(1), Validators.max(99999), Validators.pattern("^[0-9]*$")]],
      firstName: ["", [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      lastName: ["", [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      password: ["", [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      passwordRequired: ["",]
    })
  }

  getById(userId: string) {
    this.userService.getById(userId).subscribe(dataResult => {
      if (dataResult) {
        if (dataResult.success) {
          if (dataResult.data) {
            this.userForm.controls["registrationNumber"].setValue(dataResult.data.registrationNumber)
            this.userForm.controls["firstName"].setValue(dataResult.data.firstName)
            this.userForm.controls["lastName"].setValue(dataResult.data.lastName)
          }
        }
      }
    })
  }

  setPasswordRequired(event: any) {
    this.isPasswordRequired = event.currentTarget.checked
  }

  openUserModal(userId?: string) {
    this.displayUserModal = "block"
    if (userId) {
      this.selectedUserId = userId
      this.isPasswordRequired = false
      this.userForm.controls['passwordRequired'].setValue(false);
      this.saveType = SaveTypeEnum.Update
      this.getById(userId)
    }
    else {
      this.saveType = SaveTypeEnum.Add
    }
  }

  closeUserModal() {
    this.displayUserModal = "none"
    this.resetUserModal()
  }

  resetUserModal() {
    this.userForm.controls["registrationNumber"].setValue(0)
    this.userForm.controls["firstName"].setValue('')
    this.userForm.controls["lastName"].setValue('')
    this.displayConfirmModal = "none"
    this.displayUserModal = "none"
    this.isPasswordRequired = false
  }

  openConfirmModal(id: string) {
    this.displayConfirmModal = 'block';
    this.selectedUserId = id
  }

  closeConfirmModal() {
    this.displayConfirmModal = "none"
  }

  delete(userId: string) {
    this.userService.delete(userId).subscribe((result) => {
      if (result) {
        if (result.success) {
          this.alertifyService.success(result.message);
          this.search()
        } else {
          this.alertifyService.error(result.message);
        }
      }
    });
    this.resetUserModal()
  }

  deleteFromConfirm() {
    this.delete(this.selectedUserId)
    this.closeConfirmModal()
  }

  save() {
    if (this.userForm.valid) {
      this.userModel = Object.assign({}, this.userForm.value)
      if (this.userModel) {
        if (this.saveType == SaveTypeEnum.Add) {

          this.userModel.id = UUID.UUID()
          this.userModel.optime = new Date()
          this.userModel.isActive = true

          if (!this.isPasswordRequired) {
            this.userModel.password = ""
          }

          this.userService.add(this.userModel).subscribe(result => {
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
          this.userModel.id = this.selectedUserId
          this.userModel.optime = new Date()
          this.userModel.isActive = true

          if (!this.isPasswordRequired) {
            this.userModel.password = ""
          }

          this.userService.update(this.userModel).subscribe(result => {
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
    this.resetUserModal()
  }
}
