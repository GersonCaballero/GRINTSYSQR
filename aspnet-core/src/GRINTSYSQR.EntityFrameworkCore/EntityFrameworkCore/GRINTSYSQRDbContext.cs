using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using GRINTSYSQR.Authorization.Roles;
using GRINTSYSQR.Authorization.Users;
using GRINTSYSQR.MultiTenancy;
using GRINTSYSQR.Features.Patients;
using GRINTSYSQR.Features.Exams;
using GRINTSYSQR.Features.Doctors;
using GRINTSYSQR.Features.Results;
using GRINTSYSQR.Features.Techniques;
using GRINTSYSQR.Features.Tests;
using GRINTSYSQR.Features.Details;

namespace GRINTSYSQR.EntityFrameworkCore
{
    public class GRINTSYSQRDbContext : AbpZeroDbContext<Tenant, Role, User, GRINTSYSQRDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<technique> Techniques { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Detail> Details { get; set; }
        public GRINTSYSQRDbContext(DbContextOptions<GRINTSYSQRDbContext> options)
            : base(options)
        {
        }
    }
}
