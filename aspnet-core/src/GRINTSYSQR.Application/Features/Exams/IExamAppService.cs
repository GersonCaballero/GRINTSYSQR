using Abp.Application.Services;
using GRINTSYSQR.Features.Exams.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRINTSYSQR.Features.Exams
{
    public interface IExamAppService : IAsyncCrudAppService<ExamDto, long, PagedExamResultRequestDto>
    {
    }
}
