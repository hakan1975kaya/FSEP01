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
    public class PLCRewinderPressureManager : IPLCRewinderPressureService
    {
        private IPLCDal _plcDal;
        private IPLCGeneralDal _plcGeneralDal;
        private IPLCRewinderPressureDal _plcRewinderPressureDal;
        private string _recipeNameLast;
        public PLCRewinderPressureManager(IPLCDal plcDal, IPLCGeneralDal plcGeneralDal, IPLCRewinderPressureDal plcRewinderPressureDal)
        {
            _plcDal = plcDal;
            _plcGeneralDal = plcGeneralDal;
            _plcRewinderPressureDal = plcRewinderPressureDal;
            _recipeNameLast = (string)_plcDal.Read(DataType.DataBlock, 90, 40, VarType.String, 1);
        }

        [SecurityAspect("PLCRewinderPressure.ReadRewinderOnePressureLaySetScaled", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderOnePressureLaySetScaled()//Name:Rew1PresLaySetScaled,Addres:DB 91 DBW 352,Data Type:Int
        {
            var rewinderOnePressureLaySetScaled = (decimal)_plcDal.Read(DataType.DataBlock, 91, 352, VarType.Int, 1);

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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOnePressureLaySetScaled = rewinderOnePressureLaySetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureLaySetScaled = rewinderOnePressureLaySetScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOnePressureLaySetScaled = rewinderOnePressureLaySetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureLaySetScaled = rewinderOnePressureLaySetScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            return new SuccessDataResult<decimal>(rewinderOnePressureLaySetScaled, PLCRewinderPressureMessages.Read);
        }

        [SecurityAspect("PLCRewinderPressure.WriteRewinderOnePressureLaySetScaled", Priority = 2)]
        public async Task<IResult> WriteRewinderOnePressureLaySetScaled(decimal rewinderOnePressureLaySetScaled)//Name:Rew1PresLaySetScaled,Addres:DB 91 DBW 352,Data Type:Int
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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOnePressureLaySetScaled = rewinderOnePressureLaySetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureLaySetScaled = rewinderOnePressureLaySetScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOnePressureLaySetScaled = rewinderOnePressureLaySetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureLaySetScaled = rewinderOnePressureLaySetScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 352, rewinderOnePressureLaySetScaled);
            return new SuccessResult(PLCRewinderPressureMessages.Write);
        }


        [SecurityAspect("PLCRewinderPressure.ReadRewinderOnePressureLayCalculateCharScaled", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderOnePressureLayCalculateCharScaled()//Name:Rew1PresLayCalcCharScaled,Addres:DB 90 DBW 356,Data Type:Int
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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOnePressureLayCalculateCharScaled = rewinderOnePressureLayCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureLayCalculateCharScaled = rewinderOnePressureLayCalculateCharScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOnePressureLayCalculateCharScaled = rewinderOnePressureLayCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureLayCalculateCharScaled = rewinderOnePressureLayCalculateCharScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            return new SuccessDataResult<decimal>(rewinderOnePressureLayCalculateCharScaled, PLCRewinderPressureMessages.Read);
        }

        [SecurityAspect("PLCRewinderPressure.WriteRewinderOnePressureLayCalculateCharScaled", Priority = 2)]
        public async Task<IResult> WriteRewinderOnePressureLayCalculateCharScaled(decimal rewinderOnePressureLayCalculateCharScaled)//Name:Rew1PresLayCalcCharScaled,Addres:DB 90 DBW 356,Data Type:Int
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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOnePressureLayCalculateCharScaled = rewinderOnePressureLayCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureLayCalculateCharScaled = rewinderOnePressureLayCalculateCharScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOnePressureLayCalculateCharScaled = rewinderOnePressureLayCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureLayCalculateCharScaled = rewinderOnePressureLayCalculateCharScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 356, rewinderOnePressureLayCalculateCharScaled);
            return new SuccessResult(PLCRewinderPressureMessages.Write);
        }


        [SecurityAspect("PLCRewinderPressure.ReadRewinderOnePresureLayBalance", Priority = 2)]
        public async Task<IDataResult<int>> ReadRewinderOnePresureLayBalance()//Name:Rew1PresLayBalance,Addres:DB 91 DBW 366, Data Type:Int
        {
            var rewinderOnePresureLayBalance = (int)_plcDal.Read(DataType.DataBlock, 91, 366, VarType.Int, 1);

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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOnePresureLayBalance = rewinderOnePresureLayBalance,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePresureLayBalance = rewinderOnePresureLayBalance;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOnePresureLayBalance = rewinderOnePresureLayBalance,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePresureLayBalance = rewinderOnePresureLayBalance;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            return new SuccessDataResult<int>(rewinderOnePresureLayBalance, PLCRewinderPressureMessages.Read);
        }

        [SecurityAspect("PLCRewinderPressure.WriteRewinderOnePresureLayBalance", Priority = 2)]
        public async Task<IResult> WriteRewinderOnePresureLayBalance(int rewinderOnePresureLayBalance)//Name:Rew1PresLayBalance,Addres:DB 91 DBW 366,DataType:Int
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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOnePresureLayBalance = rewinderOnePresureLayBalance,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePresureLayBalance = rewinderOnePresureLayBalance;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOnePresureLayBalance = rewinderOnePresureLayBalance,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePresureLayBalance = rewinderOnePresureLayBalance;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 366, rewinderOnePresureLayBalance);
            return new SuccessResult(PLCRewinderPressureMessages.Write);
        }


        [SecurityAspect("PLCRewinderPressure.ReadRewinderOnePressureLayCalculateRight", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderOnePressureLayCalculateRight()//Name:Rew1PresLayCalcRight,Addres:DB 90 DBW 364,Data Type:Int
        {
            var rewinderOnePressureLayCalculateRight = (decimal)_plcDal.Read(DataType.DataBlock, 90, 364, VarType.Int, 1);

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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOnePressureLayCalculateRight = rewinderOnePressureLayCalculateRight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureLayCalculateRight = rewinderOnePressureLayCalculateRight;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOnePressureLayCalculateRight = rewinderOnePressureLayCalculateRight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureLayCalculateRight = rewinderOnePressureLayCalculateRight;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            return new SuccessDataResult<decimal>(rewinderOnePressureLayCalculateRight, PLCRewinderPressureMessages.Read);
        }

        [SecurityAspect("PLCRewinderPressure.WriteRewinderOnePressureLayCalculateRight", Priority = 2)]
        public async Task<IResult> WriteRewinderOnePressureLayCalculateRight(decimal rewinderOnePressureLayCalculateRight)//Name:Rew1PresLayCalcRight,Addres:DB 90 DBW 364,Data Type:Int
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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOnePressureLayCalculateRight = rewinderOnePressureLayCalculateRight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureLayCalculateRight = rewinderOnePressureLayCalculateRight;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOnePressureLayCalculateRight = rewinderOnePressureLayCalculateRight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureLayCalculateRight = rewinderOnePressureLayCalculateRight;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 364, rewinderOnePressureLayCalculateRight);
            return new SuccessResult(PLCRewinderPressureMessages.Write);
        }


        [SecurityAspect("PLCRewinderPressure.ReadRewinderOnePressureLayCalculateLeft", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderOnePressureLayCalculateLeft()//Name:Rew1PresLayCalcLeft,Addres:DB 90 DBW 362,Data Type:Int
        {
            var rewinderOnePressureLayCalculateLeft = (decimal)_plcDal.Read(DataType.DataBlock, 90, 362, VarType.Int, 1);

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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOnePressureLayCalculateLeft = rewinderOnePressureLayCalculateLeft,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureLayCalculateLeft = rewinderOnePressureLayCalculateLeft;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOnePressureLayCalculateLeft = rewinderOnePressureLayCalculateLeft,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureLayCalculateLeft = rewinderOnePressureLayCalculateLeft;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            return new SuccessDataResult<decimal>(rewinderOnePressureLayCalculateLeft, PLCRewinderPressureMessages.Read);
        }

        [SecurityAspect("PLCRewinderPressure.WriteRewinderOnePressureLayCalculateLeft", Priority = 2)]
        public async Task<IResult> WriteRewinderOnePressureLayCalculateLeft(decimal rewinderOnePressureLayCalculateLeft)//Name:Rew1PresLayCalcLeft,Addres:DB 90 DBW 362,Data Type:Int
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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOnePressureLayCalculateLeft = rewinderOnePressureLayCalculateLeft,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureLayCalculateLeft = rewinderOnePressureLayCalculateLeft;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOnePressureLayCalculateLeft = rewinderOnePressureLayCalculateLeft,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureLayCalculateLeft = rewinderOnePressureLayCalculateLeft;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 362, rewinderOnePressureLayCalculateLeft);
            return new SuccessResult(PLCRewinderPressureMessages.Write);
        }


        [SecurityAspect("PLCRewinderPressure.ReadRewinderOnePressureContactSetScaled", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderOnePressureContactSetScaled()//Name:Rew1PresContSetScaled,Addres:DB 91 DBW 322,Data Type:Int
        {
            var rewinderOnePressureContactSetScaled = (decimal)_plcDal.Read(DataType.DataBlock, 91, 322, VarType.Int, 1);

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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOnePressureContactSetScaled = rewinderOnePressureContactSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureContactSetScaled = rewinderOnePressureContactSetScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOnePressureContactSetScaled = rewinderOnePressureContactSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureContactSetScaled = rewinderOnePressureContactSetScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            return new SuccessDataResult<decimal>(rewinderOnePressureContactSetScaled, PLCRewinderPressureMessages.Read);
        }

        [SecurityAspect("PLCRewinderPressure.WriteRewinderOnePressureContactSetScaled", Priority = 2)]
        public async Task<IResult> WriteRewinderOnePressureContactSetScaled(decimal rewinderOnePressureContactSetScaled)//Name:Rew1PresContSetScaled,Addres:DB 91 DBW 322,Data Type:Int
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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOnePressureContactSetScaled = rewinderOnePressureContactSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureContactSetScaled = rewinderOnePressureContactSetScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOnePressureContactSetScaled = rewinderOnePressureContactSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureContactSetScaled = rewinderOnePressureContactSetScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 322, rewinderOnePressureContactSetScaled);
            return new SuccessResult(PLCRewinderPressureMessages.Write);
        }


        [SecurityAspect("PLCRewinderPressure.ReadRewinderOnePressureContactCalculateCharScaled", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderOnePressureContactCalculateCharScaled()//Name:Rew1PresContCalcCharScaled,Addres:DB 90 DBW 326,Data Type:Int
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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOnePressureContactCalculateCharScaled = rewinderOnePressureContactCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureContactCalculateCharScaled = rewinderOnePressureContactCalculateCharScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOnePressureContactCalculateCharScaled = rewinderOnePressureContactCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureContactCalculateCharScaled = rewinderOnePressureContactCalculateCharScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            return new SuccessDataResult<decimal>(rewinderOnePressureContactCalculateCharScaled, PLCRewinderPressureMessages.Read);
        }

        [SecurityAspect("PLCRewinderPressure.WriteRewinderOnePressureContactCalculateCharScaled", Priority = 2)]
        public async Task<IResult> WriteRewinderOnePressureContactCalculateCharScaled(decimal rewinderOnePressureContactCalculateCharScaled)//Name:Rew1PresContCalcCharScaled,Addres:DB 90 DBW 326,Data Type:Int
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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOnePressureContactCalculateCharScaled = rewinderOnePressureContactCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureContactCalculateCharScaled = rewinderOnePressureContactCalculateCharScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOnePressureContactCalculateCharScaled = rewinderOnePressureContactCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureContactCalculateCharScaled = rewinderOnePressureContactCalculateCharScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 326, rewinderOnePressureContactCalculateCharScaled);
            return new SuccessResult(PLCRewinderPressureMessages.Write);
        }


        [SecurityAspect("PLCRewinderPressure.ReadRewinderOnePressureContactBalance", Priority = 2)]
        public async Task<IDataResult<int>> ReadRewinderOnePressureContactBalance()//Name:Rew1PresContBalance,Addres:DB 91 DBW 336, Data Type:Int
        {
            var rewinderOnePressureContactBalance = (int)_plcDal.Read(DataType.DataBlock, 91, 336, VarType.Int, 1);

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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOnePressureContactBalance = rewinderOnePressureContactBalance,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureContactBalance = rewinderOnePressureContactBalance;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOnePressureContactBalance = rewinderOnePressureContactBalance,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureContactBalance = rewinderOnePressureContactBalance;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            return new SuccessDataResult<int>(rewinderOnePressureContactBalance, PLCRewinderPressureMessages.Read);
        }

        [SecurityAspect("PLCRewinderPressure.WriteRewinderOnePressureContactBalance", Priority = 2)]
        public async Task<IResult> WriteRewinderOnePressureContactBalance(int rewinderOnePressureContactBalance)//Name:Rew1PresContBalance,Addres:DB 91 DBW 336,DataType:Int
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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOnePressureContactBalance = rewinderOnePressureContactBalance,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureContactBalance = rewinderOnePressureContactBalance;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOnePressureContactBalance = rewinderOnePressureContactBalance,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureContactBalance = rewinderOnePressureContactBalance;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 336, rewinderOnePressureContactBalance);
            return new SuccessResult(PLCRewinderPressureMessages.Write);
        }


        [SecurityAspect("PLCRewinderPressure.ReadRewinderOnePressureContactCalculateRight", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderOnePressureContactCalculateRight()//Name:Rew1PresContCalcRight,Addres:DB 90 DBW 334,Data Type:Int
        {
            var rewinderOnePressureContactCalculateRight = (decimal)_plcDal.Read(DataType.DataBlock, 90, 334, VarType.Int, 1);

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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOnePressureContactCalculateRight = rewinderOnePressureContactCalculateRight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureContactCalculateRight = rewinderOnePressureContactCalculateRight;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOnePressureContactCalculateRight = rewinderOnePressureContactCalculateRight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureContactCalculateRight = rewinderOnePressureContactCalculateRight;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            return new SuccessDataResult<decimal>(rewinderOnePressureContactCalculateRight, PLCRewinderPressureMessages.Read);
        }

        [SecurityAspect("PLCRewinderPressure.WriteRewinderOnePressureContactCalculateRight", Priority = 2)]
        public async Task<IResult> WriteRewinderOnePressureContactCalculateRight(decimal rewinderOnePressureContactCalculateRight)//Name:Rew1PresContCalcRight,Addres:DB 90 DBW 334,Data Type:Int
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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOnePressureContactCalculateRight = rewinderOnePressureContactCalculateRight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureContactCalculateRight = rewinderOnePressureContactCalculateRight;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOnePressureContactCalculateRight = rewinderOnePressureContactCalculateRight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureContactCalculateRight = rewinderOnePressureContactCalculateRight;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 334, rewinderOnePressureContactCalculateRight);
            return new SuccessResult(PLCRewinderPressureMessages.Write);
        }


        [SecurityAspect("PLCRewinderPressure.ReadRewinderOnePressureContactCalculateLeft", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderOnePressureContactCalculateLeft()//Name:Rew1PresContCalcLeft,Addres:DB 90 DBW 332,Data Type:Int
        {
            var rewinderOnePressureContactCalculateLeft = (decimal)_plcDal.Read(DataType.DataBlock, 90, 332, VarType.Int, 1);

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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOnePressureContactCalculateLeft = rewinderOnePressureContactCalculateLeft,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureContactCalculateLeft = rewinderOnePressureContactCalculateLeft;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOnePressureContactCalculateLeft = rewinderOnePressureContactCalculateLeft,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureContactCalculateLeft = rewinderOnePressureContactCalculateLeft;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            return new SuccessDataResult<decimal>(rewinderOnePressureContactCalculateLeft, PLCRewinderPressureMessages.Read);
        }

        [SecurityAspect("PLCRewinderPressure.WriteRewinderOnePressureContactCalculateLeft", Priority = 2)]
        public async Task<IResult> WriteRewinderOnePressureContactCalculateLeft(decimal rewinderOnePressureContactCalculateLeft)//Name:Rew1PresContCalcLeft,Addres:DB 90 DBW 332,Data Type:Int
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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOnePressureContactCalculateLeft = rewinderOnePressureContactCalculateLeft,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureContactCalculateLeft = rewinderOnePressureContactCalculateLeft;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOnePressureContactCalculateLeft = rewinderOnePressureContactCalculateLeft,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderOnePressureContactCalculateLeft = rewinderOnePressureContactCalculateLeft;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 332, rewinderOnePressureContactCalculateLeft);
            return new SuccessResult(PLCRewinderPressureMessages.Write);
        }


        [SecurityAspect("PLCRewinderPressure.ReadRewinderTwoPressureContanctSetScaled", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderTwoPressureContanctSetScaled()//Name:Rew2PresContSetScaled,Addres:DB 91 DBW 422,Data Type:Int
        {
            var rewinderTwoPressureContanctSetScaled = (decimal)_plcDal.Read(DataType.DataBlock, 91, 422, VarType.Int, 1);

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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoPressureContanctSetScaled = rewinderTwoPressureContanctSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureContanctSetScaled = rewinderTwoPressureContanctSetScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoPressureContanctSetScaled = rewinderTwoPressureContanctSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureContanctSetScaled = rewinderTwoPressureContanctSetScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            return new SuccessDataResult<decimal>(rewinderTwoPressureContanctSetScaled, PLCRewinderPressureMessages.Read);
        }

        [SecurityAspect("PLCRewinderPressure.WriteRewinderTwoPressureContanctSetScaled", Priority = 2)]
        public async Task<IResult> WriteRewinderTwoPressureContanctSetScaled(decimal rewinderTwoPressureContanctSetScaled)//Name:Rew2PresContSetScaled,Addres:DB 91 DBW 422,Data Type:Int
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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoPressureContanctSetScaled = rewinderTwoPressureContanctSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureContanctSetScaled = rewinderTwoPressureContanctSetScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoPressureContanctSetScaled = rewinderTwoPressureContanctSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureContanctSetScaled = rewinderTwoPressureContanctSetScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 422, rewinderTwoPressureContanctSetScaled);
            return new SuccessResult(PLCRewinderPressureMessages.Write);
        }


        [SecurityAspect("PLCRewinderPressure.ReadRewinderTwoPressureContactCalculateCharScaled", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderTwoPressureContactCalculateCharScaled()//Name:Rew2PresContCalcCharScaled,Addres:DB 90 DBW 426,Data Type:Int
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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoPressureContactCalculateCharScaled = rewinderTwoPressureContactCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureContactCalculateCharScaled = rewinderTwoPressureContactCalculateCharScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoPressureContactCalculateCharScaled = rewinderTwoPressureContactCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureContactCalculateCharScaled = rewinderTwoPressureContactCalculateCharScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            return new SuccessDataResult<decimal>(rewinderTwoPressureContactCalculateCharScaled, PLCRewinderPressureMessages.Read);
        }

        [SecurityAspect("PLCRewinderPressure.WriteRewinderTwoPressureContactCalculateCharScaled", Priority = 2)]
        public async Task<IResult> WriteRewinderTwoPressureContactCalculateCharScaled(decimal rewinderTwoPressureContactCalculateCharScaled)//Name:Rew2PresContCalcCharScaled,Addres:DB 90 DBW 426,Data Type:Int
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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoPressureContactCalculateCharScaled = rewinderTwoPressureContactCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureContactCalculateCharScaled = rewinderTwoPressureContactCalculateCharScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoPressureContactCalculateCharScaled = rewinderTwoPressureContactCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureContactCalculateCharScaled = rewinderTwoPressureContactCalculateCharScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 426, rewinderTwoPressureContactCalculateCharScaled);
            return new SuccessResult(PLCRewinderPressureMessages.Write);
        }


        [SecurityAspect("PLCRewinderPressure.ReadRewinderTwoPressureContanctBalance", Priority = 2)]
        public async Task<IDataResult<int>> ReadRewinderTwoPressureContanctBalance()//Name:Rew2PresContBalance,Addres:DB 91 DBW 436,Data Type:Int
        {
            var rewinderTwoPressureContanctBalance = (int)_plcDal.Read(DataType.DataBlock, 91, 436, VarType.Int, 1);

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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoPressureContanctBalance = rewinderTwoPressureContanctBalance,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureContanctBalance = rewinderTwoPressureContanctBalance;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoPressureContanctBalance = rewinderTwoPressureContanctBalance,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureContanctBalance = rewinderTwoPressureContanctBalance;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            return new SuccessDataResult<int>(rewinderTwoPressureContanctBalance, PLCRewinderPressureMessages.Read);
        }

        [SecurityAspect("PLCRewinderPressure.WriteRewinderTwoPressureContanctBalance", Priority = 2)]
        public async Task<IResult> WriteRewinderTwoPressureContanctBalance(int rewinderTwoPressureContanctBalance)//Name:Rew2PresContBalance,Addres:DB 91 DBW 436,Data Type:Int
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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoPressureContanctBalance = rewinderTwoPressureContanctBalance,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureContanctBalance = rewinderTwoPressureContanctBalance;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoPressureContanctBalance = rewinderTwoPressureContanctBalance,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureContanctBalance = rewinderTwoPressureContanctBalance;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 436, rewinderTwoPressureContanctBalance);
            return new SuccessResult(PLCRewinderPressureMessages.Write);
        }


        [SecurityAspect("PLCRewinderPressure.ReadRewinderTwoPressureContactCalculateRight", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderTwoPressureContactCalculateRight()//Name:Rew2PresContCalcRight,Addres:DB 90 DBW 434,Data Type:Int
        {
            var rewinderTwoPressureContactCalculateRight = (decimal)_plcDal.Read(DataType.DataBlock, 90, 434, VarType.Int, 1);

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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoPressureContactCalculateRight = rewinderTwoPressureContactCalculateRight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureContactCalculateRight = rewinderTwoPressureContactCalculateRight;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoPressureContactCalculateRight = rewinderTwoPressureContactCalculateRight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureContactCalculateRight = rewinderTwoPressureContactCalculateRight;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            return new SuccessDataResult<decimal>(rewinderTwoPressureContactCalculateRight, PLCRewinderPressureMessages.Read);
        }

        [SecurityAspect("PLCRewinderPressure.WriteRewinderTwoPressureContactCalculateRight", Priority = 2)]
        public async Task<IResult> WriteRewinderTwoPressureContactCalculateRight(decimal rewinderTwoPressureContactCalculateRight)//Name:Rew2PresContCalcRight,Addres:DB 90 DBW 434,Data Type:Int
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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoPressureContactCalculateRight = rewinderTwoPressureContactCalculateRight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureContactCalculateRight = rewinderTwoPressureContactCalculateRight;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoPressureContactCalculateRight = rewinderTwoPressureContactCalculateRight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureContactCalculateRight = rewinderTwoPressureContactCalculateRight;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 434, rewinderTwoPressureContactCalculateRight);
            return new SuccessResult(PLCRewinderPressureMessages.Write);
        }


        [SecurityAspect("PLCRewinderPressure.ReadRewinderTwoPressureContactCalculateLeft", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderTwoPressureContactCalculateLeft()//Name:Rew2PresContCalcLeft,Addres:DB 90 DBW 432,Data Type:Int
        {
            var rewinderTwoPressureContactCalculateLeft = (decimal)_plcDal.Read(DataType.DataBlock, 90, 432, VarType.Int, 1);

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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoPressureContactCalculateLeft = rewinderTwoPressureContactCalculateLeft,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureContactCalculateLeft = rewinderTwoPressureContactCalculateLeft;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoPressureContactCalculateLeft = rewinderTwoPressureContactCalculateLeft,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureContactCalculateLeft = rewinderTwoPressureContactCalculateLeft;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            return new SuccessDataResult<decimal>(rewinderTwoPressureContactCalculateLeft, PLCRewinderPressureMessages.Read);
        }

        [SecurityAspect("PLCRewinderPressure.WriteRewinderTwoPressureContactCalculateLeft", Priority = 2)]
        public async Task<IResult> WriteRewinderTwoPressureContactCalculateLeft(decimal rewinderTwoPressureContactCalculateLeft)//Name:Rew2PresContCalcLeft,Addres:DB 90 DBW 432,Data Type:Int
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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoPressureContactCalculateLeft = rewinderTwoPressureContactCalculateLeft,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureContactCalculateLeft = rewinderTwoPressureContactCalculateLeft;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoPressureContactCalculateLeft = rewinderTwoPressureContactCalculateLeft,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureContactCalculateLeft = rewinderTwoPressureContactCalculateLeft;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 432, rewinderTwoPressureContactCalculateLeft);
            return new SuccessResult(PLCRewinderPressureMessages.Write);
        }


        [SecurityAspect("PLCRewinderPressure.ReadRewinderTwoPressureSupportSetScaled", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderTwoPressureSupportSetScaled()//Name:Rew2PresSupSetScaled,Addres:DB 91 DBW 452,Data Type:Int
        {
            var rewinderTwoPressureSupportSetScaled = (decimal)_plcDal.Read(DataType.DataBlock, 91, 452, VarType.Int, 1);

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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoPressureSupportSetScaled = rewinderTwoPressureSupportSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureSupportSetScaled = rewinderTwoPressureSupportSetScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoPressureSupportSetScaled = rewinderTwoPressureSupportSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureSupportSetScaled = rewinderTwoPressureSupportSetScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            return new SuccessDataResult<decimal>(rewinderTwoPressureSupportSetScaled, PLCRewinderPressureMessages.Read);
        }

        [SecurityAspect("PLCRewinderPressure.WriteRewinderTwoPressureSupportSetScaled", Priority = 2)]
        public async Task<IResult> WriteRewinderTwoPressureSupportSetScaled(decimal rewinderTwoPressureSupportSetScaled)//Name:Rew2PresSupSetScaled,Addres:DB 91 DBW 452,Data Type:Int
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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoPressureSupportSetScaled = rewinderTwoPressureSupportSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureSupportSetScaled = rewinderTwoPressureSupportSetScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoPressureSupportSetScaled = rewinderTwoPressureSupportSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureSupportSetScaled = rewinderTwoPressureSupportSetScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 452, rewinderTwoPressureSupportSetScaled);
            return new SuccessResult(PLCRewinderPressureMessages.Write);
        }


        [SecurityAspect("PLCRewinderPressure.ReadRewinderTwoPressureSupportCalculateCharScaled", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderTwoPressureSupportCalculateCharScaled()//Name:Rew2PresSupCalcCharScaled,Addres:DB 90 DBW 456,Data Type:Int
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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoPressureSupportCalculateCharScaled = rewinderTwoPressureSupportCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureSupportCalculateCharScaled = rewinderTwoPressureSupportCalculateCharScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoPressureSupportCalculateCharScaled = rewinderTwoPressureSupportCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureSupportCalculateCharScaled = rewinderTwoPressureSupportCalculateCharScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            return new SuccessDataResult<decimal>(rewinderTwoPressureSupportCalculateCharScaled, PLCRewinderPressureMessages.Read);
        }

        [SecurityAspect("PLCRewinderPressure.WriteRewinderTwoPressureSupportCalculateCharScaled", Priority = 2)]
        public async Task<IResult> WriteRewinderTwoPressureSupportCalculateCharScaled(decimal rewinderTwoPressureSupportCalculateCharScaled)//Name:Rew2PresSupCalcCharScaled,Addres:DB 90 DBW 456,Data Type:Int
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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoPressureSupportCalculateCharScaled = rewinderTwoPressureSupportCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureSupportCalculateCharScaled = rewinderTwoPressureSupportCalculateCharScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoPressureSupportCalculateCharScaled = rewinderTwoPressureSupportCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureSupportCalculateCharScaled = rewinderTwoPressureSupportCalculateCharScaled;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 456, rewinderTwoPressureSupportCalculateCharScaled);
            return new SuccessResult(PLCRewinderPressureMessages.Write);
        }


        [SecurityAspect("PLCRewinderPressure.ReadRewinderTwoPressureSupportBalance", Priority = 2)]
        public async Task<IDataResult<int>> ReadRewinderTwoPressureSupportBalance()//Name:Rew2PresSupCalcCharScaled,Addres:DB 91 DBW 466,Data Type:Int
        {
            var rewinderTwoPressureSupportBalance = (int)_plcDal.Read(DataType.DataBlock, 91, 466, VarType.Int, 1);

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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoPressureSupportBalance = rewinderTwoPressureSupportBalance,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureSupportBalance = rewinderTwoPressureSupportBalance;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoPressureSupportBalance = rewinderTwoPressureSupportBalance,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureSupportBalance = rewinderTwoPressureSupportBalance;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            return new SuccessDataResult<int>(rewinderTwoPressureSupportBalance, PLCRewinderPressureMessages.Read);
        }

        [SecurityAspect("PLCRewinderPressure.WriteRewinderTwoPressureSupportBalance", Priority = 2)]
        public async Task<IResult> WriteRewinderTwoPressureSupportBalance(int rewinderTwoPressureSupportBalance)//Name:Rew2PresSupCalcCharScaled,Addres:DB 91 DBW 466,Data Type:Int
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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoPressureSupportBalance = rewinderTwoPressureSupportBalance,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureSupportBalance = rewinderTwoPressureSupportBalance;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoPressureSupportBalance = rewinderTwoPressureSupportBalance,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureSupportBalance = rewinderTwoPressureSupportBalance;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 466, rewinderTwoPressureSupportBalance);
            return new SuccessResult(PLCRewinderPressureMessages.Write);
        }


        [SecurityAspect("PLCRewinderPressure.ReadRewinderTwoPressureSupportCalcuteRight", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderTwoPressureSupportCalcuteRight()//Name:Rew2PresSupCalcRight,Addres:DB 90 DBW 464,Data Type:Int
        {
            var rewinderTwoPressureSupportCalcuteRight = (decimal)_plcDal.Read(DataType.DataBlock, 90, 464, VarType.Int, 1);

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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoPressureSupportCalcuteRight = rewinderTwoPressureSupportCalcuteRight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureSupportCalcuteRight = rewinderTwoPressureSupportCalcuteRight;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoPressureSupportCalcuteRight = rewinderTwoPressureSupportCalcuteRight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureSupportCalcuteRight = rewinderTwoPressureSupportCalcuteRight;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            return new SuccessDataResult<decimal>(rewinderTwoPressureSupportCalcuteRight, PLCRewinderPressureMessages.Read);
        }

        [SecurityAspect("PLCRewinderPressure.WriteRewinderTwoPressureSupportCalcuteRight", Priority = 2)]
        public async Task<IResult> WriteRewinderTwoPressureSupportCalcuteRight(decimal rewinderTwoPressureSupportCalcuteRight)//Name:Rew2PresSupCalcRight,Addres:DB 90 DBW 464,Data Type:Int
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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoPressureSupportCalcuteRight = rewinderTwoPressureSupportCalcuteRight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureSupportCalcuteRight = rewinderTwoPressureSupportCalcuteRight;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoPressureSupportCalcuteRight = rewinderTwoPressureSupportCalcuteRight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureSupportCalcuteRight = rewinderTwoPressureSupportCalcuteRight;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 464, rewinderTwoPressureSupportCalcuteRight);
            return new SuccessResult(PLCRewinderPressureMessages.Write);
        }


        [SecurityAspect("PLCRewinderPressure.ReadRewinderTwoPressureSupportCalcuteLeft", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderTwoPressureSupportCalcuteLeft()//Name:Rew2PresSupCalcLeft,Addres:DB 90 DBW 462,Data Type:Int
        {
            var rewinderTwoPressureSupportCalcuteLeft = (decimal)_plcDal.Read(DataType.DataBlock, 90, 462, VarType.Int, 1);

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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoPressureSupportCalcuteLeft = rewinderTwoPressureSupportCalcuteLeft,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureSupportCalcuteLeft = rewinderTwoPressureSupportCalcuteLeft;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoPressureSupportCalcuteLeft = rewinderTwoPressureSupportCalcuteLeft,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureSupportCalcuteLeft = rewinderTwoPressureSupportCalcuteLeft;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            return new SuccessDataResult<decimal>(rewinderTwoPressureSupportCalcuteLeft, PLCRewinderPressureMessages.Read);
        }

        [SecurityAspect("PLCRewinderPressure.WriteRewinderTwoPressureSupportCalcuteLeft", Priority = 2)]
        public async Task<IResult> WriteRewinderTwoPressureSupportCalcuteLeft(decimal rewinderTwoPressureSupportCalcuteLeft)//Name:Rew2PresSupCalcLeft,Addres:DB 90 DBW 462,Data Type:Int
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

                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoPressureSupportCalcuteLeft = rewinderTwoPressureSupportCalcuteLeft,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureSupportCalcuteLeft = rewinderTwoPressureSupportCalcuteLeft;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }
            else
            {
                var plcRewinderPressure = await _plcRewinderPressureDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderPressure == null)
                {
                    var plcRewinderPressureId = Guid.NewGuid();
                    plcRewinderPressure = new PLCRewinderPressure
                    {
                        Id = plcRewinderPressureId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoPressureSupportCalcuteLeft = rewinderTwoPressureSupportCalcuteLeft,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderPressureDal.Add(plcRewinderPressure);
                }
                else
                {
                    plcRewinderPressure.RewinderTwoPressureSupportCalcuteLeft = rewinderTwoPressureSupportCalcuteLeft;
                    await _plcRewinderPressureDal.Update(plcRewinderPressure);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 462, rewinderTwoPressureSupportCalcuteLeft);
            return new SuccessResult(PLCRewinderPressureMessages.Write);
        }

    }
}
