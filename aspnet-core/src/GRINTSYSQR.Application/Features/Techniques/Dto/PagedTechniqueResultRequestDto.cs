using Abp.Application.Services.Dto;

namespace GRINTSYSQR.Features.Techniques.Dto
{
    public class PagedTechniqueResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
