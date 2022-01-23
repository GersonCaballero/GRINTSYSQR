using System.Threading.Tasks;
using Abp.Application.Services;
using GRINTSYSQR.Sessions.Dto;

namespace GRINTSYSQR.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
