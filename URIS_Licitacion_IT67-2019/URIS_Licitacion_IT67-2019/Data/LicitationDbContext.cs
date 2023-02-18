using Microsoft.EntityFrameworkCore;
using URIS_Licitacion_IT67_2019.Entities;

namespace URIS_Licitacion_IT67_2019.Data
{
    public class LicitationDbContext: DbContext
    {
        public LicitationDbContext(DbContextOptions<LicitationDbContext> options): base(options)
        {

        }
        public DbSet<Licitation> Licitacions { get; set; }  
    }
}
