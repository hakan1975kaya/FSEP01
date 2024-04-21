using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.General;

namespace Business.Abstract.General.General
{
    public interface ILevelThreeTelegramService
    {
        public Task<IResult> Add(LevelThreeTelegram levelThreeTelegram);
        public Task<IResult> Update(LevelThreeTelegram levelThreeTelegram);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<LevelThreeTelegram>> GetById(Guid id);
        public Task<IDataResult<List<LevelThreeTelegram>>> GetAll();
        public Task<IDataResult<List<LevelThreeTelegram>>> Search(FilterDto filterDto);
    }
}
