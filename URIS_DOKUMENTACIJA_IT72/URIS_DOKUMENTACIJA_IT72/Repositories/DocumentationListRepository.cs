using Microsoft.EntityFrameworkCore;
using URIS_DOKUMENTACIJA_IT72.Data;
using URIS_DOKUMENTACIJA_IT72.Models.Domain;

namespace URIS_DOKUMENTACIJA_IT72.Repositories
{
    public class DocumentationListRepository : IDocumentationListRepository
    {
        private readonly DocumentationAPIDbContext documentationAPIDbContext;

        public DocumentationListRepository(DocumentationAPIDbContext documentationAPIDbContext)
        {
            this.documentationAPIDbContext = documentationAPIDbContext;


        }

        public async Task<IEnumerable<DocumentationList>> GetAllAsync()
        {
            return await documentationAPIDbContext.DocumentationLists.ToListAsync();
        }

        public async Task<DocumentationList> GetAsync(Guid id)
        {
            return await documentationAPIDbContext.DocumentationLists.FirstOrDefaultAsync(x => x.DocumentationListId == id);


        }

        public async Task<DocumentationList> AddAsync(DocumentationList documentationList)
        {

            documentationList.DocumentationListId = Guid.NewGuid();
            await documentationAPIDbContext.DocumentationLists.AddAsync(documentationList);
            await documentationAPIDbContext.SaveChangesAsync();

            return documentationList;
        }

        public async Task<DocumentationList> DeleteAsync(Guid id)
        {
            var documentationList = await documentationAPIDbContext.DocumentationLists.FirstOrDefaultAsync(x => x.DocumentationListId == id);

            if (documentationList == null)
            {
                return null;

            }

            documentationAPIDbContext.DocumentationLists.Remove(documentationList);
            await documentationAPIDbContext.SaveChangesAsync();

            return documentationList;
        }



        public async Task<DocumentationList> UpdateAsync(Guid id, DocumentationList documentationList)
        {
            var existingDocumentationList = await documentationAPIDbContext.DocumentationLists.FirstOrDefaultAsync(x => x.DocumentationListId == id);

            if (existingDocumentationList == null)
            {
                return null;
            }
            existingDocumentationList.ListId = documentationList.ListId;
            existingDocumentationList.ListName = documentationList.ListName;

            await documentationAPIDbContext.SaveChangesAsync();

            return existingDocumentationList;

        }
    }
}
