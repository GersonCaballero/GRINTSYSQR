using Abp.Application.Services.Dto;

namespace GRINTSYSQR.Features.Exams.Dto
{
    public class PagedExamResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
