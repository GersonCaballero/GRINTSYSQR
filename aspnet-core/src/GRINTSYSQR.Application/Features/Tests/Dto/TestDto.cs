using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GRINTSYSQR.Features.Details;
using GRINTSYSQR.Features.Doctors;
using GRINTSYSQR.Features.Patients;
using System;
using System.Collections.Generic;

namespace GRINTSYSQR.Features.Tests.Dto
{
    [AutoMap(typeof(Test))]
    public class TestDto : EntityDto<long>
    {
        public long? PatientId { get; set; }
        public Patient Patient { get; set; }
        public string OrderId { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime CloseDate { get; set; }
        public long? DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public ICollection<Detail> Detail { get; set; }
    }
}
