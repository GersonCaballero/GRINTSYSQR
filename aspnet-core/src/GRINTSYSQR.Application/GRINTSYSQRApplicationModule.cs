using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using GRINTSYSQR.Authorization;

namespace GRINTSYSQR
{
    [DependsOn(
        typeof(GRINTSYSQRCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class GRINTSYSQRApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<GRINTSYSQRAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(GRINTSYSQRApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
