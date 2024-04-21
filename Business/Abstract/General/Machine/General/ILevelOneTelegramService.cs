using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.General;

namespace Business.Abstract.General.General
{
    public interface ILevelOneTelegramService
    {
        public Task<IResult> Add(LevelOneTelegram levelOneTelegram);
        public Task<IResult> Update(LevelOneTelegram levelOneTelegram);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<LevelOneTelegram>> GetById(Guid id);
        public Task<IDataResult<List<LevelOneTelegram>>> GetAll();
        public Task<IDataResult<List<LevelOneTelegram>>> Search(FilterDto filterDto);
    }
}
