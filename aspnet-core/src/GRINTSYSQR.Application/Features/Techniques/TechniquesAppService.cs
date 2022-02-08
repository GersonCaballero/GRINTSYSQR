using Abp.Application.Services;
using Abp.Domain.Repositories;
using GRINTSYSQR.Features.Techniques.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRINTSYSQR.Features.Techniques
{
    public class TechniquesAppService : AsyncCrudAppService<technique, TechniqueDto, long, PagedTechniqueResultRequestDto>, ITechniquesAppService
    {
        public TechniquesAppService(IRepository<technique, long> repository) : base(repository)
        {

        }
    }
}
