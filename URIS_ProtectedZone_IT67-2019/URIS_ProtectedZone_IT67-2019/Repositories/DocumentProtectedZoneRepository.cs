using Microsoft.EntityFrameworkCore;
using URIS_ProtectedZone_IT67_2019.Data;
using URIS_ProtectedZone_IT67_2019.Entities;

namespace URIS_ProtectedZone_IT67_2019.Repositories
{
    public class DocumentProtectedZoneRepository : IDocumentProtectedZoneRepository
    {
        private readonly ProtectedZoneDbContext protectedZoneDbContext;

        public DocumentProtectedZoneRepository(ProtectedZoneDbContext protectedZoneDbContext)
        {
            this.protectedZoneDbContext = protectedZoneDbContext;
        }

        public async Task<DocumentProtectedZone> AddDocumentProtectedZone(DocumentProtectedZone documentProtectedZone)
        {
            documentProtectedZone.DocumentProtectedZoneId = Guid.NewGuid(); 
            await protectedZoneDbContext.DocumentProtectedZones.AddAsync(documentProtectedZone);    
            await protectedZoneDbContext.SaveChangesAsync();
            return documentProtectedZone;
        }

        public async Task<DocumentProtectedZone> DeleteDocumentProtectedZone(Guid DocumentProtectedZoneId)
        {
            var existingDocumentProtectedZone = await protectedZoneDbContext.DocumentProtectedZones.FindAsync(DocumentProtectedZoneId);
            if (existingDocumentProtectedZone == null)
            {
                return null;
            }
            protectedZoneDbContext.DocumentProtectedZones.Remove(existingDocumentProtectedZone);
            await protectedZoneDbContext.SaveChangesAsync();
            return existingDocumentProtectedZone;
        }

        public async Task<IEnumerable<DocumentProtectedZone>> GetAllDocumentsProtectedZone()
        {
            return await 
                protectedZoneDbContext.DocumentProtectedZones
                .Include(x => x.ProtectedZone)
                .ToListAsync();
        }

        public async Task<DocumentProtectedZone> GetDocumentProtectedZone(Guid DocumentProtectedZoneId)
        {
            return await protectedZoneDbContext.DocumentProtectedZones.FirstOrDefaultAsync(x => x.DocumentProtectedZoneId == DocumentProtectedZoneId);
        }

        public async Task<DocumentProtectedZone> UpdateDocumentProtectedZone(Guid DocumentProtectedZoneId, DocumentProtectedZone documentProtectedZone)
        {
            var existingDocumentProtectedZone = await protectedZoneDbContext.DocumentProtectedZones.FindAsync(DocumentProtectedZoneId);
            if(existingDocumentProtectedZone == null)
            {
                return null;
            }
            existingDocumentProtectedZone.Date = documentProtectedZone.Date;
            existingDocumentProtectedZone.ReferenceNumber = documentProtectedZone.ReferenceNumber;
            existingDocumentProtectedZone.DateOfSubmission = documentProtectedZone.DateOfSubmission;
            existingDocumentProtectedZone.PermitedWorks = documentProtectedZone.PermitedWorks;
            return existingDocumentProtectedZone;
        }
    }
}
