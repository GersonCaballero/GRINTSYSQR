using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using GRINTSYSQR.Configuration;
using GRINTSYSQR.EntityFrameworkCore;
using GRINTSYSQR.Migrator.DependencyInjection;

namespace GRINTSYSQR.Migrator
{
    [DependsOn(typeof(GRINTSYSQREntityFrameworkModule))]
    public class GRINTSYSQRMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public GRINTSYSQRMigratorModule(GRINTSYSQREntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(GRINTSYSQRMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                GRINTSYSQRConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(GRINTSYSQRMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
