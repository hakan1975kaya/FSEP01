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
    public class PLCBasicDataManager : IPLCBasicDataService
    {
        private IPLCDal _plcDal;
        private IPLCGeneralDal _plcGeneralDal;
        private IPLCBasicDataDal _plcBasicDataDal;
        private string _recipeNameLast;
        public PLCBasicDataManager(IPLCDal plcDal, IPLCGeneralDal plcGeneralDal, IPLCBasicDataDal plcBasicDataDal)
        {
            _plcDal = plcDal;
            _plcGeneralDal = plcGeneralDal;
            _plcBasicDataDal = plcBasicDataDal;
            _recipeNameLast = (string)_plcDal.Read(DataType.DataBlock, 90, 40, VarType.String, 1);
        }

        [SecurityAspect("PLCBasicData.ReadRewinderOneDiameterLayRoll", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderOneDiameterLayRoll()//Name:Rew1DiaLayRoll,Adress:DB 91 DBD 368,Data Type:DInt
        {
            var rewinderOneDiameterLayRoll = (decimal)_plcDal.Read(DataType.DataBlock, 91, 368, VarType.DInt, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneDiameterLayRoll = rewinderOneDiameterLayRoll,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.RewinderOneDiameterLayRoll = rewinderOneDiameterLayRoll;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneDiameterLayRoll = rewinderOneDiameterLayRoll,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.RewinderOneDiameterLayRoll = rewinderOneDiameterLayRoll;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            return new SuccessDataResult<decimal>(rewinderOneDiameterLayRoll, PLCBasicDataMessages.Read);
        }

        [SecurityAspect("PLCBasicData.WriteRewinderOneDiameterLayRoll", Priority = 2)]
        public async Task<IResult> WriteRewinderOneDiameterLayRoll(decimal rewinderOneDiameterLayRoll)//Name:Rew1DiaLayRoll,Adress:DB 91 DBD 368,Data Type:DInt
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

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneDiameterLayRoll = rewinderOneDiameterLayRoll,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.RewinderOneDiameterLayRoll = rewinderOneDiameterLayRoll;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneDiameterLayRoll = rewinderOneDiameterLayRoll,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.RewinderOneDiameterLayRoll = rewinderOneDiameterLayRoll;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 368, rewinderOneDiameterLayRoll);
            return new SuccessResult(PLCBasicDataMessages.Write);
        }


        [SecurityAspect("PLCBasicData.ReadRewinderOneDiameterContactRoll", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderOneDiameterContactRoll()//Name:Rew1DiaContRoll,Adress:DB 91 DBD 338,Data Type:Int
        {
            var rewinderOneDiameterContactRoll = (decimal)_plcDal.Read(DataType.DataBlock, 91, 368, VarType.DInt, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneDiameterContactRoll = rewinderOneDiameterContactRoll,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.RewinderOneDiameterContactRoll = rewinderOneDiameterContactRoll;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneDiameterContactRoll = rewinderOneDiameterContactRoll,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.RewinderOneDiameterContactRoll = rewinderOneDiameterContactRoll;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            return new SuccessDataResult<decimal>(rewinderOneDiameterContactRoll, PLCBasicDataMessages.Read);
        }

        [SecurityAspect("PLCBasicData.WriteRewinderOneDiameterContactRoll", Priority = 2)]
        public async Task<IResult> WriteRewinderOneDiameterContactRoll(decimal rewinderOneDiameterContactRoll)//Name:Rew1DiaContRoll,Adress:DB 91 DBD 338,Data Type:Int
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

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        RewinderOneDiameterContactRoll = rewinderOneDiameterContactRoll,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.RewinderOneDiameterContactRoll = rewinderOneDiameterContactRoll;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderOneDiameterContactRoll = rewinderOneDiameterContactRoll,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.RewinderOneDiameterContactRoll = rewinderOneDiameterContactRoll;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 338, rewinderOneDiameterContactRoll);
            return new SuccessResult(PLCBasicDataMessages.Write);
        }


        [SecurityAspect("PLCBasicData.ReadRewinderTwoDiameterContactRoll", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderTwoDiameterContactRoll()//Name:Rew2DiaContRoll,Adress:DB 91 DBD 438,Data Type:DInt
        {
            var rewinderTwoDiameterContactRoll = (decimal)_plcDal.Read(DataType.DataBlock, 91, 438, VarType.DInt, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoDiameterContactRoll = rewinderTwoDiameterContactRoll,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.RewinderTwoDiameterContactRoll = rewinderTwoDiameterContactRoll;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoDiameterContactRoll = rewinderTwoDiameterContactRoll,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.RewinderTwoDiameterContactRoll = rewinderTwoDiameterContactRoll;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            return new SuccessDataResult<decimal>(rewinderTwoDiameterContactRoll, PLCBasicDataMessages.Read);
        }

        [SecurityAspect("PLCBasicData.WriteRewinderTwoDiameterContactRoll", Priority = 2)]
        public async Task<IResult> WriteRewinderTwoDiameterContactRoll(decimal rewinderTwoDiameterContactRoll)//Name:Rew2DiaContRoll,Adress:DB 91 DBD 438,Data Type:DInt
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

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoDiameterContactRoll = rewinderTwoDiameterContactRoll,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.RewinderTwoDiameterContactRoll = rewinderTwoDiameterContactRoll;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoDiameterContactRoll = rewinderTwoDiameterContactRoll,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.RewinderTwoDiameterContactRoll = rewinderTwoDiameterContactRoll;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 438, rewinderTwoDiameterContactRoll);
            return new SuccessResult(PLCBasicDataMessages.Write);
        }


        [SecurityAspect("PLCBasicData.ReadRewinderTwoDiameterSupportRoll", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadRewinderTwoDiameterSupportRoll()//Name:Rew2DiaSupRoll,Adress:DB 91 DBD 468,Data Type:DInt
        {
            var rewinderTwoDiameterSupportRoll = (decimal)_plcDal.Read(DataType.DataBlock, 91, 468, VarType.DInt, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoDiameterSupportRoll = rewinderTwoDiameterSupportRoll,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.RewinderTwoDiameterSupportRoll = rewinderTwoDiameterSupportRoll;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoDiameterSupportRoll = rewinderTwoDiameterSupportRoll,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.RewinderTwoDiameterSupportRoll = rewinderTwoDiameterSupportRoll;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            return new SuccessDataResult<decimal>(rewinderTwoDiameterSupportRoll, PLCBasicDataMessages.Read);
        }

        [SecurityAspect("PLCBasicData.WriteRewinderTwoDiameterSupportRoll", Priority = 2)]
        public async Task<IResult> WriteRewinderTwoDiameterSupportRoll(decimal rewinderTwoDiameterSupportRoll)//Name:Rew2DiaSupRoll,Adress:DB 91 DBD 468,Data Type:DInt
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

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        RewinderTwoDiameterSupportRoll = rewinderTwoDiameterSupportRoll,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.RewinderTwoDiameterSupportRoll = rewinderTwoDiameterSupportRoll;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        RewinderTwoDiameterSupportRoll = rewinderTwoDiameterSupportRoll,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.RewinderTwoDiameterSupportRoll = rewinderTwoDiameterSupportRoll;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 468, rewinderTwoDiameterSupportRoll);
            return new SuccessResult(PLCBasicDataMessages.Write);
        }


        [SecurityAspect("PLCBasicData.ReadMaterialSpecGravity", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadMaterialSpecGravity()//Name:MaterialSpecGravity,Adress:DB 91 DBW 38,Data Type:Int
        {
            var materialSpecGravity = (decimal)_plcDal.Read(DataType.DataBlock, 91, 38, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        MaterialSpecGravity = materialSpecGravity,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MaterialSpecGravity = materialSpecGravity;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        MaterialSpecGravity = materialSpecGravity,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MaterialSpecGravity = materialSpecGravity;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            return new SuccessDataResult<decimal>(materialSpecGravity, PLCBasicDataMessages.Read);
        }

        [SecurityAspect("PLCBasicData.WriteMaterialSpecGravity", Priority = 2)]
        public async Task<IResult> WriteMaterialSpecGravity(decimal materialSpecGravity)//Name:MaterialSpecGravity,Adress:DB 91 DBW 38,Data Type:Int
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

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        MaterialSpecGravity = materialSpecGravity,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MaterialSpecGravity = materialSpecGravity;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        MaterialSpecGravity = materialSpecGravity,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MaterialSpecGravity = materialSpecGravity;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 38, materialSpecGravity);
            return new SuccessResult(PLCBasicDataMessages.Write);
        }


        [SecurityAspect("PLCBasicData.ReadUnwinderOneMaterialWidth", Priority = 2)]
        public async Task<IDataResult<int>> ReadUnwinderOneMaterialWidth()//Name:Unw1MaterialWidth,Adress:DB 91 DBW 110,Data Type:Int
        {
            var unwinderOneMaterialWidth = (int)_plcDal.Read(DataType.DataBlock, 91, 110, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        UnwinderOneMaterialWidth = unwinderOneMaterialWidth,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.UnwinderOneMaterialWidth = unwinderOneMaterialWidth;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        UnwinderOneMaterialWidth = unwinderOneMaterialWidth,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.UnwinderOneMaterialWidth = unwinderOneMaterialWidth;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            return new SuccessDataResult<int>(unwinderOneMaterialWidth, PLCBasicDataMessages.Read);
        }

        [SecurityAspect("PLCBasicData.WriteUnwinderOneMaterialWidth", Priority = 2)]
        public async Task<IResult> WriteUnwinderOneMaterialWidth(int unwinderOneMaterialWidth)//Name:Unw1MaterialWidth,Adress:DB 91 DBW 110,Data Type:Int
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

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        UnwinderOneMaterialWidth = unwinderOneMaterialWidth,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.UnwinderOneMaterialWidth = unwinderOneMaterialWidth;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        UnwinderOneMaterialWidth = unwinderOneMaterialWidth,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.UnwinderOneMaterialWidth = unwinderOneMaterialWidth;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 110, unwinderOneMaterialWidth);
            return new SuccessResult(PLCBasicDataMessages.Write);
        }


        [SecurityAspect("PLCBasicData.ReadMaterialThickness", Priority = 2)]
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

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        MaterialThickness = materialThickness,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MaterialThickness = materialThickness;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        MaterialThickness = materialThickness,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MaterialThickness = materialThickness;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            return new SuccessDataResult<decimal>(materialThickness, PLCBasicDataMessages.Read);
        }

        [SecurityAspect("PLCBasicData.WriteMaterialThickness", Priority = 2)]
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

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        MaterialThickness = materialThickness,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MaterialThickness = materialThickness;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        MaterialThickness = materialThickness,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MaterialThickness = materialThickness;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 36, materialThickness);
            return new SuccessResult(PLCBasicDataMessages.Write);
        }


        //Calculated
        [SecurityAspect("PLCBasicData.ReadMaterialThicknessCalculatedValueActuel", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadMaterialThicknessCalculatedValueActuel()//HMI:Only Read,Name:MaterialThicknessCalc,Adress:DB 90 DBW 36,Data Type:Int
        {
            var materialThicknessCalculatedValueActuel = (decimal)_plcDal.Read(DataType.DataBlock, 90, 36, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        MaterialThicknessCalculatedValueActuel = materialThicknessCalculatedValueActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MaterialThicknessCalculatedValueActuel = materialThicknessCalculatedValueActuel;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        MaterialThicknessCalculatedValueActuel = materialThicknessCalculatedValueActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MaterialThicknessCalculatedValueActuel = materialThicknessCalculatedValueActuel;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            return new SuccessDataResult<decimal>(materialThicknessCalculatedValueActuel, PLCBasicDataMessages.Read);
        }

        [SecurityAspect("PLCBasicData.WriteMaterialThicknessCalculatedValueActuel", Priority = 2)]
        public async Task<IResult> WriteMaterialThicknessCalculatedValueActuel(decimal materialThicknessCalculatedValueActuel)//Name:MaterialThicknessCalc,Adress:DB 90 DBW 36,Data Type:Int
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

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        MaterialThicknessCalculatedValueActuel = materialThicknessCalculatedValueActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MaterialThicknessCalculatedValueActuel = materialThicknessCalculatedValueActuel;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        MaterialThicknessCalculatedValueActuel = materialThicknessCalculatedValueActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MaterialThicknessCalculatedValueActuel = materialThicknessCalculatedValueActuel;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 36, materialThicknessCalculatedValueActuel);
            return new SuccessResult(PLCBasicDataMessages.Write);
        }


        [SecurityAspect("PLCBasicData.ReadMaterialThicknessCalculatedValueMinimum", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadMaterialThicknessCalculatedValueMinimum()//Name:MaterialThicknessMin,Adress:DB 90 DBW 124,Data Type:Int
        {
            var materialThicknessCalculatedValueMinimum = (decimal)_plcDal.Read(DataType.DataBlock, 90, 124, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        MaterialThicknessCalculatedValueMinimum = materialThicknessCalculatedValueMinimum,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MaterialThicknessCalculatedValueMinimum = materialThicknessCalculatedValueMinimum;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        MaterialThicknessCalculatedValueMinimum = materialThicknessCalculatedValueMinimum,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MaterialThicknessCalculatedValueMinimum = materialThicknessCalculatedValueMinimum;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            return new SuccessDataResult<decimal>(materialThicknessCalculatedValueMinimum, PLCBasicDataMessages.Read);
        }

        [SecurityAspect("PLCBasicData.WritenMaterialThicknessCalculatedValueMinimum", Priority = 2)]
        public async Task<IResult> WritenMaterialThicknessCalculatedValueMinimum(decimal materialThicknessCalculatedValueMinimum)//Name:MaterialThicknessMin,Adress:DB 90 DBW 124,Data Type:Int
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

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        MaterialThicknessCalculatedValueMinimum = materialThicknessCalculatedValueMinimum,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MaterialThicknessCalculatedValueMinimum = materialThicknessCalculatedValueMinimum;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        MaterialThicknessCalculatedValueMinimum = materialThicknessCalculatedValueMinimum,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MaterialThicknessCalculatedValueMinimum = materialThicknessCalculatedValueMinimum;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 124, materialThicknessCalculatedValueMinimum);
            return new SuccessResult(PLCBasicDataMessages.Write);
        }


        [SecurityAspect("PLCBasicData.ReadMaterialThicknessCalculatedValueMaximum", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadMaterialThicknessCalculatedValueMaximum()//Name:MaterialThicknessMax,Adress:DB 90 DBW 126,Data Type:Int
        {
            var materialThicknessCalculatedValueMaximum = (decimal)_plcDal.Read(DataType.DataBlock, 90, 126, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        MaterialThicknessCalculatedValueMaximum = materialThicknessCalculatedValueMaximum,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MaterialThicknessCalculatedValueMaximum = materialThicknessCalculatedValueMaximum;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        MaterialThicknessCalculatedValueMaximum = materialThicknessCalculatedValueMaximum,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MaterialThicknessCalculatedValueMaximum = materialThicknessCalculatedValueMaximum;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            return new SuccessDataResult<decimal>(materialThicknessCalculatedValueMaximum, PLCBasicDataMessages.Read);
        }

        [SecurityAspect("PLCBasicData.WriteMaterialThicknessCalculatedValueMaximum", Priority = 2)]
        public async Task<IResult> WriteMaterialThicknessCalculatedValueMaximum(decimal materialThicknessCalculatedValueMaximum)
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

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        MaterialThicknessCalculatedValueMaximum = materialThicknessCalculatedValueMaximum,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MaterialThicknessCalculatedValueMaximum = materialThicknessCalculatedValueMaximum;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        MaterialThicknessCalculatedValueMaximum = materialThicknessCalculatedValueMaximum,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MaterialThicknessCalculatedValueMaximum = materialThicknessCalculatedValueMaximum;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 126, materialThicknessCalculatedValueMaximum);
            return new SuccessResult(PLCBasicDataMessages.Write);
        }


        [SecurityAspect("PLCBasicData.ReadMachineWeldingSpeedSet", Priority = 2)]
        public async Task<IDataResult<short>> ReadMachineWeldingSpeedSet()//Name:MachineWeldingSpeedSet_0,Adress:DB 91 DBW 80,Data Type:Int
        {
            var machineWeldingSpeedSet = (short)_plcDal.Read(DataType.DataBlock, 91, 80, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        MachineWeldingSpeedSet = machineWeldingSpeedSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineWeldingSpeedSet = machineWeldingSpeedSet;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        MachineWeldingSpeedSet = machineWeldingSpeedSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineWeldingSpeedSet = machineWeldingSpeedSet;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            return new SuccessDataResult<short>(machineWeldingSpeedSet, PLCBasicDataMessages.Read);
        }

        [SecurityAspect("PLCBasicData.WriteMachineWeldingSpeedSet", Priority = 2)]
        public async Task<IResult> WriteMachineWeldingSpeedSet(short machineWeldingSpeedSet)//Name:MachineWeldingSpeedSet_0,Adress:DB 91 DBW 80,Data Type:Int
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

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        MachineWeldingSpeedSet = machineWeldingSpeedSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineWeldingSpeedSet = machineWeldingSpeedSet;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        MachineWeldingSpeedSet = machineWeldingSpeedSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineWeldingSpeedSet = machineWeldingSpeedSet;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 80, machineWeldingSpeedSet);
            return new SuccessResult(PLCBasicDataMessages.Write);
        }


        [SecurityAspect("PLCBasicData.ReadMachineWeldingAmplitudeSet", Priority = 2)]
        public async Task<IDataResult<short>> ReadMachineWeldingAmplitudeSet()//Name:MachineWeldingAmplitudeSet,Adress:DB 91 DBW 82,Data Type:Int
        {
            var machineWeldingAmplitudeSet = (short)_plcDal.Read(DataType.DataBlock, 91, 82, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        MachineWeldingAmplitudeSet = machineWeldingAmplitudeSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineWeldingAmplitudeSet = machineWeldingAmplitudeSet;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        MachineWeldingAmplitudeSet = machineWeldingAmplitudeSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineWeldingAmplitudeSet = machineWeldingAmplitudeSet;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            return new SuccessDataResult<short>(machineWeldingAmplitudeSet, PLCBasicDataMessages.Read);
        }

        [SecurityAspect("PLCBasicData.WriteMachineWeldingAmplitudeSet", Priority = 2)]
        public async Task<IResult> WriteMachineWeldingAmplitudeSet(short machineWeldingAmplitudeSet)//Name:MachineWeldingAmplitudeSet,Adress:DB 91 DBW 82,Data Type:Int
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

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        MachineWeldingAmplitudeSet = machineWeldingAmplitudeSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineWeldingAmplitudeSet = machineWeldingAmplitudeSet;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        MachineWeldingAmplitudeSet = machineWeldingAmplitudeSet,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineWeldingAmplitudeSet = machineWeldingAmplitudeSet;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 82, machineWeldingAmplitudeSet);
            return new SuccessResult(PLCBasicDataMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCBasicData.ReadMachineWeldingPowerActuel", Priority = 2)]
        public async Task<IDataResult<decimal>> ReadMachineWeldingPowerActuel()//HMI:Read Only, Name:MachineWeldingPowerAct,Adress:DB 90 DBW 82,Data Type:Int
        {
            var machineWeldingPowerActuel = (decimal)_plcDal.Read(DataType.DataBlock, 90, 82, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        MachineWeldingPowerActuel = machineWeldingPowerActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineWeldingPowerActuel = machineWeldingPowerActuel;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        MachineWeldingPowerActuel = machineWeldingPowerActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineWeldingPowerActuel = machineWeldingPowerActuel;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            return new SuccessDataResult<decimal>(machineWeldingPowerActuel, PLCBasicDataMessages.Read);
        }

        [SecurityAspect("PLCBasicData.WriteMachineWeldingPowerActuel", Priority = 2)]
        public async Task<IResult> WriteMachineWeldingPowerActuel(decimal machineWeldingPowerActuel)//HMI:Read Only, Name:MachineWeldingPowerAct,Adress:DB 90 DBW 82,Data Type:Int
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

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        MachineWeldingPowerActuel = machineWeldingPowerActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineWeldingPowerActuel = machineWeldingPowerActuel;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        MachineWeldingPowerActuel = machineWeldingPowerActuel,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineWeldingPowerActuel = machineWeldingPowerActuel;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 82, machineWeldingPowerActuel);
            return new SuccessResult(PLCBasicDataMessages.Write);
        }


        [SecurityAspect("PLCBasicData.ReadMachineTimeAcceleration", Priority = 2)]
        public async Task<IDataResult<short>> ReadMachineTimeAcceleration()//Name:MachineTimeAccel,Addres:DB 91 DBW 8
        {
            var machineTimeAcceleration = (short)_plcDal.Read(DataType.DataBlock, 91, 8, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        MachineTimeAcceleration = machineTimeAcceleration,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineTimeAcceleration = machineTimeAcceleration;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        MachineTimeAcceleration = machineTimeAcceleration,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineTimeAcceleration = machineTimeAcceleration;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            return new SuccessDataResult<short>(machineTimeAcceleration, PLCBasicDataMessages.Read);
        }

        [SecurityAspect("PLCBasicData.WriteMachineTimeAcceleration", Priority = 2)]
        public async Task<IResult> WriteMachineTimeAcceleration(short machineTimeAcceleration)//Name:MachineTimeAccel,Addres:DB 91 DBW 8
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

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        MachineTimeAcceleration = machineTimeAcceleration,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineTimeAcceleration = machineTimeAcceleration;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        MachineTimeAcceleration = machineTimeAcceleration,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineTimeAcceleration = machineTimeAcceleration;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 8, machineTimeAcceleration);
            return new SuccessResult(PLCBasicDataMessages.Write);
        }


        [SecurityAspect("PLCBasicData.ReadMachineTimeDecelaration", Priority = 2)]
        public async Task<IDataResult<short>> ReadMachineTimeDecelaration()//Name:MachineTimeDecel,Addres:DB 91 DBW 10
        {
            var machineTimeDecelaration = (short)_plcDal.Read(DataType.DataBlock, 91, 8, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        MachineTimeDecelaration = machineTimeDecelaration,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineTimeDecelaration = machineTimeDecelaration;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        MachineTimeDecelaration = machineTimeDecelaration,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineTimeDecelaration = machineTimeDecelaration;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            return new SuccessDataResult<short>(machineTimeDecelaration, PLCBasicDataMessages.Read);
        }

        [SecurityAspect("PLCBasicData.WriteMachineTimeDecelaration", Priority = 2)]
        public async Task<IResult> WriteMachineTimeDecelaration(short machineTimeDecelaration)//Name:MachineTimeDecel,Addres:DB 91 DBW 10
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

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        MachineTimeDecelaration = machineTimeDecelaration,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineTimeDecelaration = machineTimeDecelaration;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        MachineTimeDecelaration = machineTimeDecelaration,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineTimeDecelaration = machineTimeDecelaration;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 10, machineTimeDecelaration);
            return new SuccessResult(PLCBasicDataMessages.Write);
        }


        [SecurityAspect("PLCBasicData.ReadMachineTimeFastStop", Priority = 2)]
        public async Task<IDataResult<short>> ReadMachineTimeFastStop()//Name:MachineTimeFastStop,Addres:DB 91 DBW 12
        {
            var machineTimeFastStop = (short)_plcDal.Read(DataType.DataBlock, 91, 12, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        MachineTimeFastStop = machineTimeFastStop,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineTimeFastStop = machineTimeFastStop;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        MachineTimeFastStop = machineTimeFastStop,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineTimeFastStop = machineTimeFastStop;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            return new SuccessDataResult<short>(machineTimeFastStop, PLCBasicDataMessages.Read);
        }

        [SecurityAspect("PLCBasicData.WriteMachineTimeFastStop", Priority = 2)]
        public async Task<IResult> WriteMachineTimeFastStop(short machineTimeFastStop)//Name:MachineTimeFastStop,Addres:DB 91 DBW 12
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

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        MachineTimeFastStop = machineTimeFastStop,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineTimeFastStop = machineTimeFastStop;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        MachineTimeFastStop = machineTimeFastStop,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineTimeFastStop = machineTimeFastStop;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 12, machineTimeFastStop);
            return new SuccessResult(PLCBasicDataMessages.Write);
        }


        [SecurityAspect("PLCBasicData.ReadMachineSpeedJog", Priority = 2)]
        public async Task<IDataResult<short>> ReadMachineSpeedJog()//Name:MachineSpeedJog,Addres:DB 91 DBW 4
        {
            var machineSpeedJog = (short)_plcDal.Read(DataType.DataBlock, 91, 4, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        MachineSpeedJog = machineSpeedJog,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineSpeedJog = machineSpeedJog;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        MachineSpeedJog = machineSpeedJog,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineSpeedJog = machineSpeedJog;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            return new SuccessDataResult<short>(machineSpeedJog, PLCBasicDataMessages.Read);
        }

        [SecurityAspect("PLCBasicData.WriteMachineSpeedJog", Priority = 2)]
        public async Task<IResult> WriteMachineSpeedJog(short machineSpeedJog)//Name:MachineSpeedJog,Addres:DB 91 DBW 4
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

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        MachineSpeedJog = machineSpeedJog,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineSpeedJog = machineSpeedJog;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        MachineSpeedJog = machineSpeedJog,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineSpeedJog = machineSpeedJog;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            _plcDal.Write(DataType.DataBlock, 91, 4, machineSpeedJog);
            return new SuccessResult(PLCBasicDataMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCBasicData.ReadMachineLengthTotal", Priority = 2)]
        public async Task<IDataResult<long>> ReadMachineLengthTotal()//Name:MachineLengthTotal,Adress:DB 90 DBD 16,Data Type:DInt
        {
            var machineLengthTotal = (long)_plcDal.Read(DataType.DataBlock, 90, 16, VarType.DInt, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = _recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        MachineLengthTotal = machineLengthTotal,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineLengthTotal = machineLengthTotal;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        MachineLengthTotal = machineLengthTotal,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineLengthTotal = machineLengthTotal;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            return new SuccessDataResult<long>(machineLengthTotal, PLCBasicDataMessages.Read);
        }

        [SecurityAspect("PLCBasicData.WriteMachineLengthTotal", Priority = 2)]
        public async Task<IResult> WriteMachineLengthTotal(long machineLengthTotal)//Name:MachineLengthTotal,Adress:DB 90 DBD 16,Data Type:DInt
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

                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneralId);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneralId,
                        MachineLengthTotal = machineLengthTotal,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineLengthTotal = machineLengthTotal;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }
            else
            {
                var plcBasicData = await _plcBasicDataDal.Get(x => x.PLCGeneralId == plcGeneral.Id);
                if (plcBasicData == null)
                {
                    var plcBasicDataId = Guid.NewGuid();
                    plcBasicData = new PLCBasicData
                    {
                        Id = plcBasicDataId,
                        PLCGeneralId = plcGeneral.Id,
                        MachineLengthTotal = machineLengthTotal,
                        Optime = DateTime.Now,
                        IsActive = true
                    };
                    await _plcBasicDataDal.Add(plcBasicData);
                }
                else
                {
                    plcBasicData.MachineLengthTotal = machineLengthTotal;
                    await _plcBasicDataDal.Update(plcBasicData);
                }
            }

            _plcDal.Write(DataType.DataBlock, 90, 16, machineLengthTotal);
            return new SuccessResult(PLCBasicDataMessages.Write);
        }


    }
}
