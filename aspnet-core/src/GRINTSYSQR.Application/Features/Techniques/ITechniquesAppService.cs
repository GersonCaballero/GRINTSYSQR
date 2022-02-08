using Abp.Application.Services;
using GRINTSYSQR.Features.Techniques.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRINTSYSQR.Features.Techniques
{
    public interface ITechniquesAppService : IAsyncCrudAppService<TechniqueDto, long, PagedTechniqueResultRequestDto>
    {
    }
}
