using Business.Abstract.General.General;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.General.Machine.General;
using Business.Validators.FluentValidators.General.General.DemandValidators;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.General.Machine.General;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.General;

namespace Business.Concrete.General.General
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class ContactRollManager : IContactRollService
    {
        private IContactRollDal _contactRollDal;
        public ContactRollManager(IContactRollDal contactRollDal)
        {
            _contactRollDal = contactRollDal;
        }

        [SecurityAspect("ContactRoll.Add", Priority = 2)]
        [ValidationAspect(typeof(ContactRollValidator), Priority = 3)]
        [CacheRemoveAspect("IContactRollService.Get", Priority = 4)]
        public async Task<IResult> Add(ContactRoll contactRoll)
        {
            await _contactRollDal.Add(contactRoll);
            return new SuccessResult(ContactRollMessages.Added);
        }

        [SecurityAspect("ContactRoll.Delete", Priority = 2)]
        [CacheRemoveAspect("IContactRollService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var contactRollDataResult = await GetById(id);
            if (contactRollDataResult != null)
            {
                if (contactRollDataResult.Success)
                {
                    var contactRoll = contactRollDataResult.Data;
                    contactRoll.IsActive = false;
                    await _contactRollDal.Update(contactRoll);
                    return new SuccessResult(ContactRollMessages.Deleted);
                }
            }
            return new ErrorResult(ContactRollMessages.OperationFailed);
        }

        [SecurityAspect("ContactRoll.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<ContactRoll>>> GetAll()
        {
            var contactRolls = await _contactRollDal.GetList(x => x.IsActive == true);
            contactRolls = contactRolls.OrderBy(x => x.RollName).ToList();
            return new SuccessDataResult<List<ContactRoll>>(contactRolls);
        }

        [SecurityAspect("ContactRoll.GetById", Priority = 2)]
        public async Task<IDataResult<ContactRoll>> GetById(Guid id)
        {
            return new SuccessDataResult<ContactRoll>(await _contactRollDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("ContactRoll.Search", Priority = 2)]
        public async Task<IDataResult<List<ContactRoll>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<ContactRoll>>(await _contactRollDal.GetList(
            x => x.IsActive == true &&
            (x.Optime.ToString().Contains(filterDto.Filter) ||
            x.RollNumber.Contains(filterDto.Filter) ||
            x.RollDiameter.ToString().Contains(filterDto.Filter) ||
            x.GroupName.Contains(filterDto.Filter) ||
            x.RollName.Contains(filterDto.Filter))));
        }

        [SecurityAspect("ContactRoll.Update", Priority = 2)]
        [ValidationAspect(typeof(ContactRollValidator), Priority = 3)]
        [CacheRemoveAspect("IContactRollService.Get", Priority = 4)]
        public async Task<IResult> Update(ContactRoll contactRoll)
        {
            await _contactRollDal.Update(contactRoll);
            return new SuccessResult(ContactRollMessages.Updated);
        }
    }
}
