using Abp.Application.Services;
using GRINTSYSQR.Features.Tests.Dto;

namespace GRINTSYSQR.Features.Tests
{
    public interface ITestAppService : IAsyncCrudAppService<TestDto, long, PagedTestResultRequestDto>
    {
    }
}
