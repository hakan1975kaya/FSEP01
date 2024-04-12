using Business.Abstract.PSI;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.General.General;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.PSI.Telegrams;
using DataAccess.Abstract.PSI.Types;
using Entities.Concrete.Entities.PSI.Telegrams;
using Entities.Concrete.Entities.PSI.Types;
using PSI.Dtos.Telegrams;
using PSI.Dtos.Types;

namespace Business.Concrete.PSI
{
    public class PSIManager : IPSIService
    {
        private IPSIProcessDataPES2L2Dal _psiProcessDataPES2L2Dal;
        private IPSIGeneralAckPES2L2Dal _psiGeneralAckPES2L2Dal;
        private IPSITypeHeaderDal _psiTypeHeaderDal;
        private IPSITypeTimeStampDal _psiTimeStampDal;
        private IPSITypeParameterListDal _psiParameterListDal;
        private IPSITypeProcessInstructionsDal _psiProcessInstructionsDal;
        private IPSITypeMatIdDal _psiMatIdDal;
        private IPSITypeInputMatDal _psiTypeInputMatDal;
        private IPSITypeOutputMatTargetDal _psiTypeOutputMatTargetDal;
        private IPSITypeInputMatCoordDal _psiTypeInputMatCoordDal;
        private IPSITypeDefectListDal _psiTypeDefectListDal;
        public PSIManager(
            IPSIProcessDataPES2L2Dal psiProcessDataPES2L2Dal,
            IPSIGeneralAckPES2L2Dal psiGeneralAckPES2L2Dal,
            IPSITypeHeaderDal psiTypeHeaderDal,
            IPSITypeTimeStampDal psiTimeStampDal,
            IPSITypeParameterListDal psiParameterListDal,
            IPSITypeProcessInstructionsDal psiProcessInstructionsDal,
            IPSITypeMatIdDal psiTypeMatIdDal,
            IPSITypeInputMatDal psiTypeInputMatDal,
            IPSITypeOutputMatTargetDal psiTypeOutputMatTargetDal,
            IPSITypeInputMatCoordDal psiTypeInputMatCoordDal,
            IPSITypeDefectListDal psiTypeDefectListDal)
        {
            _psiProcessDataPES2L2Dal = psiProcessDataPES2L2Dal;
            _psiGeneralAckPES2L2Dal = psiGeneralAckPES2L2Dal;
            _psiTypeHeaderDal = psiTypeHeaderDal;
            _psiTimeStampDal = psiTimeStampDal;
            _psiParameterListDal = psiParameterListDal;
            _psiProcessInstructionsDal = psiProcessInstructionsDal;
            _psiMatIdDal = psiTypeMatIdDal;
            _psiTypeInputMatDal = psiTypeInputMatDal;
            _psiTypeOutputMatTargetDal = psiTypeOutputMatTargetDal;
            _psiTypeInputMatCoordDal = psiTypeInputMatCoordDal;
            _psiTypeDefectListDal = psiTypeDefectListDal;
        }

        [SecurityAspect("PSI.SetGeneralAckPES2L2", Priority = 2)]
        [TransactionAspect(Priority = 3)]
        public async Task<IResult> SetGeneralAckPES2L2(GeneralAckPES2L2 generalAckPES2L2)
        {
            var psiGeneralAckPES2L2Id = Guid.NewGuid();
            var psiTypeHeaderId = Guid.NewGuid();
            var psiTypeTimeSpanId = Guid.NewGuid();

            var psiGeneralAckPES2L2 = new PSIGeneralAckPES2L2
            {
                Id = psiGeneralAckPES2L2Id,
                Header = psiTypeHeaderId,
                AckState = generalAckPES2L2.AckState,
                InfoCode = generalAckPES2L2.InfoCode,
                InfoText = generalAckPES2L2.InfoText,
                TelegramSeqNo = generalAckPES2L2.TelegramSeqNo,
                CountParameter = generalAckPES2L2.CountParameter,
                Optime = DateTime.Now,
                IsActive = true
            };
            await _psiGeneralAckPES2L2Dal.Add(psiGeneralAckPES2L2);

            var setTypeHeaderResult = await SetTypeHeader(generalAckPES2L2.Header, psiTypeHeaderId, psiTypeTimeSpanId);

            return new SuccessResult(PSIMessages.Added);
        }

