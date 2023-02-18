using URIS_DOKUMENTACIJA_IT72.Models.Domain;

namespace URIS_DOKUMENTACIJA_IT72.Repositories
{
    public interface IDocumentRepository
    {
       Task<IEnumerable<Document>> GetAllAsync();

       Task<Document> GetAsync(Guid id);


        Task<Document> AddAsync(Document document);

        Task<Document> DeleteAsync(Guid id);

        Task<Document> UpdateAsync(Guid id, Document document);
    }
}
