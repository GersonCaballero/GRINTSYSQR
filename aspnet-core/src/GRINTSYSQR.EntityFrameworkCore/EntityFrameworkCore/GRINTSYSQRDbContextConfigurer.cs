using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace GRINTSYSQR.EntityFrameworkCore
{
    public static class GRINTSYSQRDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<GRINTSYSQRDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<GRINTSYSQRDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
