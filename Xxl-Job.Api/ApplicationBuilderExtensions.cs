using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System;
using DotXxlJob.Core;
using System.Linq;

namespace Xxl_Job.Api
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseXxlJobExecutor(this IApplicationBuilder @this)
        {
            return @this.UseMiddleware<XxlJobExecutorMiddleware>();
        }
        public static void AddCustomJobHandler(this IServiceCollection services)
        {

            #region 依赖注入 
            var baseType = typeof(IJobHandler);
            var path = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;
            var referencedAssemblies = System.IO.Directory.GetFiles(path, "*.dll").Select(Assembly.LoadFrom).ToArray();
            var types = referencedAssemblies
                .SelectMany(a => a.DefinedTypes)
                .Select(type => type.AsType())
                .Where(x => baseType.IsAssignableFrom(x) && x.IsClass && !x.IsAbstract).ToArray();

            foreach (var implementType in types)
            {
                services.AddSingleton(baseType, implementType);
            }

            #endregion 
        }
    }

}
