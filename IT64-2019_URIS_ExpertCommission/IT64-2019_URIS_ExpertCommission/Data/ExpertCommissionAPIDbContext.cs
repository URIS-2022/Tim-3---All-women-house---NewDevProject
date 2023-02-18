using IT64_2019_URIS_ExpertCommission.Entities;
using Microsoft.EntityFrameworkCore;

namespace IT64_2019_URIS_ExpertCommission.Data
{
    public class ExpertCommissionAPIDbContext : DbContext
    {
        public ExpertCommissionAPIDbContext(DbContextOptions<ExpertCommissionAPIDbContext> options) : base(options)
        {
        }

        public DbSet<ExpertCommission> ExpertCommissions { get; set; }
        public DbSet<Member> Members { get; set; }

    }
}
