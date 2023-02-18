using Microsoft.EntityFrameworkCore;
using URIS_Stages_it24.Models.Entities;

namespace URIS_Stages_it24.Data
{
    public class StagesAPIDbContext : DbContext
    {
        public StagesAPIDbContext(DbContextOptions<StagesAPIDbContext> options) : base(options) 
        {

        }
        public DbSet<Stage> Stages { get; set; }
    }
}
