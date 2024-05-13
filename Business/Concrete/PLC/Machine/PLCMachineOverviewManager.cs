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

namespace Business.Concrete.PLC.MachineOverview
{

    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class PLCMachineOverviewManager : IPLCMachineOverviewService
    {
        private IPLCDal _plcDal;
        private IPLCGeneralDal _plcGeneralDal;
        private IPLCMachineOverviewDal _plcMachineOverviewDal;
        private string _recipeNameLast;
        public PLCMachineOverviewManager(IPLCDal plcDal, IPLCGeneralDal plcGeneralDal, IPLCMachineOverviewDal plcMachineOverviewDal)
        {
            _plcDal = plcDal;
            _plcGeneralDal = plcGeneralDal;
            _plcMachineOverviewDal = plcMachineOverviewDal;
            _recipeNameLast = (string)_plcDal.Read(DataType.DataBlock, 90, 40, VarType.String, 1);
        }

        //Read Only
        [SecurityAspect("PLCMachineOverview.ReadUnwinderOneDiameterActuel", Priority = 2)]
        public async Task<IDataResult<long>> ReadUnwinderOneDiameterActuel()//Name:Unw1DiaAct,Adress:DB 90 DBW 100,Data Type:Int
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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        UnwinderOneDiameterActuel = unwinderOneDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.UnwinderOneDiameterActuel = unwinderOneDiameterActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        UnwinderOneDiameterActuel = unwinderOneDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.UnwinderOneDiameterActuel = unwinderOneDiameterActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            return new SuccessDataResult<long>(unwinderOneDiameterActuel, PLCMachineOverviewMessages.Read);
        }

