using Business.Abstract.PLC.Machine;
using Business.Constants.Messages.PLC.Machine;
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
    public class PLCRewinderTensionManager : IPLCRewinderTensionService
    {
        private IPLCDal _plcDal;
        private IPLCGeneralDal _plcGeneralDal;
        private IPLCRewinderTensionDal _plcRewinderTensionDal;
        private string _recipeNameLast;
        public PLCRewinderTensionManager(IPLCDal plcDal, IPLCGeneralDal plcGeneralDal, IPLCRewinderTensionDal plcRewinderTensionDal)
        {
            _plcDal = plcDal;
            _plcGeneralDal = plcGeneralDal;
            _plcRewinderTensionDal = plcRewinderTensionDal;
            _recipeNameLast = (string)_plcDal.Read(DataType.DataBlock, 90, 40, VarType.String, 1);
        }
        public async Task<IDataResult<decimal>> ReadRewinderOneTensionSetScaled()//Name:Rew1TensionSetScaled,Addres:DB 91 DBW 312,Data Type:Int
        {
            var rewinderOneTensionSetScaled = (decimal)_plcDal.Read(DataType.DataBlock, 91, 312, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneTensionSetScaled = rewinderOneTensionSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneTensionSetScaled = rewinderOneTensionSetScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneTensionSetScaled = rewinderOneTensionSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneTensionSetScaled = rewinderOneTensionSetScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            return new SuccessDataResult<decimal>(rewinderOneTensionSetScaled, PLCRewinderTensionMessages.Read);
        }
        public async Task<IResult> WriteRewinderOneTensionSetScaled(decimal rewinderOneTensionSetScaled)//Name:Rew1TensionSetScaled,Addres:DB 91 DBW 312,Data Type:Int
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

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneTensionSetScaled = rewinderOneTensionSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneTensionSetScaled = rewinderOneTensionSetScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneTensionSetScaled = rewinderOneTensionSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneTensionSetScaled = rewinderOneTensionSetScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 312, rewinderOneTensionSetScaled);
            return new SuccessResult();
        }

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

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneTensionCalculateCharScaled = rewinderOneTensionCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneTensionCalculateCharScaled = rewinderOneTensionCalculateCharScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneTensionCalculateCharScaled = rewinderOneTensionCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneTensionCalculateCharScaled = rewinderOneTensionCalculateCharScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            return new SuccessDataResult<decimal>(rewinderOneTensionCalculateCharScaled, PLCRewinderTensionMessages.Read);
        }
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

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneTensionCalculateCharScaled = rewinderOneTensionCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneTensionCalculateCharScaled = rewinderOneTensionCalculateCharScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneTensionCalculateCharScaled = rewinderOneTensionCalculateCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneTensionCalculateCharScaled = rewinderOneTensionCalculateCharScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 316, rewinderOneTensionCalculateCharScaled);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderOneTensionActuelMeasureScaled()//Name:Rew1TensionActMeasScaled,Addres:DB 90 DBW 312,Data Type:Int
        {
            var rewinderOneTensionActuelMeasureScaled = (decimal)_plcDal.Read(DataType.DataBlock, 90, 312, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneTensionActuelMeasureScaled = rewinderOneTensionActuelMeasureScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneTensionActuelMeasureScaled = rewinderOneTensionActuelMeasureScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneTensionActuelMeasureScaled = rewinderOneTensionActuelMeasureScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneTensionActuelMeasureScaled = rewinderOneTensionActuelMeasureScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            return new SuccessDataResult<decimal>(rewinderOneTensionActuelMeasureScaled, PLCRewinderTensionMessages.Read);
        }
        public async Task<IResult> WriteRewinderOneTensionActuelMeasureScaled(decimal rewinderOneTensionActuelMeasureScaled)//Name:Rew1TensionActMeasScaled,Addres:DB 90 DBW 312,Data Type:Int
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

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneTensionActuelMeasureScaled = rewinderOneTensionActuelMeasureScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneTensionActuelMeasureScaled = rewinderOneTensionActuelMeasureScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneTensionActuelMeasureScaled = rewinderOneTensionActuelMeasureScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneTensionActuelMeasureScaled = rewinderOneTensionActuelMeasureScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 312, rewinderOneTensionActuelMeasureScaled);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderOneTensionCalculateCharNewton()//Name:Rew1TensionCalcCharNewton,Addres:DB 90 DBW 318,Data Type:Int
        {
            var rewinderOneTensionCalculateCharNewton = (decimal)_plcDal.Read(DataType.DataBlock, 90, 318, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneTensionCalculateCharNewton = rewinderOneTensionCalculateCharNewton,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneTensionCalculateCharNewton = rewinderOneTensionCalculateCharNewton;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneTensionCalculateCharNewton = rewinderOneTensionCalculateCharNewton,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneTensionCalculateCharNewton = rewinderOneTensionCalculateCharNewton;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            return new SuccessDataResult<decimal>(rewinderOneTensionCalculateCharNewton, PLCRewinderTensionMessages.Read);
        }
        public async Task<IResult> WriteRewinderOneTensionCalculateCharNewton(decimal rewinderOneTensionCalculateCharNewton)//Name:Rew1TensionCalcCharNewton,Addres:DB 90 DBW 318,Data Type:Int
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

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneTensionCalculateCharNewton = rewinderOneTensionCalculateCharNewton,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneTensionCalculateCharNewton = rewinderOneTensionCalculateCharNewton;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneTensionCalculateCharNewton = rewinderOneTensionCalculateCharNewton,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneTensionCalculateCharNewton = rewinderOneTensionCalculateCharNewton;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 318, rewinderOneTensionCalculateCharNewton);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderOneTensionActuelMeasureNewton()//Name:Rew1TensionActMeasNewton,Addres:DB 90 DBW 314,Data Type:Int
        {
            var rewinderOneTensionActuelMeasureNewton = (decimal)_plcDal.Read(DataType.DataBlock, 90, 314, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneTensionActuelMeasureNewton = rewinderOneTensionActuelMeasureNewton,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneTensionActuelMeasureNewton = rewinderOneTensionActuelMeasureNewton;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneTensionActuelMeasureNewton = rewinderOneTensionActuelMeasureNewton,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneTensionActuelMeasureNewton = rewinderOneTensionActuelMeasureNewton;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            return new SuccessDataResult<decimal>(rewinderOneTensionActuelMeasureNewton, PLCRewinderTensionMessages.Read);
        }
        public async Task<IResult> WriteRewinderOneTensionActuelMeasureNewton(decimal rewinderOneTensionActuelMeasureNewton)//Name:Rew1TensionActMeasNewton,Addres:DB 90 DBW 314,Data Type:Int
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

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneTensionActuelMeasureNewton = rewinderOneTensionActuelMeasureNewton,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneTensionActuelMeasureNewton = rewinderOneTensionActuelMeasureNewton;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneTensionActuelMeasureNewton = rewinderOneTensionActuelMeasureNewton,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneTensionActuelMeasureNewton = rewinderOneTensionActuelMeasureNewton;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 314, rewinderOneTensionActuelMeasureNewton);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderOneTensionContactSetScaled()//Name:Rew1TensionContSetScaled,Addres:DB 91 DBW 342,Data Type:Int
        {
            var rewinderOneTensionContactSetScaled = (decimal)_plcDal.Read(DataType.DataBlock, 91, 342, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneTensionContactSetScaled = rewinderOneTensionContactSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneTensionContactSetScaled = rewinderOneTensionContactSetScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneTensionContactSetScaled = rewinderOneTensionContactSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneTensionContactSetScaled = rewinderOneTensionContactSetScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            return new SuccessDataResult<decimal>(rewinderOneTensionContactSetScaled, PLCRewinderTensionMessages.Read);
        }
        public async Task<IResult> WriteRewinderOneTensionContactSetScaled(decimal rewinderOneTensionContactSetScaled)//Name:Rew1TensionContSetScaled,Addres:DB 91 DBW 342,Data Type:Int
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

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneTensionContactSetScaled = rewinderOneTensionContactSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneTensionContactSetScaled = rewinderOneTensionContactSetScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneTensionContactSetScaled = rewinderOneTensionContactSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneTensionContactSetScaled = rewinderOneTensionContactSetScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 342, rewinderOneTensionContactSetScaled);
            return new SuccessResult();
        }

        public async Task<IDataResult<short>> ReadRewinderOneMaterialWidth()//Name:Rew1MaterialWidth,Addres:DB 91 DBW 310,Data Type:Int
        {
            var rewinderOneMaterialWidth = (short)_plcDal.Read(DataType.DataBlock, 91, 310, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneMaterialWidth = rewinderOneMaterialWidth,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneMaterialWidth = rewinderOneMaterialWidth;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneMaterialWidth = rewinderOneMaterialWidth,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneMaterialWidth = rewinderOneMaterialWidth;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            return new SuccessDataResult<short>(rewinderOneMaterialWidth, PLCRewinderTensionMessages.Read);
        }
        public async Task<IResult> WriteRewinderOneMaterialWidth(short rewinderOneMaterialWidth)//Name:Rew1MaterialWidth,Addres:DB 91 DBW 310,Data Type:Int
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

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneMaterialWidth = rewinderOneMaterialWidth,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneMaterialWidth = rewinderOneMaterialWidth;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneMaterialWidth = rewinderOneMaterialWidth,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneMaterialWidth = rewinderOneMaterialWidth;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 310, rewinderOneMaterialWidth);
            return new SuccessResult();
        }

        public async Task<IDataResult<short>> ReadRewinderOneShaft()//Name:Rew1Shaft,Addres:DB 91 DBW 382,Data Type:Int
        {
            var rewinderOneShaft = (short)_plcDal.Read(DataType.DataBlock, 91, 382, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneShaft = rewinderOneShaft,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneShaft = rewinderOneShaft;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneShaft = rewinderOneShaft,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneShaft = rewinderOneShaft;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            return new SuccessDataResult<short>(rewinderOneShaft, PLCRewinderTensionMessages.Read);
        }
        public async Task<IResult> WriteRewinderOneShaft(short rewinderOneShaft)//Name:Rew1Shaft,Addres:DB 91 DBW 382,Data Type:Int
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

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneShaft = rewinderOneShaft,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneShaft = rewinderOneShaft;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneShaft = rewinderOneShaft,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderOneShaft = rewinderOneShaft;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 382, rewinderOneShaft);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderTwoTensionContactSetScaled()//Name:Rew2TensionContSetScaled,Addres:DB 91 DBW 442,Data Type:Int
        {
            var rewinderTwoTensionContactSetScaled = (decimal)_plcDal.Read(DataType.DataBlock, 91, 442, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoTensionContactSetScaled = rewinderTwoTensionContactSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoTensionContactSetScaled = rewinderTwoTensionContactSetScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoTensionContactSetScaled = rewinderTwoTensionContactSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoTensionContactSetScaled = rewinderTwoTensionContactSetScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            return new SuccessDataResult<decimal>(rewinderTwoTensionContactSetScaled, PLCRewinderTensionMessages.Read);
        }
        public async Task<IResult> WriteRewinderTwoTensionContactSetScaled(decimal rewinderTwoTensionContactSetScaled)//Name:Rew2TensionContSetScaled,Addres:DB 91 DBW 442,Data Type:Int
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

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoTensionContactSetScaled = rewinderTwoTensionContactSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoTensionContactSetScaled = rewinderTwoTensionContactSetScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoTensionContactSetScaled = rewinderTwoTensionContactSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoTensionContactSetScaled = rewinderTwoTensionContactSetScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 442, rewinderTwoTensionContactSetScaled);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderTwoTensionSetScaled()//Name:Rew2TensionSetScaled,Addres:DB 91 DBW 412,Data Type:Int
        {
            var rewinderTwoTensionSetScaled = (decimal)_plcDal.Read(DataType.DataBlock, 91, 412, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoTensionSetScaled = rewinderTwoTensionSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoTensionSetScaled = rewinderTwoTensionSetScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoTensionSetScaled = rewinderTwoTensionSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoTensionSetScaled = rewinderTwoTensionSetScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            return new SuccessDataResult<decimal>(rewinderTwoTensionSetScaled, PLCRewinderTensionMessages.Read);
        }
        public async Task<IResult> WriteRewinderTwoTensionSetScaled(decimal rewinderTwoTensionSetScaled)//Name:Rew2TensionSetScaled,Addres:DB 91 DBW 412,Data Type:Int
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

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoTensionSetScaled = rewinderTwoTensionSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoTensionSetScaled = rewinderTwoTensionSetScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoTensionSetScaled = rewinderTwoTensionSetScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoTensionSetScaled = rewinderTwoTensionSetScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 412, rewinderTwoTensionSetScaled);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderTwoTensionCalculeteCharScaled()//Name:Rew2TensionCalcCharScaled,Addres:DB 90 DBW 416,Data Type:Int
        {
            var rewinderTwoTensionCalculeteCharScaled = (decimal)_plcDal.Read(DataType.DataBlock, 90, 416, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoTensionCalculeteCharScaled = rewinderTwoTensionCalculeteCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoTensionCalculeteCharScaled = rewinderTwoTensionCalculeteCharScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoTensionCalculeteCharScaled = rewinderTwoTensionCalculeteCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoTensionCalculeteCharScaled = rewinderTwoTensionCalculeteCharScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            return new SuccessDataResult<decimal>(rewinderTwoTensionCalculeteCharScaled, PLCRewinderTensionMessages.Read);
        }
        public async Task<IResult> WriteRewinderTwoTensionCalculeteCharScaled(decimal rewinderTwoTensionCalculeteCharScaled)//Name:Rew2TensionCalcCharScaled,Addres:DB 90 DBW 416,Data Type:Int
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

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoTensionCalculeteCharScaled = rewinderTwoTensionCalculeteCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoTensionCalculeteCharScaled = rewinderTwoTensionCalculeteCharScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoTensionCalculeteCharScaled = rewinderTwoTensionCalculeteCharScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoTensionCalculeteCharScaled = rewinderTwoTensionCalculeteCharScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 416, rewinderTwoTensionCalculeteCharScaled);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderTwoTensionActuelMeasureScaled()//Name:Rew2TensionActMeasScaled,Addres:DB 90 DBW 412,Data Type:Int
        {
            var rewinderTwoTensionActuelMeasureScaled = (decimal)_plcDal.Read(DataType.DataBlock, 90, 412, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoTensionActuelMeasureScaled = rewinderTwoTensionActuelMeasureScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoTensionActuelMeasureScaled = rewinderTwoTensionActuelMeasureScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoTensionActuelMeasureScaled = rewinderTwoTensionActuelMeasureScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoTensionActuelMeasureScaled = rewinderTwoTensionActuelMeasureScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            return new SuccessDataResult<decimal>(rewinderTwoTensionActuelMeasureScaled, PLCRewinderTensionMessages.Read);
        }
        public async Task<IResult> WriteRewinderTwoTensionActuelMeasureScaled(decimal rewinderTwoTensionActuelMeasureScaled)//Name:Rew2TensionActMeasScaled,Addres:DB 90 DBW 412,Data Type:Int
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

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoTensionActuelMeasureScaled = rewinderTwoTensionActuelMeasureScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoTensionActuelMeasureScaled = rewinderTwoTensionActuelMeasureScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoTensionActuelMeasureScaled = rewinderTwoTensionActuelMeasureScaled,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoTensionActuelMeasureScaled = rewinderTwoTensionActuelMeasureScaled;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 412, rewinderTwoTensionActuelMeasureScaled);
            return new SuccessResult();
        }

        public async Task<IDataResult<short>> ReadRewinderTwoTensionCalculateCharNewton()//Name:Rew2TensionCalcCharNewton,Addres:DB 90 DBW 418,Data Type:Int
        {
            var rewinderTwoTensionCalculateCharNewton = (short)_plcDal.Read(DataType.DataBlock, 90, 418, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoTensionCalculateCharNewton = rewinderTwoTensionCalculateCharNewton,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoTensionCalculateCharNewton = rewinderTwoTensionCalculateCharNewton;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoTensionCalculateCharNewton = rewinderTwoTensionCalculateCharNewton,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoTensionCalculateCharNewton = rewinderTwoTensionCalculateCharNewton;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            return new SuccessDataResult<short>(rewinderTwoTensionCalculateCharNewton, PLCRewinderTensionMessages.Read);
        }
        public async Task<IResult> WriteRewinderTwoTensionCalculateCharNewton(short rewinderTwoTensionCalculateCharNewton)//Name:Rew2TensionCalcCharNewton,Addres:DB 90 DBW 418,Data Type:Int
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

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoTensionCalculateCharNewton = rewinderTwoTensionCalculateCharNewton,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoTensionCalculateCharNewton = rewinderTwoTensionCalculateCharNewton;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoTensionCalculateCharNewton = rewinderTwoTensionCalculateCharNewton,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoTensionCalculateCharNewton = rewinderTwoTensionCalculateCharNewton;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 418, rewinderTwoTensionCalculateCharNewton);
            return new SuccessResult();
        }

        public async Task<IDataResult<short>> ReadRewinderTwoTensionActuelMeasureNewton()//Name:Rew2TensionActMeasNewton,Addres:DB 90 DBW 414,Data Type:Int
        {
            var rewinderTwoTensionActuelMeasureNewton = (short)_plcDal.Read(DataType.DataBlock, 90, 414, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoTensionActuelMeasureNewton = rewinderTwoTensionActuelMeasureNewton,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoTensionActuelMeasureNewton = rewinderTwoTensionActuelMeasureNewton;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoTensionActuelMeasureNewton = rewinderTwoTensionActuelMeasureNewton,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoTensionActuelMeasureNewton = rewinderTwoTensionActuelMeasureNewton;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            return new SuccessDataResult<short>(rewinderTwoTensionActuelMeasureNewton, PLCRewinderTensionMessages.Read);
        }
        public async Task<IResult> WriteRewinderTwoTensionActuelMeasureNewton(short rewinderTwoTensionActuelMeasureNewton)//Name:Rew2TensionActMeasNewton,Addres:DB 90 DBW 414,Data Type:Int
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

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoTensionActuelMeasureNewton = rewinderTwoTensionActuelMeasureNewton,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoTensionActuelMeasureNewton = rewinderTwoTensionActuelMeasureNewton;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoTensionActuelMeasureNewton = rewinderTwoTensionActuelMeasureNewton,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoTensionActuelMeasureNewton = rewinderTwoTensionActuelMeasureNewton;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 414, rewinderTwoTensionActuelMeasureNewton);
            return new SuccessResult();
        }

        public async Task<IDataResult<short>> ReadRewinderTwoMaterialWidth()//Name:Rew2MaterialWidth,Addres:DB 91 DBW 410,Data Type:Int
        {
            var rewinderTwoMaterialWidth = (short)_plcDal.Read(DataType.DataBlock, 90, 410, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoMaterialWidth = rewinderTwoMaterialWidth,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoMaterialWidth = rewinderTwoMaterialWidth;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoMaterialWidth = rewinderTwoMaterialWidth,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoMaterialWidth = rewinderTwoMaterialWidth;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            return new SuccessDataResult<short>(rewinderTwoMaterialWidth, PLCRewinderTensionMessages.Read);
        }
        public async Task<IResult> WriteRewinderTwoMaterialWidth(short rewinderTwoMaterialWidth)//Name:Rew2MaterialWidth,Addres:DB 91 DBW 410,Data Type:Int
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

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoMaterialWidth = rewinderTwoMaterialWidth,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoMaterialWidth = rewinderTwoMaterialWidth;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoMaterialWidth = rewinderTwoMaterialWidth,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoMaterialWidth = rewinderTwoMaterialWidth;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 410, rewinderTwoMaterialWidth);
            return new SuccessResult();
        }

        public async Task<IDataResult<short>> ReadRewinderTwoShaft()//Name:Rew2Shaft,Addres:DB 91 DBW 482,Data Type:Int
        {
            var rewinderTwoShaft = (short)_plcDal.Read(DataType.DataBlock, 91, 482, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoShaft = rewinderTwoShaft,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoShaft = rewinderTwoShaft;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoShaft = rewinderTwoShaft,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoShaft = rewinderTwoShaft;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            return new SuccessDataResult<short>(rewinderTwoShaft, PLCRewinderTensionMessages.Read);
        }
        public async Task<IResult> WriteRewinderTwoShaft(short rewinderTwoShaft)//Name:Rew2Shaft,Addres:DB 91 DBW 482,Data Type:Int
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

                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoShaft = rewinderTwoShaft,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoShaft = rewinderTwoShaft;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }
            else
            {
                var plcRewinderTension = await _plcRewinderTensionDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcRewinderTension == null)
                {
                    var plcRewinderTensionId = Guid.NewGuid();
                    plcRewinderTension = new PLCRewinderTension
                    {
                        Id = plcRewinderTensionId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoShaft = rewinderTwoShaft,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcRewinderTensionDal.Add(plcRewinderTension);
                }
                else
                {
                    plcRewinderTension.RewinderTwoShaft = rewinderTwoShaft;
                    await _plcRewinderTensionDal.Update(plcRewinderTension);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 482, rewinderTwoShaft);
            return new SuccessResult();
        }


    }
}
