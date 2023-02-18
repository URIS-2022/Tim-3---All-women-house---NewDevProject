using Microsoft.EntityFrameworkCore;
using URIS_DOKUMENTACIJA_IT72.Models.Domain;

namespace URIS_DOKUMENTACIJA_IT72.Data
{
    public class DocumentationApiDbContext: DbContext
    {
        public DocumentationApiDbContext(DbContextOptions<DocumentationApiDbContext> options) : base(options)
        {

        }

        public DbSet<Document> Documents { get; set; }
        public DbSet<Decision> Decisions { get; set; }
        public DbSet<BiddingProgram> BiddingPrograms { get; set; }
        public DbSet<DocumentationList> DocumentationLists { get; set; }
    }
}
