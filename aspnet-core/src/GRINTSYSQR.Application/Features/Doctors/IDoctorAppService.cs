using Abp.Application.Services;
using GRINTSYSQR.Features.Doctors.Dto;

namespace GRINTSYSQR.Features.Doctors
{
    public interface IDoctorAppService : IAsyncCrudAppService<DoctorDto, long, PagedDoctorResultRequestDto>
    {
    }
}
