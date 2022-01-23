using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using GRINTSYSQR.EntityFrameworkCore.Seed;

namespace GRINTSYSQR.EntityFrameworkCore
{
    [DependsOn(
        typeof(GRINTSYSQRCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class GRINTSYSQREntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<GRINTSYSQRDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        GRINTSYSQRDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        GRINTSYSQRDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(GRINTSYSQREntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
