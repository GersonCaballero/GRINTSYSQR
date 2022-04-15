using Abp.Domain.Entities;
using GRINTSYSQR.Features.Exams;
using GRINTSYSQR.Features.Results;
using GRINTSYSQR.Features.Techniques;
using GRINTSYSQR.Features.Tests;

namespace GRINTSYSQR.Features.Details
{
    public class Detail : Entity<long>
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
