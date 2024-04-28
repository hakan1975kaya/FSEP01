using Business.Abstract.PLC.InputCoils;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using PLC.Abstract;
using S7.Net;
using System.Text;

namespace Business.Concrete.PLC.InputCoils
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class PLCInputCoilManager : IPLCInputCoilService
    {
        private IPLCDal _plcDal;
        public PLCInputCoilManager(IPLCDal plcDal)
        {
            _plcDal = plcDal;
        }
        public async Task<IDataResult<string>> ReadRecipeNumber()//Name:RecipeNameLast,Adress:DB 90 DBB 40,Data Type:String
        {
            return new SuccessDataResult<string>((string)_plcDal.Read(DataType.DataBlock, 90, 40, VarType.String, 1));
        }
        public async Task<IResult> WriteRecipeNumber(string recipeNumber)//Name:RecipeNameLast,Adress:DB 90 DBB 40,Data Type:String
        {
            _plcDal.Write(DataType.DataBlock, 90, 40,recipeNumber);
            return new SuccessResult();
        }

    }
}
