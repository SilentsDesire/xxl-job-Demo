using DotXxlJob.Core.Model;
using DotXxlJob.Core;
using System.Threading.Tasks;
using System;

namespace Xxl_Job.Api
{
    [JobHandler("demoJobHandler")]
    public class DemoJobHandler : AbstractJobHandler
    {
        public override Task<ReturnT> Execute(JobExecuteContext context)
        {
            context.JobLogger.Log("receive demo job handler,parameter:{0}", context.JobParameter);
            Console.WriteLine("parameter:{0},执行时间{1}", context.JobParameter,DateTime.Now);
            return Task.FromResult(ReturnT.SUCCESS);
        }
    } 
}
