using Abp.Application.Services;
using Abp.Domain.Repositories;
using GRINTSYSQR.Features.Details.Dto;

namespace GRINTSYSQR.Features.Details
{
    public class DetailAppService : AsyncCrudAppService<Detail, DetailDto, long, PagedDetailResultRequestDto>, IDetailAppService
    {
        public DetailAppService(IRepository<Detail, long> repository) : base(repository)
        {

        }
    }
}
