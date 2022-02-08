using Abp.Application.Services;
using Abp.Domain.Repositories;
using GRINTSYSQR.Features.Results.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRINTSYSQR.Features.Results
{
    public class ResultAppService : AsyncCrudAppService<Result, ResultDto, long, PagedResultResultRequestDto>, IResultAppService
    {
        public ResultAppService(IRepository<Result, long> repository) : base(repository)
        {

        }
    }
}
