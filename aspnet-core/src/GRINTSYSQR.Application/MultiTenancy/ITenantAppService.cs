using Abp.Application.Services;
using GRINTSYSQR.MultiTenancy.Dto;

namespace GRINTSYSQR.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

