using Abp.Application.Services.Dto;

namespace GRINTSYSQR.Features.Tests.Dto
{
    public class PagedTestResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
