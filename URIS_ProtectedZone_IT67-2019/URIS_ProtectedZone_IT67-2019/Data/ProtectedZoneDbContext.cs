using Microsoft.EntityFrameworkCore;
using URIS_ProtectedZone_IT67_2019.Entities;

namespace URIS_ProtectedZone_IT67_2019.Data
{
    public class ProtectedZoneDbContext: DbContext
    {
        public ProtectedZoneDbContext(DbContextOptions<ProtectedZoneDbContext> options): base(options)
        {

        }
        public DbSet<ProtectedZone> ProtectedZones { get; set; }
        public DbSet<DocumentProtectedZone> DocumentProtectedZones { get; set; }

    }
}
