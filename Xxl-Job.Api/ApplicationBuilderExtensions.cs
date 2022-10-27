using Microsoft.AspNetCore.Builder;

namespace Xxl_Job.Api
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseXxlJobExecutor(this IApplicationBuilder @this)
        {
            return @this.UseMiddleware<XxlJobExecutorMiddleware>();
        }
    }

}
