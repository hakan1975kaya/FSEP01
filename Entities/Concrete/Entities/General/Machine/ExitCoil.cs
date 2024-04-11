using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine
{
    public class ExitCoil : IEntity
    {
        public Guid Id { get; set; }
        public Guid EntryCoilId { get; set; }
        public string LocalId { get; set; }//Bobin no
        public DateTime ProductionStart { get; set; }//Üretim bitiş zamanı
        public DateTime ProductionEnd { get; set; }//Üretim bitiş zamanı
        public string FlagConsumed { get; set; }//Son makine mı?→Hayır→N Evet→Y (CONSUMED)
        public decimal OuterDiameter { get; set; }//Coil_Diameter: Slitpattern detaildeki min ve max Min Outdiamater ve Max Outdimater değerlerine göre çıkışta operatör tarafından üretim raparu ekranına girilecektir.  (mm)
        public decimal ExitCoilLength { get; set; }//Coil_Length(Üretilen bobin genişliği): Çıkışta operatör tarafından formül tablosu ile hesaplanıp üretim raporu ekranına girilecek.  (mm)
        public decimal ExitInnerDiameter { get; set; }//Coil_Inner_Diameter:Üretim raporunda innerdimater açılan listesi olacak.Operatör Slitpatterndeki innerdiamaterler otomatik olarak burada görülecektir.Çıkışta operatör tarafından üretim raporu ekranından girilecektir.Değerler:76,150,152,300,400,508 olacak.  (mm)
        public string SpoolTypeAsas { get; set; }//SpoolType (Kor Bilgisi):Üretim bittiğinde,üretim bildirim ekranında Spool Type Selection diye bir ekran olacak.Operatör hangi masurayı kullandı ise buradan masura numarasını seçecek.
        public long TensionerBottom { get; set; }//Rewinder1TensionAct(Rewinder1 Tension Actual Value):Üst sarıcı hesaplanan gergi değeri,hmi ekranına a giden değer. (N/mm2)
        public long TensionerTop { get; set; }//Rewinder2TensionAct (Rewinder2 Tension Actual  Value)::Alt  sarıcı hesaplanan gergi değeri,hmi ekranına a giden değer. (N/mm2)
        public float ThicknessInspectionTop { get; set; }//Inspection da ölçülen  üst kalınlık bilgisi:Operatör tarafından ölçülen değer,üretim bildirim ekranına girilecek (mm)
        public float ThicknessInspectionBottom { get; set; }//Inspection da ölçülen  alt  kalınlık bilgisi,üretim bildirim ekranına girilecek (mm)
        public string WindingSenseExitOne { get; set; }//Sarma Algı Çıkışı bir
        public string WindingSenseExitTwo { get; set; }//Sarma Algı Çıkışı İki
        public string WindingSenseEntry { get; set; }//Sarma Algı Girişi
        public string SlitBaseNumber { get; set; }//slitpattern ekranından yani PSI  output metarial plan  ekranındaki outmatplanıd ler üretim ektanında otomatik olarak gösterilecektir.Üretim bitince operatör hangi sipariş planını kullandıysa onu seçecektir.eg: MAT:2098063-Car1
        public string OperatorName { get; set; }//operatör adı:Üretim bildirim ekranından hangi operatör üretim yaptı ise adını girecektir.
        public int TransporterOneMinimumTension { get; set; }//TRANSPORT1 minumum gergi değeri (%)
        public int TransporterOneMaximumTension { get; set; }//TRANSPORT1 maximum  gergi değeri  (%)
        public int TransporterOneAverageTension { get; set; }//TRANSPORT1  avaraj gergi değeri (%)
        public int TransporterTwoMinimumTension { get; set; }//TRANSPORT2 minumum gergi değeri (%)
        public int TransporterTwoMaximumTension { get; set; }//TRANSPORT2 maximum  gergi değeri (%)
        public int TransporterTwoAverageTension { get; set; }//TRANSPORT2  avaraj gergi değeri (%)
        public decimal RewinderOneMinimumContactPressure { get; set; }//sarıcı 1 min contak basınç değeri (N/mm)
        public decimal RewinderOneMaximumContactPressure { get; set; }//sarıcı 1 max contak basınç değeri (N/mm)
        public decimal WorkRollTopDiameter { get; set; }//N'iş merdane üst çap değeri'
        public decimal RewinderOneAverageContactPressure { get; set; }//sarıcı 1 max avaraj basınç değeri (N/mm)
        public decimal RewinderTwoMinimumContactPressure { get; set; }//sarıcı 2 min contak basınç değeri (N/mm)
        public decimal RewinderTwoMaximumContactPressure { get; set; }//sarıcı 2 max contak basınç değeri (N/mm)
        public decimal RewinderTwoAverageContactPressure { get; set; }//sarıcı 2 avaraj contak basınç değeri (N/mm)
        public int RewinderOneTensionMaximum { get; set; }//sarıcı 1 max gergi değeri (N/mm2)
        public int RewinderOneTensionAverage { get; set; }//sarıcı 1 avaraj gergi değeri (N/mm2)
        public int RewinderTwoTensionMinimum { get; set; }//sarıcı 2 min gergi değeri (N/mm2)
        public int RewinderTwoTensionMaximum { get; set; }//sarıcı 2 maxgergi değeri (N/mm2)
        public int RewinderTwoTensionAverage { get; set; }//sarıcı 2 avaraj gergi değeri (N/mm2)
        public int MachineMaximumSpeed { get; set; }//makine max hız (m/min)
        public int MachineAverageSpeed { get; set; }//makine avaraj hız değeri (m/min)
        public long DownTimeDuration { get; set; }//makine duruş süresi (s)
        public string ScrapReasonOne { get; set; }//hurda nedeni
        public long ScrapValueOne { get; set; }//hurda miktarı
        public decimal UnwinderThickness { get; set; }//açıcı kalınlık değeri (mikroMeter)
        public decimal UnwinderThicknessCalculatedValue { get; set; }//açıcı kalınlık hesaplanan değeri (mikroMeter)
        public decimal UnwinderThicknessCalculatedValueMinumum { get; set; }//açıcı kalınlık hesaplanan  minumum değeri (mikroMeter)
        public decimal UnwinderThicknessCalculatedValueMaximum { get; set; }//açıcı kalınlık hesaplanan  max değeri (mikroMeter)
        public int TensionInletValueActuel { get; set; }//inlet  act  gergi değeri (N)
        public int TensionInletValueMinimum { get; set; }//inlet min  gergi değeri (N)
        public int TensionInletValueMaximum { get; set; }//inlet max  gergi değeri (N)
        public int TensionOutletValueActuel { get; set; }//Outlet  act  gergi değeri (N)
        public int TensionOutletValueMinimum { get; set; }//Outlet min  gergi değeri (N)
        public int TensionOutletValueMaximum { get; set; }//Outlet max  gergi değeri (N)
        public int TensionOutletValueAverage { get; set; }//outlet avg gergi değeri (N)
        public decimal ContactRollTwoTwoDiameter { get; set; }//CONTACT_ROLL22 çap değeri  (mm)
        public decimal ContactRollTwoThreeDiameter { get; set; }//CONTACT_ROLL23 çap değeri (mm)
        public int AccelerationTime { get; set; }//ivlenme zamanı (s)
        public int TransportMachineRpmMaximum { get; set; }//transport 1 makine hız rpm max değeri (rpm)
        public int TransportMachineRpmAverage { get; set; }//transport 1 makine hız rpm avg değeri (rpm)
        public int RewinderOneAbsoliteTensionMinimum { get; set; }//1.sarıcı gergi abs min gergi değeri (N)
        public int RewinderOneAbsoliteTensionMaximum { get; set; }//1.sarıcı gergi abs max gergi değeri (N)
        public int RewinderOneAbsoliteTensionAverage { get; set; }//1.sarıcı gergi abs avg gergi değeri (N)
        public decimal RewinderOneContactPressureActuelNewton { get; set; }//1.sarıcı kontak basınç  act değeri N cinsinden (N)
        public decimal RewinderOneContactPressureMinimumlNewton { get; set; }//1.sarıcı kontak basınç  min değeri N cinsinden (N)
        public decimal RewinderOneContactPressureMaximumlNewton { get; set; }//1.sarıcı kontak basınç  max değeri N cinsinden (N)
        public decimal RewinderOneContactPressureAverageNewton { get; set; }//1.sarıcı kontak basınç  avg değeri N cinsinden (N)
        public int RewinderTwoAbsoliteTensionActuel { get; set; }//2.sarıcı gergi abs act gergi değeri (N)
        public int RewinderTwoAbsoliteTensionMimimum { get; set; }//2.sarıcı gergi abs min gergi değeri (N)
        public int RewinderTwoAbsoliteTensionMaximum { get; set; }//2.sarıcı gergi abs max gergi değeri (N)
        public int RewinderTwoAbsoliteTensionAverage { get; set; }//2.sarıcı gergi abs avg gergi değeri (N)
        public decimal RewinderTwoContactPressureActuelNewton { get; set; }//2.sarıcı kontak basınç  act değeri N cinsinden (N)
        public decimal RewinderTwoContactPressureMinimumlNewton { get; set; }//2.sarıcı kontak basınç  min değeri N cinsinden (N)
        public decimal RewinderTwoContactPressureMaximumlNewton { get; set; }//2.sarıcı kontak basınç  max değeri N cinsinden (N)
        public decimal RewinderTwoContactPressureAverageNewton { get; set; }//2.sarıcı kontak basınç  avg değeri N cinsinden (N)
        public long ContactRollOnePositionActual { get; set; }//kontak 1.merdane pozisyon act değeri (mm)
        public long ContactRollTwoPositionActual { get; set; }//kontak 2.merdane pozisyon act değeri (mm) 
        public int RewinderOneSlittingWidthSported { get; set; }//Rew1 desteklenen  dilme genişliği (mm)
        public int RewinderTwoSlittingWidthSported { get; set; }//Rew2 desteklenen  dilme genişliği (mm)
        public bool PreCutterOneTwoOnOffStatus { get; set; }//Ön Kesici on veya off
        public bool BoosterOnOffStatus { get; set; }//Yükseltici on veya off
        public bool SuctionOnOffStatus { get; set; }//Emme on veya off
        public bool BoosterSortOneOnOffStatus { get; set; }//Yükseltici Sıralama 1 on veya off
        public bool BoosterSortTwoOnOffStatus { get; set; }//Yükseltici Sıralama 2 on veya off
        public bool BoosterSortThreeOnOffStatus { get; set; }//Yükseltici Sıralama 3 on veya off
        public int AirFlapOneMinimum { get; set; }//Hava Kapağı 1 Min (%)
        public int AirFlapOneMaximum { get; set; }//Hava Kapağı 1 Max (%)
        public int AirFlapOneAverage { get; set; }//Hava Kapağı 1 Avg (%)
        public int AirFlapTwoActual { get; set; }//Hava Kapağı 2 Act (%)
        public int AirFlapTwoMinimum { get; set; }//Hava Kapağı 2 Min (%)
        public int AirFlapTwoMaximum { get; set; }//Hava Kapağı 2 Max (%)
        public int AirFlapTwoAverage { get; set; }//Hava Kapağı 2 Avg (%)
        public bool RollWidthTwoOneOnOffStatus { get; set; }//Rulo 2 1 on veya off
        public bool RollWidthTwoTwoOnOffStatus { get; set; }//Rulo 2 2 on veya off
        public bool RollWidthFourOnOffStatus { get; set; }//Rulo 4 on veya off
        public int RollWidthOneThreeSpeedMaximum { get; set; }//Rulo 1 3  speed max
        public int RollWidthOneThreeSpeedAverage { get; set; }//Rulo 1 3 speed  avg
        public int RollWidthOneFourSpeedMaximum { get; set; }//Rulo 1 4 speed  max
        public int RollWidthOneFourSpeedAverage { get; set; }//Rulo 1 4 speed  avg
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
