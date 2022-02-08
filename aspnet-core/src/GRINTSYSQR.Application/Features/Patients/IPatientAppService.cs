using Abp.Application.Services;
using GRINTSYSQR.Features.Patients.Dto;

namespace GRINTSYSQR.Features.Patients
{
    public interface IPatientAppService: IAsyncCrudAppService<PatientDto, long, PagedPatientResultRequestDto>
    {
    }
}
