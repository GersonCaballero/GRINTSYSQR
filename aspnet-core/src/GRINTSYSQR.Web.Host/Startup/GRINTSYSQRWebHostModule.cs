using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using GRINTSYSQR.Configuration;

namespace GRINTSYSQR.Web.Host.Startup
{
    [DependsOn(
       typeof(GRINTSYSQRWebCoreModule))]
    public class GRINTSYSQRWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public GRINTSYSQRWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(GRINTSYSQRWebHostModule).GetAssembly());
        }
    }
}
