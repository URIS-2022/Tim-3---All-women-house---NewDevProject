using URIS_ProtectedZone_IT67_2019.Entities;

namespace URIS_ProtectedZone_IT67_2019.Repositories
{
    public interface IDocumentProtectedZoneRepository
    {
        Task<IEnumerable<DocumentProtectedZone>> GetAllDocumentsProtectedZone();
        Task<DocumentProtectedZone> GetDocumentProtectedZone(Guid DocumentProtectedZoneId);
        Task<DocumentProtectedZone> AddDocumentProtectedZone(DocumentProtectedZone documentProtectedZone);
        Task<DocumentProtectedZone> UpdateDocumentProtectedZone(Guid DocumentProtectedZoneId, DocumentProtectedZone documentProtectedZone);
        Task<DocumentProtectedZone> DeleteDocumentProtectedZone(Guid DocumentProtectedZoneId);
    }
}
