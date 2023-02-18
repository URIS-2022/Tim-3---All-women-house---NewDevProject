using Microsoft.EntityFrameworkCore;
using URIS_Ministry_IT67_2019.Entities;

namespace URIS_Ministry_IT67_2019.Data
{
    public class MinistryDbContext: DbContext
    {
        public MinistryDbContext(DbContextOptions<MinistryDbContext> options): base(options)
        {

        }
        public DbSet<Ministry> Ministries { get; set; }
    }
}
