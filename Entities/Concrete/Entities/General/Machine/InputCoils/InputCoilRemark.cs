using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine.InputCoils
{
    public class InputCoilRemark : IEntity//Giriş Bobini Açıklama
    {
        public Guid Id { get; set; }
        public Guid InputCoilId { get; set; }
        public string? Text { get; set; }//D0KKATT! S0P SAP 2 MM ALTI S0PAR0^LERE VER0LMEL0D0R. deneme
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
