using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.PSI.Types;
using PSI.Dtos.Telegrams;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.PSI.Transfers
{
    public interface IPSIService
    {
        public Task<IResult> SetProcessDataPES2L2(ProcessDataPES2L2 processDataPES2L2);
        public Task<IResult> SetGeneralAckPES2L2(GeneralAckPES2L2 generalAckPES2L2);
        public Task<IResult> SetTypeHeader(SetTypeHeaderDto setTypeHeaderDto);
        public Task<IResult> SetTypeTimeStamp(SetTypeTimeStampDto setTypeTimeStampDto);
        public Task<IResult> SetTypeParameterList(SetTypeParameterListDto setTypeParameterListDto );
        public Task<IResult> SetTypeProcessInstructions(SetTypeProcessInstructionsDto setTypeProcessInstructionsDto);
        public Task<IResult> SetTypeInputMat(SetTypeInputMatDto setTypeInputMatDto);
        public Task<IResult> SetTypeOutputMatTarget(SetTypeOutputMatTargetDto setTypeOutputMatTargetDto);
        public Task<IResult> SetTypeMatId(SetTypeMatIdDto setTypeMatIdDto);
        public Task<IResult> SetTypeDefectList(SetTypeDefectListDto setTypeDefectListDto);
        public Task<IResult> SetTypeInputMatCoords(SetTypeInputMatCoordsDto setTypeInputMatCoordsDto);

    }
}
