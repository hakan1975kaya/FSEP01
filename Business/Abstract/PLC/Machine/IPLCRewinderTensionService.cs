using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.PLC.Machine
{
    public interface IPLCRewinderTensionService
    {
        public Task<IDataResult<decimal>> ReadRewinderOneTensionSetScaled();
        public Task<IResult> WriteRewinderOneTensionSetScaled(decimal rewinderOneTensionSetScale);

        public Task<IDataResult<decimal>> ReadRewinderOneTensionCalculateCharScaled();
        public Task<IResult> WriteRewinderOneTensionCalculateCharScaled(decimal rewinderOneTensionCalculateCharScaled);

        public Task<IDataResult<decimal>> ReadRewinderOneTensionActuelMeasureScaled();
        public Task<IResult> WriteRewinderOneTensionActuelMeasureScaled(decimal rewinderOneTensionActuelMeasureScaled);

        public Task<IDataResult<decimal>> ReadRewinderOneTensionCalculateCharNewton();
        public Task<IResult> WriteRewinderOneTensionCalculateCharNewton(decimal rewinderOneTensionCalculateCharNewton);

        public Task<IDataResult<decimal>> ReadRewinderOneTensionActuelMeasureNewton();
        public Task<IResult> WriteRewinderOneTensionActuelMeasureNewton(decimal rewinderOneTensionActuelMeasureNewton);

        public Task<IDataResult<decimal>> ReadRewinderOneTensionContactSetScaled();
        public Task<IResult> WriteRewinderOneTensionContactSetScaled(decimal rewinderOneTensionContactSetScaled);

        public Task<IDataResult<int>> ReadRewinderOneMaterialWidth();
        public Task<IResult> WriteRewinderOneMaterialWidth(int rewinderOneMaterialWidth);

        public Task<IDataResult<decimal>> ReadRewinderOneShaft();
        public Task<IResult> WriteRewinderOneShaft(decimal rewinderOneShaft);

        public Task<IDataResult<decimal>> ReadRewinderTwoTensionContactSetScaled();
        public Task<IResult> WriteRewinderTwoTensionContactSetScaled(decimal rewinderTwoTensionContactSetScaled);

        public Task<IDataResult<decimal>> ReadRewinderTwoTensionSetScaled();
        public Task<IResult> WriteRewinderTwoTensionSetScaled(decimal rewinderTwoTensionSetScaled);

        public Task<IDataResult<decimal>> ReadRewinderTwoTensionCalculeteCharScaled();
        public Task<IResult> WriteRewinderTwoTensionCalculeteCharScaled(decimal rewinderTwoTensionCalculeteCharScaled);

        public Task<IDataResult<decimal>> ReadRewinderTwoTensionActuelMeasureScaled();
        public Task<IResult> WriteRewinderTwoTensionActuelMeasureScaled(decimal rewinderTwoTensionActuelMeasureScaled);

        public Task<IDataResult<decimal>> ReadRewinderTwoTensionCalculateCharNewton();
        public Task<IResult> WriteRewinderTwoTensionCalculateCharNewton(decimal rewinderTwoTensionCalculateCharNewton);

        public Task<IDataResult<decimal>> ReadRewinderTwoTensionActuelMeasureNewton();
        public Task<IResult> WriteRewinderTwoTensionActuelMeasureNewton(decimal rewinderTwoTensionActuelMeasureNewton);

        public Task<IDataResult<decimal>> ReadRewinderTwoMaterialWidth();
        public Task<IResult> WriteRewinderTwoMaterialWidth(decimal rewinderTwoMaterialWidth);

        public Task<IDataResult<decimal>> ReadRewinderTwoShaft();
        public Task<IResult> WriteRewinderTwoShaft(decimal rewinderTwoShaft);

    }
}
