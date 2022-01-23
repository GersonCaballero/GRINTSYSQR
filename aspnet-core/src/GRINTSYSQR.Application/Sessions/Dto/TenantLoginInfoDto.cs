using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GRINTSYSQR.MultiTenancy;

namespace GRINTSYSQR.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
