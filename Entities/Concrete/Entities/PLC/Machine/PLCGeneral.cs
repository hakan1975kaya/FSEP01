using Core.Entities.Abstract;
using Entities.Concrete.Enums.PLC.Machine;

namespace Entities.Concrete.Entities.PLC.Machine
{
    public class PLCGeneral : IEntity
    {
        public Guid Id { get; set; }
        public string? RecipeNameLast { get; set; }//Name:RecipeNameLast,Adress:DB 90 DBB 40,Data Type:String
        public ServiceEnum? MachineMode { get; set; }//Name:MachineMode,Adress:DB 90 DBW 24,Data Type:Int
        public MachineEnum? MachineState { get; set; }//Name:MachineMode,Adress:DB 90 DBW 26,Data Type:Int
        public short? MachineSpeedSet { get; set; }//Name:MachineSpeedSet,Adress:DB 91 DBW 2,Data Type:Int
        public short? MachineSpeedActuel { get; set; }//Name:MachineSpeedAct,Adress:DB 90 DBW 2,Data Type:Int
        public short? MachineSpeedMaximum { get; set; }//Name:MachineSpeedMax,Adress:DB 90 DBW 0,Data Type:Int
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}


