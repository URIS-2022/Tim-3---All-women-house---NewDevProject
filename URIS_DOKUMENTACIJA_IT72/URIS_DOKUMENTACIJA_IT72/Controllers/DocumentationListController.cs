using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Metadata;
using URIS_DOKUMENTACIJA_IT72.Data;
using URIS_DOKUMENTACIJA_IT72.Models.Domain;
using URIS_DOKUMENTACIJA_IT72.Models.DTO;
using URIS_DOKUMENTACIJA_IT72.Repositories;

namespace URIS_DOKUMENTACIJA_IT72.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentationListController : Controller
    {
        private readonly IDocumentationListRepository documentationListRepository;
        public readonly IMapper mapper;


        public DocumentationListController(IDocumentationListRepository documentationListRepository, IMapper mapper)

        {
            this.documentationListRepository = documentationListRepository;
            this. mapper = mapper;
        }

        ///<summary>
        ///Retrives all Documentation Lists from the database
        ///</summary>>
        ///<returns> A list of Documentation List DTOs.</returns>
        ///<response code="200">Returns a list of Documentation List</response>

        [HttpGet]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> GetDocumentationListAsync()
        {
            var documentationListDomain = await documentationListRepository.GetAllAsync();


            var documentationListDTO = mapper.Map<List<Models.DTO.DocumentationList>>(documentationListDomain);


            return Ok(documentationListDomain);
        }
        /// <summary>
        /// Retrives specific Documentation List from the database based on given DocumentationListId
        /// </summary>
        /// 
        /// <param name="id"> The id of Documentation List to retrive</param>
        /// <returns>The Documentation List DTO with the given id</returns>
        /// <response code="200">returns DocumentationListDTO with the given id</response>
        /// <responce code="404">there is no Documentation List with given id</responce>

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetDocumentationListAsync")]
        public async Task<IActionResult> GetDocumentationListAsync(Guid id)
        {
            var documentList = await documentationListRepository.GetAsync(id);

            if (documentList == null)
            {

                return NotFound();
            }


            var documentListDTO = mapper.Map<Models.DTO.DocumentationList>(documentList);

            return Ok(documentListDTO);
        }

        /// <summary>
        /// Adds a new Documentation List to the database
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// \
        /// POST api/DocumentationList
        /// {
        /// 
        /// "ListId":1,
        /// "ListName":"Prva",
        ///  }
        /// </remarks>
        /// <param name="addDocumentationListRequest"> The DTO containing the information for the new Documentation List</param>
        /// <returns>The newly created Documentation List DTO</returns>
        /// <response code="201">Returns newly created Documentation List</response>


        [HttpPost]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> AddDocumentationListAsync(Models.DTO.AddDocumentationListRequest addDocumentationListRequest)
        {
            var docum = new Models.Domain.DocumentationList()
            {

                //     DocumentId = Guid.NewGuid(),
               ListId= addDocumentationListRequest.ListId,
               ListName= addDocumentationListRequest.ListName,
            };

            docum=await documentationListRepository.AddAsync(docum);

            var documentlistDTO = mapper.Map<Models.DTO.DocumentationList>(docum);
           


            return CreatedAtAction(nameof(GetDocumentationListAsync), new { id = documentlistDTO.DocumentationListId }, documentlistDTO);
        }

        /// <summary>
        /// Deletes a specific set of Documentation List from the database
        /// </summary>
        /// <param name="id">Id of the Documentation List to delete</param>
        /// <returns>An IActionResult containing the deleted Documentation List as DocumentationListDTO if successful,or a NotFound error if no Documentation List with the given Id are found</returns>
        /// /// <response code="200">returns deleted Documentation List and DocumentationListDTO</response>
        /// <responce code="404">Returns NotFund error if no Documentation List with with the given Id are found</responce> 


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteDocumentationListAsync(Guid id)
        {

            //get doc from database

            var documentationList = await documentationListRepository.DeleteAsync(id);

            if (documentationList == null)
            {
                return NotFound();
            }

            var documentListDTO = mapper.Map<Models.DTO.DocumentationList>(documentationList);
          

            return Ok(documentListDTO);

        }

        /// <summary>
        /// Updates a set of Documentation Lists in the database, changing all the attributes except of the primary key
        /// </summary>
        /// <param name="id"> Id of the Documentation List to update</param>
        /// <param name="updateDocumentationListRequest">The updated attributes for Documentation List, as a DTO</param>
        /// <returns>An IActionResult containing the updated Documentation List as DocumentationListDTO if successful,or a NotFound error if no Documentation List with the given Id are found</returns>
        /// <response code="200">returns updated Documentation List ad DocumentationListDTO</response>
        /// <responce code="404">Returns error if no Documentation List with the given Id are found</responce> 


        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> UpdateDocumentationListAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateDocumentationListRequest updateDocumentationListRequest)
        {
            var documentList = new Models.Domain.DocumentationList()
            {

                //     DocumentId = Guid.NewGuid(),
                ListId = updateDocumentationListRequest.ListId,
                ListName = updateDocumentationListRequest.ListName,
            };

            documentList=await documentationListRepository.UpdateAsync(id, documentList);

            if (documentList == null)
            {
                return NotFound();
            }
            var documentationListDTO = mapper.Map<Models.DTO.DocumentationList>(documentList);
          



            return Ok(documentationListDTO);

        }




    }
}
