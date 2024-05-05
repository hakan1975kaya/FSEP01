using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.Messages.PLC.Machine
{
    public static class PLCRewinderTensionMessages
    {
        public static string Added = " Sarıcı Gerilimi eklendi";
        public static string Updated = " Sarıcı Gerilimi güncellendi";
        public static string Deleted = " Sarıcı Gerilimi silindi";
        public static string OperationFailed = "İşlem Başarısız";
        public static string Read = " Sarıcı Gerilimi Bileşeni PLC den okundu";
        public static string Write = " Sarıcı Gerilimi Bileşeni PLC ye yazıldı";
    }
}
