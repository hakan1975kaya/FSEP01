using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.PLC.Machine
{
    public interface IPLCDensityService
    {
        public Task<IDataResult<int>> ReadRewinderOneDensityGraph();
        public Task<IResult> WriteRewinderOneDensityGraph(int rewinderOneDensityGraph);

        public Task<IDataResult<int>> ReadMachineSpeedActArchive();
        public Task<IResult> WriteMachineSpeedActArchive(int machineSpeedActArchive);

        public Task<IDataResult<int>> ReadRewinderTwoDensityGraph();
        public Task<IResult> WriteRewinderTwoDensityGraph(int rewinderTwoDensityGraph);

        public Task<IDataResult<int>> ReadRewinderOneDiameterActuel();
        public Task<IResult> WriteRewinderOneDiameterActuel(int rewinderOneDiameterActuel);

        public Task<IDataResult<int>> ReadRewinderOneLengthActuel();
        public Task<IResult> WriteRewinderOneLengthActuel(int rewinderOneLengthActuel);

        public Task<IDataResult<int>> ReadRewinderTwoDiameterActuel();
        public Task<IResult> WriteRewinderTwoDiameterActuel(int rewinderTwoDiameterActuel);

        public Task<IDataResult<long>> ReadRewinderTwoLengthActuel();
        public Task<IResult> WriteRewinderTwoLengthActuel(long rewinderTwoLengthActuel);
    }
}
