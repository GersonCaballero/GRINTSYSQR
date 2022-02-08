using Abp.Application.Services;
using Abp.Domain.Repositories;
using GRINTSYSQR.Features.Doctors.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRINTSYSQR.Features.Doctors
{
    public class DoctorAppService : AsyncCrudAppService<Doctor, DoctorDto, long, PagedDoctorResultRequestDto>, IDoctorAppService
    {
        public DoctorAppService(IRepository<Doctor, long> repository) : base(repository)
        {

        }
    }
}
