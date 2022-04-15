using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using GRINTSYSQR.Features.Details;
using GRINTSYSQR.Features.Doctors;
using GRINTSYSQR.Features.Patients;
using System;
using System.Collections.Generic;

namespace GRINTSYSQR.Features.Tests
{
    public class Test : Entity<long>, IFullAudited
    {
        public long? PatientId { get; set; }
        public Patient Patient { get; set; }
        public string OrderId { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime CloseDate { get; set; }
        public long? DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public ICollection<Detail> Detail{ get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
