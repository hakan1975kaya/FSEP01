using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine
{
    public class EntryCoil : IEntity
    {
        public Guid Id { get; set; }
        public string Alloy { get; set; }//Bobinin alaşım değeri
        public string LocalId { get; set; }//Bobin numarası
        public decimal EntryThickness { get; set; }//Bobin giriş kalınlığı (mm)
        public string Temper { get; set; }//Proses Kondüsyonu  (mm)
        public string ProdGroup { get; set; }//Kullanım Alanı Not:OD ile tartışılacak  (mm)
        public decimal EntryCoilInnerDiameter { get; set; }//Bobin giriş iç çapı  (mm)
        public decimal EntryCoilWidth { get; set; }//Bobin giriş genişliği  (mm)
        public decimal EntryCoilWeight { get; set; }//Entry coil weight  (kg)
        public decimal EntryCoilLength { get; set; }//Bobin giriş metrajı  (mm)
        public decimal EntryInnerDiameter { get; set; }//Önceki hatlardan kor takıldıysa,korun iç çapı ,bobinin iç çapı oluyor.Korlu bobin iç çapı olarak düşünülebilir.Bu değer baz alınacak  (mm)
        public decimal EntryOuterDiameter { get; set; }//Giriş bobin dış çap bilgisi  (mm)
        public long PostedId { get; set; }//Psi daki bir bobinin step numarası
        public DateTime LastProductionTime { get; set; }//Bobinin son üretim zamanı
        public string PreviousPositionSteps { get; set; }//Önceki process isimleri  (mm)
        public string BlockedFlag { get; set; }//PSI(Mes) tarafınki bobinin bloklanıp bloklanmadığını gösteren parametredir."Y" ise bobini psi bloklamıştır,"N" ise bloklanmamıştır.
        public int CoilOuterDiameterMinimum { get; set; }//Outer Diametermin  (Rulo Dış Çapı Min)  Minumum OuterDiameter
        public int CoilOuterDiameterMaximum { get; set; }//Outer Diameter max Rulo Dış Çapı Max (mm  )   MaximumOuterDiameter
        public decimal CoilWeightMinimum { get; set; }//Coil Weight MİN  Rulo Ağırlığı min (kg) CoilWeightMin
        public decimal CoilWeightMaximum { get; set; }//Coil Weight Max  Rulo Ağırlığı max (kg) CoilWeightMax
        public int WidthAim { get; set; }//En amaç WidthAim
        public decimal WidthToleranceMinimum { get; set; }//En Eksi Tolerans (mm) WidthTolMin
        public decimal WidthToleranceMaximum { get; set; }// En Artı Tolerans (mm)) WidthTolMax
        public string PositionStepId { get; set; }//Psi daki step numarası
        public string MainCoilProductionId { get; set; }//Psi malzeme rotasındaki Ana bobinin poid numarası. 
        public string PositionStepSequenceNumber { get; set; }//Psi malzeme rotasındaki ilgili stepin  sequens numarası
        public string PositionStepType { get; set; }//Psi daki step ismi(FROLL,CROLL)
        public string TerstenActivate { get; set; }//Rulo açılım yönü
        public string CustomerName { get; set; }//Müşteri adı
        public string ProductionGroup { get; set; }//Kullanım Alanı
        public decimal ThickbessAim { get; set; }//Kalınlık amaç
        public decimal SoiThickness { get; set; }//Kalınlık Soi
        public decimal ThicknessToleranceMinimum { get; set; }//Minumum Thıckness Tolerance
        public decimal ThicknessToleranceMaximum { get; set; }//Maximum Thıckness Tolerance
        public string SurfaceCondition { get; set; }//Surface→Yüzey Görünümü
        public string SpoolProtrusion { get; set; }//Spool Protrusion →Masura Çıkıntısı (Tek Kenar- mm)
        public string EntrySpoolType { get; set; }//Giriş kor var yada yok bilgisi  1 veye 0 gidecek
        public int ExitSpoolInnerDiameter { get; set; }//INNER_DIA_OUT→çıkış kor çapı
        public string ExitSpoolType { get; set; }//SPOOL_TYP_OUT→çıkış kor tipi
        public long LengthInMeters { get; set; }//METRAJ (m) →LengthInMeters  Not:Metrajlı malzeme siparişleri için önemli !!
        public int LengthInMetersToleranceMaximum { get; set; }//Metraj Artı Tolerans (m)→LengthInMetersTolMax  Not:Metrajlı malzeme siparişleri için önemli !!
        public int LengthInMetersToleranceMinimum { get; set; }//Metraj Eksi Tolerans (m)→LengthInMetersTolMin  Not:Metrajlı malzeme siparişleri için önemli !!
        public decimal FoilAverageThicknessTolerance { get; set; }//FoilAvgThicknessTol→Foil Average Thickness Toleran→Avaraj kalınlık toleransı
        public int NumberOfSplicesPerCoilMaximum { get; set; }//NumOfSplicesPerCoilMax→Rulo Başına Max. Ek Sayısı
        public DateTime TargendDate { get; set; }//Termin Tarihi
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
