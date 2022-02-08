using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.MultiTenancy;

namespace GRINTSYSQR.MultiTenancy.Dto
{
    [AutoMapTo(typeof(Tenant))]
    public class CreateTenantDto
    {
        [Required]
        [StringLength(AbpTenantBase.MaxTenancyNameLength)]
        [RegularExpression(AbpTenantBase.TenancyNameRegex)]
        public string TenancyName { get; set; }

        [Required]
        [StringLength(AbpTenantBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string AdminEmailAddress { get; set; }

        [StringLength(AbpTenantBase.MaxConnectionStringLength)]
        public string ConnectionString { get; set; }

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

        public bool IsActive {get; set;}
    }
}
