using Abp.Application.Services.Dto;

namespace GRINTSYSQR.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

