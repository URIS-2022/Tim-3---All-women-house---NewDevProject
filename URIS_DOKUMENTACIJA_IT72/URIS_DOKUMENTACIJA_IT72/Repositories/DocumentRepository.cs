using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using URIS_DOKUMENTACIJA_IT72.Data;
using URIS_DOKUMENTACIJA_IT72.Models.Domain;

namespace URIS_DOKUMENTACIJA_IT72.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly DocumentationApiDbContext documentationApiDbContext;

        public DocumentRepository(DocumentationApiDbContext documentationApiDbContext)
        {
            this.documentationApiDbContext = documentationApiDbContext;
        }

       

        public async Task<IEnumerable<Document>> GetAllAsync()
        {
           return await documentationApiDbContext.Documents
                .Include(x=>x.DocumentationLists)
                .ToListAsync();
        }

        public async Task<Document> GetAsync(Guid id)
        {

           return await documentationApiDbContext.Documents
                .Include(x => x.DocumentationLists)
                .FirstOrDefaultAsync(x => x.DocumentationListId == id);
                
        
        }

        

        public async Task<Document> AddAsync(Document document)
        {
           
            document.DocumentId = Guid.NewGuid();
            await documentationApiDbContext.Documents.AddAsync(document);
            await documentationApiDbContext.SaveChangesAsync();

            return document;
        }


        public async Task<Document> DeleteAsync(Guid id)
        {
            var document = await documentationApiDbContext.Documents.FirstOrDefaultAsync(x => x.DocumentId == id);

            if (document == null)
            {
                return null;
                
            }

            documentationApiDbContext.Documents.Remove(document);
            await documentationApiDbContext.SaveChangesAsync();

            return document;
        }



        
        public async Task<Document> UpdateAsync( Guid id, Document document)
        {
            var existingDocument = await documentationApiDbContext.Documents.FirstOrDefaultAsync(x => x.DocumentId == id);

            if (existingDocument == null)
            {
                return null;
            }
                existingDocument.ReferenceNumber = document.ReferenceNumber;
                existingDocument.Date = document.Date;
                existingDocument.CreatingDate = document.CreatingDate;
                existingDocument.DocumentationListId= document.DocumentationListId;

                await documentationApiDbContext.SaveChangesAsync();

                return existingDocument;
            
        }
    }


}
