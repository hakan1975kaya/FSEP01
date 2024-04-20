using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine
{
    public class OutputCoil : IEntity
    {
        public Guid Id { get; set; }
        public Guid InputCoilId { get; set; }
        public string? CoilIdOutput { get; set; }//122041233.01.03
        public string? CoilIdInput { get; set; }//122041233.01
        public int? CoilStatusNumber { get; set; }//2
        public string? CoilStatus { get; set; }//L3 Reported
        public string? CustomerName { get; set; }//ALUCOAT CONVERSION, S.A
        public decimal? CoilLength { get; set; }//5000.00
        public decimal? CoilDiameter { get; set; }//682.00
        public decimal? CoilInnerDiameter { get; set; }//150.00
        public string? SpoolType { get; set; }//Makara Türü 13001582
        public int? TensionerBottom { get; set; }//Gergi Alt 16
        public int? TensionTop { get; set; }//16
        public float? ThicknessInspectionTop { get; set; }//Kalınlık Kontrolü Üst 0.071
        public float? ThicknessInspectionBottom { get; set; }//0.071
        public string? WindingSenseEntry { get; set; }//Sarma Duyusu Girişi Top
        public string? WindingSenseExitOne { get; set; }//Top
        public string? WindingSenseExitTwo { get; set; }//Top
        public short? SlitNumber { get; set; }//Yarık Numara 0
        public string? SlitBaseNumber { get; set; }//MAT:5048443-Car3
        public string? OperatorName { get; set; }//SEMH
        public string? ScrapReasonOne { get; set; }//Hurda Nedeni Bir 50
        public int? ScrapValueOne { get; set; }//Kat Izi
        public string? ScrapReasonTwo { get; set; }//25
        public int? ScrapValueTwo { get; set; }//Giris Kg Hatasi
        public string? ScrapReasonThree { get; set; }//25
        public int? ScrapValueThree { get; set; }
        public string? ScrapReasonFour { get; set; }
        public int? ScrapValueFour { get; set; }
        public string? ScrapReasonFive { get; set; }
        public int? ScrapValueFive { get; set; }
        public DateTime? ProductionStart { get; set; }//2023-01-05 07:17:12
        public DateTime? ProductionEnd { get; set; }//2023-01-29 03:52:57
        public string? Remark { get; set; }//Açıklma
        public string? FlagConsumed { get; set; }//Tüketilen Bayrak Yes
        public short? TransportOneTensionActive { get; set; }//Transport Bir Gerginlik Aktif 25
        public short? TransportOneTensionMinimum { get; set; }//25
        public short? TransportOneTensionMaximum { get; set; }//25
        public short? TransportOneTensionAverage { get; set; }//25
        public short? TransportTwoTensionActive { get; set; }//25
        public short? TransportTwoTensionMinimum { get; set; }//25
        public short? TransportTwoTensionMaximum { get; set; }//25
        public short? TransportTwoTensionAverage { get; set; }//25
        public short? RewinderOneActiveTension { get; set; }//Geri Sarma Bir Aktif Gerilim 25
        public short? RewinderOneMinimumTension { get; set; }//25
        public short? RewinderOneMaximumTension { get; set; }//28
        public short? RewinderOneAverageTension { get; set; }//26
        public decimal? RewinderOneActiveContactPressure { get; set; }//Geri Sarıcı Bir Aktif Kontak Basıncı 0.55
        public decimal? RewinderOneMinimumContactPressure { get; set; }//0.55
        public decimal? RewinderOneMaximumContactPressure { get; set; }//0.55
        public decimal? RewinderOneAverageContactPressure { get; set; }//0.55
        public short? RewinderTwoActiveTension { get; set; }//24
        public short? RewinderTwoMinimumTension { get; set; }//24
        public short? RewinderTwoMaximumTension { get; set; }//28
        public short? RewinderTwoAverageTension { get; set; }//25
        public decimal? RewinderTwoActiveContactPressure { get; set; }//0.55
        public decimal? RewinderTwoMinimumContactPressure { get; set; }//0.55
        public decimal? RewinderTwoMaximumContacPressure { get; set; }//0.55
        public decimal? RewinderTwoAverageContactPressure { get; set; }//0.55
        public short? MachineMinimumSpeed { get; set; }//0
        public short? MachineMaximumSpeed { get; set; }//555
        public short? MachineAverageSpeed { get; set; }//404
        public int? ProductionDuration { get; set; }//810
        public int? DownTimeDuration { get; set; }//91
        public string? FileName { get; set; }//\numpyDB\2023\January\031\numpyfile_8139.npz
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}

