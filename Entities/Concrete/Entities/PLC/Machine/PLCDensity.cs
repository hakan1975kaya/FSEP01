using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.PLC.Machine
{
    public class PLCDensity : IEntity
    {
        public Guid Id { get; set; }
        public Guid PLCGeneralId { get; set; }
        public int? RewinderOneDensityGraph { get; set; }//Name:Rew1DensityGraph,Adress:DB 43 DBW 48,Data Type:Int
        public int? RewinderTwoDensityGraph { get; set; }//Name:Rew2DensityGraph,Adress:DB 53 DBW 48,Data Type:Int
        public int? MachineSpeedActuelArchive { get; set; }//Name:MachineSpeedActArchive,Adress:DB 304 DBW 20,Data Type:Int
        public decimal? MaterialThickness { get; set; }//Name:MaterialThickness,Adress:DB 91 DBW 36,Data Type:Int
        public long? RewinderOneDiameterActuel { get; set; }//Name:Rew1DiaAct,Addres:DB 90 DBW 300,Data Type:Int
        public long? RewinderOneLengthActuel { get; set; }//Name:Rew1LengthAct,Adress:DB 90 DBD 306,Data Type:Int
        public long? RewinderTwoDiameterActuel { get; set; }//Name:Rew2DiaAct,Adress:DB 90 DBW 400,Data Type:Int
        public long? RewinderTwoLengthActuel { get; set; }//Name:Rew2LengthAct,Adress:DB 90 DBD 406,Data Type:DInt
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
