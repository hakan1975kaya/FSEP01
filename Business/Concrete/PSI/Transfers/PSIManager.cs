using Business.Abstract.PSI.Transfers;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.PSI.Telegrams;
using Business.Constants.Messages.PSI.Types;
using Business.Validators.FluentValidators.PSI.Transfers;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.PSI.Telegrams;
using DataAccess.Abstract.PSI.Types;
using Entities.Concrete.Dtos.PSI.Types;
using Entities.Concrete.Entities.PSI.Telegrams;
using Entities.Concrete.Entities.PSI.Types;
using PSI.Dtos.Telegrams;
using PSI.Validators.FluentValidators.Telegrams.GeneralAckPES2L2Validators;
using PSI.Validators.FluentValidators.Telegrams.PSIProcessDataPES2L2Validators;

namespace Business.Concrete.PSI.Transfers
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
        [ValidationAspect(typeof(GeneralAckPES2L2Validator), Priority = 3)]
        [TransactionAspect(Priority = 4)]
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

            var setTypeHeaderDto = new SetTypeHeaderDto
            {
                typeHeader = generalAckPES2L2.Header,
                psiTypeHeaderId = psiTypeHeaderId,
                psiTypeTimeStampId = psiTypeTimeSpanId
            };
            var setTypeHeaderResult = await SetTypeHeader(setTypeHeaderDto);

            return new SuccessResult(PSIGeneralAckPES2L2Messages.Added);
        }

        [SecurityAspect("PSI.SetProcessDataPES2L2", Priority = 2)]
        [ValidationAspect(typeof(ProcessDataPES2L2Validator), Priority = 3)]
        [TransactionAspect(Priority = 4)]
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

            var setTypeHeaderDto = new SetTypeHeaderDto
            {
                typeHeader = processDataPES2L2.Header,
                psiTypeHeaderId = psiTypeHeaderId,
                psiTypeTimeStampId = psiTypeTimeSpanId
            };
            var setTypeHeaderResult = await SetTypeHeader(setTypeHeaderDto);

            var setTypeTimeStampDto = new SetTypeTimeStampDto
            {
                typeTimeStamp = processDataPES2L2.EventTime,
                psiTypeTimeStampId = psiTypeTimeSpanEventTimeId
            };
            var setTypeTimeStampResult = await SetTypeTimeStamp(setTypeTimeStampDto);


            var setTypeParameterListDto = new SetTypeParameterListDto
            {
                typeParameterLists = processDataPES2L2.LineSeqParameterList,
                psiProcessDataPES2L2 = psiProcessDataPES2L2Id
            };
            var setTypeParameterListResult = await SetTypeParameterList(setTypeParameterListDto);

            var setTypeProcessInstructionsDto = new SetTypeProcessInstructionsDto
            {
                typeProcessInstructions = processDataPES2L2.ProcessInstructions,
                psiProcessDataPES2L2 = psiProcessDataPES2L2Id
            };
            var setTypeProcessInstructionsResult = await SetTypeProcessInstructions(setTypeProcessInstructionsDto);

            return new SuccessResult(PSIProcessDataPES2L2Messages.Added);
        }

        [SecurityAspect("PSI.SetTypeDefectList", Priority = 2)]
        [ValidationAspect(typeof(SetTypeDefectListDtoValidator), Priority = 3)]
        [TransactionAspect(Priority = 4)]
        public async Task<IResult> SetTypeDefectList(SetTypeDefectListDto setTypeDefectListDto)
        {
            foreach (var typeDefectList in setTypeDefectListDto.typeDefectLists)
            {
                var psiTypeDefectListId = Guid.NewGuid();

                var psiTypeDefectList = new PSITypeDefectList
                {
                    Id = psiTypeDefectListId,
                    PSITypeDefectActionList = setTypeDefectListDto.psiTypeDefectActionList,
                    PSITypeInputMat = setTypeDefectListDto.psiTypeInputMat,
                    PSITypeOutputMat = setTypeDefectListDto.psiTypeOutputMat,
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
            return new SuccessResult(PSITypeDefectListMessages.Added);
        }

        [SecurityAspect("PSI.SetTypeHeader", Priority = 2)]
        [ValidationAspect(typeof(SetTypeHeaderDtoValidator), Priority = 3)]
        [TransactionAspect(Priority = 4)]
        public async Task<IResult> SetTypeHeader(SetTypeHeaderDto setTypeHeaderDto)
        {
            var psiTypeHeader = new PSITypeHeader
            {
                Id = setTypeHeaderDto.psiTypeHeaderId,
                TelegramType = setTypeHeaderDto.typeHeader.TelegramType,
                TelegramLength = setTypeHeaderDto.typeHeader.TelegramLength,
                Sender = setTypeHeaderDto.typeHeader.Sender,
                Receiver = setTypeHeaderDto.typeHeader.Receiver,
                TelegramSeqNo = setTypeHeaderDto.typeHeader.TelegramSeqNo,
                TimeStamp = setTypeHeaderDto.psiTypeTimeStampId,
                AckReq = setTypeHeaderDto.typeHeader.AckReq,
                Optime = DateTime.Now,
                IsActive = true
            };
            await _psiTypeHeaderDal.Add(psiTypeHeader);

            var setTypeTimeStampDto = new SetTypeTimeStampDto
            {
                typeTimeStamp = setTypeHeaderDto.typeHeader.TimeStamp,
                psiTypeTimeStampId = setTypeHeaderDto.psiTypeTimeStampId
            };
            var setTypeTimeStampResult = await SetTypeTimeStamp(setTypeTimeStampDto);

            return new SuccessResult(PSITypeHeaderMessages.Added);
        }

        [SecurityAspect("PSI.SetTypeInputMat", Priority = 2)]
        [ValidationAspect(typeof(SetTypeInputMatDtoValidator), Priority = 3)]
        [TransactionAspect(Priority = 4)]
        public async Task<IResult> SetTypeInputMat(SetTypeInputMatDto setTypeInputMatDto)
        {
            var psiTypeInputMat = new PSITypeInputMat
            {
                Id = setTypeInputMatDto.psiTypeInputMatId,
                PSITypeProcessInstructions = setTypeInputMatDto.psiTypeProcessInstructions,
                PSIProdReportL22PES = setTypeInputMatDto.psiProdReportL22PES,
                MatId = setTypeInputMatDto.psiTypeMatId,
                FlagConsumed = setTypeInputMatDto.typeInputMat.FlagConsumed,
                UsageOfInput = setTypeInputMatDto.typeInputMat.UsageOfInput,
                CountInputParameter = setTypeInputMatDto.typeInputMat.CountInputParameter,
                CountInputDefects = setTypeInputMatDto.typeInputMat.CountInputDefects,
                Optime = DateTime.Now,
                IsActive = true
            };
            await _psiTypeInputMatDal.Add(psiTypeInputMat);

            var setTypeMatIdDto = new SetTypeMatIdDto
            {
                typeMatId = setTypeInputMatDto.typeInputMat.MatId,
                psiTypeMatIdId = setTypeInputMatDto.psiTypeMatId
            };
            var setTypeMatIdResult = await SetTypeMatId(setTypeMatIdDto);

            var setTypeParameterListDto = new SetTypeParameterListDto
            {
                typeParameterLists = setTypeInputMatDto.typeInputMat.ParameterList,
                psiTypeInputMat = setTypeInputMatDto.psiTypeInputMatId
            };
            var setTypeParameterList = await SetTypeParameterList(setTypeParameterListDto);

            var setTypeDefectListDto = new SetTypeDefectListDto
            {
                typeDefectLists = setTypeInputMatDto.typeInputMat.InputDefectList,
                psiTypeInputMat = setTypeInputMatDto.psiTypeInputMatId
            };
            var setTypeDefectList = await SetTypeDefectList(setTypeDefectListDto);

            return new SuccessResult(PSITypeInputMatMessages.Added);
        }


        [SecurityAspect("PSI.SetTypeInputMatCoords", Priority = 2)]
        [ValidationAspect(typeof(SetTypeInputMatCoordsDtoValidator), Priority = 3)]
        [TransactionAspect(Priority = 4)]
        public async Task<IResult> SetTypeInputMatCoords(SetTypeInputMatCoordsDto setTypeInputMatCoordsDto)
        {
            foreach (var typeInputMatCoord in setTypeInputMatCoordsDto.typeInputMatCoords)
            {
                var typeInputMatCoordId = Guid.NewGuid();
                var matCoord = new PSITypeInputMatCoord
                {
                    Id = typeInputMatCoordId,
                    PSITypeOutputMatTarget = setTypeInputMatCoordsDto.psiTypeOutputMatTarget,
                    OutputMatStartX = typeInputMatCoord.OutputMatStartX,
                    OutputMatEndX = typeInputMatCoord.OutputMatEndX,
                    OutputMatStartY = typeInputMatCoord.OutputMatStartY,
                    OutputMatEndY = typeInputMatCoord.OutputMatEndY,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _psiTypeInputMatCoordDal.Add(matCoord);
            }
            return new SuccessResult(PSITypeInputMatCoordMessages.Added);
        }

        [SecurityAspect("PSI.SetTypeMatId", Priority = 2)]
        [ValidationAspect(typeof(SetTypeMatIdDtoValidator), Priority = 3)]
        [TransactionAspect(Priority = 4)]
        public async Task<IResult> SetTypeMatId(SetTypeMatIdDto setTypeMatIdDto)
        {
            var psiTypeMatId = new PSITypeMatId
            {
                Id = setTypeMatIdDto.psiTypeMatIdId,
                GlobalId = setTypeMatIdDto.typeMatId.GlobalId,
                LocalId = setTypeMatIdDto.typeMatId.LocalId,
                InternalId = setTypeMatIdDto.typeMatId.InternalId,
                Optime = DateTime.Now,
                IsActive = true
            };
            await _psiMatIdDal.Add(psiTypeMatId);

            return new SuccessResult(PSITypeMatIdMessages.Added);
        }

        [SecurityAspect("PSI.SetTypeOutputMatTarget", Priority = 2)]
        [ValidationAspect(typeof(SetTypeOutputMatTargetDtoValidator), Priority = 3)]
        [TransactionAspect(Priority = 4)]
        public async Task<IResult> SetTypeOutputMatTarget(SetTypeOutputMatTargetDto setTypeOutputMatTargetDto)
        {
            foreach (var typeOutputMatTarget in setTypeOutputMatTargetDto.typeOutputMatTargets)
            {
                var psiTypeOutputMatTargetId = Guid.NewGuid();

                var outputMatList = new PSITypeOutputMatTarget
                {
                    Id = psiTypeOutputMatTargetId,
                    PSITypeIProcessInstructions = setTypeOutputMatTargetDto.psiTypeIProcessInstructions,
                    MatId = setTypeOutputMatTargetDto.psiTypeMatId,
                    CountOutputParameter = typeOutputMatTarget.CountOutputParameter,
                    CountInputMatRelation = typeOutputMatTarget.CountInputMatRelation,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _psiTypeOutputMatTargetDal.Add(outputMatList);

                var setTypeMatIdDto = new SetTypeMatIdDto
                {
                    typeMatId = typeOutputMatTarget.MatId,
                    psiTypeMatIdId = setTypeOutputMatTargetDto.psiTypeMatId
                };
                var setTypeMatIdResult = await SetTypeMatId(setTypeMatIdDto);

                var setTypeParameterListDto = new SetTypeParameterListDto
                {
                    typeParameterLists = typeOutputMatTarget.ParameterList,
                    psiTypeOutputMatTarget = psiTypeOutputMatTargetId
                };
                var setTypeParameterList = await SetTypeParameterList(setTypeParameterListDto);

                var setTypeInputMatCoordsDto = new SetTypeInputMatCoordsDto
                {
                    typeInputMatCoords = typeOutputMatTarget.MatRelationList,
                    psiTypeOutputMatTarget = psiTypeOutputMatTargetId
                };
                var setTypeInputMatCoords = await SetTypeInputMatCoords(setTypeInputMatCoordsDto);

            }
            return new SuccessResult(PSITypeOutputMatTargetMessages.Added);
        }

        [SecurityAspect("PSI.SetTypeParameterList", Priority = 2)]
        [ValidationAspect(typeof(SetTypeParameterListDtoValidator), Priority = 3)]
        [TransactionAspect(Priority = 4)]
        public async Task<IResult> SetTypeParameterList(SetTypeParameterListDto setTypeParameterListDto)
        {
            foreach (var typeParameterList in setTypeParameterListDto.typeParameterLists)
            {
                var psiTypeParameterListId = Guid.NewGuid();
                var psiTypeTimeStampId = Guid.NewGuid();

                var psiTypeParameterList = new PSITypeParameterList
                {
                    Id = psiTypeParameterListId,
                    PSIProcessDataPES2L2 = setTypeParameterListDto.psiProcessDataPES2L2,
                    PSIProcessStateL22PES = setTypeParameterListDto.psiProcessStateL22PES,
                    PSITypeInputMat = setTypeParameterListDto.psiTypeInputMat,
                    PSITypeOutputMat = setTypeParameterListDto.psiTypeOutputMat,
                    PSITypeProcessInstructions = setTypeParameterListDto.psiTypeProcessInstructions,
                    PSITypeOutputMatTarget = setTypeParameterListDto.psiTypeOutputMatTarget,
                    PSIGeneralAckPES2L2 = setTypeParameterListDto.psiGeneralAckPES2L2,
                    ParameterName = typeParameterList.ParameterName,
                    ParameterValueString = typeParameterList.ParameterValueString,
                    ParameterValueNumber = typeParameterList.ParameterValueNumber,
                    ParameterDate = psiTypeTimeStampId,
                    UnitOfMeasurement = typeParameterList.UnitOfMeasurement,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _psiParameterListDal.Add(psiTypeParameterList);

                var setTypeTimeStampDto = new SetTypeTimeStampDto
                {
                    typeTimeStamp = typeParameterList.ParameterDate,
                    psiTypeTimeStampId = psiTypeTimeStampId
                };
                var setTypeTimeStampResult = await SetTypeTimeStamp(setTypeTimeStampDto);
            }
            return new SuccessResult(PSITypeParameterListMessages.Added);
        }

        [SecurityAspect("PSI.SetTypeProcessInstructions", Priority = 2)]
        [ValidationAspect(typeof(SetTypeProcessInstructionsDtoValidator), Priority = 3)]
        [TransactionAspect(Priority = 4)]
        public async Task<IResult> SetTypeProcessInstructions(SetTypeProcessInstructionsDto setTypeProcessInstructionsDto)
        {
            foreach (var typeProcessInstruction in setTypeProcessInstructionsDto.typeProcessInstructions)
            {
                var psiTypeProcessInstructionsId = Guid.NewGuid();
                var psiTypeInputMatId = Guid.NewGuid();
                var psiTypeMatId = Guid.NewGuid();

                var psiTypeProcessInstructions = new PSITypeProcessInstructions
                {
                    Id = psiTypeProcessInstructionsId,
                    PSIProcessDataPES2L2 = setTypeProcessInstructionsDto.psiProcessDataPES2L2,
                    InputMat = psiTypeInputMatId,
                    CountOutputMat = typeProcessInstruction.CountOutputMat,
                    CountProdParameter = typeProcessInstruction.CountProdParameter,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _psiProcessInstructionsDal.Add(psiTypeProcessInstructions);

                var setTypeInputMatDto = new SetTypeInputMatDto
                {
                    typeInputMat = typeProcessInstruction.InputMat,
                    psiTypeInputMatId = psiTypeInputMatId,
                    psiTypeProcessInstructions = psiTypeProcessInstructionsId
                };
                var setTypeInputMatResult = await SetTypeInputMat(setTypeInputMatDto);

                var setTypeParameterListDto = new SetTypeParameterListDto
                {
                    typeParameterLists = typeProcessInstruction.ProdParameterList,
                    psiTypeProcessInstructions = psiTypeProcessInstructionsId
                };
                var setTypeParameterListResult = await SetTypeParameterList(setTypeParameterListDto);

                var setTypeOutputMatTargetDto = new SetTypeOutputMatTargetDto
                {
                    typeOutputMatTargets = typeProcessInstruction.OutputMatList,
                    psiTypeMatId = psiTypeMatId,
                    psiTypeIProcessInstructions = psiTypeProcessInstructionsId
                };
                var setTypeOutputMatTargetResult = await SetTypeOutputMatTarget(setTypeOutputMatTargetDto);
            }
            return new SuccessResult(PSITypeProcessInstructionsMessages.Added);
        }

        [SecurityAspect("PSI.SetTypeTimeStampDto", Priority = 2)]
        [ValidationAspect(typeof(SetTypeTimeStampDtoValidator), Priority = 3)]
        [TransactionAspect(Priority = 4)]
        public async Task<IResult> SetTypeTimeStamp(SetTypeTimeStampDto setTypeTimeStampDto)
        {
            var psiTypeTimeStamp = new PSITypeTimeStamp
            {
                Id = setTypeTimeStampDto.psiTypeTimeStampId,
                TimeStamp = setTypeTimeStampDto.typeTimeStamp.TimeStamp,
                Optime = DateTime.Now,
                IsActive = true
            };
            await _psiTimeStampDal.Add(psiTypeTimeStamp);

            return new SuccessResult(PSITypeTimeStampMessages.Added);
        }





    }
}
