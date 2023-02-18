using Microsoft.EntityFrameworkCore;
using URIS_DOKUMENTACIJA_IT72.Data;
using URIS_DOKUMENTACIJA_IT72.Models.Domain;

namespace URIS_DOKUMENTACIJA_IT72.Repositories
{
    public class DocumentationListRepository : IDocumentationListRepository
    {
        private readonly DocumentationApiDbContext documentationApiDbContext;

        public DocumentationListRepository(DocumentationApiDbContext documentationApiDbContext)
        {
            this.documentationApiDbContext = documentationApiDbContext;


        }

        public async Task<IEnumerable<DocumentationList>> GetAllAsync()
        {
            return await documentationApiDbContext.DocumentationLists.ToListAsync();
        }

        public async Task<DocumentationList> GetAsync(Guid id)
        {
            return await documentationApiDbContext.DocumentationLists.FirstOrDefaultAsync(x => x.DocumentationListId == id);


        }

        public async Task<DocumentationList> AddAsync(DocumentationList documentationList)
        {

            documentationList.DocumentationListId = Guid.NewGuid();
            await documentationApiDbContext.DocumentationLists.AddAsync(documentationList);
            await documentationApiDbContext.SaveChangesAsync();

            return documentationList;
        }

        public async Task<DocumentationList> DeleteAsync(Guid id)
        {
            var documentationList = await documentationApiDbContext.DocumentationLists.FirstOrDefaultAsync(x => x.DocumentationListId == id);

            if (documentationList == null)
            {
                return null;

            }

            documentationApiDbContext.DocumentationLists.Remove(documentationList);
            await documentationApiDbContext.SaveChangesAsync();

            return documentationList;
        }



        public async Task<DocumentationList> UpdateAsync(Guid id, DocumentationList documentationList)
        {
            var existingDocumentationList = await documentationApiDbContext.DocumentationLists.FirstOrDefaultAsync(x => x.DocumentationListId == id);

            if (existingDocumentationList == null)
            {
                return null;
            }
            existingDocumentationList.ListId = documentationList.ListId;
            existingDocumentationList.ListName = documentationList.ListName;

            await documentationApiDbContext.SaveChangesAsync();

            return existingDocumentationList;

        }
    }
}
