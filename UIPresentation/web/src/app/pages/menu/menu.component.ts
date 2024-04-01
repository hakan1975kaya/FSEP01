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
import { MenuService } from 'src/app/services/menu/menu.service';
import { Menu } from 'src/app/models/menu/menu';
@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css'],
  providers: [MenuService],
})
export class MenuComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private menuService: MenuService,
    private alertifyService: AlertifyService,
    private orderService:OrderService
  ) { }

  searchForm!: FormGroup;
  filterModel!: FilterModel;
  menus!: Menu[];
  currentPage: number = 1;
  itemsPerPage: number = 10
  displayMenuModal: string = 'none';
  menuForm!: FormGroup;
  saveType!: SaveTypeEnum
  menu!: Menu
  selectedMenuId!: string
  fileName = 'menu';
  displayConfirmModal: string = 'none';

  ngOnInit() {
    this.createSearchForm();
    this.createMenuForm();
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
        this.menuService.search(this.filterModel).subscribe((dataResult) => {
          if (dataResult) {
            if (dataResult.success) {
              if (dataResult.data) {
                this.menus = dataResult.data;
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
    this.orderService.order(this.menus, columnName, OrderTypeEnum.Asc)
  }

  orderDesc(columnName: string) {
    this.orderService.order(this.menus, columnName, OrderTypeEnum.Desc)
  }

  clear() {
    this.searchForm.controls['filter'].setValue('');
  }

  exportToExcel() {
    const ws: xlsx.WorkSheet = xlsx.utils.json_to_sheet(this.menus);
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

  createMenuForm() {
    this.menuForm = this.formBuilder.group({
      id: [""],
      menuName: ["", [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      description: ["", [Validators.required, Validators.minLength(2), Validators.maxLength(100)]],
      path: ["", [Validators.required, Validators.minLength(2), Validators.maxLength(200)]],
      menuOrder: ["", [Validators.required, Validators.min(1), Validators.max(200),Validators.pattern("^[0-9]*$")]]
    })
  }

  getById(menuId: string) {
    this.menuService.getById(menuId).subscribe(dataResult => {
      if (dataResult) {
        if (dataResult.success) {
          if (dataResult.data) {
              this.menuForm.controls["menuName"].setValue(dataResult.data.menuName)
              this.menuForm.controls["description"].setValue(dataResult.data.description)
              this.menuForm.controls["path"].setValue(dataResult.data.path)
              this.menuForm.controls["menuOrder"].setValue(dataResult.data.menuOrder)
          }
        }
      }
    })
  }

  openMenuModal(menuId?: string) {
    this.displayMenuModal = "block"
    if (menuId) {
      this.selectedMenuId = menuId
      this.saveType = SaveTypeEnum.Update
      this.getById(menuId)
    }
    else {
      this.saveType = SaveTypeEnum.Add
    }
  }

  closeMenuModal() {
    this.displayMenuModal = "none"
    this.resetMenuModal()
  }

  resetMenuModal() {
    this.menuForm.controls["menuName"].setValue('')
    this.menuForm.controls["description"].setValue('')
    this.menuForm.controls["path"].setValue('')
    this.menuForm.controls["menuOrder"].setValue(0)
    this.displayConfirmModal="none"
    this.displayMenuModal="none"
  }

  openConfirmModal(id: string) {
    this.displayConfirmModal = 'block';
    this.selectedMenuId = id
  }

  closeConfirmModal()
  {
    this.displayConfirmModal="none"
  }

  delete(menuId: string) {
    this.menuService.delete(menuId).subscribe((result) => {
      if (result) {
        if (result.success) {
          this.alertifyService.success(result.message);
          this.search()
        } else {
          this.alertifyService.error(result.message);
        }
      }
    });
    this.resetMenuModal()
  }

  deleteFromConfirm() {
    this.delete(this.selectedMenuId)
    this.closeConfirmModal()
  }

  save() {
    if (this.menuForm.valid) {
      this.menu = Object.assign({}, this.menuForm.value)
      if (this.menu) {
        if (this.saveType == SaveTypeEnum.Add) {

          this.menu.id = UUID.UUID()
          this.menu.optime = new Date()
          this.menu.isActive = true
          this.menuService.add(this.menu).subscribe(result => {
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
          this.menu.id = this.selectedMenuId
          this.menu.optime = new Date()
          this.menu.isActive = true
          this.menuService.update(this.menu).subscribe(result => {
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
    this.resetMenuModal()
  }









}
