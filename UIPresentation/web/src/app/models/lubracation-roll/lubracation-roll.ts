import { LocationEnum } from "src/app/enums/location-enum.enum"
import { RollStatusEnum } from "src/app/enums/roll-status-enum.enum"

export class LubracationRoll {
  id!:string
  rollNumber!:string
  rollDiameter?:number
  groupName?:string
  rollName?:string
  hardness?:number
  roughness?:string
  status!:RollStatusEnum
  location!:LocationEnum
  optime!:Date
  isActive!:boolean
}
