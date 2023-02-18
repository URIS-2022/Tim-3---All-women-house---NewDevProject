using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using URIS_DOKUMENTACIJA_IT72.Data;
using URIS_DOKUMENTACIJA_IT72.Models.Domain;
using URIS_DOKUMENTACIJA_IT72.Models.DTO;
using URIS_DOKUMENTACIJA_IT72.Repositories;

namespace URIS_DOKUMENTACIJA_IT72.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : Controller
    {
        private readonly IDocumentRepository documentRepository;
        private readonly IMapper mapper;

        public DocumentsController(IDocumentRepository documentRepository, IMapper mapper)
        
        {
            this.documentRepository = documentRepository;
            this.mapper = mapper;
        }

        ///<summary>
        ///Retrives all Documents from the database
        ///</summary>>
        ///<returns> A list of Document DTOs.</returns>
        ///<response code="200">Returns a list of Document</response>


        [HttpGet]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> GetDocumentsAsync()
        {
           var document = await documentRepository.GetAllAsync();



           var documentsDTO= mapper.Map<List<Models.DTO.Document>>(document);


            return Ok(document);
        }
        /// <summary>
        /// Retrives specific Document from the database based on given DocumentId
        /// </summary>
        /// 
        /// <param name="id"> The id of Document to retrive</param>
        /// <returns>The Document DTO with the given id</returns>
        /// <response code="200">returns DocumentDTO with the given id</response>
        /// <responce code="404">there is no Document with given id</responce>

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetDocumentAsync")]
      

        public async Task<IActionResult> GetDocumentAsync( Guid id)
        {
            var document = await documentRepository.GetAsync(id);
           
            if(document == null) 
            {

                return NotFound();
            }


            var documentDTO=mapper.Map<Models.DTO.Document>(document);

            return Ok(documentDTO);
        }


        /// <summary>
        /// Adds a new Document to the database
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// \
        /// POST api/Document
        /// {
        /// "ReferenceNumber": 0,
        /// "Date": "2022-02-17T10:37:07.023",
        /// "CreatingDate": "2023-02-17T10:37:07.023",
        /// "DocumentationListId": "329dce4d-0f3c-4242-8e3d-083622fa298b"
        /// }
        /// </remarks>
        /// <param name="addDocumentRequest"> The DTO containing the information for the new Document</param>
        /// <returns>The newly created Document DTO</returns>
        /// <response code="201">Returns newly created Document</response>


        [HttpPost]
        [Authorize(Roles = "superuser")]

        public async Task<IActionResult> AddDocumentAsync([FromBody] Models.DTO.AddDocumentRequest addDocumentRequest)
        {
            var document = new Models.Domain.Document
            {

           //     DocumentId = Guid.NewGuid(),
                ReferenceNumber = addDocumentRequest.ReferenceNumber,
                Date = addDocumentRequest.Date,
                CreatingDate = addDocumentRequest.CreatingDate,
                DocumentationListId= addDocumentRequest.DocumentationListId,
            };
            document=await documentRepository.AddAsync(document);

            var documentDTO= mapper.Map<Models.DTO.Document>(document);



            

            return CreatedAtAction(nameof(GetDocumentAsync), new { id = documentDTO.DocumentId }, documentDTO);
        }

        /// <summary>
        /// Deletes a specific set of Document from the database
        /// </summary>
        /// <param name="id">Id of the Document to delete</param>
        /// <returns>An IActionResult containing the deleted Document as DocumentDTO if successful,or a NotFound error if no Document with the given Id are found</returns>
        /// /// <response code="200">returns deleted Document ad DocumentDTO</response>
        /// <responce code="404">Returns NotFund error if no Document with with the given Id are found</responce> 


        [HttpDelete]
        [Route("{id:guid}")]
        
        public async Task<IActionResult> DeleteDocumentAsync( Guid id)
        {

            //get doc from database

            var document = await documentRepository.DeleteAsync(id);

            if (document == null)
            {
                return NotFound();
            }

            var documentDTO =  mapper.Map<Models.DTO.Document>(document);
           
                return Ok(documentDTO);
         
        }


        /// <summary>
        /// Updates a set of Document in the database, changing all the attributes except of the primary key
        /// </summary>
        /// <param name="id"> Id of the Document to update</param>
        /// <param name="updateDocumentRequest">The updated attributes for Document, as a DTO</param>
        /// <returns>An IActionResult containing the updated Document as DocumentDTO if successful,or a NotFound error if no Document with the given Id are found</returns>
        /// <response code="200">returns updated Document ad DocumentDTO</response>
        /// <responce code="404">Returns error if no Document with the given Id are found</responce> 


        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "superuser")]

        public async Task<IActionResult> UpdateDocumentAsync([FromRoute] Guid id,[FromBody] Models.DTO.UpdateDocumentRequest updateDocumentRequest)
        {
            var document = new Models.Domain.Document()
            {

                //     DocumentId = Guid.NewGuid(),
                ReferenceNumber = updateDocumentRequest.ReferenceNumber,
                Date = updateDocumentRequest.Date,
                CreatingDate = updateDocumentRequest.CreatingDate,
                DocumentationListId= updateDocumentRequest.DocumentationListId,
            };

            document=await documentRepository.UpdateAsync(id, document);

            if (document == null)
            {
                return NotFound();
            }
            var documentDTO = mapper.Map<Models.DTO.Document>(document);



                return Ok(documentDTO);
          
        }
    }
}
