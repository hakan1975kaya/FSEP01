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
    public class PLCSuctionHydraulicManager : IPLCSuctionHydraulicService
    {
        private IPLCDal _plcDal;
        private IPLCGeneralDal _plcGeneralDal;
        private IPLCSuctionHydraulicDal _plcSuctionHydraulicDal;
        private string _recipeNameLast;
        public PLCSuctionHydraulicManager(IPLCDal plcDal, IPLCGeneralDal plcGeneralDal, IPLCSuctionHydraulicDal plcSuctionHydraulicDal)
        {
            _plcDal = plcDal;
            _plcGeneralDal = plcGeneralDal;
            _plcSuctionHydraulicDal = plcSuctionHydraulicDal;
            _recipeNameLast = (string)_plcDal.Read(DataType.DataBlock, 90, 40, VarType.String, 1);
        }

        [SecurityAspect("PLCSuctionHydraulic.ReadStartCycleCentralLubrication", Priority = 2)]
        public async Task<IDataResult<bool>> ReadStartCycleCentralLubrication()//Name:MachineFunctFlag1,Adress:DB 91 DBW 28,Data Type:short,Note:91.28.6 StartCycleCentrallubrication
        {
            var startCycleCentralLubrication = (bool)_plcDal.Read(DataType.DataBlock, 91, 28, VarType.Bit, 1, 6);

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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        StartCycleCentralLubrication = startCycleCentralLubrication,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.StartCycleCentralLubrication = startCycleCentralLubrication;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        StartCycleCentralLubrication = startCycleCentralLubrication,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.StartCycleCentralLubrication = startCycleCentralLubrication;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            return new SuccessDataResult<bool>(startCycleCentralLubrication, PLCSuctionHydraulicMessages.Read);
        }

        [SecurityAspect("PLCSuctionHydraulic.WriteStartCycleCentralLubrication", Priority = 2)]
        public async Task<IResult> WriteStartCycleCentralLubrication(bool startCycleCentralLubrication)//Name:MachineFunctFlag1,Adress:DB 91 DBW 28,Data Type:short,Note:91.28.6 StartCycleCentrallubrication
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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        StartCycleCentralLubrication = startCycleCentralLubrication,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.StartCycleCentralLubrication = startCycleCentralLubrication;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        StartCycleCentralLubrication = startCycleCentralLubrication,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.StartCycleCentralLubrication = startCycleCentralLubrication;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 28, startCycleCentralLubrication, 6);
            return new SuccessResult(PLCSuctionHydraulicMessages.Write);
        }


        [SecurityAspect("PLCSuctionHydraulic.ReadStartCycleCentralLubricationIsRunning", Priority = 2)]
        public async Task<IDataResult<bool>> ReadStartCycleCentralLubricationIsRunning()//Name:MachineFunctFlag1,Adress:DB 91 DBW 28,Data Type:short,Note:91.28.15 StartLubrication
        {
            var startCycleCentralLubricationIsRunning = (bool)_plcDal.Read(DataType.DataBlock, 91, 28, VarType.Bit, 1, 15);

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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        StartCycleCentralLubricationIsRunning = startCycleCentralLubricationIsRunning,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.StartCycleCentralLubricationIsRunning = startCycleCentralLubricationIsRunning;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        StartCycleCentralLubricationIsRunning = startCycleCentralLubricationIsRunning,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.StartCycleCentralLubricationIsRunning = startCycleCentralLubricationIsRunning;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            return new SuccessDataResult<bool>(startCycleCentralLubricationIsRunning, PLCSuctionHydraulicMessages.Read);
        }

        [SecurityAspect("PLCSuctionHydraulic.WriteStartCycleCentralLubricationIsRunning", Priority = 2)]
        public async Task<IResult> WriteStartCycleCentralLubricationIsRunning(bool startCycleCentralLubricationIsRunning)//Name:MachineFunctFlag1,Adress:DB 91 DBW 28,Data Type:short,Note:91.28.15 StartLubrication
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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        StartCycleCentralLubricationIsRunning = startCycleCentralLubricationIsRunning,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.StartCycleCentralLubricationIsRunning = startCycleCentralLubricationIsRunning;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        StartCycleCentralLubricationIsRunning = startCycleCentralLubricationIsRunning,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.StartCycleCentralLubricationIsRunning = startCycleCentralLubricationIsRunning;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 28, startCycleCentralLubricationIsRunning, 15);
            return new SuccessResult(PLCSuctionHydraulicMessages.Write);
        }


        [SecurityAspect("PLCSuctionHydraulic.ReadHydraulicTemperature", Priority = 2)]
        public async Task<IDataResult<short>> ReadHydraulicTemperature()//Name:HydraulicTemperature,Addres:DB 90 DBW 28,Data Type:short,Note:90.28.6 :Start Cycle Central lubrication Button,90.28.15 :Cycle Central lubrication Lamp
        {
            var hydraulicTemperature = (short)_plcDal.Read(DataType.DataBlock, 90, 28, VarType.Int, 1);

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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        HydraulicTemperature = hydraulicTemperature,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.HydraulicTemperature = hydraulicTemperature;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        HydraulicTemperature = hydraulicTemperature,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.HydraulicTemperature = hydraulicTemperature;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            return new SuccessDataResult<short>(hydraulicTemperature, PLCSuctionHydraulicMessages.Read);
        }

        [SecurityAspect("PLCSuctionHydraulic.WriteHydraulicTemperature", Priority = 2)]
        public async Task<IResult> WriteHydraulicTemperature(short hydraulicTemperature)//Name:HydraulicTemperature,Addres:DB 90 DBW 28,Data Type:short
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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        HydraulicTemperature = hydraulicTemperature,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.HydraulicTemperature = hydraulicTemperature;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        HydraulicTemperature = hydraulicTemperature,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.HydraulicTemperature = hydraulicTemperature;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 28, hydraulicTemperature);
            return new SuccessResult(PLCSuctionHydraulicMessages.Write);
        }


        [SecurityAspect("PLCSuctionHydraulic.ReadHydraulicLevel", Priority = 2)]
        public async Task<IDataResult<short>> ReadHydraulicLevel()//Name:HydraulicLevel,Addres:DB 90 DBW 662,Data Type:short
        {
            var hydraulicLevel = (short)_plcDal.Read(DataType.DataBlock, 90, 662, VarType.Int, 1);

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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        HydraulicLevel = hydraulicLevel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.HydraulicLevel = hydraulicLevel;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        HydraulicLevel = hydraulicLevel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.HydraulicLevel = hydraulicLevel;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            return new SuccessDataResult<short>(hydraulicLevel, PLCSuctionHydraulicMessages.Read);
        }

        [SecurityAspect("PLCSuctionHydraulic.WriteHydraulicLevel", Priority = 2)]
        public async Task<IResult> WriteHydraulicLevel(short hydraulicLevel)//Name:HydraulicLevel,Addres:DB 90 DBW 662,Data Type:short
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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        HydraulicLevel = hydraulicLevel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.HydraulicLevel = hydraulicLevel;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        HydraulicLevel = hydraulicLevel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.HydraulicLevel = hydraulicLevel;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 662, hydraulicLevel);
            return new SuccessResult(PLCSuctionHydraulicMessages.Write);
        }


        [SecurityAspect("PLCSuctionHydraulic.ReadHydraulicPressure", Priority = 2)]
        public async Task<IDataResult<short>> ReadHydraulicPressure()//Name:HydraulicPressure,Addres:DB 90 DBW 664, Data Type:short
        {
            var hydraulicPressure = (short)_plcDal.Read(DataType.DataBlock, 90, 664, VarType.Int, 1);

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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        HydraulicPressure = hydraulicPressure,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.HydraulicPressure = hydraulicPressure;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        HydraulicPressure = hydraulicPressure,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.HydraulicPressure = hydraulicPressure;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            return new SuccessDataResult<short>(hydraulicPressure, PLCSuctionHydraulicMessages.Read);
        }

        [SecurityAspect("PLCSuctionHydraulic.WriteHydraulicPressure", Priority = 2)]
        public async Task<IResult> WriteHydraulicPressure(short hydraulicPressure)//Name:HydraulicPressure,Addres:DB 90 DBW 664, Data Type:short
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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        HydraulicPressure = hydraulicPressure,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.HydraulicPressure = hydraulicPressure;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        HydraulicPressure = hydraulicPressure,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.HydraulicPressure = hydraulicPressure;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 664, hydraulicPressure);
            return new SuccessResult(PLCSuctionHydraulicMessages.Write);
        }


        [SecurityAspect("PLCSuctionHydraulic.ReadSuctionRPMSet", Priority = 2)]
        public async Task<IDataResult<short>> ReadSuctionRPMSet()//Name:SuctionRPMSet,Addres:DB 91 DBW 690, Data Type:short
        {
            var suctionRPMSet = (short)_plcDal.Read(DataType.DataBlock, 91, 690, VarType.Int, 1);

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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        SuctionRPMSet = suctionRPMSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionRPMSet = suctionRPMSet;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        SuctionRPMSet = suctionRPMSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionRPMSet = suctionRPMSet;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            return new SuccessDataResult<short>(suctionRPMSet, PLCSuctionHydraulicMessages.Read);
        }

        [SecurityAspect("PLCSuctionHydraulic.WriteSuctionRPMSet", Priority = 2)]
        public async Task<IResult> WriteSuctionRPMSet(short suctionRPMSet)//Name:SuctionRPMSet,Addres:DB 91 DBW 690, Data Type:short
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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        SuctionRPMSet = suctionRPMSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionRPMSet = suctionRPMSet;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        SuctionRPMSet = suctionRPMSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionRPMSet = suctionRPMSet;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 690, suctionRPMSet);
            return new SuccessResult(PLCSuctionHydraulicMessages.Write);
        }


        [SecurityAspect("PLCSuctionHydraulic.ReadSuctionRPMActuel", Priority = 2)]
        public async Task<IDataResult<short>> ReadSuctionRPMActuel()//Name:SuctionRPMSet,Addres:DB 90 DBW 690, Data Type:short
        {
            var suctionRPMActuel = (short)_plcDal.Read(DataType.DataBlock, 90, 690, VarType.Int, 1);

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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        SuctionRPMActuel = suctionRPMActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionRPMActuel = suctionRPMActuel;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        SuctionRPMActuel = suctionRPMActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionRPMActuel = suctionRPMActuel;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            return new SuccessDataResult<short>(suctionRPMActuel, PLCSuctionHydraulicMessages.Read);
        }

        [SecurityAspect("PLCSuctionHydraulic.WriteSuctionRPMActuel", Priority = 2)]
        public async Task<IResult> WriteSuctionRPMActuel(short suctionRPMActuel)//Name:SuctionRPMSet,Addres:DB 90 DBW 690, Data Type:short
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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        SuctionRPMActuel = suctionRPMActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionRPMActuel = suctionRPMActuel;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        SuctionRPMActuel = suctionRPMActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionRPMActuel = suctionRPMActuel;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 690, suctionRPMActuel);
            return new SuccessResult(PLCSuctionHydraulicMessages.Write);
        }


        [SecurityAspect("PLCSuctionHydraulic.ReadSuctionSpeedForMaximumRPM", Priority = 2)]
        public async Task<IDataResult<short>> ReadSuctionSpeedForMaximumRPM()//Name:SuctionSpeedForMaxRPM,Addres:DB 91 DBW 694, Data Type:short
        {
            var suctionSpeedForMaximumRPM = (short)_plcDal.Read(DataType.DataBlock, 91, 694, VarType.Int, 1);

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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        SuctionSpeedForMaximumRPM = suctionSpeedForMaximumRPM,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionSpeedForMaximumRPM = suctionSpeedForMaximumRPM;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        SuctionSpeedForMaximumRPM = suctionSpeedForMaximumRPM,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionSpeedForMaximumRPM = suctionSpeedForMaximumRPM;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            return new SuccessDataResult<short>(suctionSpeedForMaximumRPM, PLCSuctionHydraulicMessages.Read);
        }

        [SecurityAspect("PLCSuctionHydraulic.WriteSuctionSpeedForMaximumRPM", Priority = 2)]
        public async Task<IResult> WriteSuctionSpeedForMaximumRPM(short suctionSpeedForMaximumRPM)//Name:SuctionSpeedForMaxRPM,Addres:DB 91 DBW 694, Data Type:short
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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        SuctionSpeedForMaximumRPM = suctionSpeedForMaximumRPM,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionSpeedForMaximumRPM = suctionSpeedForMaximumRPM;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        SuctionSpeedForMaximumRPM = suctionSpeedForMaximumRPM,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionSpeedForMaximumRPM = suctionSpeedForMaximumRPM;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 694, suctionSpeedForMaximumRPM);
            return new SuccessResult(PLCSuctionHydraulicMessages.Write);
        }


        [SecurityAspect("PLCSuctionHydraulic.ReadMachineSpeedActuel", Priority = 2)]
        public async Task<IDataResult<short>> ReadMachineSpeedActuel()//Name:SuctionSpeedForMaxRPM,Addres:DB 90 DBW 2, Data Type:short
        {
            var machineSpeedActuel = (short)_plcDal.Read(DataType.DataBlock, 90, 2, VarType.Int, 1);

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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        MachineSpeedActuel = machineSpeedActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.MachineSpeedActuel = machineSpeedActuel;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        MachineSpeedActuel = machineSpeedActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.MachineSpeedActuel = machineSpeedActuel;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            return new SuccessDataResult<short>(machineSpeedActuel, PLCSuctionHydraulicMessages.Read);
        }

        [SecurityAspect("PLCSuctionHydraulic.WriteMachineSpeedActuel", Priority = 2)]
        public async Task<IResult> WriteMachineSpeedActuel(short machineSpeedActuel)//Name:SuctionSpeedForMaxRPM,Addres:DB 90 DBW 2, Data Type:short
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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        MachineSpeedActuel = machineSpeedActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.MachineSpeedActuel = machineSpeedActuel;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        MachineSpeedActuel = machineSpeedActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.MachineSpeedActuel = machineSpeedActuel;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 2, machineSpeedActuel);
            return new SuccessResult(PLCSuctionHydraulicMessages.Write);
        }


        [SecurityAspect("PLCSuctionHydraulic.ReadBoosterIsRaedy", Priority = 2)]
        public async Task<IDataResult<bool>> ReadBoosterIsRaedy()//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.0
        {
            var boosterIsRaedy = (bool)_plcDal.Read(DataType.DataBlock, 91, 702, VarType.Bit, 1, 0);

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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        BoosterIsRaedy = boosterIsRaedy,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.BoosterIsRaedy = boosterIsRaedy;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        BoosterIsRaedy = boosterIsRaedy,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.BoosterIsRaedy = boosterIsRaedy;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            return new SuccessDataResult<bool>(boosterIsRaedy,PLCSuctionHydraulicMessages.Read);
        }

        [SecurityAspect("PLCSuctionHydraulic.WriteBoosterIsRaedy", Priority = 2)]
        public async Task<IResult> WriteBoosterIsRaedy(bool boosterIsRaedy)//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.0
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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        BoosterIsRaedy = boosterIsRaedy,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.BoosterIsRaedy = boosterIsRaedy;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        BoosterIsRaedy = boosterIsRaedy,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.BoosterIsRaedy = boosterIsRaedy;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 702, boosterIsRaedy, 0);
            return new SuccessResult(PLCSuctionHydraulicMessages.Write);
        }


        [SecurityAspect("PLCSuctionHydraulic.ReadBoosterIsRunning", Priority = 2)]
        public async Task<IDataResult<bool>> ReadBoosterIsRunning()//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.1
        {
            var boosterIsRunning = (bool)_plcDal.Read(DataType.DataBlock, 91, 702, VarType.Bit, 1, 1);

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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        BoosterIsRunning = boosterIsRunning,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.BoosterIsRunning = boosterIsRunning;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        BoosterIsRunning = boosterIsRunning,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.BoosterIsRunning = boosterIsRunning;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            return new SuccessDataResult<bool>(boosterIsRunning,PLCSuctionHydraulicMessages.Read);
        }

        [SecurityAspect("PLCSuctionHydraulic.WriteBoosterIsRunning", Priority = 2)]
        public async Task<IResult> WriteBoosterIsRunning(bool boosterIsRunning)//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.1
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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        BoosterIsRunning = boosterIsRunning,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.BoosterIsRunning = boosterIsRunning;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        BoosterIsRunning = boosterIsRunning,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.BoosterIsRunning = boosterIsRunning;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 702, boosterIsRunning, 1);
            return new SuccessResult(PLCSuctionHydraulicMessages.Write);
        }


        [SecurityAspect("PLCSuctionHydraulic.ReadSuctionExternFunctionSetOne", Priority = 2)]
        public async Task<IDataResult<bool>> ReadSuctionExternFunctionSetOne()//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.2
        {
            var suctionExternFunctionSetOne = (bool)_plcDal.Read(DataType.DataBlock, 91, 702, VarType.Bit, 1, 2);

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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        SuctionExternFunctionSetOne = suctionExternFunctionSetOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionExternFunctionSetOne = suctionExternFunctionSetOne;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        SuctionExternFunctionSetOne = suctionExternFunctionSetOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionExternFunctionSetOne = suctionExternFunctionSetOne;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            return new SuccessDataResult<bool>(suctionExternFunctionSetOne,PLCSuctionHydraulicMessages.Read);
        }

        [SecurityAspect("PLCSuctionHydraulic.WriteSuctionExternFunctionSetOne", Priority = 2)]
        public async Task<IResult> WriteSuctionExternFunctionSetOne(bool suctionExternFunctionSetOne)//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.2
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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        SuctionExternFunctionSetOne = suctionExternFunctionSetOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionExternFunctionSetOne = suctionExternFunctionSetOne;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        SuctionExternFunctionSetOne = suctionExternFunctionSetOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionExternFunctionSetOne = suctionExternFunctionSetOne;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 702, suctionExternFunctionSetOne, 2);
            return new SuccessResult(PLCSuctionHydraulicMessages.Write);
        }


        [SecurityAspect("PLCSuctionHydraulic.ReadSuctionExternFunctionSetTwo", Priority = 2)]
        public async Task<IDataResult<bool>> ReadSuctionExternFunctionSetTwo()//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.3
        {
            var suctionExternFunctionSetTwo = (bool)_plcDal.Read(DataType.DataBlock, 91, 702, VarType.Bit, 1, 3);

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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        SuctionExternFunctionSetTwo = suctionExternFunctionSetTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionExternFunctionSetTwo = suctionExternFunctionSetTwo;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        SuctionExternFunctionSetTwo = suctionExternFunctionSetTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionExternFunctionSetTwo = suctionExternFunctionSetTwo;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            return new SuccessDataResult<bool>(suctionExternFunctionSetTwo,PLCSuctionHydraulicMessages.Read);
        }

        [SecurityAspect("PLCSuctionHydraulic.WriteSuctionExternFunctionSetTwo", Priority = 2)]
        public async Task<IResult> WriteSuctionExternFunctionSetTwo(bool suctionExternFunctionSetTwo)//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.3
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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        SuctionExternFunctionSetTwo = suctionExternFunctionSetTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionExternFunctionSetTwo = suctionExternFunctionSetTwo;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        SuctionExternFunctionSetTwo = suctionExternFunctionSetTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionExternFunctionSetTwo = suctionExternFunctionSetTwo;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 702, suctionExternFunctionSetTwo, 3);
            return new SuccessResult(PLCSuctionHydraulicMessages.Write);
        }


        [SecurityAspect("PLCSuctionHydraulic.ReadSuctionExternFunctionSetThree", Priority = 2)]
        public async Task<IDataResult<bool>> ReadSuctionExternFunctionSetThree()//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.4
        {
            var suctionExternFunctionSetThree = (bool)_plcDal.Read(DataType.DataBlock, 91, 702, VarType.Bit, 1, 4);

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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        SuctionExternFunctionSetThree = suctionExternFunctionSetThree,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionExternFunctionSetThree = suctionExternFunctionSetThree;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        SuctionExternFunctionSetThree = suctionExternFunctionSetThree,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionExternFunctionSetThree = suctionExternFunctionSetThree;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            return new SuccessDataResult<bool>(suctionExternFunctionSetThree,PLCSuctionHydraulicMessages.Read);
        }

        [SecurityAspect("PLCSuctionHydraulic.WriteSuctionExternFunctionSetThree", Priority = 2)]
        public async Task<IResult> WriteSuctionExternFunctionSetThree(bool suctionExternFunctionSetThree)//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.4
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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        SuctionExternFunctionSetThree = suctionExternFunctionSetThree,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionExternFunctionSetThree = suctionExternFunctionSetThree;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        SuctionExternFunctionSetThree = suctionExternFunctionSetThree,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionExternFunctionSetThree = suctionExternFunctionSetThree;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 702, suctionExternFunctionSetThree, 4);
            return new SuccessResult(PLCSuctionHydraulicMessages.Write);
        }


        [SecurityAspect("PLCSuctionHydraulic.ReadSuctionExternFunctionReady", Priority = 2)]
        public async Task<IDataResult<bool>> ReadSuctionExternFunctionReady()//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.5
        {
            var suctionExternFunctionReady = (bool)_plcDal.Read(DataType.DataBlock, 91, 702, VarType.Bit, 1, 5);

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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        SuctionExternFunctionReady = suctionExternFunctionReady,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionExternFunctionReady = suctionExternFunctionReady;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        SuctionExternFunctionReady = suctionExternFunctionReady,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionExternFunctionReady = suctionExternFunctionReady;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            return new SuccessDataResult<bool>(suctionExternFunctionReady,PLCSuctionHydraulicMessages.Read);
        }

        [SecurityAspect("PLCSuctionHydraulic.WriteSuctionExternFunctionReady", Priority = 2)]
        public async Task<IResult> WriteSuctionExternFunctionReady(bool suctionExternFunctionReady)//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.5
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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        SuctionExternFunctionReady = suctionExternFunctionReady,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionExternFunctionReady = suctionExternFunctionReady;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        SuctionExternFunctionReady = suctionExternFunctionReady,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionExternFunctionReady = suctionExternFunctionReady;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 702, suctionExternFunctionReady, 5);
            return new SuccessResult(PLCSuctionHydraulicMessages.Write);
        }


        [SecurityAspect("PLCSuctionHydraulic.ReadSuctionExternFunctionIsRunning", Priority = 2)]
        public async Task<IDataResult<bool>> ReadSuctionExternFunctionIsRunning()//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.6
        {
            var suctionExternFunctionIsRunning = (bool)_plcDal.Read(DataType.DataBlock, 91, 702, VarType.Bit, 1, 6);

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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        SuctionExternFunctionIsRunning = suctionExternFunctionIsRunning,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionExternFunctionIsRunning = suctionExternFunctionIsRunning;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        SuctionExternFunctionIsRunning = suctionExternFunctionIsRunning,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionExternFunctionIsRunning = suctionExternFunctionIsRunning;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            return new SuccessDataResult<bool>(suctionExternFunctionIsRunning,PLCSuctionHydraulicMessages.Read);
        }

        [SecurityAspect("PLCSuctionHydraulic.WriteSuctionExternFunctionIsRunning", Priority = 2)]
        public async Task<IResult> WriteSuctionExternFunctionIsRunning(bool suctionExternFunctionIsRunning)//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.6
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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        SuctionExternFunctionIsRunning = suctionExternFunctionIsRunning,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionExternFunctionIsRunning = suctionExternFunctionIsRunning;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        SuctionExternFunctionIsRunning = suctionExternFunctionIsRunning,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionExternFunctionIsRunning = suctionExternFunctionIsRunning;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 702, suctionExternFunctionIsRunning, 6);
            return new SuccessResult(PLCSuctionHydraulicMessages.Write);
        }


        [SecurityAspect("PLCSuctionHydraulic.ReadSuctionExternFunctionIsFault", Priority = 2)]
        public async Task<IDataResult<bool>> ReadSuctionExternFunctionIsFault()//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.6
        {
            var suctionExternFunctionIsFault = (bool)_plcDal.Read(DataType.DataBlock, 91, 702, VarType.Bit, 1, 7);

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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        SuctionExternFunctionIsFault = suctionExternFunctionIsFault,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionExternFunctionIsFault = suctionExternFunctionIsFault;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        SuctionExternFunctionIsFault = suctionExternFunctionIsFault,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionExternFunctionIsFault = suctionExternFunctionIsFault;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            return new SuccessDataResult<bool>(suctionExternFunctionIsFault,PLCSuctionHydraulicMessages.Read);
        }

        [SecurityAspect("PLCSuctionHydraulic.WriteSuctionExternFunctionIsFault", Priority = 2)]
        public async Task<IResult> WriteSuctionExternFunctionIsFault(bool suctionExternFunctionIsFault)//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.6
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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        SuctionExternFunctionIsFault = suctionExternFunctionIsFault,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionExternFunctionIsFault = suctionExternFunctionIsFault;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        SuctionExternFunctionIsFault = suctionExternFunctionIsFault,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionExternFunctionIsFault = suctionExternFunctionIsFault;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 702, suctionExternFunctionIsFault, 7);
            return new SuccessResult(PLCSuctionHydraulicMessages.Write);
        }


        [SecurityAspect("PLCSuctionHydraulic.ReadSuctionLeakAirFlapOneSet", Priority = 2)]
        public async Task<IDataResult<short>> ReadSuctionLeakAirFlapOneSet()//Name:suction externFunktionFlag,Addres:DB 91 DBW 698, Data Type:short
        {
            var suctionLeakAirFlapOneSet = (short)_plcDal.Read(DataType.DataBlock, 91, 698, VarType.Int, 1);

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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        SuctionLeakAirFlapOneSet = suctionLeakAirFlapOneSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionLeakAirFlapOneSet = suctionLeakAirFlapOneSet;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        SuctionLeakAirFlapOneSet = suctionLeakAirFlapOneSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionLeakAirFlapOneSet = suctionLeakAirFlapOneSet;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            return new SuccessDataResult<short>(suctionLeakAirFlapOneSet,PLCSuctionHydraulicMessages.Read);
        }

        [SecurityAspect("PLCSuctionHydraulic.WriteSuctionLeakAirFlapOneSet", Priority = 2)]
        public async Task<IResult> WriteSuctionLeakAirFlapOneSet(short suctionLeakAirFlapOneSet)//Name:suction externFunktionFlag,Addres:DB 91 DBW 698, Data Type:short
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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        SuctionLeakAirFlapOneSet = suctionLeakAirFlapOneSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionLeakAirFlapOneSet = suctionLeakAirFlapOneSet;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        SuctionLeakAirFlapOneSet = suctionLeakAirFlapOneSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionLeakAirFlapOneSet = suctionLeakAirFlapOneSet;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 698, suctionLeakAirFlapOneSet);
            return new SuccessResult(PLCSuctionHydraulicMessages.Write);
        }


        [SecurityAspect("PLCSuctionHydraulic.ReadSuctionLeakAirFlapOneActuel", Priority = 2)]
        public async Task<IDataResult<short>> ReadSuctionLeakAirFlapOneActuel()//Name:SuctionLeakAirFlap1Act,Addres:DB 91 DBW 698, Data Type:short
        {
            var suctionLeakAirFlapOneActuel = (short)_plcDal.Read(DataType.DataBlock, 91, 698, VarType.Int, 1);

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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        SuctionLeakAirFlapOneActuel = suctionLeakAirFlapOneActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionLeakAirFlapOneActuel = suctionLeakAirFlapOneActuel;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        SuctionLeakAirFlapOneActuel = suctionLeakAirFlapOneActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionLeakAirFlapOneActuel = suctionLeakAirFlapOneActuel;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            return new SuccessDataResult<short>(suctionLeakAirFlapOneActuel,PLCSuctionHydraulicMessages.Read);
        }

        [SecurityAspect("PLCSuctionHydraulic.WriteSuctionLeakAirFlapOneActuel", Priority = 2)]
        public async Task<IResult> WriteSuctionLeakAirFlapOneActuel(short suctionLeakAirFlapOneActuel)//Name:SuctionLeakAirFlap1Act,Addres:DB 91 DBW 698, Data Type:short
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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        SuctionLeakAirFlapOneActuel = suctionLeakAirFlapOneActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionLeakAirFlapOneActuel = suctionLeakAirFlapOneActuel;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        SuctionLeakAirFlapOneActuel = suctionLeakAirFlapOneActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionLeakAirFlapOneActuel = suctionLeakAirFlapOneActuel;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 698, suctionLeakAirFlapOneActuel);
            return new SuccessResult(PLCSuctionHydraulicMessages.Write);
        }


        [SecurityAspect("PLCSuctionHydraulic.ReadSuctionLeakAirFlapTwoSet", Priority = 2)]
        public async Task<IDataResult<short>> ReadSuctionLeakAirFlapTwoSet()//Name:SuctionLeakAirFlap2Set,Addres:DB 91 DBW 700, Data Type:short
        {
            var suctionLeakAirFlapTwoSet = (short)_plcDal.Read(DataType.DataBlock, 91, 700, VarType.Int, 1);

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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        SuctionLeakAirFlapTwoSet = suctionLeakAirFlapTwoSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionLeakAirFlapTwoSet = suctionLeakAirFlapTwoSet;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        SuctionLeakAirFlapTwoSet = suctionLeakAirFlapTwoSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionLeakAirFlapTwoSet = suctionLeakAirFlapTwoSet;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            return new SuccessDataResult<short>(suctionLeakAirFlapTwoSet,PLCSuctionHydraulicMessages.Read);
        }

        [SecurityAspect("PLCSuctionHydraulic.WriteSuctionLeakAirFlapTwoSet", Priority = 2)]
        public async Task<IResult> WriteSuctionLeakAirFlapTwoSet(short suctionLeakAirFlapTwoSet)//Name:SuctionLeakAirFlap2Set,Addres:DB 91 DBW 700, Data Type:short
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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        SuctionLeakAirFlapTwoSet = suctionLeakAirFlapTwoSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionLeakAirFlapTwoSet = suctionLeakAirFlapTwoSet;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        SuctionLeakAirFlapTwoSet = suctionLeakAirFlapTwoSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionLeakAirFlapTwoSet = suctionLeakAirFlapTwoSet;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 700, suctionLeakAirFlapTwoSet);
            return new SuccessResult(PLCSuctionHydraulicMessages.Write);
        }


        [SecurityAspect("PLCSuctionHydraulic.ReadSuctionLeakAirFlapTwoActuel", Priority = 2)]
        public async Task<IDataResult<short>> ReadSuctionLeakAirFlapTwoActuel()//Name:SuctionLeakAirFlap2Act,Addres:DB 90 DBW 700, Data Type:short
        {
            var suctionLeakAirFlapTwoActuel = (short)_plcDal.Read(DataType.DataBlock, 90, 700, VarType.Int, 1);

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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        SuctionLeakAirFlapTwoActuel = suctionLeakAirFlapTwoActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionLeakAirFlapTwoActuel = suctionLeakAirFlapTwoActuel;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        SuctionLeakAirFlapTwoActuel = suctionLeakAirFlapTwoActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionLeakAirFlapTwoActuel = suctionLeakAirFlapTwoActuel;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            return new SuccessDataResult<short>(suctionLeakAirFlapTwoActuel,PLCSuctionHydraulicMessages.Read);
        }

        [SecurityAspect("PLCSuctionHydraulic.WriteSuctionLeakAirFlapTwoActuel", Priority = 2)]
        public async Task<IResult> WriteSuctionLeakAirFlapTwoActuel(short suctionLeakAirFlapTwoActuel)//Name:SuctionLeakAirFlap2Act,Addres:DB 90 DBW 700, Data Type:short
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

                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneralId,
                        SuctionLeakAirFlapTwoActuel = suctionLeakAirFlapTwoActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionLeakAirFlapTwoActuel = suctionLeakAirFlapTwoActuel;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }
            else
            {
                var plcSuctionHydraulic = await _plcSuctionHydraulicDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcSuctionHydraulic == null)
                {
                    var plcSuctionHydraulicId = Guid.NewGuid();
                    plcSuctionHydraulic = new PLCSuctionHydraulic
                    {
                        Id = plcSuctionHydraulicId,
                        PLCGeneralId = plcGeneral.Id,
                        SuctionLeakAirFlapTwoActuel = suctionLeakAirFlapTwoActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcSuctionHydraulicDal.Add(plcSuctionHydraulic);
                }
                else
                {
                    plcSuctionHydraulic.SuctionLeakAirFlapTwoActuel = suctionLeakAirFlapTwoActuel;
                    await _plcSuctionHydraulicDal.Update(plcSuctionHydraulic);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 700, suctionLeakAirFlapTwoActuel);
            return new SuccessResult(PLCSuctionHydraulicMessages.Write);
        }

    }
}
