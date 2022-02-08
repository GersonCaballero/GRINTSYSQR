using Abp.MultiTenancy;
using GRINTSYSQR.Authorization.Users;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string AddressLogo { get; set; }

        [Required]
        public string AddressStamp { get; set; }

        [Required]
        public string RTN { get; set; }

        [Required]
        public string PrincipalAddress { get; set; }

        [Required]
        public string SecondaryAddress { get; set; }
    }
}
