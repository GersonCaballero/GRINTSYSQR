using Abp.Application.Services;
using Abp.Domain.Repositories;
using GRINTSYSQR.Features.Patients.Dto;

namespace GRINTSYSQR.Features.Patients
{
    public class PatientAppService: AsyncCrudAppService<Patient,PatientDto, long, PagedPatientResultRequestDto>, IPatientAppService
    {
        public PatientAppService(IRepository<Patient, long> repository): base(repository)
        {
        }
    }
}
