using Business.Abstract.PLC.Machine;
using Business.BusinessAspect.Autofac;
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
    public class PLCDensityManager : IPLCDensityService
    {
        private IPLCDal _plcDal;
        private IPLCGeneralDal _plcGeneralDal;
        private IPLCDensityDal _plcDensityDal;
        private string _recipeNameLast;
        public PLCDensityManager(IPLCDal plcDal, IPLCGeneralDal plcGeneralDal, IPLCDensityDal plcDensityDal)
        {
            _plcDal = plcDal;
            _plcGeneralDal = plcGeneralDal;
            _plcDensityDal = plcDensityDal;
            _recipeNameLast = (string)_plcDal.Read(DataType.DataBlock, 90, 40, VarType.String, 1);
        }

        //Read Only
        [SecurityAspect("PLCDensity.ReadRewinderOneDensityGraph", Priority = 2)]
        public async Task<IDataResult<int>> ReadRewinderOneDensityGraph()//Name:Rew1DensityGraph,Adress:DB 43 DBW 48,Data Type:Int
        {
            var rewinderOneDensityGraph = (int)_plcDal.Read(DataType.DataBlock, 43, 48, VarType.Int, 1);

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

                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneDensityGraph = rewinderOneDensityGraph,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.RewinderOneDensityGraph = rewinderOneDensityGraph;
                    await _plcDensityDal.Update(plcDensity);
                }
            }
            else
            {
                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneDensityGraph = rewinderOneDensityGraph,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.RewinderOneDensityGraph = rewinderOneDensityGraph;
                    await _plcDensityDal.Update(plcDensity);
                }
            }

            return new SuccessDataResult<int>(rewinderOneDensityGraph, PLCDensityMessages.Read);
        }

        [SecurityAspect("PLCDensity.WriteRewinderOneDensityGraph", Priority = 2)]
        public async Task<IResult> WriteRewinderOneDensityGraph(int rewinderOneDensityGraph)//Name:Rew1DensityGraph,Adress:DB 43 DBW 48,Data Type:Int
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

                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneDensityGraph = rewinderOneDensityGraph,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.RewinderOneDensityGraph = rewinderOneDensityGraph;
                    await _plcDensityDal.Update(plcDensity);
                }
            }
            else
            {
                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneDensityGraph = rewinderOneDensityGraph,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.RewinderOneDensityGraph = rewinderOneDensityGraph;
                    await _plcDensityDal.Update(plcDensity);
                }
            }

            _plcDal.Write(DataType.DataBlock, 43, 48, rewinderOneDensityGraph);
            return new SuccessResult(PLCDensityMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCDensity.ReadRewinderTwoDensityGraph", Priority = 2)]
        public async Task<IDataResult<int>> ReadRewinderTwoDensityGraph()//Name:Rew2DensityGraph,Adress:DB 53 DBW 48,Data Type:Int
        {
            var rewinderTwoDensityGraph = (int)_plcDal.Read(DataType.DataBlock, 53, 48, VarType.Int, 1);

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

                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoDensityGraph = rewinderTwoDensityGraph,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.RewinderTwoDensityGraph = rewinderTwoDensityGraph;
                    await _plcDensityDal.Update(plcDensity);
                }
            }
            else
            {
                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoDensityGraph = rewinderTwoDensityGraph,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.RewinderTwoDensityGraph = rewinderTwoDensityGraph;
                    await _plcDensityDal.Update(plcDensity);
                }
            }

            return new SuccessDataResult<int>(rewinderTwoDensityGraph, PLCDensityMessages.Read);
        }

        [SecurityAspect("PLCDensity.WriteRewinderTwoDensityGraph", Priority = 2)]
        public async Task<IResult> WriteRewinderTwoDensityGraph(int rewinderTwoDensityGraph)//Name:Rew2DensityGraph,Adress:DB 53 DBW 48,Data Type:Int
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

                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoDensityGraph = rewinderTwoDensityGraph,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.RewinderTwoDensityGraph = rewinderTwoDensityGraph;
                    await _plcDensityDal.Update(plcDensity);
                }
            }
            else
            {
                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoDensityGraph = rewinderTwoDensityGraph,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.RewinderTwoDensityGraph = rewinderTwoDensityGraph;
                    await _plcDensityDal.Update(plcDensity);
                }
            }

            _plcDal.Write(DataType.DataBlock, 53, 48, rewinderTwoDensityGraph);
            return new SuccessResult(PLCDensityMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCDensity.ReadMachineSpeedActuelArchive", Priority = 2)]
        public async Task<IDataResult<int>> ReadMachineSpeedActuelArchive()//Name:MachineSpeedActArchive,Adress:DB 304 DBW 20,Data Type:Int
        {
            var machineSpeedActuelArchive = (int)_plcDal.Read(DataType.DataBlock, 304, 20, VarType.Int, 1);

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

                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneralId,
                        MachineSpeedActuelArchive = machineSpeedActuelArchive,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.MachineSpeedActuelArchive = machineSpeedActuelArchive;
                    await _plcDensityDal.Update(plcDensity);
                }
            }
            else
            {
                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneral.Id,
                        MachineSpeedActuelArchive = machineSpeedActuelArchive,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.MachineSpeedActuelArchive = machineSpeedActuelArchive;
                    await _plcDensityDal.Update(plcDensity);
                }
            }

            return new SuccessDataResult<int>(machineSpeedActuelArchive, PLCDensityMessages.Read);
        }

        [SecurityAspect("PLCDensity.WriteMachineSpeedActuelArchive", Priority = 2)]
        public async Task<IResult> WriteMachineSpeedActuelArchive(int machineSpeedActuelArchive)//Name:MachineSpeedActArchive,Adress:DB 304 DBW 20,Data Type:Int
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

                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneralId,
                        MachineSpeedActuelArchive = machineSpeedActuelArchive,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.MachineSpeedActuelArchive = machineSpeedActuelArchive;
                    await _plcDensityDal.Update(plcDensity);
                }
            }
            else
            {
                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneral.Id,
                        MachineSpeedActuelArchive = machineSpeedActuelArchive,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.MachineSpeedActuelArchive = machineSpeedActuelArchive;
                    await _plcDensityDal.Update(plcDensity);
                }
            }

            _plcDal.Write(DataType.DataBlock, 304, 20, machineSpeedActuelArchive);
            return new SuccessResult(PLCDensityMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCDensity.ReadMaterialThickness", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadMaterialThickness()//Name:MaterialThickness,Adress:DB 91 DBW 36,Data Type:Int
        {
            var materialThickness = (decimal)_plcDal.Read(DataType.DataBlock, 91, 36, VarType.Int, 1);

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

                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneralId,
                        MaterialThickness = materialThickness,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.MaterialThickness = materialThickness;
                    await _plcDensityDal.Update(plcDensity);
                }
            }
            else
            {
                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneral.Id,
                        MaterialThickness = materialThickness,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.MaterialThickness = materialThickness;
                    await _plcDensityDal.Update(plcDensity);
                }
            }

            return new SuccessDataResult<decimal>(materialThickness, PLCDensityMessages.Read);
        }

        [SecurityAspect("PLCDensity.WriteMaterialThickness", Priority = 2)]
        public async Task<IResult> WriteMaterialThickness(decimal materialThickness)//Name:MaterialThickness,Adress:DB 91 DBW 36,Data Type:Int
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

                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneralId,
                        MaterialThickness = materialThickness,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.MaterialThickness = materialThickness;
                    await _plcDensityDal.Update(plcDensity);
                }
            }
            else
            {
                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneral.Id,
                        MaterialThickness = materialThickness,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.MaterialThickness = materialThickness;
                    await _plcDensityDal.Update(plcDensity);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 36, materialThickness);
            return new SuccessResult();
        }


        //Read Only
        [SecurityAspect("PLCDensity.ReadRewinderOneDiameterActuel", Priority = 2)]
        public async Task<IDataResult<long>> ReadRewinderOneDiameterActuel()//Name:Rew1DiaAct,Addres:DB 90 DBW 300,Data Type:Int
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

                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneDiameterActuel = rewinderOneDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.RewinderOneDiameterActuel = rewinderOneDiameterActuel;
                    await _plcDensityDal.Update(plcDensity);
                }
            }
            else
            {
                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneDiameterActuel = rewinderOneDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.RewinderOneDiameterActuel = rewinderOneDiameterActuel;
                    await _plcDensityDal.Update(plcDensity);
                }
            }

            return new SuccessDataResult<long>(rewinderOneDiameterActuel, PLCDensityMessages.Read);
        }

        [SecurityAspect("PLCDensity.WriteRewinderOneDiameterActuel", Priority = 2)]
        public async Task<IResult> WriteRewinderOneDiameterActuel(long rewinderOneDiameterActuel)//Name:Rew1DiaAct,Addres:DB 90 DBW 300,Data Type:Int
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

                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneDiameterActuel = rewinderOneDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.RewinderOneDiameterActuel = rewinderOneDiameterActuel;
                    await _plcDensityDal.Update(plcDensity);
                }
            }
            else
            {
                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneDiameterActuel = rewinderOneDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.RewinderOneDiameterActuel = rewinderOneDiameterActuel;
                    await _plcDensityDal.Update(plcDensity);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 300, rewinderOneDiameterActuel);
            return new SuccessResult(PLCDensityMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCDensity.ReadRewinderOneLengthActuel", Priority = 2)]
        public async Task<IDataResult<long>> ReadRewinderOneLengthActuel()//Name:Rew1LengthAct,Adress:DB 90 DBD 306,Data Type:Int
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

                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneLengthActuel = rewinderOneLengthActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.RewinderOneLengthActuel = rewinderOneLengthActuel;
                    await _plcDensityDal.Update(plcDensity);
                }
            }
            else
            {
                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneLengthActuel = rewinderOneLengthActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.RewinderOneLengthActuel = rewinderOneLengthActuel;
                    await _plcDensityDal.Update(plcDensity);
                }
            }

            return new SuccessDataResult<long>(rewinderOneLengthActuel, PLCDensityMessages.Read);
        }

        [SecurityAspect("PLCDensity.WriteRewinderOneLengthActuel", Priority = 2)]
        public async Task<IResult> WriteRewinderOneLengthActuel(long rewinderOneLengthActuel)//Name:Rew1LengthAct,Adress:DB 90 DBD 306,Data Type:Int
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

                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneLengthActuel = rewinderOneLengthActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.RewinderOneLengthActuel = rewinderOneLengthActuel;
                    await _plcDensityDal.Update(plcDensity);
                }
            }
            else
            {
                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneLengthActuel = rewinderOneLengthActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.RewinderOneLengthActuel = rewinderOneLengthActuel;
                    await _plcDensityDal.Update(plcDensity);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 306, rewinderOneLengthActuel);
            return new SuccessResult(PLCDensityMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCDensity.ReadRewinderTwoDiameterActuel", Priority = 2)]
        public async Task<IDataResult<long>> ReadRewinderTwoDiameterActuel()//Name:Rew2DiaAct,Adress:DB 90 DBW 400,Data Type:Int
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

                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoDiameterActuel = rewinderTwoDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.RewinderTwoDiameterActuel = rewinderTwoDiameterActuel;
                    await _plcDensityDal.Update(plcDensity);
                }
            }
            else
            {
                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoDiameterActuel = rewinderTwoDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.RewinderTwoDiameterActuel = rewinderTwoDiameterActuel;
                    await _plcDensityDal.Update(plcDensity);
                }
            }

            return new SuccessDataResult<long>(rewinderTwoDiameterActuel, PLCDensityMessages.Read);
        }

        [SecurityAspect("PLCDensity.WriteRewinderTwoDiameterActuel", Priority = 2)]
        public async Task<IResult> WriteRewinderTwoDiameterActuel(long rewinderTwoDiameterActuel)//Name:Rew2DiaAct,Adress:DB 90 DBW 400,Data Type:Int
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

                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoDiameterActuel = rewinderTwoDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.RewinderTwoDiameterActuel = rewinderTwoDiameterActuel;
                    await _plcDensityDal.Update(plcDensity);
                }
            }
            else
            {
                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoDiameterActuel = rewinderTwoDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.RewinderTwoDiameterActuel = rewinderTwoDiameterActuel;
                    await _plcDensityDal.Update(plcDensity);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 400, rewinderTwoDiameterActuel);
            return new SuccessResult(PLCDensityMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCDensity.ReadRewinderTwoLengthActuel", Priority = 2)]
        public async Task<IDataResult<long>> ReadRewinderTwoLengthActuel()//Name:Rew2LengthAct,Adress:DB 90 DBD 406,Data Type:DInt
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

                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoLengthActuel = rewinderTwoLengthActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.RewinderTwoLengthActuel = rewinderTwoLengthActuel;
                    await _plcDensityDal.Update(plcDensity);
                }
            }
            else
            {
                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoLengthActuel = rewinderTwoLengthActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.RewinderTwoLengthActuel = rewinderTwoLengthActuel;
                    await _plcDensityDal.Update(plcDensity);
                }
            }

            return new SuccessDataResult<long>(rewinderTwoLengthActuel, PLCDensityMessages.Read);
        }

        [SecurityAspect("PLCDensity.WriteRewinderTwoLengthActuel", Priority = 2)]
        public async Task<IResult> WriteRewinderTwoLengthActuel(long rewinderTwoLengthActuel)//Name:Rew2LengthAct,Adress:DB 90 DBD 406,Data Type:DInt
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

                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoLengthActuel = rewinderTwoLengthActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.RewinderTwoLengthActuel = rewinderTwoLengthActuel;
                    await _plcDensityDal.Update(plcDensity);
                }
            }
            else
            {
                var plcDensity = await _plcDensityDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcDensity == null)
                {
                    var plcDensityId = Guid.NewGuid();
                    plcDensity = new PLCDensity
                    {
                        Id = plcDensityId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoLengthActuel = rewinderTwoLengthActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcDensityDal.Add(plcDensity);
                }
                else
                {
                    plcDensity.RewinderTwoLengthActuel = rewinderTwoLengthActuel;
                    await _plcDensityDal.Update(plcDensity);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 406, rewinderTwoLengthActuel);
            return new SuccessResult(PLCDensityMessages.Write);
        }


    }
}
