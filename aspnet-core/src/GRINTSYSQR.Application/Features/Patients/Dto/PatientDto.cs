using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;

namespace GRINTSYSQR.Features.Patients.Dto
{
    [AutoMap(typeof(Patient))]
    public class PatientDto : EntityDto<long>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string DNI { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}
