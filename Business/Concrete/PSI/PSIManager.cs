using Business.Abstract.PSI;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.General.General;
using Business.Validators.FluentValidators.General.General.ApiLogValidators;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.PSI.Telegrams;
using Entities.Concrete.Dtos.PSI.Telegrams;
using Entities.Concrete.Entities.PSI.Telegrams;
using Entities.Concrete.Entities.PSI.Types;
using Microsoft.Extensions.Logging;

namespace Business.Concrete.PSI
{
    public class PSIManager : IPSIService
    {
        private IProcessDataPES2L2Dal _processDataPES2L2Dal;
        public PSIManager(IProcessDataPES2L2Dal processDataPES2L2Dal)
        {
            _processDataPES2L2Dal = processDataPES2L2Dal;
        }

        [SecurityAspect("PSI.ProcessDataPES2L2", Priority = 2)]
        [ValidationAspect(typeof(ApiLogValidator), Priority = 3)]
        public async Task<IResult> SetProcessDataPES2L2(ProcessDataPES2L2 processDataPES2L2)
        {
            var headerId= Guid.NewGuid();
            var headerTimeStampId= Guid.NewGuid();
            var eventTimeTypeTimeStampId=Guid.NewGuid();
            var lineSeqParameterListTimeStampId = Guid.NewGuid();


                   var Header=new PSITypeHeader()

            var psiProcessDataPES2L2 = new PSIProcessDataPES2L2();
            psiProcessDataPES2L2.
                      Id 
         Header 
        EventTime 
  EventCode
     LineId
        LineSequenceId 
     CountLineSeqParameter 
        CountProcessInstructions 
     Optime 
        IsActive 


        await _processDataPES2L2Dal.Add(processDataPES2L2);
            return new SuccessResult(PSIMessages.Added);
        }
    }
}
