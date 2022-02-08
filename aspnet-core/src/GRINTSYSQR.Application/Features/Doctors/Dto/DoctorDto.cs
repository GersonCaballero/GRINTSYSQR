using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace GRINTSYSQR.Features.Doctors.Dto
{
    [AutoMap(typeof(Doctor))]
    public class DoctorDto : EntityDto<long>
    {
        [Required]
        public string Name { get; set; }
    }
}