        [SecurityAspect("PLCMachineOverview.WriteUnwinderOneDiameterActuel", Priority = 2)]
        public async Task<IResult> WriteUnwinderOneDiameterActuel(long unwinderOneDiameterActuel)//Name:Unw1DiaAct,Adress:DB 90 DBW 100,Data Type:Int
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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        UnwinderOneDiameterActuel = unwinderOneDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.UnwinderOneDiameterActuel = unwinderOneDiameterActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        UnwinderOneDiameterActuel = unwinderOneDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.UnwinderOneDiameterActuel = unwinderOneDiameterActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 100, unwinderOneDiameterActuel);
            return new SuccessResult(PLCMachineOverviewMessages.Write);
        }

        //Read Only
        [SecurityAspect("PLCMachineOverview.ReadTransportOneTensionSet", Priority = 2)]
        public async Task<IDataResult<long>> ReadTransportOneTensionSet()//Name:Transport1TensionSet,Adress:DB 91 DBW 550,Data Type:Int
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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        TransportOneTensionSet = transportOneTensionSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.TransportOneTensionSet = transportOneTensionSet;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        TransportOneTensionSet = transportOneTensionSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.TransportOneTensionSet = transportOneTensionSet;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            return new SuccessDataResult<long>(transportOneTensionSet, PLCMachineOverviewMessages.Read);
        }

        [SecurityAspect("PLCMachineOverview.WriteTransportOneTensionSet", Priority = 2)]
        public async Task<IResult> WriteTransportOneTensionSet(long transportOneTensionSet)//Name:Transport1TensionSet,Adress:DB 91 DBW 550,Data Type:Int
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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        TransportOneTensionSet = transportOneTensionSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.TransportOneTensionSet = transportOneTensionSet;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        TransportOneTensionSet = transportOneTensionSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.TransportOneTensionSet = transportOneTensionSet;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 550, transportOneTensionSet);
            return new SuccessResult(PLCMachineOverviewMessages.Write);
        }

        //Read Only
        [SecurityAspect("PLCMachineOverview.ReadTransportTwoTensionSet", Priority = 2)]
        public async Task<IDataResult<long>> ReadTransportTwoTensionSet()//Name:Transport2TensionSet,Adress:DB 91 DBW 560,Data Type:Int
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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        TransportTwoTensionSet = transportTwoTensionSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.TransportTwoTensionSet = transportTwoTensionSet;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        TransportTwoTensionSet = transportTwoTensionSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.TransportTwoTensionSet = transportTwoTensionSet;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            return new SuccessDataResult<long>(transportTwoTensionSet, PLCMachineOverviewMessages.Read);
        }

        [SecurityAspect("PLCMachineOverview.WriteTransportTwoTensionSet", Priority = 2)]
        public async Task<IResult> WriteTransportTwoTensionSet(long transportTwoTensionSet)///Name:Transport2TensionSet,Adress:DB 91 DBW 560,Data Type:Int
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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        TransportTwoTensionSet = transportTwoTensionSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.TransportTwoTensionSet = transportTwoTensionSet;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        TransportTwoTensionSet = transportTwoTensionSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.TransportTwoTensionSet = transportTwoTensionSet;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 560, transportTwoTensionSet);
            return new SuccessResult(PLCMachineOverviewMessages.Write);
        }

        //Read Only
        [SecurityAspect("PLCMachineOverview.ReadRewinderOneTensionLaySetScaled", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderOneTensionLaySetScaled()//Name:Rew1TensionLaySetScaled,Addres:DB 91 DBW 372,Data Type:Int
        {
            var rewinderOneTensionLaySetScaled = (decimal)_plcDal.Read(DataType.DataBlock, 91, 372, VarType.Int, 1);

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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneTensionLaySetScaled = rewinderOneTensionLaySetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderOneTensionLaySetScaled = rewinderOneTensionLaySetScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneTensionLaySetScaled = rewinderOneTensionLaySetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderOneTensionLaySetScaled = rewinderOneTensionLaySetScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            return new SuccessDataResult<decimal>(rewinderOneTensionLaySetScaled, PLCMachineOverviewMessages.Read);
        }

        [SecurityAspect("PLCMachineOverview.WriteRewinderOneTensionLaySetScaled", Priority = 2)]
        public async Task<IResult> WriteRewinderOneTensionLaySetScaled(decimal rewinderOneTensionLaySetScaled)//Name:Rew1TensionLaySetScaled,Addres:DB 91 DBW 372,Data Type:Int
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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneTensionLaySetScaled = rewinderOneTensionLaySetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderOneTensionLaySetScaled = rewinderOneTensionLaySetScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneTensionLaySetScaled = rewinderOneTensionLaySetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderOneTensionLaySetScaled = rewinderOneTensionLaySetScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 372, rewinderOneTensionLaySetScaled);
            return new SuccessResult(PLCMachineOverviewMessages.Write);
        }

        //Read Only
        [SecurityAspect("PLCMachineOverview.ReadRewinderOneTensionCalculateCharScaled", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderOneTensionCalculateCharScaled()//Name:Rew1TensionCalcCharScaled,Addres:DB 90 DBW 316,Data Type:Int
        {
            var rewinderOneTensionCalculateCharScaled = (decimal)_plcDal.Read(DataType.DataBlock, 90, 316, VarType.Int, 1);

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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneTensionCalculateCharScaled = rewinderOneTensionCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderOneTensionCalculateCharScaled = rewinderOneTensionCalculateCharScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneTensionCalculateCharScaled = rewinderOneTensionCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderOneTensionCalculateCharScaled = rewinderOneTensionCalculateCharScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            return new SuccessDataResult<decimal>(rewinderOneTensionCalculateCharScaled, PLCMachineOverviewMessages.Read);
        }

        [SecurityAspect("PLCMachineOverview.WriteRewinderOneTensionCalculateCharScaled", Priority = 2)]
        public async Task<IResult> WriteRewinderOneTensionCalculateCharScaled(decimal rewinderOneTensionCalculateCharScaled)//Name:Rew1TensionCalcCharScaled,Addres:DB 90 DBW 316,Data Type:Int
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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneTensionCalculateCharScaled = rewinderOneTensionCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderOneTensionCalculateCharScaled = rewinderOneTensionCalculateCharScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneTensionCalculateCharScaled = rewinderOneTensionCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderOneTensionCalculateCharScaled = rewinderOneTensionCalculateCharScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 316, rewinderOneTensionCalculateCharScaled);
            return new SuccessResult(PLCMachineOverviewMessages.Write);
        }

        //Read Only
        [SecurityAspect("PLCMachineOverview.ReadRewinderOneLengthActuel", Priority = 2)]
        public async Task<IDataResult<long>> ReadRewinderOneLengthActuel()//Name:Rew1LengthAct,Adress:DB 90 DBD 306,Data Type:Int
        {
            var rewinderOneLengthActuel = (long)_plcDal.Read(DataType.DataBlock, 90, 306, VarType.Int, 1);

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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneLengthActuel = rewinderOneLengthActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderOneLengthActuel = rewinderOneLengthActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneLengthActuel = rewinderOneLengthActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderOneLengthActuel = rewinderOneLengthActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            return new SuccessDataResult<long>(rewinderOneLengthActuel, PLCMachineOverviewMessages.Read);
        }

        [SecurityAspect("PLCMachineOverview.WriteRewinderOneLengthActuel", Priority = 2)]
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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneLengthActuel = rewinderOneLengthActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderOneLengthActuel = rewinderOneLengthActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneLengthActuel = rewinderOneLengthActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderOneLengthActuel = rewinderOneLengthActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 306, rewinderOneLengthActuel);
            return new SuccessResult(PLCMachineOverviewMessages.Write);
        }

        //Read Only
        [SecurityAspect("PLCMachineOverview.ReadRewinderOneDiameterActuel", Priority = 2)]
        public async Task<IDataResult<long>> ReadRewinderOneDiameterActuel()//Name:Rew1DiaAct,Adress:DB 90 DBW 300,Data Type:Int
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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneDiameterActuel = rewinderOneDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderOneDiameterActuel = rewinderOneDiameterActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneDiameterActuel = rewinderOneDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderOneDiameterActuel = rewinderOneDiameterActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            return new SuccessDataResult<long>(rewinderOneDiameterActuel, PLCMachineOverviewMessages.Read);
        }

        [SecurityAspect("PLCMachineOverview.WriteRewinderOneDiameterActuel", Priority = 2)]
        public async Task<IResult> WriteRewinderOneDiameterActuel(long rewinderOneDiameterActuel)//Name:Rew1DiaAct,Adress:DB 90 DBW 300,Data Type:Int
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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneDiameterActuel = rewinderOneDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderOneDiameterActuel = rewinderOneDiameterActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneDiameterActuel = rewinderOneDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderOneDiameterActuel = rewinderOneDiameterActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 300, rewinderOneDiameterActuel);
            return new SuccessResult(PLCMachineOverviewMessages.Write);
        }

        //Read Only
        [SecurityAspect("PLCMachineOverview.ReadContactOneTensionActuel", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadContactOneTensionActuel()//Name:Cont1TensionAct,Addres:DB 90 DBW 580,Data Type:Int
        {
            var contactOneTensionActuel = (decimal)_plcDal.Read(DataType.DataBlock, 90, 580, VarType.Int, 1);

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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        ContactOneTensionActuel = contactOneTensionActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.ContactOneTensionActuel = contactOneTensionActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        ContactOneTensionActuel = contactOneTensionActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.ContactOneTensionActuel = contactOneTensionActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            return new SuccessDataResult<decimal>(contactOneTensionActuel, PLCMachineOverviewMessages.Read);
        }

        [SecurityAspect("PLCMachineOverview.WriteContactOneTensionActuel", Priority = 2)]
        public async Task<IResult> WriteContactOneTensionActuel(decimal contactOneTensionActuel)//Name:Cont1TensionAct,Addres:DB 90 DBW 580,Data Type:Int
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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        ContactOneTensionActuel = contactOneTensionActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.ContactOneTensionActuel = contactOneTensionActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        ContactOneTensionActuel = contactOneTensionActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.ContactOneTensionActuel = contactOneTensionActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 580, contactOneTensionActuel);
            return new SuccessResult(PLCMachineOverviewMessages.Write);
        }

        //Read Only
        [SecurityAspect("PLCMachineOverview.ReadContactTwoTensionActuel", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadContactTwoTensionActuel()//Name:Cont2TensionAct,Addres:DB 90 DBW 590,Data Type:Int
        {
            var contactTwoTensionActuel = (decimal)_plcDal.Read(DataType.DataBlock, 90, 590, VarType.Int, 1);

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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        ContactTwoTensionActuel = contactTwoTensionActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.ContactTwoTensionActuel = contactTwoTensionActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        ContactTwoTensionActuel = contactTwoTensionActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.ContactTwoTensionActuel = contactTwoTensionActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            return new SuccessDataResult<decimal>(contactTwoTensionActuel, PLCMachineOverviewMessages.Read);
        }

        [SecurityAspect("PLCMachineOverview.WriteContactTwoTensionActuel", Priority = 2)]
        public async Task<IResult> WriteContactTwoTensionActuel(decimal contactTwoTensionActuel)//Name:Cont2TensionAct,Addres:DB 90 DBW 590,Data Type:Int
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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        ContactTwoTensionActuel = contactTwoTensionActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.ContactTwoTensionActuel = contactTwoTensionActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        ContactTwoTensionActuel = contactTwoTensionActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.ContactTwoTensionActuel = contactTwoTensionActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 590, contactTwoTensionActuel);
            return new SuccessResult(PLCMachineOverviewMessages.Write);
        }

        //Read Only
        [SecurityAspect("PLCMachineOverview.ReadRewinderTwoTensionCalculateCharScaled", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderTwoTensionCalculateCharScaled()//Name:Rew2TensionCalcCharScaled,Adress:DB 90 DBW 416,Data Type:Int
        {
            var rewinderTwoTensionCalculateCharScaled = (decimal)_plcDal.Read(DataType.DataBlock, 90, 416, VarType.Int, 1);

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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoTensionCalculateCharScaled = rewinderTwoTensionCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderTwoTensionCalculateCharScaled = rewinderTwoTensionCalculateCharScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoTensionCalculateCharScaled = rewinderTwoTensionCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderTwoTensionCalculateCharScaled = rewinderTwoTensionCalculateCharScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            return new SuccessDataResult<decimal>(rewinderTwoTensionCalculateCharScaled, PLCMachineOverviewMessages.Read);
        }

        [SecurityAspect("PLCMachineOverview.WriteRewinderTwoTensionCalculateCharScaled", Priority = 2)]
        public async Task<IResult> WriteRewinderTwoTensionCalculateCharScaled(decimal rewinderTwoTensionCalculateCharScaled)//Name:Rew2TensionCalcCharScaled,Adress:DB 90 DBW 416,Data Type:Int
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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoTensionCalculateCharScaled = rewinderTwoTensionCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderTwoTensionCalculateCharScaled = rewinderTwoTensionCalculateCharScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoTensionCalculateCharScaled = rewinderTwoTensionCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderTwoTensionCalculateCharScaled = rewinderTwoTensionCalculateCharScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 416, rewinderTwoTensionCalculateCharScaled);
            return new SuccessResult(PLCMachineOverviewMessages.Write);
        }

        //Read Only
        [SecurityAspect("PLCMachineOverview.ReadRewinderTwoLengthActuel", Priority = 2)]
        public async Task<IDataResult<long>> ReadRewinderTwoLengthActuel()//Name:Rew2LengthAct,Adress:DB 90 DBD 406,Data Type:Int
        {
            var rewinderTwoLengthActuel = (long)_plcDal.Read(DataType.DataBlock, 90, 406, VarType.Int, 1);

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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoLengthActuel = rewinderTwoLengthActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderTwoLengthActuel = rewinderTwoLengthActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoLengthActuel = rewinderTwoLengthActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderTwoLengthActuel = rewinderTwoLengthActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            return new SuccessDataResult<long>(rewinderTwoLengthActuel, PLCMachineOverviewMessages.Read);
        }

        [SecurityAspect("PLCMachineOverview.WriteRewinderTwoLengthActuel", Priority = 2)]
        public async Task<IResult> WriteRewinderTwoLengthActuel(long rewinderTwoLengthActuel)//Name:Rew2LengthAct,Adress:DB 90 DBD 406,Data Type:Int
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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoLengthActuel = rewinderTwoLengthActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderTwoLengthActuel = rewinderTwoLengthActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoLengthActuel = rewinderTwoLengthActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderTwoLengthActuel = rewinderTwoLengthActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 406, rewinderTwoLengthActuel);
            return new SuccessResult(PLCMachineOverviewMessages.Write);
        }

        //Read Only
        [SecurityAspect("PLCMachineOverview.ReadRewinderTwoDiameterActuel", Priority = 2)]
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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoDiameterActuel = rewinderTwoDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderTwoDiameterActuel = rewinderTwoDiameterActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoDiameterActuel = rewinderTwoDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderTwoDiameterActuel = rewinderTwoDiameterActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            return new SuccessDataResult<long>(rewinderTwoDiameterActuel, PLCMachineOverviewMessages.Read);
        }

        [SecurityAspect("PLCMachineOverview.WriteRewinderTwoDiameterActuel", Priority = 2)]
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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoDiameterActuel = rewinderTwoDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderTwoDiameterActuel = rewinderTwoDiameterActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoDiameterActuel = rewinderTwoDiameterActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderTwoDiameterActuel = rewinderTwoDiameterActuel;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 400, rewinderTwoDiameterActuel);
            return new SuccessResult(PLCMachineOverviewMessages.Write);
        }

        //Read Only
        [SecurityAspect("PLCMachineOverview.ReadRewinderTwoTensionSupportSetScaled", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderTwoTensionSupportSetScaled()//Name:Rew2TensionSupSetScaled,Addres:DB 91 DBW 472,Data Type:Int
        {
            var rewinderTwoTensionSupportSetScaled = (decimal)_plcDal.Read(DataType.DataBlock, 91, 472, VarType.Int, 1);

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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoTensionSupportSetScaled = rewinderTwoTensionSupportSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderTwoTensionSupportSetScaled = rewinderTwoTensionSupportSetScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoTensionSupportSetScaled = rewinderTwoTensionSupportSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderTwoTensionSupportSetScaled = rewinderTwoTensionSupportSetScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            return new SuccessDataResult<decimal>(rewinderTwoTensionSupportSetScaled, PLCMachineOverviewMessages.Read);
        }

        [SecurityAspect("PLCMachineOverview.WriteRewinderTwoTensionSupportSetScaled", Priority = 2)]
        public async Task<IResult> WriteRewinderTwoTensionSupportSetScaled(decimal rewinderTwoTensionSupportSetScaled)//Name:Rew2TensionSupSetScaled,Addres:DB 91 DBW 472,Data Type:Int
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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoTensionSupportSetScaled = rewinderTwoTensionSupportSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderTwoTensionSupportSetScaled = rewinderTwoTensionSupportSetScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoTensionSupportSetScaled = rewinderTwoTensionSupportSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderTwoTensionSupportSetScaled = rewinderTwoTensionSupportSetScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 472, rewinderTwoTensionSupportSetScaled);
            return new SuccessResult(PLCMachineOverviewMessages.Write);
        }

        //Read Only
        [SecurityAspect("PLCMachineOverview.ReadRewinderOnePressureLayCalculateCharScaled", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderOnePressureLayCalculateCharScaled()//Name:Rew1PresLayCalcCharScaled,Adress:DB 90 DBW 356,Data Type:I
        {
            var rewinderOnePressureLayCalculateCharScaled = (decimal)_plcDal.Read(DataType.DataBlock, 90, 356, VarType.Int, 1);

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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOnePressureLayCalculateCharScaled = rewinderOnePressureLayCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderOnePressureLayCalculateCharScaled = rewinderOnePressureLayCalculateCharScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOnePressureLayCalculateCharScaled = rewinderOnePressureLayCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderOnePressureLayCalculateCharScaled = rewinderOnePressureLayCalculateCharScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            return new SuccessDataResult<decimal>(rewinderOnePressureLayCalculateCharScaled, PLCMachineOverviewMessages.Read);
        }

        [SecurityAspect("PLCMachineOverview.WriteRewinderOnePressureLayCalculateCharScaled", Priority = 2)]
        public async Task<IResult> WriteRewinderOnePressureLayCalculateCharScaled(decimal rewinderOnePressureLayCalculateCharScaled)//Name:Rew1PresLayCalcCharScaled,Adress:DB 90 DBW 356,Data Type:I
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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOnePressureLayCalculateCharScaled = rewinderOnePressureLayCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderOnePressureLayCalculateCharScaled = rewinderOnePressureLayCalculateCharScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOnePressureLayCalculateCharScaled = rewinderOnePressureLayCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderOnePressureLayCalculateCharScaled = rewinderOnePressureLayCalculateCharScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 356, rewinderOnePressureLayCalculateCharScaled);
            return new SuccessResult(PLCMachineOverviewMessages.Write);
        }

        //Read Only
        [SecurityAspect("PLCMachineOverview.ReadRewinderOnePressureContactCalculateCharScaled", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderOnePressureContactCalculateCharScaled()//Name:Rew1PresContCalcCharScaled,Adress:DB 90 DBW 326,Data Type:Int
        {
            var rewinderOnePressureContactCalculateCharScaled = (decimal)_plcDal.Read(DataType.DataBlock, 90, 326, VarType.Int, 1);

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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOnePressureContactCalculateCharScaled = rewinderOnePressureContactCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderOnePressureContactCalculateCharScaled = rewinderOnePressureContactCalculateCharScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOnePressureContactCalculateCharScaled = rewinderOnePressureContactCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderOnePressureContactCalculateCharScaled = rewinderOnePressureContactCalculateCharScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            return new SuccessDataResult<decimal>(rewinderOnePressureContactCalculateCharScaled, PLCMachineOverviewMessages.Read);
        }

        [SecurityAspect("PLCMachineOverview.WriteRewinderOnePressureContactCalculateCharScaled", Priority = 2)]
        public async Task<IResult> WriteRewinderOnePressureContactCalculateCharScaled(decimal rewinderOnePressureContactCalculateCharScaled)//Name:Rew1PresContCalcCharScaled,Adress:DB 90 DBW 326,Data Type:Int
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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOnePressureContactCalculateCharScaled = rewinderOnePressureContactCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderOnePressureContactCalculateCharScaled = rewinderOnePressureContactCalculateCharScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOnePressureContactCalculateCharScaled = rewinderOnePressureContactCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderOnePressureContactCalculateCharScaled = rewinderOnePressureContactCalculateCharScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 326, rewinderOnePressureContactCalculateCharScaled);
            return new SuccessResult(PLCMachineOverviewMessages.Write);
        }

        //Read Only
        [SecurityAspect("PLCMachineOverview.ReadRewinderTwoPressureContactCalculateCharScaled", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderTwoPressureContactCalculateCharScaled()//Name:Rew2PresContCalcCharScaled,Adress:DB 90 DBW 426,Data Type:Int
        {
            var rewinderTwoPressureContactCalculateCharScaled = (decimal)_plcDal.Read(DataType.DataBlock, 90, 426, VarType.Int, 1);

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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoPressureContactCalculateCharScaled = rewinderTwoPressureContactCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderTwoPressureContactCalculateCharScaled = rewinderTwoPressureContactCalculateCharScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoPressureContactCalculateCharScaled = rewinderTwoPressureContactCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderTwoPressureContactCalculateCharScaled = rewinderTwoPressureContactCalculateCharScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            return new SuccessDataResult<decimal>(rewinderTwoPressureContactCalculateCharScaled, PLCMachineOverviewMessages.Read);
        }

        [SecurityAspect("PLCMachineOverview.WriteRewinderTwoPressureContactCalculateCharScaled", Priority = 2)]
        public async Task<IResult> WriteRewinderTwoPressureContactCalculateCharScaled(decimal rewinderTwoPressureContactCalculateCharScaled)//Name:Rew2PresContCalcCharScaled,Adress:DB 90 DBW 426,Data Type:Int
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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoPressureContactCalculateCharScaled = rewinderTwoPressureContactCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderTwoPressureContactCalculateCharScaled = rewinderTwoPressureContactCalculateCharScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoPressureContactCalculateCharScaled = rewinderTwoPressureContactCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderTwoPressureContactCalculateCharScaled = rewinderTwoPressureContactCalculateCharScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 426, rewinderTwoPressureContactCalculateCharScaled);
            return new SuccessResult(PLCMachineOverviewMessages.Write);
        }

        //Read Only
        [SecurityAspect("PLCMachineOverview.ReadRewinderTwoPressureSupportCalculateCharScaled", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderTwoPressureSupportCalculateCharScaled()//Name:Rew2PresSupCalcCharScaled,Adress:DB 90 DBW 456,Data Type:Int
        {
            var rewinderTwoPressureSupportCalculateCharScaled = (decimal)_plcDal.Read(DataType.DataBlock, 90, 456, VarType.Int, 1);

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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoPressureSupportCalculateCharScaled = rewinderTwoPressureSupportCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderTwoPressureSupportCalculateCharScaled = rewinderTwoPressureSupportCalculateCharScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoPressureSupportCalculateCharScaled = rewinderTwoPressureSupportCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderTwoPressureSupportCalculateCharScaled = rewinderTwoPressureSupportCalculateCharScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            return new SuccessDataResult<decimal>(rewinderTwoPressureSupportCalculateCharScaled, PLCMachineOverviewMessages.Read);
        }

        [SecurityAspect("PLCMachineOverview.WriteRewinderTwoPressureSupportCalculateCharScaled", Priority = 2)]
        public async Task<IResult> WriteRewinderTwoPressureSupportCalculateCharScaled(decimal rewinderTwoPressureSupportCalculateCharScaled)//Name:Rew2PresSupCalcCharScaled,Adress:DB 90 DBW 456,Data Type:Int
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

                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoPressureSupportCalculateCharScaled = rewinderTwoPressureSupportCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderTwoPressureSupportCalculateCharScaled = rewinderTwoPressureSupportCalculateCharScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }
            else
            {
                var plcMachineOverview = await _plcMachineOverviewDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcMachineOverview == null)
                {
                    var plcMachineOverviewId = Guid.NewGuid();
                    plcMachineOverview = new PLCMachineOverview
                    {
                        Id = plcMachineOverviewId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoPressureSupportCalculateCharScaled = rewinderTwoPressureSupportCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcMachineOverviewDal.Add(plcMachineOverview);
                }
                else
                {
                    plcMachineOverview.RewinderTwoPressureSupportCalculateCharScaled = rewinderTwoPressureSupportCalculateCharScaled;
                    await _plcMachineOverviewDal.Update(plcMachineOverview);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 456, rewinderTwoPressureSupportCalculateCharScaled);
            return new SuccessResult(PLCMachineOverviewMessages.Write);
        }


    }
}





