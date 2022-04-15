using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GRINTSYSQR.Features.Exams;
using GRINTSYSQR.Features.Results;
using GRINTSYSQR.Features.Techniques;
using GRINTSYSQR.Features.Tests;

namespace GRINTSYSQR.Features.Details.Dto
{
    [AutoMap(typeof(Detail))]
    public class DetailDto : EntityDto<long>
    {
        public long? ExamId { get; set; }
        public Exam Exams { get; set; }
        public long? ResultId { get; set; }
        public Result Results { get; set; }
        public long? TechniqueId { get; set; }
        public technique Technique { get; set; }
        public long TestId { get; set; }
        public Test Test { get; set; }
    }
}