        [SecurityAspect("PSI.SetProcessDataPES2L2", Priority = 2)]
        [TransactionAspect(Priority = 3)]
        public async Task<IResult> SetProcessDataPES2L2(ProcessDataPES2L2 processDataPES2L2)
        {
            var psiProcessDataPES2L2Id = Guid.NewGuid();
            var psiTypeHeaderId = Guid.NewGuid();
            var psiTypeTimeSpanId = Guid.NewGuid();
            var psiTypeTimeSpanEventTimeId = Guid.NewGuid();

            var psiProcessDataPES2L2 = new PSIProcessDataPES2L2
            {
                Id = psiProcessDataPES2L2Id,
                Header = psiTypeHeaderId,
                EventTime = psiTypeTimeSpanEventTimeId,
                EventCode = processDataPES2L2.EventCode,
                LineId = processDataPES2L2.LineId,
                LineSequenceId = processDataPES2L2.LineSequenceId,
                CountLineSeqParameter = processDataPES2L2.CountLineSeqParameter,
                CountProcessInstructions = processDataPES2L2.CountProcessInstructions,
                Optime = DateTime.Now,
                IsActive = true
            };
            await _psiProcessDataPES2L2Dal.Add(psiProcessDataPES2L2);

            var setTypeHeaderResult = await SetTypeHeader(processDataPES2L2.Header, psiTypeHeaderId, psiTypeTimeSpanId);

            var setTypeTimeStampResult = await SetTypeTimeStamp(processDataPES2L2.EventTime, psiTypeTimeSpanEventTimeId);

            var setTypeParameterListResult = await SetTypeParameterList(processDataPES2L2.LineSeqParameterList, psiProcessDataPES2L2Id);

            var setTypeProcessInstructionsResult = await SetTypeProcessInstructions(processDataPES2L2.ProcessInstructions, psiProcessDataPES2L2Id);

            return new SuccessResult(PSIMessages.Added);
        }
        public async Task<IResult> SetTypeDefectList(List<TypeDefectList> typeDefectLists, Guid? psiTypeDefectActionList = null, Guid? psiTypeInputMat = null, Guid? psiTypeOutputMat = null)
        {
            foreach (var typeDefectList in typeDefectLists)
            {
                var psiTypeDefectListId = Guid.NewGuid();

                var psiTypeDefectList = new PSITypeDefectList
                {
                    Id = psiTypeDefectListId,
                    PSITypeDefectActionList = psiTypeDefectActionList,
                    PSITypeInputMat = psiTypeInputMat,
                    PSITypeOutputMat = psiTypeOutputMat,
                    DefectCode = typeDefectList.DefectCode,
                    DefectBlocking = typeDefectList.DefectBlocking,
                    DefectSeverity = typeDefectList.DefectSeverity,
                    DefectComment = typeDefectList.DefectComment,
                    DefectLengthStartPos = typeDefectList.DefectLengthStartPos,
                    DefectLength = typeDefectList.DefectLength,
                    DefectWidthStartPos = typeDefectList.DefectWidthStartPos,
                    DefectWidth = typeDefectList.DefectWidth,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _psiTypeDefectListDal.Add(psiTypeDefectList);
            }
            return new SuccessResult(PSIMessages.Added);
        }
        public async Task<IResult> SetTypeHeader(TypeHeader typeHeader, Guid psiTypeHeaderId, Guid psiTypeTimeStampId)
        {
            var psiTypeHeader = new PSITypeHeader
            {
                Id = psiTypeHeaderId,
                TelegramType = typeHeader.TelegramType,
                TelegramLength = typeHeader.TelegramLength,
                Sender = typeHeader.Sender,
                Receiver = typeHeader.Receiver,
                TelegramSeqNo = typeHeader.TelegramSeqNo,
                TimeStamp = psiTypeTimeStampId,
                AckReq = typeHeader.AckReq,
                Optime = DateTime.Now,
                IsActive = true
            };
            await _psiTypeHeaderDal.Add(psiTypeHeader);

            var setTypeTimeStampResult = await SetTypeTimeStamp(typeHeader.TimeStamp, psiTypeTimeStampId);

            return new SuccessResult(PSIMessages.Added);
        }
        public async Task<IResult> SetTypeInputMat(TypeInputMat typeInputMat, Guid psiTypeInputMatId, Guid psiTypeMatId, Guid? psiTypeProcessInstructions = null, Guid? psiProdReportL22PES = null)
        {
            var psiTypeInputMat = new PSITypeInputMat
            {
                Id = psiTypeInputMatId,
                PSITypeProcessInstructions = psiTypeProcessInstructions,
                PSIProdReportL22PES = psiProdReportL22PES,
                MatId = psiTypeMatId,
                FlagConsumed = typeInputMat.FlagConsumed,
                UsageOfInput = typeInputMat.UsageOfInput,
                CountInputParameter = typeInputMat.CountInputParameter,
                CountInputDefects = typeInputMat.CountInputDefects,
                Optime = DateTime.Now,
                IsActive = true
            };
            await _psiTypeInputMatDal.Add(psiTypeInputMat);

            var setTypeMatIdResult = await SetTypeMatId(typeInputMat.MatId, psiTypeMatId);

            var setTypeParameterList = await SetTypeParameterList(typeInputMat.ParameterList, null, null, psiTypeInputMatId);

            var setTypeDefectList = await SetTypeDefectList(typeInputMat.InputDefectList, null, psiTypeInputMatId);

            return new SuccessResult(PSIMessages.Added);
        }
        public async Task<IResult> SetTypeInputMatCoords(List<TypeInputMatCoord> typeInputMatCoords, Guid psiTypeOutputMatTarget)
        {
            foreach (var typeInputMatCoord in typeInputMatCoords)
            {
                var typeInputMatCoordId = Guid.NewGuid();
                var matCoord = new PSITypeInputMatCoord
                {
                    Id = typeInputMatCoordId,
                    PSITypeOutputMatTarget = psiTypeOutputMatTarget,
                    OutputMatStartX = typeInputMatCoord.OutputMatStartX,
                    OutputMatEndX = typeInputMatCoord.OutputMatEndX,
                    OutputMatStartY = typeInputMatCoord.OutputMatStartY,
                    OutputMatEndY = typeInputMatCoord.OutputMatEndY,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _psiTypeInputMatCoordDal.Add(matCoord);
            }
            return new SuccessResult(PSIMessages.Added);
        }

        public async Task<IResult> SetTypeMatId(TypeMatId typeMatId, Guid psiTypeMatIdId)
        {
            var psiTypeMatId = new PSITypeMatId
            {
                Id = psiTypeMatIdId,
                GlobalId = typeMatId.GlobalId,
                LocalId = typeMatId.LocalId,
                InternalId = typeMatId.InternalId,
                Optime = DateTime.Now,
                IsActive = true
            };
            await _psiMatIdDal.Add(psiTypeMatId);

            return new SuccessResult(PSIMessages.Added);
        }
        public async Task<IResult> SetTypeOutputMatTarget(List<TypeOutputMatTarget> typeOutputMatTargets, Guid psiTypeMatId, Guid psiTypeIProcessInstructions)
        {
            foreach (var typeOutputMatTarget in typeOutputMatTargets)
            {
                var psiTypeOutputMatTargetId = Guid.NewGuid();

                var outputMatList = new PSITypeOutputMatTarget
                {
                    Id = psiTypeOutputMatTargetId,
                    PSITypeIProcessInstructions = psiTypeIProcessInstructions,
                    MatId = psiTypeMatId,
                    CountOutputParameter = typeOutputMatTarget.CountOutputParameter,
                    CountInputMatRelation = typeOutputMatTarget.CountInputMatRelation,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _psiTypeOutputMatTargetDal.Add(outputMatList);

                var setTypeMatIdResult = await SetTypeMatId(typeOutputMatTarget.MatId, psiTypeMatId);

                var setTypeParameterList = await SetTypeParameterList(typeOutputMatTarget.ParameterList, null, null, null, psiTypeOutputMatTargetId);

                var setTypeInputMatCoords = await SetTypeInputMatCoords(typeOutputMatTarget.MatRelationList, psiTypeOutputMatTargetId);

            }
            return new SuccessResult(PSIMessages.Added);
        }
        public async Task<IResult> SetTypeParameterList(List<TypeParameterList> typeParameterLists, Guid? psiProcessDataPES2L2 = null, Guid? psiProcessStateL22PES = null, Guid? psiTypeInputMat = null, Guid? psiTypeOutputMat = null, Guid? psiTypeProcessInstructions = null, Guid? psiTypeOutputMatTarget = null, Guid? psiGeneralAckPES2L2 = null)
        {
            foreach (var typeParameterList in typeParameterLists)
            {
                var psiTypeParameterListId = Guid.NewGuid();
                var psiTypeTimeStampId = Guid.NewGuid();

                var psiTypeParameterList = new PSITypeParameterList
                {
                    Id = psiTypeParameterListId,
                    PSIProcessDataPES2L2 = psiProcessDataPES2L2,
                    PSIProcessStateL22PES = psiProcessStateL22PES,
                    PSITypeInputMat = psiTypeInputMat,
                    PSITypeOutputMat = psiTypeOutputMat,
                    PSITypeProcessInstructions = psiTypeProcessInstructions,
                    PSITypeOutputMatTarget = psiTypeOutputMatTarget,
                    PSIGeneralAckPES2L2 = psiGeneralAckPES2L2,
                    ParameterName = typeParameterList.ParameterName,
                    ParameterValueString = typeParameterList.ParameterValueString,
                    ParameterValueNumber = typeParameterList.ParameterValueNumber,
                    ParameterDate = psiTypeTimeStampId,
                    UnitOfMeasurement = typeParameterList.UnitOfMeasurement,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _psiParameterListDal.Add(psiTypeParameterList);

                var setTypeTimeStampResult = await SetTypeTimeStamp(typeParameterList.ParameterDate, psiTypeTimeStampId);
            }
            return new SuccessResult(PSIMessages.Added);
        }
        public async Task<IResult> SetTypeProcessInstructions(List<TypeProcessInstructions> typeProcessInstructions, Guid psiProcessDataPES2L2)
        {
            foreach (var typeProcessInstruction in typeProcessInstructions)
            {
                var psiTypeProcessInstructionsId = Guid.NewGuid();
                var psiTypeInputMatId = Guid.NewGuid();
                var psiTypeMatId = Guid.NewGuid();

                var psiTypeProcessInstructions = new PSITypeProcessInstructions
                {
                    Id = psiTypeProcessInstructionsId,
                    PSIProcessDataPES2L2 = psiProcessDataPES2L2,
                    InputMat = psiTypeInputMatId,
                    CountOutputMat = typeProcessInstruction.CountOutputMat,
                    CountProdParameter = typeProcessInstruction.CountProdParameter,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _psiProcessInstructionsDal.Add(psiTypeProcessInstructions);
             
                var setTypeInputMatResult = await SetTypeInputMat(typeProcessInstruction.InputMat, psiTypeInputMatId, psiTypeProcessInstructionsId);

                var setTypeParameterListResult = await SetTypeParameterList(typeProcessInstruction.ProdParameterList, null, null, null, null, psiTypeProcessInstructionsId);

                var setTypeOutputMatTargetResult = await SetTypeOutputMatTarget(typeProcessInstruction.OutputMatList, psiTypeProcessInstructionsId, psiTypeMatId);
            }
            return new SuccessResult(PSIMessages.Added);
        }
        public async Task<IResult> SetTypeTimeStamp(TypeTimeStamp typeTimeStamp, Guid psiTypeTimeStampId)
        {
            var psiTypeTimeStamp = new PSITypeTimeStamp
            {
                Id = psiTypeTimeStampId,
                TimeStamp = typeTimeStamp.TimeStamp,
                Optime = DateTime.Now,
                IsActive = true
            };
            await _psiTimeStampDal.Add(psiTypeTimeStamp);

            return new SuccessResult(PSIMessages.Added);
        }





    }
}
