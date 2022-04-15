using Abp.Application.Services;
using GRINTSYSQR.Features.Details.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRINTSYSQR.Features.Details
{
    public interface IDetailAppService : IAsyncCrudAppService<DetailDto, long, PagedDetailResultRequestDto>
    {
    }
}
