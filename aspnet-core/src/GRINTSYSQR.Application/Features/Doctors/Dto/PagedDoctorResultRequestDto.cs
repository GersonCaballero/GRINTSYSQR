using Abp.Application.Services.Dto;

namespace GRINTSYSQR.Features.Doctors.Dto
{
    public class PagedDoctorResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
