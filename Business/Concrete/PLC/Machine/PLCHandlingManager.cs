using Business.Abstract.PLC.Machine;
using Business.Constants.Messages.PLC.Machine;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.PLC.General;
using DataAccess.Abstract.PLC.Machine;
using DataAccess.Concrete.EntityFramework.PLC.Machine;
using Entities.Concrete.Entities.PLC.General;
using Entities.Concrete.Entities.PLC.Machine;
using PLC.Abstract;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.PLC.Machine
{
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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

            return new SuccessDataResult<decimal>(positionHandling,PLCHandlingMessages.Read);
        }
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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

            return new SuccessDataResult<decimal>(positionHandlingLiftOne,PLCHandlingMessages.Read);
        }
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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

            return new SuccessDataResult<decimal>(positionHandlingLiftTwo,PLCHandlingMessages.Read);
        }
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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

            return new SuccessDataResult<long>(handlingPositionOne,PLCHandlingMessages.Read);
        }
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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

            return new SuccessDataResult<long>(handlingPositionTwo,PLCHandlingMessages.Read);
        }
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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

            return new SuccessDataResult<long>(handlingPositionThree,PLCHandlingMessages.Read);
        }
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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

            return new SuccessDataResult<long>(handlingPositionFour,PLCHandlingMessages.Read);
        }
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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

            return new SuccessDataResult<long>(handlingPositionFive,PLCHandlingMessages.Read);
        }
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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

            return new SuccessDataResult<bool>(liftOnePositionOne,PLCHandlingMessages.Read);
        }
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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

            return new SuccessDataResult<bool>(liftOnePositionTwo,PLCHandlingMessages.Read);
        }
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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

            return new SuccessDataResult<bool>(liftOnePositionThree,PLCHandlingMessages.Read);
        }
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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

            return new SuccessDataResult<bool>(liftOnePositionFour,PLCHandlingMessages.Read);
        }
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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

            return new SuccessDataResult<bool>(liftOnePositionFive,PLCHandlingMessages.Read);
        }
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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

            return new SuccessDataResult<bool>(liftOnePositionSix,PLCHandlingMessages.Read);
        }
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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

            return new SuccessDataResult<bool>(liftOnePositionSeven,PLCHandlingMessages.Read);
        }
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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

            return new SuccessDataResult<bool>(liftOnePositionEight,PLCHandlingMessages.Read);
        }
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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

            return new SuccessDataResult<bool>(liftTwoPositionOne,PLCHandlingMessages.Read);
        }
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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

            return new SuccessDataResult<bool>(liftTwoPositionTwo,PLCHandlingMessages.Read);
        }
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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

            return new SuccessDataResult<bool>(liftTwoPositionThree,PLCHandlingMessages.Read);
        }
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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

        //Read Only
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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

            return new SuccessDataResult<bool>(liftTwoPositionFour,PLCHandlingMessages.Read);
        }
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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

            return new SuccessDataResult<bool>(liftTwoPositionFive,PLCHandlingMessages.Read);
        }
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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

            return new SuccessDataResult<bool>(liftTwoPositionSix,PLCHandlingMessages.Read);
        }
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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

            return new SuccessDataResult<bool>(liftTwoPositionSeven,PLCHandlingMessages.Read);
        }
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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

            return new SuccessDataResult<bool>(liftTwoPositionEight,PLCHandlingMessages.Read);
        }
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
                        PLCGeneralId = plcHandlingId,
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
                        PLCGeneralId = plcHandlingId,
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
        public async Task<IDataResult<long>> ReadLiftOneSetPositionOne()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 68,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 230, 68, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftOneSetPositionOne(long liftoneSetPositionOne)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 68,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 230, 68, liftoneSetPositionOne);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftOneSetPositionTwo()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 72,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 230, 72, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftOneSetPositionTwo(long liftoneSetPositionTwo)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 72,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 230, 72, liftoneSetPositionTwo);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftOneSetPositionThree()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 76,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 230, 76, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftOneSetPositionThree(long liftoneSetPositionThree)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 76,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 230, 76, liftoneSetPositionThree);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftOneSetPositionFour()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 80,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 230, 80, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftOneSetPositionFour(long liftoneSetPositionFour)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 80,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 230, 80, liftoneSetPositionFour);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftOneSetPositionFive()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 84,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 230, 84, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftOneSetPositionFive(long liftoneSetPositionFive)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 84,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 230, 84, liftoneSetPositionFive);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftOneSetPositionSix()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 88,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 230, 88, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftOneSetPositionSix(long liftoneSetPositionSix)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 88,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 230, 88, liftoneSetPositionSix);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftOneSetPositionSeven()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 92,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 230, 92, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftOneSetPositionSeven(long liftoneSetPositionSeven)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 92,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 230, 92, liftoneSetPositionSeven);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftOneSetPositionEight()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 96,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 230, 96, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftOneSetPositionEight(long liftoneSetPositionEight)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 96,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 230, 96, liftoneSetPositionEight);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftTwoSetPositionOne()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 68,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 231, 68, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftTwoSetPositionOne(long LiftTwoSetPositionOne)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 68,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 231, 68, LiftTwoSetPositionOne);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftTwoSetPositionTwo()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 72,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 231, 72, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftTwoSetPositionTwo(long LiftTwoSetPositionTwo)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 72,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 231, 72, LiftTwoSetPositionTwo);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftTwoSetPositionThree()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 76,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 231, 76, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftTwoSetPositionThree(long LiftTwoSetPositionThree)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 76,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 231, 76, LiftTwoSetPositionThree);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftTwoSetPositionFour()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 80,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 231, 80, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftTwoSetPositionFour(long LiftTwoSetPositionFour)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 80,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 231, 80, LiftTwoSetPositionFour);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftTwoSetPositionFive()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 84,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 231, 84, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftTwoSetPositionFive(long LiftTwoSetPositionFive)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 84,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 231, 84, LiftTwoSetPositionFive);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftTwoSetPositionSix()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 88,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 231, 88, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftTwoSetPositionSix(long LiftTwoSetPositionSix)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 88,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 231, 88, LiftTwoSetPositionSix);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftTwoSetPositionSeven()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 92,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 231, 92, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftTwoSetPositionSeven(long LiftTwoSetPositionSeven)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 92,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 231, 92, LiftTwoSetPositionSeven);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftTwoSetPositionEight()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 96,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 231, 96, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftTwoSetPositionEight(long LiftTwoSetPositionEight)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 96,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 231, 96, LiftTwoSetPositionEight);
            return new SuccessResult();
        }



    }
}
