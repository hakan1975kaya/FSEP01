using Business.Abstract.PLC;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using PLC.Abstract;
using S7.Net;

namespace Business.Concrete.PLC
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class PLCManager : IPLCService
    {
        private IPLCDal _plcDal;
        public PLCManager(IPLCDal plcDal)
        {
            _plcDal = plcDal;
        }

        public async Task<IResult> MotorStart()
        {
            _plcDal.WriteBit(DataType.Memory, 0, 0, 0, 1);
            _plcDal.WriteBit(DataType.Memory, 0, 0, 1, 0);
            return new SuccessResult();
        }
        public async Task<IResult> MotorStop()
        {
            _plcDal.WriteBit(DataType.Memory, 0, 0, 1, 1);
            _plcDal.WriteBit(DataType.Memory, 0, 0, 0, 0);
            return new SuccessResult();
        }
    }
}
