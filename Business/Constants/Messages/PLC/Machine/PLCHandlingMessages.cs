using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.Messages.PLC.Machine
{
    public static class PLCHandlingMessages
    {
        public static string Added = " Taşıma eklendi";
        public static string Updated = " Taşıma güncellendi";
        public static string Deleted = " Taşıma silindi";
        public static string OperationFailed = "İşlem Başarısız";
        public static string Read = " Taşıma Bileşeni PLC den okundu";
        public static string Write = " Taşıma Bileşeni PLC ye yazıldı";
    }
}
