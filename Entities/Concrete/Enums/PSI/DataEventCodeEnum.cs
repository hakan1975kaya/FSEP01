using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Enums.PSI
{
    public enum DataEventCodeEnum
    {
        None = 0,
        REQUEST = 1,//On request from L2. In this case all foil data are sent to L2-->L2'nin talebi üzerine. Bu durumda tüm folyo verileri L2'ye gönderilir.
        DELETE = 2,//The schedule was deleted. Only foil IDs are sent to L2.-->Program silindi. L2'ye yalnızca folyo kimlikleri gönderilir.
        RELEASE = 3,//The schedule was released by MES. Only foil IDs are sent to L2.-->Program MES tarafından açıklandı. L2'ye yalnızca folyo kimlikleri gönderilir.
        UPDATE = 4, //The schedule was changed. Only foil IDs are sent to L2.-->Program değiştirildi. L2'ye yalnızca folyo kimlikleri gönderilir.
        INTERRUPT = 5,//The schedule was interrupted but will be con-tinued later. Only foil IDs are sent to L2.-->Program kesintiye uğradı ancak daha sonra devam edilecek. L2'ye yalnızca folyo kimlikleri gönderilir.
        LOCATED = 6,//A coil is located to the before line location-->Hat öncesi konuma bir bobin yerleştirilmiştir
    }
}
