using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace GRINTSYSQR.Features.Techniques.Dto
{
    [AutoMap(typeof(technique))]
    public class TechniqueDto : EntityDto<long>
    {
        [Required]
        public string Name { get; set; }
    }
}
