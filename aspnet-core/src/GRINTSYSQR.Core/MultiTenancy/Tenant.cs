using Abp.MultiTenancy;
using GRINTSYSQR.Authorization.Users;

namespace GRINTSYSQR.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
