import { Injectable } from '@angular/core';
import { OrderTypeEnum } from 'src/app/enums/order-type-enum.enum';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

constructor() { }

order(array: any[], columnName: string, orderType: OrderTypeEnum): any[] {
  if (orderType == OrderTypeEnum.Asc) {
    return array.sort((a, b) => (a[columnName] < b[columnName]) ? -1 : 1)
  }
  else if (orderType == OrderTypeEnum.Desc) {
    return array.sort((a, b) => (a[columnName] > b[columnName]) ? -1 : 1)
  }
  else {
    return array
  }
}


}
