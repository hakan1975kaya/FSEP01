import { AuditEnum } from "src/app/enums/audit-enum.enum"

export class WebLog {
  id!:string
  detail!:string
  date!:Date
  audit!:AuditEnum
}

