using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine
{
    public class InputCoilAttachment : IEntity
    {
        public Guid Id { get; set; }
        public Guid InputCoilId { get; set; }
        public string? FileName { get; set; }//COIL_REPORT_REF_PATH
        public string? Path { get; set; }//\\10.54.1.155\L2_Report\Frm02_Report\Coil_Report_600167316_120030333.02_48µm_0.pdf
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
