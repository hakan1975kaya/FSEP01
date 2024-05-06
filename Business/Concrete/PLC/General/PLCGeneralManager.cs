using Business.Abstract.PLC.General;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.PLC.General;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.PLC.General;
using Entities.Concrete.Entities.PLC.General;
using Entities.Concrete.Enums.PLC.Machine;
using PLC.Abstract;
using S7.Net;

namespace Business.Concrete.PLC.General
{

    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class PLCGeneralManager : IPLCGeneralService
    {
        private IPLCDal _plcDal;
        private IPLCGeneralDal _plcGeneralDal;
        private string _recipeNameLast;
        public PLCGeneralManager(IPLCDal plcDal, IPLCGeneralDal plcGeneralDal)
        {
            _plcDal = plcDal;
            _plcGeneralDal = plcGeneralDal;
            _recipeNameLast = (string)_plcDal.Read(DataType.DataBlock, 90, 40, VarType.String, 1);
        }

        [SecurityAspect("PLCGeneral.ReadRecipeNameLast", Priority = 2)]
        public async Task<IDataResult<string>> ReadRecipeNameLast()//Name:RecipeNameLast,Adress:DB 90 DBB 40,Data Type:String
        {
            var recipeNameLast = (string)_plcDal.Read(DataType.DataBlock, 90, 40, VarType.String, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);
            }
            else
            {
                plcGeneral.RecipeNameLast = recipeNameLast;
                await _plcGeneralDal.Update(plcGeneral);
            }

            return new SuccessDataResult<string>(recipeNameLast, PLCGeneralMessages.Read);
        }

