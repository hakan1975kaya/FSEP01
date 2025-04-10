﻿using Core.Utilities.Results.Abstract;
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

        public Task<IDataResult<int>> ReadRewinderTwoDensityGraph();
        public Task<IResult> WriteRewinderTwoDensityGraph(int rewinderTwoDensityGraph);

        public Task<IDataResult<int>> ReadMachineSpeedActuelArchive();
        public Task<IResult> WriteMachineSpeedActuelArchive(int machineSpeedActuelArchiv);

        public Task<IDataResult<decimal>> ReadMaterialThickness();
        public Task<IResult> WriteMaterialThickness(decimal materialThickness);

        public Task<IDataResult<long>> ReadRewinderOneDiameterActuel();
        public Task<IResult> WriteRewinderOneDiameterActuel(long rewinderOneDiameterActuel);

        public Task<IDataResult<long>> ReadRewinderOneLengthActuel();
        public Task<IResult> WriteRewinderOneLengthActuel(long rewinderOneLengthActuel);

        public Task<IDataResult<long>> ReadRewinderTwoDiameterActuel();
        public Task<IResult> WriteRewinderTwoDiameterActuel(long rewinderTwoDiameterActuel);

        public Task<IDataResult<long>> ReadRewinderTwoLengthActuel();
        public Task<IResult> WriteRewinderTwoLengthActuel(long rewinderTwoLengthActuel);
    }
}
