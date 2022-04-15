using Abp.Application.Services.Dto;

namespace GRINTSYSQR.Features.Details.Dto
{
    public class PagedDetailResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
