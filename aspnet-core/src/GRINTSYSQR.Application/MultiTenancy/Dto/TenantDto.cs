using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.MultiTenancy;

namespace GRINTSYSQR.MultiTenancy.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantDto : EntityDto
    {
        [Required]
        [StringLength(AbpTenantBase.MaxTenancyNameLength)]
        [RegularExpression(AbpTenantBase.TenancyNameRegex)]
        public string TenancyName { get; set; }

        [Required]
        [StringLength(AbpTenantBase.MaxNameLength)]
        public string Name { get; set; }

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
