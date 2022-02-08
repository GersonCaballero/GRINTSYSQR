using Abp.Application.Services.Dto;

namespace GRINTSYSQR.Features.Patients.Dto
{
    public class PagedPatientResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
