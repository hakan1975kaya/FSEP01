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
        public Task<IResult> WriteRewinderOneTensionSetScaled(decimal rewinderOneTensionSetScaled);

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

        public Task<IDataResult<short>> ReadRewinderOneMaterialWidth();
        public Task<IResult> WriteRewinderOneMaterialWidth(short rewinderOneMaterialWidth);

        public Task<IDataResult<short>> ReadRewinderOneShaft();
        public Task<IResult> WriteRewinderOneShaft(short rewinderOneShaft);

        public Task<IDataResult<decimal>> ReadRewinderTwoTensionContactSetScaled();
        public Task<IResult> WriteRewinderTwoTensionContactSetScaled(decimal rewinderTwoTensionContactSetScaled);

        public Task<IDataResult<decimal>> ReadRewinderTwoTensionSetScaled();
        public Task<IResult> WriteRewinderTwoTensionSetScaled(decimal rewinderTwoTensionSetScaled);

        public Task<IDataResult<decimal>> ReadRewinderTwoTensionCalculeteCharScaled();
        public Task<IResult> WriteRewinderTwoTensionCalculeteCharScaled(decimal rewinderTwoTensionCalculeteCharScaled);

        public Task<IDataResult<decimal>> ReadRewinderTwoTensionActuelMeasureScaled();
        public Task<IResult> WriteRewinderTwoTensionActuelMeasureScaled(decimal rewinderTwoTensionActuelMeasureScaled);

        public Task<IDataResult<short>> ReadRewinderTwoTensionCalculateCharNewton();
        public Task<IResult> WriteRewinderTwoTensionCalculateCharNewton(short rewinderTwoTensionCalculateCharNewton);

        public Task<IDataResult<short>> ReadRewinderTwoTensionActuelMeasureNewton();
        public Task<IResult> WriteRewinderTwoTensionActuelMeasureNewton(short rewinderTwoTensionActuelMeasureNewton);

        public Task<IDataResult<short>> ReadRewinderTwoMaterialWidth();
        public Task<IResult> WriteRewinderTwoMaterialWidth(short rewinderTwoMaterialWidth);

        public Task<IDataResult<short>> ReadRewinderTwoShaft();
        public Task<IResult> WriteRewinderTwoShaft(short rewinderTwoShaft);

    }
}
