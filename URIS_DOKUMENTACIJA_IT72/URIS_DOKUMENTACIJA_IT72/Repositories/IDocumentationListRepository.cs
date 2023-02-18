using URIS_DOKUMENTACIJA_IT72.Models.Domain;

namespace URIS_DOKUMENTACIJA_IT72.Repositories
{
    public interface IDocumentationListRepository
    {
        Task<IEnumerable<DocumentationList>> GetAllAsync();

        Task<DocumentationList> GetAsync(Guid id);


        Task<DocumentationList> AddAsync(DocumentationList documentationList);

        Task<DocumentationList> DeleteAsync(Guid id);

        Task<DocumentationList> UpdateAsync(Guid id, DocumentationList documentationList);
    }
}
