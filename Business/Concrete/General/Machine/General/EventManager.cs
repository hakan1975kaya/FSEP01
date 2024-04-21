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
    public class EventManager : IEventService
    {
        private IEventDal _eventDal;
        public EventManager(IEventDal eventDal)
        {
            _eventDal = eventDal;
        }

        [SecurityAspect("Event.Add", Priority = 2)]
        [ValidationAspect(typeof(EventValidator), Priority = 3)]
        [CacheRemoveAspect("IEventService.Get", Priority = 4)]
        public async Task<IResult> Add(Event events)
        {
            await _eventDal.Add(events);
            return new SuccessResult(EventMessages.Added);
        }

        [SecurityAspect("Event.Delete", Priority = 2)]
        [CacheRemoveAspect("IEventService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var eventDataResult = await GetById(id);
            if (eventDataResult != null)
            {
                if (eventDataResult.Success)
                {
                    var events = eventDataResult.Data;
                    events.IsActive = false;
                    await _eventDal.Update(events);
                    return new SuccessResult(EventMessages.Deleted);
                }
            }
            return new ErrorResult(EventMessages.OperationFailed);
        }

        [SecurityAspect("Event.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<Event>>> GetAll()
        {
            var events = await _eventDal.GetList(x => x.IsActive == true);
            events = events.OrderBy(x => x.LocalId).ToList();
            return new SuccessDataResult<List<Event>>(events);
        }

        [SecurityAspect("Event.GetById", Priority = 2)]
        public async Task<IDataResult<Event>> GetById(Guid id)
        {
            return new SuccessDataResult<Event>(await _eventDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("Event.Search", Priority = 2)]
        public async Task<IDataResult<List<Event>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<Event>>(await _eventDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("Event.Update", Priority = 2)]
        [ValidationAspect(typeof(EventValidator), Priority = 3)]
        [CacheRemoveAspect("IEventService.Get", Priority = 4)]
        public async Task<IResult> Update(Event events)
        {
            await _eventDal.Update(events);
            return new SuccessResult(EventMessages.Updated);
        }
    }
}
