using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace GRINTSYSQR.Features.Exams.Dto
{
    [AutoMap(typeof(Exam))]
    public class ExamDto : EntityDto<long>
    {
        [Required]
        public string Name { get; set; }
    }
}
