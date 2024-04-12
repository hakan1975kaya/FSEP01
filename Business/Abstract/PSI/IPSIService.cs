using Core.Utilities.Results.Abstract;
using PSI.Dtos.Telegrams;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.PSI
{
    public interface IPSIService
    {
        public Task<IResult> SetProcessDataPES2L2(ProcessDataPES2L2 processDataPES2L2);
        public Task<IResult> SetTypeHeader(TypeHeader typeHeader, Guid psiHeaderId, Guid psiTimeStampId);
        public Task<IResult> SetTypeTimeStamp(TypeTimeStamp typeTimeStamp, Guid psiTimeStampId);
        public Task<IResult> SetTypeParameterList(List<TypeParameterList> typeParameterLists, Guid? psiProcessDataPES2L2 = null, Guid? psiProcessStateL22PES = null, Guid? psiTypeInputMat = null, Guid? psiTypeOutputMat = null, Guid? psiTypeProcessInstructions = null, Guid? psiTypeOutputMatTarget = null, Guid? psiGeneralAckPES2L2 = null);
        public Task<IResult> SetTypeProcessInstructions(List<TypeProcessInstructions> typeProcessInstructions,Guid psiProcessDataPES2L2);
        public Task<IResult> SetTypeInputMat(TypeInputMat typeInputMat, Guid psiInputMatId, Guid psiMatId, Guid? psiTypeProcessInstructions = null, Guid? psiProdReportL22PES = null);
        public Task<IResult> SetTypeOutputMatTarget(List<TypeOutputMatTarget> typeOutputMatTargets,  Guid psiMatId, Guid psiTypeIProcessInstructions);
        public Task<IResult> SetTypeMatId(TypeMatId typeMatId, Guid psiTypeMatIdId);
        public Task<IResult> SetTypeDefectList(List<TypeDefectList> typeDefectLists, Guid? psiTypeDefectActionList = null, Guid? psiTypeInputMat = null, Guid? psiTypeOutputMat = null);
        public Task<IResult> SetTypeInputMatCoords(List<TypeInputMatCoord> typeInputMatCoords, Guid psiTypeOutputMatTarget);

    }
}