        [SecurityAspect("PLCGeneral.WriteRecipeNameLast", Priority = 2)]
        public async Task<IResult> WriteRecipeNameLast(string recipeNameLast)//Name:RecipeNameLast,Adress:DB 90 DBB 40,Data Type:String
        {
            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    RecipeNameLast = recipeNameLast,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);
            }
            else
            {
                plcGeneral.RecipeNameLast = recipeNameLast;
                await _plcGeneralDal.Update(plcGeneral);
            }

            _plcDal.Write(DataType.DataBlock, 90, 40, recipeNameLast);
            return new SuccessResult(PLCGeneralMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCGeneral.ReadMachineMode", Priority = 2)]
        public async Task<IDataResult<ServiceEnum>> ReadMachineMode()//Name:MachineMode,Adress:DB 90 DBW 24,Data Type:Int
        {
            var machineMode = (ServiceEnum)_plcDal.Read(DataType.DataBlock, 90, 24, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    MachineMode = machineMode,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);
            }
            else
            {
                plcGeneral.MachineMode = machineMode;
                await _plcGeneralDal.Update(plcGeneral);
            }

            return new SuccessDataResult<ServiceEnum>(machineMode, PLCGeneralMessages.Read);
        }

        [SecurityAspect("PLCGeneral.WriteMachineMode", Priority = 2)]
        public async Task<IResult> WriteMachineMode(ServiceEnum machineMode)//Name:MachineMode,Adress:DB 90 DBW 24,Data Type:Int
        {
            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    MachineMode = machineMode,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);
            }
            else
            {
                plcGeneral.MachineMode = machineMode;
                await _plcGeneralDal.Update(plcGeneral);
            }

            _plcDal.Write(DataType.DataBlock, 90, 24, machineMode);
            return new SuccessResult(PLCGeneralMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCGeneral.ReadMachineState", Priority = 2)]
        public async Task<IDataResult<MachineEnum>> ReadMachineState()//Name:MachineState,Adress:DB 90 DBW 26,Data Type:Int
        {
            var machineState = (MachineEnum)_plcDal.Read(DataType.DataBlock, 90, 26, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    MachineState = machineState,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);
            }
            else
            {
                plcGeneral.MachineState = machineState;
                await _plcGeneralDal.Update(plcGeneral);
            }

            return new SuccessDataResult<MachineEnum>(machineState, PLCGeneralMessages.Read);
        }

        [SecurityAspect("PLCGeneral.WriteMachineState", Priority = 2)]
        public async Task<IResult> WriteMachineState(MachineEnum machineState)//Name:MachineState,Adress:DB 90 DBW 26,Data Type:Int
        {
            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    MachineState = machineState,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);
            }
            else
            {
                plcGeneral.MachineState = machineState;
                await _plcGeneralDal.Update(plcGeneral);
            }

            _plcDal.Write(DataType.DataBlock, 90, 26, machineState);
            return new SuccessResult(PLCGeneralMessages.Write);
        }


        [SecurityAspect("PLCGeneral.ReadMachineSpeedSet", Priority = 2)]
        public async Task<IDataResult<short>> ReadMachineSpeedSet()//Name:MachineSpeedSet,Adress:DB 91 DBW 2 ,Data Type:Int
        {
            var machineSpeedSet = (short)_plcDal.Read(DataType.DataBlock, 91, 2, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    MachineSpeedSet = machineSpeedSet,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);
            }
            else
            {
                plcGeneral.MachineSpeedSet = machineSpeedSet;
                await _plcGeneralDal.Update(plcGeneral);
            }

            return new SuccessDataResult<short>(machineSpeedSet, PLCGeneralMessages.Read);
        }

        [SecurityAspect("PLCGeneral.WriteMachineSpeedSet", Priority = 2)]
        public async Task<IResult> WriteMachineSpeedSet(short machineSpeedSet)//Name:MachineSpeedSet,Adress:DB 91 DBW 2,Data Type:Int
        {
            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    MachineSpeedSet = machineSpeedSet,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);
            }
            else
            {
                plcGeneral.MachineSpeedSet = machineSpeedSet;
                await _plcGeneralDal.Update(plcGeneral);
            }

            _plcDal.Write(DataType.DataBlock, 91, 2, machineSpeedSet);
            return new SuccessResult(PLCGeneralMessages.Write);
        }


        //Read Only
        [SecurityAspect("PLCGeneral.ReadMachineSpeedActuel", Priority = 2)]
        public async Task<IDataResult<short>> ReadMachineSpeedActuel()//Name:MachineSpeedAct,Adress:DB 90 DBW 2
        {
            var machineSpeedActuel = (short)_plcDal.Read(DataType.DataBlock, 90, 2, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    MachineSpeedActuel = machineSpeedActuel,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);
            }
            else
            {
                plcGeneral.MachineSpeedActuel = machineSpeedActuel;
                await _plcGeneralDal.Update(plcGeneral);
            }

            return new SuccessDataResult<short>(machineSpeedActuel, PLCGeneralMessages.Read);
        }

        [SecurityAspect("PLCGeneral.WriteMachineSpeedActuel", Priority = 2)]
        public async Task<IResult> WriteMachineSpeedActuel(short machineSpeedActuel)//Name:MachineSpeedAct,Adress:DB 90 DBW 2
        {
            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    MachineSpeedActuel = machineSpeedActuel,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);
            }
            else
            {
                plcGeneral.MachineSpeedActuel = machineSpeedActuel;
                await _plcGeneralDal.Update(plcGeneral);
            }

            _plcDal.Write(DataType.DataBlock, 90, 2, machineSpeedActuel);
            return new SuccessResult(PLCGeneralMessages.Write);
        }


        [SecurityAspect("PLCGeneral.ReadMachineSpeedMaximum", Priority = 2)]
        public async Task<IDataResult<short>> ReadMachineSpeedMaximum()//Name:MachineSpeedMax,Addres:DB 90 DBW 0,Data Type:Int
        {
            var machineSpeedMaximum = (short)_plcDal.Read(DataType.DataBlock, 90, 0, VarType.Int, 1);

            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    MachineSpeedMaximum = machineSpeedMaximum,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);
            }
            else
            {
                plcGeneral.MachineSpeedMaximum = machineSpeedMaximum;
                await _plcGeneralDal.Update(plcGeneral);
            }

            return new SuccessDataResult<short>(machineSpeedMaximum, PLCGeneralMessages.Read);
        }

        [SecurityAspect("PLCGeneral.WriteMachineSpeedMaximum", Priority = 2)]
        public async Task<IResult> WriteMachineSpeedMaximum(short machineSpeedMaximum)//Name:MachineSpeedMax,Addres:DB 90 DBW 0,Data Type:Int
        {
            var plcGeneral = await _plcGeneralDal.Get(x => x.RecipeNameLast == _recipeNameLast);
            if (plcGeneral == null)
            {
                var plcGeneralId = Guid.NewGuid();
                plcGeneral = new PLCGeneral
                {
                    Id = plcGeneralId,
                    MachineSpeedMaximum = machineSpeedMaximum,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _plcGeneralDal.Add(plcGeneral);
            }
            else
            {
                plcGeneral.MachineSpeedMaximum = machineSpeedMaximum;
                await _plcGeneralDal.Update(plcGeneral);
            }

            _plcDal.Write(DataType.DataBlock, 90, 0, machineSpeedMaximum);
            return new SuccessResult(PLCGeneralMessages.Write);
        }


    }
}

