using Abp.Application.Services;
using Abp.Domain.Repositories;
using GRINTSYSQR.Features.Tests.Dto;

namespace GRINTSYSQR.Features.Tests
{
    public class TestAppService : AsyncCrudAppService<Test, TestDto, long, PagedTestResultRequestDto>, ITestAppService
    {
        public TestAppService(IRepository<Test, long> repository) : base(repository)
        {

        }
    }
}
