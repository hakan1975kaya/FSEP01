using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.Messages.PLC.Machine
{
    public static class PLCRewinderPressureMessages
    {
        public static string Added = " Sarıcı Basıncı eklendi";
        public static string Updated = " Sarıcı Basıncı güncellendi";
        public static string Deleted = " Sarıcı Basıncı silindi";
        public static string OperationFailed = "İşlem Başarısız";
        public static string Read = " Sarıcı Basıncı Bileşeni PLC den okundu";
        public static string Write = " Sarıcı Basıncı Bileşeni PLC ye yazıldı";
    }
}
