using Business.Abstract.PLC.Machine;
using Business.Constants.Messages.PLC.Machine;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.PLC.General;
using DataAccess.Abstract.PLC.Machine;
using Entities.Concrete.Entities.PLC.General;
using Entities.Concrete.Entities.PLC.Machine;
using PLC.Abstract;
using S7.Net;

namespace Business.Concrete.PLC.Machine
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class PLCMachineManager : IPLCMachineService
    {
        private IPLCDal _plcDal;
        private IPLCGeneralDal _plcGeneralDal;
        private IPLCMachineDal _plcMachineDal;
        private string _recipeNameLast;
        public PLCMachineManager(IPLCDal plcDal, IPLCGeneralDal plcGeneralDal, IPLCMachineDal plcMachineDal)
        {
            _plcDal = plcDal;
            _plcGeneralDal = plcGeneralDal;
            _plcMachineDal = plcMachineDal;
            _recipeNameLast = (string)_plcDal.Read(DataType.DataBlock, 90, 40, VarType.String, 1);
        }
        public async Task<IDataResult<long>> ReadMachineSpeedSet()//Name:MachineSpeedSet,Addres:DB 91 DBW 2,Data Type:long
        {
            var machineSpeedSet = (long)_plcDal.Read(DataType.DataBlock, 91, 2, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        MachineSpeedSet = machineSpeedSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.MachineSpeedSet = machineSpeedSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        MachineSpeedSet = machineSpeedSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.MachineSpeedSet = machineSpeedSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            return new SuccessDataResult<long>(machineSpeedSet, PLCMachineMessages.Read);
        }
        public async Task<IResult> WriteMachineSpeedSet(long machineSpeedSet)//Name:MachineSpeedSet,Addres:DB 91 DBW 2,Data Type:long
        {
            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        MachineSpeedSet = machineSpeedSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.MachineSpeedSet = machineSpeedSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        MachineSpeedSet = machineSpeedSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.MachineSpeedSet = machineSpeedSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 2, machineSpeedSet);
            return new SuccessResult(PLCMachineMessages.Write);
        }

        public async Task<IDataResult<long>> ReadTransportOneTensionSet()//Name:Transport1TensionSet,Addres:DB 91 DBW 550,Data Type:long
        {
            var transportOneTensionSet = (long)_plcDal.Read(DataType.DataBlock, 91, 550, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        TransportOneTensionSet = transportOneTensionSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.TransportOneTensionSet = transportOneTensionSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        TransportOneTensionSet = transportOneTensionSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.TransportOneTensionSet = transportOneTensionSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            return new SuccessDataResult<long>(transportOneTensionSet, PLCMachineMessages.Read);
        }
        public async Task<IResult> WriteTransportOneTensionSet(long transportOneTensionSet)//Name:Transport1TensionSet,Addres:DB 91 DBW 550,Data Type:long
        {
            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        TransportOneTensionSet = transportOneTensionSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.TransportOneTensionSet = transportOneTensionSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        TransportOneTensionSet = transportOneTensionSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.TransportOneTensionSet = transportOneTensionSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 550, transportOneTensionSet);
            return new SuccessResult(PLCMachineMessages.Write);
        }

        public async Task<IDataResult<long>> ReadTransportTwoTensionSet()//Name:Transport2TensionSet,Addres:DB 91 DBW 560,Data Type:long
        {
            var transportTwoTensionSet = (long)_plcDal.Read(DataType.DataBlock, 91, 560, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        TransportTwoTensionSet = transportTwoTensionSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.TransportTwoTensionSet = transportTwoTensionSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        TransportTwoTensionSet = transportTwoTensionSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.TransportTwoTensionSet = transportTwoTensionSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            return new SuccessDataResult<long>(transportTwoTensionSet, PLCMachineMessages.Read);
        }
        public async Task<IResult> WriteTransportTwoTensionSet(long transportTwoTensionSet)//Name:Transport2TensionSet,Addres:DB 91 DBW 560,Data Type:long
        {
            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        TransportTwoTensionSet = transportTwoTensionSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.TransportTwoTensionSet = transportTwoTensionSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        TransportTwoTensionSet = transportTwoTensionSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.TransportTwoTensionSet = transportTwoTensionSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 560, transportTwoTensionSet);
            return new SuccessResult(PLCMachineMessages.Write);
        }

        public async Task<IDataResult<long>> ReadWeightRewinderOne()//Name:Weight_Rew_1,Addres:DB 1 DBD 2384,Data Type:long
        {
            var weightRewinderOne = (long)_plcDal.Read(DataType.DataBlock, 1, 2384, VarType.Real, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        WeightRewinderOne = weightRewinderOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.WeightRewinderOne = weightRewinderOne;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        WeightRewinderOne = weightRewinderOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.WeightRewinderOne = weightRewinderOne;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            return new SuccessDataResult<long>(weightRewinderOne, PLCMachineMessages.Read);
        }
        public async Task<IResult> WriteWeightRewinderOne(long weightRewinderOne)//Name:Weight_Rew_1,Addres:DB 1 DBD 2384,Data Type:long
        {
            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        WeightRewinderOne = weightRewinderOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.WeightRewinderOne = weightRewinderOne;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        WeightRewinderOne = weightRewinderOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.WeightRewinderOne = weightRewinderOne;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            _plcDal.Write(DataType.DataBlock, 1, 2384, weightRewinderOne);
            return new SuccessResult(PLCMachineMessages.Write);
        }

        public async Task<IDataResult<long>> ReadWeightRewinderTwo()//Name:Weight_Rew_2,Addres:DB 1 DBD 2380,Data Type:long
        {
            var weightRewinderTwo = (long)_plcDal.Read(DataType.DataBlock, 1, 2380, VarType.Real, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        WeightRewinderTwo = weightRewinderTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.WeightRewinderTwo = weightRewinderTwo;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        WeightRewinderTwo = weightRewinderTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.WeightRewinderTwo = weightRewinderTwo;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            return new SuccessDataResult<long>(weightRewinderTwo, PLCMachineMessages.Read);
        }
        public async Task<IResult> WriteWeightRewinderTwo(long weightRewinderTwo)//Name:Weight_Rew_2,Addres:DB 1 DBD 2380,Data Type:long
        {
            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        WeightRewinderTwo = weightRewinderTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.WeightRewinderTwo = weightRewinderTwo;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        WeightRewinderTwo = weightRewinderTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.WeightRewinderTwo = weightRewinderTwo;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            _plcDal.Write(DataType.DataBlock, 1, 2380, weightRewinderTwo);
            return new SuccessResult(PLCMachineMessages.Write);
        }

        public async Task<IDataResult<long>> ReadRewinderOneDiameterSet()//Name:Rew1DiaSet,Addres:DB 91 DBW 300,Data Type:long
        {
            var rewinderOneDiameterSet = (long)_plcDal.Read(DataType.DataBlock, 91, 300, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneDiameterSet = rewinderOneDiameterSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderOneDiameterSet = rewinderOneDiameterSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneDiameterSet = rewinderOneDiameterSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderOneDiameterSet = rewinderOneDiameterSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            return new SuccessDataResult<long>(rewinderOneDiameterSet, PLCMachineMessages.Read);
        }
        public async Task<IResult> WriteRewinderOneDiameterSet(long rewinderOneDiameterSet)//Name:Rew1DiaSet,Addres:DB 91 DBW 300,Data Type:long
        {
            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneDiameterSet = rewinderOneDiameterSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderOneDiameterSet = rewinderOneDiameterSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneDiameterSet = rewinderOneDiameterSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderOneDiameterSet = rewinderOneDiameterSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 300, rewinderOneDiameterSet);
            return new SuccessResult(PLCMachineMessages.Write);
        }

        //Read Only
        public async Task<IDataResult<long>> ReadRewinderOneDiameterActuel()//Name:Rew1DiaAct,Adress:DB 90 DBW 300,Data Type:long
        {
            var rewinderOneDiameterActuel = (long)_plcDal.Read(DataType.DataBlock, 90, 300, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneDiameterActuel = rewinderOneDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderOneDiameterActuel = rewinderOneDiameterActuel;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneDiameterActuel = rewinderOneDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderOneDiameterActuel = rewinderOneDiameterActuel;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            return new SuccessDataResult<long>(rewinderOneDiameterActuel, PLCMachineMessages.Read);
        }
        public async Task<IResult> WriteRewinderOneDiameterActuel(long rewinderOneDiameterActuel)//Name:Rew1DiaAct,Adress:DB 90 DBW 300,Data Type:long
        {
            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneDiameterActuel = rewinderOneDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderOneDiameterActuel = rewinderOneDiameterActuel;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneDiameterActuel = rewinderOneDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderOneDiameterActuel = rewinderOneDiameterActuel;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 300, rewinderOneDiameterActuel);
            return new SuccessResult(PLCMachineMessages.Write);
        }

        public async Task<IDataResult<long>> ReadRewinderOneLengthSet()//Name:Rew1LengthSet,Addres:DB 91 DBD 306,Data Type:Dlong
        {
            var rewinderOneLengthSet = (long)_plcDal.Read(DataType.DataBlock, 91, 306, VarType.DInt, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneLengthSet = rewinderOneLengthSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderOneLengthSet = rewinderOneLengthSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneLengthSet = rewinderOneLengthSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderOneLengthSet = rewinderOneLengthSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            return new SuccessDataResult<long>(rewinderOneLengthSet, PLCMachineMessages.Read);
        }
        public async Task<IResult> WriteRewinderOneLengthSet(long rewinderOneLengthSet)//Name:Rew1LengthSet,Addres:DB 91 DBD 306,Data Type:Dlong
        {
            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneLengthSet = rewinderOneLengthSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderOneLengthSet = rewinderOneLengthSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneLengthSet = rewinderOneLengthSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderOneLengthSet = rewinderOneLengthSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 306, rewinderOneLengthSet);
            return new SuccessResult(PLCMachineMessages.Write);
        }

        //Read Only
        public async Task<IDataResult<long>> ReadRewinderOneLengthActuel()//Name:Rew1LengthAct,Addres:DB 90 DBD 306,Data Type:DInt
        {
            var rewinderOneLengthActuel = (long)_plcDal.Read(DataType.DataBlock, 90, 306, VarType.DInt, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneLengthActuel = rewinderOneLengthActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderOneLengthActuel = rewinderOneLengthActuel;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneLengthActuel = rewinderOneLengthActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderOneLengthActuel = rewinderOneLengthActuel;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            return new SuccessDataResult<long>(rewinderOneLengthActuel, PLCMachineMessages.Read);
        }
        public async Task<IResult> WriteRewinderOneLengthActuel(long rewinderOneLengthActuel)//Name:Rew1LengthAct,Addres:DB 90 DBD 306,Data Type:Dlong
        {
            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneLengthActuel = rewinderOneLengthActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderOneLengthActuel = rewinderOneLengthActuel;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneLengthActuel = rewinderOneLengthActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderOneLengthActuel = rewinderOneLengthActuel;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 306, rewinderOneLengthActuel);
            return new SuccessResult(PLCMachineMessages.Write);
        }

        public async Task<IDataResult<long>> ReadRewinderTwoDiameterSet()//Name:Rew1DiaSet,Addres:DB 91 DBW 400,Data Type:long
        {
            var rewinderTwoDiameterSet = (long)_plcDal.Read(DataType.DataBlock, 91, 400, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoDiameterSet = rewinderTwoDiameterSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderTwoDiameterSet = rewinderTwoDiameterSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoDiameterSet = rewinderTwoDiameterSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderTwoDiameterSet = rewinderTwoDiameterSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            return new SuccessDataResult<long>(rewinderTwoDiameterSet, PLCMachineMessages.Read);
        }
        public async Task<IResult> WriteRewinderTwoDiameterSet(long rewinderTwoDiameterSet)//Name:Rew1DiaSet,Addres:DB 91 DBW 400,Data Type:long
        {
            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoDiameterSet = rewinderTwoDiameterSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderTwoDiameterSet = rewinderTwoDiameterSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoDiameterSet = rewinderTwoDiameterSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderTwoDiameterSet = rewinderTwoDiameterSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 400, rewinderTwoDiameterSet);
            return new SuccessResult(PLCMachineMessages.Write);
        }

        //Read Only
        public async Task<IDataResult<long>> ReadRewinderTwoDiameterActuel()//Name:Rew1DiaAct,Addres:DB 90 DBW 400,Data Type:long
        {
            var rewinderTwoDiameterActuel = (long)_plcDal.Read(DataType.DataBlock, 90, 400, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoDiameterActuel = rewinderTwoDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderTwoDiameterActuel = rewinderTwoDiameterActuel;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoDiameterActuel = rewinderTwoDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderTwoDiameterActuel = rewinderTwoDiameterActuel;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            return new SuccessDataResult<long>(rewinderTwoDiameterActuel, PLCMachineMessages.Read);
        }
        public async Task<IResult> WriteRewinderTwoDiameterActuel(long rewinderTwoDiameterActuel)//Name:Rew1DiaAct,Addres:DB 90 DBW 400,Data Type:long
        {
            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoDiameterActuel = rewinderTwoDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderTwoDiameterActuel = rewinderTwoDiameterActuel;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoDiameterActuel = rewinderTwoDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderTwoDiameterActuel = rewinderTwoDiameterActuel;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 400, rewinderTwoDiameterActuel);
            return new SuccessResult(PLCMachineMessages.Write);
        }

        public async Task<IDataResult<long>> ReadRewinderTwoLengthSet()//Name:Rew1LengthSet,Addres:DB 91 DBD 406,Data Type:Dlong
        {
            var rewinderTwoLengthSet = (long)_plcDal.Read(DataType.DataBlock, 91, 406, VarType.DInt, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoLengthSet = rewinderTwoLengthSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderTwoLengthSet = rewinderTwoLengthSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoLengthSet = rewinderTwoLengthSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderTwoLengthSet = rewinderTwoLengthSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            return new SuccessDataResult<long>(rewinderTwoLengthSet, PLCMachineMessages.Read);
        }
        public async Task<IResult> WriteRewinderTwoLengthSet(long rewinderTwoLengthSet)//Name:Rew1LengthSet,Addres:DB 91 DBD 406,Data Type:Dlong
        {
            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoLengthSet = rewinderTwoLengthSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderTwoLengthSet = rewinderTwoLengthSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoLengthSet = rewinderTwoLengthSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderTwoLengthSet = rewinderTwoLengthSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 406, rewinderTwoLengthSet);
            return new SuccessResult(PLCMachineMessages.Write);
        }

        //Read Only
        public async Task<IDataResult<long>> ReadRewinderTwoLengthActuel()//Name:Rew2LengthAct,Addres:DB 90 DBD 406,Data Type:Dlong
        {
            var rewinderTwoLengthActuel = (long)_plcDal.Read(DataType.DataBlock, 90, 406, VarType.DInt, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoLengthActuel = rewinderTwoLengthActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderTwoLengthActuel = rewinderTwoLengthActuel;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoLengthActuel = rewinderTwoLengthActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderTwoLengthActuel = rewinderTwoLengthActuel;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            return new SuccessDataResult<long>(rewinderTwoLengthActuel, PLCMachineMessages.Read);
        }
        public async Task<IResult> WriteRewinderTwoLengthActuel(long rewinderTwoLengthActuel)//Name:Rew2LengthAct,Addres:DB 90 DBD 406,Data Type:Dlong
        {
            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoLengthActuel = rewinderTwoLengthActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderTwoLengthActuel = rewinderTwoLengthActuel;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoLengthActuel = rewinderTwoLengthActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderTwoLengthActuel = rewinderTwoLengthActuel;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 406, rewinderTwoLengthActuel);
            return new SuccessResult(PLCMachineMessages.Write);
        }

        public async Task<IDataResult<long>> ReadUnwinderOneDiameterSet()//Name:Unw1DiaSet,Addres:DB 91 DBW 100,Data Type:long
        {
            var unwinderOneDiameterSet = (long)_plcDal.Read(DataType.DataBlock, 91, 100, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        UnwinderOneDiameterSet = unwinderOneDiameterSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.UnwinderOneDiameterSet = unwinderOneDiameterSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        UnwinderOneDiameterSet = unwinderOneDiameterSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.UnwinderOneDiameterSet = unwinderOneDiameterSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            return new SuccessDataResult<long>(unwinderOneDiameterSet, PLCMachineMessages.Read);
        }
        public async Task<IResult> WriteUnwinderOneDiameterSet(long unwinderOneDiameterSet)//Name:Unw1DiaSet,Addres:DB 91 DBW 100,Data Type:long
        {
            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        UnwinderOneDiameterSet = unwinderOneDiameterSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.UnwinderOneDiameterSet = unwinderOneDiameterSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        UnwinderOneDiameterSet = unwinderOneDiameterSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.UnwinderOneDiameterSet = unwinderOneDiameterSet;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 100, unwinderOneDiameterSet);
            return new SuccessResult(PLCMachineMessages.Write);
        }

        //Read Only
        public async Task<IDataResult<long>> ReadUnwinderOneDiameterActuel()//Name:Unw1DiaAct,Addres:DB 90 DBW 100,Data Type:long
        {
            var unwinderOneDiameterActuel = (long)_plcDal.Read(DataType.DataBlock, 90, 100, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        UnwinderOneDiameterActuel = unwinderOneDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.UnwinderOneDiameterActuel = unwinderOneDiameterActuel;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        UnwinderOneDiameterActuel = unwinderOneDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.UnwinderOneDiameterActuel = unwinderOneDiameterActuel;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            return new SuccessDataResult<long>(unwinderOneDiameterActuel, PLCMachineMessages.Read);
        }
        public async Task<IResult> WriteUnwinderOneDiameterActuel(long unwinderOneDiameterActuel)//Name:Unw1DiaAct,Addres:DB 90 DBW 100,Data Type:long
        {
            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        UnwinderOneDiameterActuel = unwinderOneDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.UnwinderOneDiameterActuel = unwinderOneDiameterActuel;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        UnwinderOneDiameterActuel = unwinderOneDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.UnwinderOneDiameterActuel = unwinderOneDiameterActuel;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 100, unwinderOneDiameterActuel);
            return new SuccessResult(PLCMachineMessages.Write);
        }

        public async Task<IDataResult<bool>> ReadRewinderOneResetLength()//Name:MachineFunctFlag1,Adress:DB 91 DBW 28,Data Type:Int,ResetLength:91.28.2
        {
            var rewinderOneResetLength = (bool)_plcDal.Read(DataType.DataBlock, 91, 28, VarType.Bit, 1, 2);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneResetLength = rewinderOneResetLength,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderOneResetLength = rewinderOneResetLength;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneResetLength = rewinderOneResetLength,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderOneResetLength = rewinderOneResetLength;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            return new SuccessDataResult<bool>(rewinderOneResetLength, PLCMachineMessages.Read);
        }
        public async Task<IResult> WriteRewinderOneResetLength(bool rewinderOneResetLength)//Name:MachineFunctFlag1,Adress:DB 91 DBW 28,Data Type:Int,ResetLength:91.28.2
        {
            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneResetLength = rewinderOneResetLength,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderOneResetLength = rewinderOneResetLength;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneResetLength = rewinderOneResetLength,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderOneResetLength = rewinderOneResetLength;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 28, rewinderOneResetLength, 2);
            return new SuccessResult(PLCMachineMessages.Write);
        }

        public async Task<IDataResult<bool>> ReadRewinderTwoResetLength()//Name:MachineFunctFlag1,Adress:DB 91 DBW 28,Data Type:Int,ResetLength:91.28.3
        {
            var rewinderTwoResetLength = (bool)_plcDal.Read(DataType.DataBlock, 91, 28, VarType.Bit, 1, 3);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoResetLength = rewinderTwoResetLength,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderTwoResetLength = rewinderTwoResetLength;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoResetLength = rewinderTwoResetLength,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderTwoResetLength = rewinderTwoResetLength;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            return new SuccessDataResult<bool>(rewinderTwoResetLength, PLCMachineMessages.Read);
        }
        public async Task<IResult> WriteRewinderTwoResetLength(bool rewinderTwoResetLength)//Name:MachineFunctFlag1,Adress:DB 91 DBW 28,Data Type:Int,ResetLength:91.28.3
        {
            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoResetLength = rewinderTwoResetLength,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderTwoResetLength = rewinderTwoResetLength;
                    await _plcMachineDal.Update(plcMachine);
                }
            }
            else
            {
                var plcMachine = await _plcMachineDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachine == null)
                {
                    var plcMachineId = Guid.NewGuid();
                    plcMachine = new PLCMachine
                    {
                        Id = plcMachineId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoResetLength = rewinderTwoResetLength,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineDal.Add(plcMachine);
                }
                else
                {
                    plcMachine.RewinderTwoResetLength = rewinderTwoResetLength;
                    await _plcMachineDal.Update(plcMachine);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 28, rewinderTwoResetLength, 3);
            return new SuccessResult(PLCMachineMessages.Write);
        }


    }
}
