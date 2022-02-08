using Abp.Application.Services;
using GRINTSYSQR.Features.Results.Dto;

namespace GRINTSYSQR.Features.Results
{
    public interface IResultAppService : IAsyncCrudAppService<ResultDto, long, PagedResultResultRequestDto>
    {
    }
}
