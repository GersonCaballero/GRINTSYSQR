using Abp.Application.Services;
using Abp.Domain.Repositories;
using GRINTSYSQR.Features.Exams.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRINTSYSQR.Features.Exams
{
    public class ExamAppService : AsyncCrudAppService<Exam, ExamDto, long, PagedExamResultRequestDto>, IExamAppService
    {
        public ExamAppService(IRepository<Exam, long> repository) : base(repository)
        {

        }
    }
}
