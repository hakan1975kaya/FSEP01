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
    public class PLCHandlingManager : IPLCHandlingService
    {
        private IPLCDal _plcDal;
        private IPLCGeneralDal _plcGeneralDal;
        private IPLCHandlingDal _plcHandlingDal;
        private string _recipeNameLast;
        public PLCHandlingManager(IPLCDal plcDal, IPLCGeneralDal plcGeneralDal, IPLCHandlingDal plcHandlingDa)
        {
            _plcDal = plcDal;
            _plcGeneralDal = plcGeneralDal;
            _plcHandlingDal = plcHandlingDa;
            _recipeNameLast = (string)_plcDal.Read(DataType.DataBlock, 90, 40, VarType.String, 1);
        }

        //Read Only
        [SecurityAspect("PLCHandling.ReadPositionHandling", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadPositionHandling()//Name:Pos_Handling,Adress:DB 233 DBD 44,Data Type:DInt
        {
            var positionHandling = (decimal)_plcDal.Read(DataType.DataBlock, 233, 44, VarType.DInt, 1);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        PositionHandling = positionHandling,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.PositionHandling = positionHandling;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        PositionHandling = positionHandling,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.PositionHandling = positionHandling;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<decimal>(positionHandling, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WritePositionHandling", Priority = 2)]
        public async Task<IResult> WritePositionHandling(decimal positionHandling)//Name:Pos_Handling,Adress:DB 233 DBD 44,Data Type:DInt
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        PositionHandling = positionHandling,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.PositionHandling = positionHandling;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        PositionHandling = positionHandling,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.PositionHandling = positionHandling;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.DataBlock, 233, 44, positionHandling);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadPositionHandlingLiftOne", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadPositionHandlingLiftOne()//Name:Pos_Handling_Lift_1,Adress:DB 230 DBD 44,Data Type:DInt
        {
            var positionHandlingLiftOne = (decimal)_plcDal.Read(DataType.DataBlock, 230, 44, VarType.DInt, 1);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        PositionHandlingLiftOne = positionHandlingLiftOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.PositionHandlingLiftOne = positionHandlingLiftOne;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        PositionHandlingLiftOne = positionHandlingLiftOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.PositionHandlingLiftOne = positionHandlingLiftOne;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<decimal>(positionHandlingLiftOne, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WritePositionHandlingLiftOne", Priority = 2)]
        public async Task<IResult> WritePositionHandlingLiftOne(decimal positionHandlingLiftOne)//Name:Pos_Handling_Lift_1,Adress:DB 230 DBD 44,Data Type:DInt
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        PositionHandlingLiftOne = positionHandlingLiftOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.PositionHandlingLiftOne = positionHandlingLiftOne;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        PositionHandlingLiftOne = positionHandlingLiftOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.PositionHandlingLiftOne = positionHandlingLiftOne;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.DataBlock, 230, 44, positionHandlingLiftOne);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadPositionHandlingLiftTwo", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadPositionHandlingLiftTwo()//Name:Pos_Handling_Lift_2,Adress:DB 231 DBD 44,Data Type:IDnt
        {
            var positionHandlingLiftTwo = (decimal)_plcDal.Read(DataType.DataBlock, 231, 44, VarType.DInt, 1);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        PositionHandlingLiftTwo = positionHandlingLiftTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.PositionHandlingLiftTwo = positionHandlingLiftTwo;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        PositionHandlingLiftTwo = positionHandlingLiftTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.PositionHandlingLiftTwo = positionHandlingLiftTwo;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<decimal>(positionHandlingLiftTwo, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WritePositionHandlingLiftTwo", Priority = 2)]
        public async Task<IResult> WritePositionHandlingLiftTwo(decimal positionHandlingLiftTwo)//Name:Pos_Handling_Lift_2,Adress:DB 231 DBD 44,Data Type:DInt
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        PositionHandlingLiftTwo = positionHandlingLiftTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.PositionHandlingLiftTwo = positionHandlingLiftTwo;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        PositionHandlingLiftTwo = positionHandlingLiftTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.PositionHandlingLiftTwo = positionHandlingLiftTwo;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.DataBlock, 231, 44, positionHandlingLiftTwo);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadHandlingPositionOne", Priority = 2)]
        public async Task<IDataResult<long>> ReadHandlingPositionOne()//Name:Handling_Set_Pos1,Adress:DB 233 DBD 68,Data Type:Real
        {
            var handlingPositionOne = (long)_plcDal.Read(DataType.DataBlock, 233, 68, VarType.Real, 1);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        HandlingPositionOne = handlingPositionOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.HandlingPositionOne = handlingPositionOne;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        HandlingPositionOne = handlingPositionOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.HandlingPositionOne = handlingPositionOne;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<long>(handlingPositionOne, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteHandlingPositionOne", Priority = 2)]
        public async Task<IResult> WriteHandlingPositionOne(long handlingPositionOne)//Name:Handling_Set_Pos1,Adress:DB 233 DBD 68,Data Type:Real
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        HandlingPositionOne = handlingPositionOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.HandlingPositionOne = handlingPositionOne;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        HandlingPositionOne = handlingPositionOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.HandlingPositionOne = handlingPositionOne;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.DataBlock, 233, 68, handlingPositionOne);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadHandlingPositionTwo", Priority = 2)]
        public async Task<IDataResult<long>> ReadHandlingPositionTwo()//Name:Handling_Set_Pos2,Adress:DB 233 DBD 72,Data Type:Real
        {
            var handlingPositionTwo = (long)_plcDal.Read(DataType.DataBlock, 233, 72, VarType.Real, 1);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        HandlingPositionTwo = handlingPositionTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.HandlingPositionTwo = handlingPositionTwo;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        HandlingPositionTwo = handlingPositionTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.HandlingPositionTwo = handlingPositionTwo;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<long>(handlingPositionTwo, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteHandlingPositionTwo", Priority = 2)]
        public async Task<IResult> WriteHandlingPositionTwo(long handlingPositionTwo)//Name:Handling_Set_Pos2,Adress:DB 233 DBD 72,Data Type:Real
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        HandlingPositionTwo = handlingPositionTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.HandlingPositionTwo = handlingPositionTwo;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        HandlingPositionTwo = handlingPositionTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.HandlingPositionTwo = handlingPositionTwo;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.DataBlock, 233, 72, handlingPositionTwo);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadHandlingPositionThree", Priority = 2)]
        public async Task<IDataResult<long>> ReadHandlingPositionThree()//Name:Handling_Set_Pos4,Adress:DB 233 DBD 76,Data Type:Real
        {
            var handlingPositionThree = (long)_plcDal.Read(DataType.DataBlock, 233, 76, VarType.Real, 1);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        HandlingPositionThree = handlingPositionThree,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.HandlingPositionThree = handlingPositionThree;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        HandlingPositionThree = handlingPositionThree,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.HandlingPositionThree = handlingPositionThree;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<long>(handlingPositionThree, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteHandlingPositionThree", Priority = 2)]
        public async Task<IResult> WriteHandlingPositionThree(long handlingPositionThree)//Name:Handling_Set_Pos4,Adress:DB 233 DBD 76,Data Type:Real
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        HandlingPositionThree = handlingPositionThree,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.HandlingPositionThree = handlingPositionThree;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        HandlingPositionThree = handlingPositionThree,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.HandlingPositionThree = handlingPositionThree;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.DataBlock, 233, 76, handlingPositionThree);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadHandlingPositionFour", Priority = 2)]
        public async Task<IDataResult<long>> ReadHandlingPositionFour()//Name:Handling_Set_Pos4,Adress:DB 233 DBD 80,Data Type:Real
        {
            var handlingPositionFour = (long)_plcDal.Read(DataType.DataBlock, 233, 80, VarType.Real, 1);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        HandlingPositionFour = handlingPositionFour,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.HandlingPositionFour = handlingPositionFour;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        HandlingPositionFour = handlingPositionFour,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.HandlingPositionFour = handlingPositionFour;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<long>(handlingPositionFour, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteHandlingPositionFour", Priority = 2)]
        public async Task<IResult> WriteHandlingPositionFour(long handlingPositionFour)//Name:Handling_Set_Pos4,Adress:DB 233 DBD 80,Data Type:Real
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        HandlingPositionFour = handlingPositionFour,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.HandlingPositionFour = handlingPositionFour;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        HandlingPositionFour = handlingPositionFour,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.HandlingPositionFour = handlingPositionFour;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.DataBlock, 233, 80, handlingPositionFour);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadHandlingPositionFive", Priority = 2)]
        public async Task<IDataResult<long>> ReadHandlingPositionFive()//Name:Handling_Set_Pos5,Adress:DB 233 DBD 84,Data Type:Real
        {
            var handlingPositionFive = (long)_plcDal.Read(DataType.DataBlock, 233, 84, VarType.Real, 1);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        HandlingPositionFive = handlingPositionFive,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.HandlingPositionFive = handlingPositionFive;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        HandlingPositionFive = handlingPositionFive,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.HandlingPositionFive = handlingPositionFive;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<long>(handlingPositionFive, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteHandlingPositionFive", Priority = 2)]
        public async Task<IResult> WriteHandlingPositionFive(long handlingPositionFive)//Name:Handling_Set_Pos5,Adress:DB 233 DBD 84,Data Type:Real
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        HandlingPositionFive = handlingPositionFive,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.HandlingPositionFive = handlingPositionFive;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        HandlingPositionFive = handlingPositionFive,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.HandlingPositionFive = handlingPositionFive;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.DataBlock, 233, 84, handlingPositionFive);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftOnePositionOne", Priority = 2)]
        public async Task<IDataResult<bool>> ReadLiftOnePositionOne()//Name:Lift1_Pos1,Adress:M 256.0,Data Type:Bool
        {
            var liftOnePositionOne = (bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1, 0);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOnePositionOne = liftOnePositionOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionOne = liftOnePositionOne;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOnePositionOne = liftOnePositionOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionOne = liftOnePositionOne;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<bool>(liftOnePositionOne, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftOnePositionOne", Priority = 2)]
        public async Task<IResult> WriteLiftOnePositionOne(bool liftOnePositionOne)//Name:Lift1_Pos1,Adress:M 256.0,Data Type:Bool
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOnePositionOne = liftOnePositionOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionOne = liftOnePositionOne;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOnePositionOne = liftOnePositionOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionOne = liftOnePositionOne;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionOne, 0);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftOnePositionTwo", Priority = 2)]
        public async Task<IDataResult<bool>> ReadLiftOnePositionTwo()//Name:Lift1_Pos2,Adress:M 256.1,Data Type:Bool
        {
            var liftOnePositionTwo = (bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1, 1);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOnePositionTwo = liftOnePositionTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionTwo = liftOnePositionTwo;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOnePositionTwo = liftOnePositionTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionTwo = liftOnePositionTwo;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<bool>(liftOnePositionTwo, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftOnePositionTwo", Priority = 2)]
        public async Task<IResult> WriteLiftOnePositionTwo(bool liftOnePositionTwo)//Name:Lift1_Pos2,Adress:M 256.1,Data Type:Bool
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOnePositionTwo = liftOnePositionTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionTwo = liftOnePositionTwo;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOnePositionTwo = liftOnePositionTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionTwo = liftOnePositionTwo;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionTwo, 1);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftOnePositionThree", Priority = 2)]
        public async Task<IDataResult<bool>> ReadLiftOnePositionThree()//Name:Lift1_Pos3,Adress:M 256.2,Data Type:Bool
        {
            var liftOnePositionThree = (bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1, 2);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOnePositionThree = liftOnePositionThree,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionThree = liftOnePositionThree;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOnePositionThree = liftOnePositionThree,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionThree = liftOnePositionThree;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<bool>(liftOnePositionThree, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftOnePositionThree", Priority = 2)]
        public async Task<IResult> WriteLiftOnePositionThree(bool liftOnePositionThree)//Name:Lift1_Pos3,Adress:M 256.2,Data Type:Bool
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOnePositionThree = liftOnePositionThree,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionThree = liftOnePositionThree;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOnePositionThree = liftOnePositionThree,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionThree = liftOnePositionThree;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionThree, 2);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftOnePositionFour", Priority = 2)]
        public async Task<IDataResult<bool>> ReadLiftOnePositionFour()//Name:Lift1_Pos4,Adress:M 256.3,Data Type:Bool
        {
            var liftOnePositionFour = (bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1, 3);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOnePositionFour = liftOnePositionFour,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionFour = liftOnePositionFour;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOnePositionFour = liftOnePositionFour,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionFour = liftOnePositionFour;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<bool>(liftOnePositionFour, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftOnePositionFour", Priority = 2)]
        public async Task<IResult> WriteLiftOnePositionFour(bool liftOnePositionFour)//Name:Lift1_Pos4,Adress:M 256.3,Data Type:Bool
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOnePositionFour = liftOnePositionFour,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionFour = liftOnePositionFour;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOnePositionFour = liftOnePositionFour,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionFour = liftOnePositionFour;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionFour, 3);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftOnePositionFive", Priority = 2)]
        public async Task<IDataResult<bool>> ReadLiftOnePositionFive()//Name:Lift1_Pos5,Adress:M 256.4,Data Type:Bool
        {
            var liftOnePositionFive = (bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1, 4);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOnePositionFive = liftOnePositionFive,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionFive = liftOnePositionFive;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOnePositionFive = liftOnePositionFive,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionFive = liftOnePositionFive;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<bool>(liftOnePositionFive, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftOnePositionFive", Priority = 2)]
        public async Task<IResult> WriteLiftOnePositionFive(bool liftOnePositionFive)//Name:Lift1_Pos5,Adress:M 256.4,Data Type:Bool
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOnePositionFive = liftOnePositionFive,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionFive = liftOnePositionFive;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOnePositionFive = liftOnePositionFive,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionFive = liftOnePositionFive;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionFive, 4);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftOnePositionSix", Priority = 2)]
        public async Task<IDataResult<bool>> ReadLiftOnePositionSix()//Name:Lift1_Pos6,Adress:M 256.5,Data Type:Bool
        {
            var liftOnePositionSix = (bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1, 5);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOnePositionSix = liftOnePositionSix,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionSix = liftOnePositionSix;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOnePositionSix = liftOnePositionSix,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionSix = liftOnePositionSix;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<bool>(liftOnePositionSix, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftOnePositionSix", Priority = 2)]
        public async Task<IResult> WriteLiftOnePositionSix(bool liftOnePositionSix)//Name:Lift1_Pos6,Adress:M 256.5,Data Type:Bool
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOnePositionSix = liftOnePositionSix,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionSix = liftOnePositionSix;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOnePositionSix = liftOnePositionSix,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionSix = liftOnePositionSix;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionSix, 5);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftOnePositionSeven", Priority = 2)]
        public async Task<IDataResult<bool>> ReadLiftOnePositionSeven()//Name:Lift1_Pos7,Adress:M 256.6,Data Type:Bool
        {
            var liftOnePositionSeven = (bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1, 6);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOnePositionSeven = liftOnePositionSeven,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionSeven = liftOnePositionSeven;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOnePositionSeven = liftOnePositionSeven,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionSeven = liftOnePositionSeven;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<bool>(liftOnePositionSeven, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftOnePositionSeven", Priority = 2)]
        public async Task<IResult> WriteLiftOnePositionSeven(bool liftOnePositionSeven)//Name:Lift1_Pos7,Adress:M 256.6,Data Type:Bool
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOnePositionSeven = liftOnePositionSeven,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionSeven = liftOnePositionSeven;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOnePositionSeven = liftOnePositionSeven,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionSeven = liftOnePositionSeven;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionSeven, 6);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftOnePositionEight", Priority = 2)]
        public async Task<IDataResult<bool>> ReadLiftOnePositionEight()//Name:Lift1_Pos8,Adress:M 256.7,Data Type:Bool
        {
            var liftOnePositionEight = (bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1, 7);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOnePositionEight = liftOnePositionEight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionEight = liftOnePositionEight;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOnePositionEight = liftOnePositionEight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionEight = liftOnePositionEight;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<bool>(liftOnePositionEight, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftOnePositionEight", Priority = 2)]
        public async Task<IResult> WriteLiftOnePositionEight(bool liftOnePositionEight)//Name:Lift1_Pos8,Adress:M 256.7,Data Type:Bool
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOnePositionEight = liftOnePositionEight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionEight = liftOnePositionEight;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOnePositionEight = liftOnePositionEight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOnePositionEight = liftOnePositionEight;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionEight, 7);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftTwoPositionOne", Priority = 2)]
        public async Task<IDataResult<bool>> ReadLiftTwoPositionOne()//Name:Lift1_Pos1,Adress:M 266.0,Data Type:Bool
        {
            var liftTwoPositionOne = (bool)_plcDal.Read(DataType.Memory, 0, 266, VarType.Bit, 1, 0);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoPositionOne = liftTwoPositionOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionOne = liftTwoPositionOne;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoPositionOne = liftTwoPositionOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionOne = liftTwoPositionOne;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<bool>(liftTwoPositionOne, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftTwoPositionOne", Priority = 2)]
        public async Task<IResult> WriteLiftTwoPositionOne(bool liftTwoPositionOne)//Name:Lift1_Pos1,Adress:M 266.0,Data Type:Bool
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoPositionOne = liftTwoPositionOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionOne = liftTwoPositionOne;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoPositionOne = liftTwoPositionOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionOne = liftTwoPositionOne;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            _plcDal.Write(DataType.Memory, 0, 266, liftTwoPositionOne, 0);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftTwoPositionTwo", Priority = 2)]
        public async Task<IDataResult<bool>> ReadLiftTwoPositionTwo()//Name:Lift1_Pos2,Adress:M 266.1,Data Type:Bool
        {
            var liftTwoPositionTwo = (bool)_plcDal.Read(DataType.Memory, 0, 266, VarType.Bit, 1, 1);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoPositionTwo = liftTwoPositionTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionTwo = liftTwoPositionTwo;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoPositionTwo = liftTwoPositionTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionTwo = liftTwoPositionTwo;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<bool>(liftTwoPositionTwo, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftTwoPositionTwo", Priority = 2)]
        public async Task<IResult> WriteLiftTwoPositionTwo(bool liftTwoPositionTwo)//Name:Lift1_Pos2,Adress:M 266.1,Data Type:Bool
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoPositionTwo = liftTwoPositionTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionTwo = liftTwoPositionTwo;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoPositionTwo = liftTwoPositionTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionTwo = liftTwoPositionTwo;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }


            _plcDal.Write(DataType.Memory, 0, 266, liftTwoPositionTwo, 1);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftTwoPositionThree", Priority = 2)]
        public async Task<IDataResult<bool>> ReadLiftTwoPositionThree()//Name:Lift1_Pos3,Adress:M 266.2,Data Type:Bool
        {
            var liftTwoPositionThree = (bool)_plcDal.Read(DataType.Memory, 0, 266, VarType.Bit, 1, 2);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoPositionThree = liftTwoPositionThree,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionThree = liftTwoPositionThree;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoPositionThree = liftTwoPositionThree,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionThree = liftTwoPositionThree;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<bool>(liftTwoPositionThree, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftTwoPositionThree", Priority = 2)]
        public async Task<IResult> WriteLiftTwoPositionThree(bool liftTwoPositionThree)//Name:Lift1_Pos3,Adress:M 266.2,Data Type:Bool
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoPositionThree = liftTwoPositionThree,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionThree = liftTwoPositionThree;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoPositionThree = liftTwoPositionThree,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionThree = liftTwoPositionThree;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.Memory, 0, 266, liftTwoPositionThree, 2);
            return new SuccessResult(PLCHandlingMessages.Write);
        }



        //Read Onl
        [SecurityAspect("PLCHandling.ReadLiftTwoPositionFour", Priority = 2)]
        public async Task<IDataResult<bool>> ReadLiftTwoPositionFour()//Name:Lift1_Pos4,Adress:M 266.3,Data Type:Bool
        {
            var liftTwoPositionFour = (bool)_plcDal.Read(DataType.Memory, 0, 266, VarType.Bit, 1, 3);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoPositionFour = liftTwoPositionFour,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionFour = liftTwoPositionFour;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoPositionFour = liftTwoPositionFour,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionFour = liftTwoPositionFour;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<bool>(liftTwoPositionFour, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftTwoPositionFour", Priority = 2)]
        public async Task<IResult> WriteLiftTwoPositionFour(bool liftTwoPositionFour)//Name:Lift1_Pos4,Adress:M 266.3,Data Type:Bool
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoPositionFour = liftTwoPositionFour,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionFour = liftTwoPositionFour;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoPositionFour = liftTwoPositionFour,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionFour = liftTwoPositionFour;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.Memory, 0, 266, liftTwoPositionFour, 3);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftTwoPositionFive", Priority = 2)]
        public async Task<IDataResult<bool>> ReadLiftTwoPositionFive()//Name:Lift1_Pos5,Adress:M 266.4,Data Type:Bool
        {
            var liftTwoPositionFive = (bool)_plcDal.Read(DataType.Memory, 0, 266, VarType.Bit, 1, 4);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoPositionFive = liftTwoPositionFive,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionFive = liftTwoPositionFive;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoPositionFive = liftTwoPositionFive,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionFive = liftTwoPositionFive;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<bool>(liftTwoPositionFive, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftTwoPositionFive", Priority = 2)]
        public async Task<IResult> WriteLiftTwoPositionFive(bool liftTwoPositionFive)//Name:Lift1_Pos5,Adress:M 266.4,Data Type:Bool
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoPositionFive = liftTwoPositionFive,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionFive = liftTwoPositionFive;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoPositionFive = liftTwoPositionFive,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionFive = liftTwoPositionFive;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.Memory, 0, 266, liftTwoPositionFive, 4);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftTwoPositionSix", Priority = 2)]
        public async Task<IDataResult<bool>> ReadLiftTwoPositionSix()//Name:Lift1_Pos6,Adress:M 266.5,Data Type:Bool
        {
            var liftTwoPositionSix = (bool)_plcDal.Read(DataType.Memory, 0, 266, VarType.Bit, 1, 5);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoPositionSix = liftTwoPositionSix,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionSix = liftTwoPositionSix;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoPositionSix = liftTwoPositionSix,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionSix = liftTwoPositionSix;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<bool>(liftTwoPositionSix, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftTwoPositionSix", Priority = 2)]
        public async Task<IResult> WriteLiftTwoPositionSix(bool liftTwoPositionSix)//Name:Lift1_Pos6,Adress:M 266.5,Data Type:Bool
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoPositionSix = liftTwoPositionSix,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionSix = liftTwoPositionSix;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoPositionSix = liftTwoPositionSix,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionSix = liftTwoPositionSix;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.Memory, 0, 266, liftTwoPositionSix, 5);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftTwoPositionSeven", Priority = 2)]
        public async Task<IDataResult<bool>> ReadLiftTwoPositionSeven()//Name:Lift1_Pos7,Adress:M 266.6,Data Type:Bool
        {
            var liftTwoPositionSeven = (bool)_plcDal.Read(DataType.Memory, 0, 266, VarType.Bit, 1, 6);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoPositionSeven = liftTwoPositionSeven,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionSeven = liftTwoPositionSeven;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoPositionSeven = liftTwoPositionSeven,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionSeven = liftTwoPositionSeven;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<bool>(liftTwoPositionSeven, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftTwoPositionSeven", Priority = 2)]
        public async Task<IResult> WriteLiftTwoPositionSeven(bool liftTwoPositionSeven)//Name:Lift1_Pos7,Adress:M 266.6,Data Type:Bool
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoPositionSeven = liftTwoPositionSeven,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionSeven = liftTwoPositionSeven;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoPositionSeven = liftTwoPositionSeven,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionSeven = liftTwoPositionSeven;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.Memory, 0, 266, liftTwoPositionSeven, 6);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftTwoPositionEight", Priority = 2)]
        public async Task<IDataResult<bool>> ReadLiftTwoPositionEight()//Name:Lift1_Pos8,Adress:M 266.7,Data Type:Bool
        {
            var liftTwoPositionEight = (bool)_plcDal.Read(DataType.Memory, 0, 266, VarType.Bit, 1, 7);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoPositionEight = liftTwoPositionEight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionEight = liftTwoPositionEight;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoPositionEight = liftTwoPositionEight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionEight = liftTwoPositionEight;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<bool>(liftTwoPositionEight, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftTwoPositionEight", Priority = 2)]
        public async Task<IResult> WriteLiftTwoPositionEight(bool liftTwoPositionEight)//Name:Lift1_Pos8,Adress:M 266.7,Data Type:Bool
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoPositionEight = liftTwoPositionEight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionEight = liftTwoPositionEight;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoPositionEight = liftTwoPositionEight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoPositionEight = liftTwoPositionEight;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.Memory, 0, 266, liftTwoPositionEight, 7);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftOneSetPositionOne", Priority = 2)]
        public async Task<IDataResult<long>> ReadLiftOneSetPositionOne()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 68,Data Type:Real
        {
            var liftOneSetPositionOne = (long)_plcDal.Read(DataType.DataBlock, 230, 68, VarType.Real, 1);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOneSetPositionOne = liftOneSetPositionOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionOne = liftOneSetPositionOne;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOneSetPositionOne = liftOneSetPositionOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionOne = liftOneSetPositionOne;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<long>(liftOneSetPositionOne, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftOneSetPositionOne", Priority = 2)]
        public async Task<IResult> WriteLiftOneSetPositionOne(long liftOneSetPositionOne)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 68,Data Type:Real
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOneSetPositionOne = liftOneSetPositionOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionOne = liftOneSetPositionOne;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOneSetPositionOne = liftOneSetPositionOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionOne = liftOneSetPositionOne;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.DataBlock, 230, 68, liftOneSetPositionOne);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftOneSetPositionTwo", Priority = 2)]
        public async Task<IDataResult<long>> ReadLiftOneSetPositionTwo()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 72,Data Type:Real
        {
            var liftOneSetPositionTwo = (long)_plcDal.Read(DataType.DataBlock, 230, 72, VarType.Real, 1);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOneSetPositionTwo = liftOneSetPositionTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionTwo = liftOneSetPositionTwo;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOneSetPositionTwo = liftOneSetPositionTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionTwo = liftOneSetPositionTwo;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<long>(liftOneSetPositionTwo, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftOneSetPositionTwo", Priority = 2)]
        public async Task<IResult> WriteLiftOneSetPositionTwo(long liftOneSetPositionTwo)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 72,Data Type:Real
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOneSetPositionTwo = liftOneSetPositionTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionTwo = liftOneSetPositionTwo;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOneSetPositionTwo = liftOneSetPositionTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionTwo = liftOneSetPositionTwo;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.DataBlock, 230, 72, liftOneSetPositionTwo);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftOneSetPositionThree", Priority = 2)]
        public async Task<IDataResult<long>> ReadLiftOneSetPositionThree()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 76,Data Type:Real
        {
            var liftOneSetPositionThree = (long)_plcDal.Read(DataType.DataBlock, 230, 76, VarType.Real, 1);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOneSetPositionThree = liftOneSetPositionThree,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionThree = liftOneSetPositionThree;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOneSetPositionThree = liftOneSetPositionThree,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionThree = liftOneSetPositionThree;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<long>(liftOneSetPositionThree, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftOneSetPositionThree", Priority = 2)]
        public async Task<IResult> WriteLiftOneSetPositionThree(long liftOneSetPositionThree)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 76,Data Type:Real
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOneSetPositionThree = liftOneSetPositionThree,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionThree = liftOneSetPositionThree;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOneSetPositionThree = liftOneSetPositionThree,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionThree = liftOneSetPositionThree;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.DataBlock, 230, 76, liftOneSetPositionThree);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftOneSetPositionFour", Priority = 2)]
        public async Task<IDataResult<long>> ReadLiftOneSetPositionFour()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 80,Data Type:Real
        {
            var liftOneSetPositionFour = (long)_plcDal.Read(DataType.DataBlock, 230, 80, VarType.Real, 1);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOneSetPositionFour = liftOneSetPositionFour,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionFour = liftOneSetPositionFour;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOneSetPositionFour = liftOneSetPositionFour,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionFour = liftOneSetPositionFour;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<long>(liftOneSetPositionFour, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftOneSetPositionFour", Priority = 2)]
        public async Task<IResult> WriteLiftOneSetPositionFour(long liftOneSetPositionFour)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 80,Data Type:Real
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOneSetPositionFour = liftOneSetPositionFour,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionFour = liftOneSetPositionFour;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOneSetPositionFour = liftOneSetPositionFour,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionFour = liftOneSetPositionFour;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.DataBlock, 230, 80, liftOneSetPositionFour);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftOneSetPositionFive", Priority = 2)]
        public async Task<IDataResult<long>> ReadLiftOneSetPositionFive()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 84,Data Type:Real
        {
            var liftOneSetPositionFive = (long)_plcDal.Read(DataType.DataBlock, 230, 84, VarType.Real, 1);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOneSetPositionFive = liftOneSetPositionFive,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionFive = liftOneSetPositionFive;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOneSetPositionFive = liftOneSetPositionFive,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionFive = liftOneSetPositionFive;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<long>(liftOneSetPositionFive, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftOneSetPositionFive", Priority = 2)]
        public async Task<IResult> WriteLiftOneSetPositionFive(long liftOneSetPositionFive)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 84,Data Type:Real
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOneSetPositionFive = liftOneSetPositionFive,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionFive = liftOneSetPositionFive;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOneSetPositionFive = liftOneSetPositionFive,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionFive = liftOneSetPositionFive;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.DataBlock, 230, 84, liftOneSetPositionFive);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftOneSetPositionSix", Priority = 2)]
        public async Task<IDataResult<long>> ReadLiftOneSetPositionSix()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 88,Data Type:Real
        {
            var liftOneSetPositionSix = (long)_plcDal.Read(DataType.DataBlock, 230, 88, VarType.Real, 1);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOneSetPositionSix = liftOneSetPositionSix,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionSix = liftOneSetPositionSix;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOneSetPositionSix = liftOneSetPositionSix,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionSix = liftOneSetPositionSix;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<long>(liftOneSetPositionSix, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftOneSetPositionSix", Priority = 2)]
        public async Task<IResult> WriteLiftOneSetPositionSix(long liftOneSetPositionSix)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 88,Data Type:Real
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOneSetPositionSix = liftOneSetPositionSix,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionSix = liftOneSetPositionSix;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOneSetPositionSix = liftOneSetPositionSix,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionSix = liftOneSetPositionSix;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.DataBlock, 230, 88, liftOneSetPositionSix);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftOneSetPositionSeven", Priority = 2)]
        public async Task<IDataResult<long>> ReadLiftOneSetPositionSeven()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 92,Data Type:Real
        {
            var liftOneSetPositionSeven = (long)_plcDal.Read(DataType.DataBlock, 230, 92, VarType.Real, 1);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOneSetPositionSeven = liftOneSetPositionSeven,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionSeven = liftOneSetPositionSeven;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOneSetPositionSeven = liftOneSetPositionSeven,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionSeven = liftOneSetPositionSeven;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<long>(liftOneSetPositionSeven, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftOneSetPositionSeven", Priority = 2)]
        public async Task<IResult> WriteLiftOneSetPositionSeven(long liftOneSetPositionSeven)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 92,Data Type:Real
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOneSetPositionSeven = liftOneSetPositionSeven,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionSeven = liftOneSetPositionSeven;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOneSetPositionSeven = liftOneSetPositionSeven,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionSeven = liftOneSetPositionSeven;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.DataBlock, 230, 92, liftOneSetPositionSeven);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftOneSetPositionEight", Priority = 2)]
        public async Task<IDataResult<long>> ReadLiftOneSetPositionEight()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 96,Data Type:Real
        {
            var liftOneSetPositionEight = (long)_plcDal.Read(DataType.DataBlock, 230, 96, VarType.Real, 1);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOneSetPositionEight = liftOneSetPositionEight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionEight = liftOneSetPositionEight;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOneSetPositionEight = liftOneSetPositionEight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionEight = liftOneSetPositionEight;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<long>(liftOneSetPositionEight, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftOneSetPositionEight", Priority = 2)]
        public async Task<IResult> WriteLiftOneSetPositionEight(long liftOneSetPositionEight)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 96,Data Type:Real
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftOneSetPositionEight = liftOneSetPositionEight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionEight = liftOneSetPositionEight;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftOneSetPositionEight = liftOneSetPositionEight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftOneSetPositionEight = liftOneSetPositionEight;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.DataBlock, 230, 96, liftOneSetPositionEight);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftTwoSetPositionOne", Priority = 2)]
        public async Task<IDataResult<long>> ReadLiftTwoSetPositionOne()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 68,Data Type:Real
        {
            var liftTwoSetPositionOne = (long)_plcDal.Read(DataType.DataBlock, 231, 68, VarType.Real, 1);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoSetPositionOne = liftTwoSetPositionOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionOne = liftTwoSetPositionOne;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoSetPositionOne = liftTwoSetPositionOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionOne = liftTwoSetPositionOne;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<long>(liftTwoSetPositionOne, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftTwoSetPositionOne", Priority = 2)]
        public async Task<IResult> WriteLiftTwoSetPositionOne(long liftTwoSetPositionOne)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 68,Data Type:Real
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoSetPositionOne = liftTwoSetPositionOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionOne = liftTwoSetPositionOne;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoSetPositionOne = liftTwoSetPositionOne,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionOne = liftTwoSetPositionOne;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.DataBlock, 231, 68, liftTwoSetPositionOne);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftTwoSetPositionTwo", Priority = 2)]
        public async Task<IDataResult<long>> ReadLiftTwoSetPositionTwo()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 72,Data Type:Real
        {
            var liftTwoSetPositionTwo = (long)_plcDal.Read(DataType.DataBlock, 231, 72, VarType.Real, 1);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoSetPositionTwo = liftTwoSetPositionTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionTwo = liftTwoSetPositionTwo;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoSetPositionTwo = liftTwoSetPositionTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionTwo = liftTwoSetPositionTwo;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<long>(liftTwoSetPositionTwo, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftTwoSetPositionTwo", Priority = 2)]
        public async Task<IResult> WriteLiftTwoSetPositionTwo(long liftTwoSetPositionTwo)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 72,Data Type:Real
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoSetPositionTwo = liftTwoSetPositionTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionTwo = liftTwoSetPositionTwo;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoSetPositionTwo = liftTwoSetPositionTwo,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionTwo = liftTwoSetPositionTwo;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.DataBlock, 231, 72, liftTwoSetPositionTwo);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftTwoSetPositionThree", Priority = 2)]
        public async Task<IDataResult<long>> ReadLiftTwoSetPositionThree()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 76,Data Type:Real
        {
            var liftTwoSetPositionThree = (long)_plcDal.Read(DataType.DataBlock, 231, 76, VarType.Real, 1);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoSetPositionThree = liftTwoSetPositionThree,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionThree = liftTwoSetPositionThree;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoSetPositionThree = liftTwoSetPositionThree,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionThree = liftTwoSetPositionThree;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<long>(liftTwoSetPositionThree, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftTwoSetPositionThree", Priority = 2)]
        public async Task<IResult> WriteLiftTwoSetPositionThree(long liftTwoSetPositionThree)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 76,Data Type:Real
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoSetPositionThree = liftTwoSetPositionThree,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionThree = liftTwoSetPositionThree;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoSetPositionThree = liftTwoSetPositionThree,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionThree = liftTwoSetPositionThree;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.DataBlock, 231, 76, liftTwoSetPositionThree);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftTwoSetPositionFour", Priority = 2)]
        public async Task<IDataResult<long>> ReadLiftTwoSetPositionFour()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 80,Data Type:Real
        {
            var liftTwoSetPositionFour = (long)_plcDal.Read(DataType.DataBlock, 231, 80, VarType.Real, 1);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoSetPositionFour = liftTwoSetPositionFour,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionFour = liftTwoSetPositionFour;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoSetPositionFour = liftTwoSetPositionFour,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionFour = liftTwoSetPositionFour;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<long>(liftTwoSetPositionFour, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftTwoSetPositionFour", Priority = 2)]
        public async Task<IResult> WriteLiftTwoSetPositionFour(long liftTwoSetPositionFour)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 80,Data Type:Real
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoSetPositionFour = liftTwoSetPositionFour,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionFour = liftTwoSetPositionFour;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoSetPositionFour = liftTwoSetPositionFour,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionFour = liftTwoSetPositionFour;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.DataBlock, 231, 80, liftTwoSetPositionFour);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftTwoSetPositionFive", Priority = 2)]
        public async Task<IDataResult<long>> ReadLiftTwoSetPositionFive()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 84,Data Type:Real
        {
            var liftTwoSetPositionFive = (long)_plcDal.Read(DataType.DataBlock, 231, 84, VarType.Real, 1);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoSetPositionFive = liftTwoSetPositionFive,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionFive = liftTwoSetPositionFive;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoSetPositionFive = liftTwoSetPositionFive,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionFive = liftTwoSetPositionFive;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<long>(liftTwoSetPositionFive, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftTwoSetPositionFive", Priority = 2)]
        public async Task<IResult> WriteLiftTwoSetPositionFive(long liftTwoSetPositionFive)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 84,Data Type:Real
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoSetPositionFive = liftTwoSetPositionFive,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionFive = liftTwoSetPositionFive;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoSetPositionFive = liftTwoSetPositionFive,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionFive = liftTwoSetPositionFive;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.DataBlock, 231, 84, liftTwoSetPositionFive);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftTwoSetPositionSix", Priority = 2)]
        public async Task<IDataResult<long>> ReadLiftTwoSetPositionSix()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 88,Data Type:Real
        {
            var liftTwoSetPositionSix = (long)_plcDal.Read(DataType.DataBlock, 231, 88, VarType.Real, 1);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoSetPositionSix = liftTwoSetPositionSix,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionSix = liftTwoSetPositionSix;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoSetPositionSix = liftTwoSetPositionSix,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionSix = liftTwoSetPositionSix;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<long>(liftTwoSetPositionSix, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftTwoSetPositionSix", Priority = 2)]
        public async Task<IResult> WriteLiftTwoSetPositionSix(long liftTwoSetPositionSix)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 88,Data Type:Real
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoSetPositionSix = liftTwoSetPositionSix,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionSix = liftTwoSetPositionSix;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoSetPositionSix = liftTwoSetPositionSix,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionSix = liftTwoSetPositionSix;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.DataBlock, 231, 88, liftTwoSetPositionSix);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftTwoSetPositionSeven", Priority = 2)]
        public async Task<IDataResult<long>> ReadLiftTwoSetPositionSeven()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 92,Data Type:Real
        {
            var liftTwoSetPositionSeven = (long)_plcDal.Read(DataType.DataBlock, 231, 92, VarType.Real, 1);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoSetPositionSeven = liftTwoSetPositionSeven,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionSeven = liftTwoSetPositionSeven;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoSetPositionSeven = liftTwoSetPositionSeven,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionSeven = liftTwoSetPositionSeven;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<long>(liftTwoSetPositionSeven, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftTwoSetPositionSeven", Priority = 2)]
        public async Task<IResult> WriteLiftTwoSetPositionSeven(long liftTwoSetPositionSeven)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 92,Data Type:Real
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoSetPositionSeven = liftTwoSetPositionSeven,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionSeven = liftTwoSetPositionSeven;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoSetPositionSeven = liftTwoSetPositionSeven,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionSeven = liftTwoSetPositionSeven;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.DataBlock, 231, 92, liftTwoSetPositionSeven);
            return new SuccessResult(PLCHandlingMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCHandling.ReadLiftTwoSetPositionEight", Priority = 2)]
        public async Task<IDataResult<long>> ReadLiftTwoSetPositionEight()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 96,Data Type:Real
        {
            var liftTwoSetPositionEight = (long)_plcDal.Read(DataType.DataBlock, 231, 96, VarType.Real, 1);

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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoSetPositionEight = liftTwoSetPositionEight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionEight = liftTwoSetPositionEight;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoSetPositionEight = liftTwoSetPositionEight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionEight = liftTwoSetPositionEight;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            return new SuccessDataResult<long>(liftTwoSetPositionEight, PLCHandlingMessages.Read);
        }

        [SecurityAspect("PLCHandling.WriteLiftTwoSetPositionEight", Priority = 2)]
        public async Task<IResult> WriteLiftTwoSetPositionEight(long liftTwoSetPositionEight)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 96,Data Type:Real
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

                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneralId,
                        LiftTwoSetPositionEight = liftTwoSetPositionEight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionEight = liftTwoSetPositionEight;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }
            else
            {
                var plcHandling = await _plcHandlingDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcHandling == null)
                {
                    var plcHandlingId = Guid.NewGuid();
                    plcHandling = new PLCHandling
                    {
                        Id = plcHandlingId,
                        PLCGeneralId = plcGeneral.Id,
                        LiftTwoSetPositionEight = liftTwoSetPositionEight,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcHandlingDal.Add(plcHandling);
                }
                else
                {
                    plcHandling.LiftTwoSetPositionEight = liftTwoSetPositionEight;
                    await _plcHandlingDal.Update(plcHandling);
                }
            }

            _plcDal.Write(DataType.DataBlock, 231, 96, liftTwoSetPositionEight);
            return new SuccessResult(PLCHandlingMessages.Write);
        }



    }
}
