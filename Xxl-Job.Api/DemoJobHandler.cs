using DotXxlJob.Core.Model;
using DotXxlJob.Core;
using System.Threading.Tasks;

namespace Xxl_Job.Api
{
    [JobHandler("demoJobHandler")]
    public class DemoJobHandler : AbstractJobHandler
    {
        public override Task<ReturnT> Execute(JobExecuteContext context)
        {
            context.JobLogger.Log("receive demo job handler,parameter:{0}", context.JobParameter);

            return Task.FromResult(ReturnT.SUCCESS);
        }
    } 
}
