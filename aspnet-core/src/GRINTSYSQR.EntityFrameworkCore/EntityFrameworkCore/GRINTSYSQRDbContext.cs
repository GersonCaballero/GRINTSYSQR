using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using GRINTSYSQR.Authorization.Roles;
using GRINTSYSQR.Authorization.Users;
using GRINTSYSQR.MultiTenancy;

namespace GRINTSYSQR.EntityFrameworkCore
{
    public class GRINTSYSQRDbContext : AbpZeroDbContext<Tenant, Role, User, GRINTSYSQRDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public GRINTSYSQRDbContext(DbContextOptions<GRINTSYSQRDbContext> options)
            : base(options)
        {
        }
    }
}
