using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using URIS_OGLAS_IT72.Models.DTO;
using URIS_OGLAS_IT72.Repositories;

namespace URIS_OGLAS_IT72.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DecisionOfAdvertismentController : Controller
    {

        private readonly IDecisionOfAdvertismentRepository decisionOfAdvertismentRepository;
        public readonly IMapper mapper;


        public DecisionOfAdvertismentController(IDecisionOfAdvertismentRepository decisionOfAdvertismentRepository, IMapper mapper)

        {
            this.decisionOfAdvertismentRepository = decisionOfAdvertismentRepository;
            this.mapper = mapper;
        }



        ///<summary>
        ///Retrives all Decision Of Advertisment from the database
        ///</summary>>
        ///<returns> A list of Decision Of Advertisment DTOs.</returns>
        ///<response code="200">Returns a list of Decision Of Advertisment</response>

        [HttpGet]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> GetDecisionOfAdvertismentsAsync()
        {
            var decisionOfAdvertismentDomain = await decisionOfAdvertismentRepository.GetAllAsync();


            var decisionOfAdvertismentDTO = mapper.Map<List<Models.DTO.DecisionOfAdvertisment>>(decisionOfAdvertismentDomain);


            return Ok(decisionOfAdvertismentDomain);
        }
        /// <summary>
        /// Retrives specific Decision Of Advertisment from the database based on given Id
        /// </summary>
        /// 
        /// <param name="id"> The id of Decision Of Advertisment to retrive</param>
        /// <returns>The Decision Of Advertisment DTO with the given id</returns>
        /// <response code="200">returns DecisionOfAdvertismentDTO with the given id</response>
        /// <responce code="404">there is no Decision Of Advertisment with given id</responce>

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetDecisionOfAdvertismentAsync")]
        public async Task<IActionResult> GetDecisionOfAdvertismentAsync(Guid id)
        {
            var decisionOfAdvertisment = await decisionOfAdvertismentRepository.GetAsync(id);

            if (decisionOfAdvertisment == null)
            {

                return NotFound();
            }


            var decisionOfAdvertismentDTO = mapper.Map<Models.DTO.DecisionOfAdvertisment>(decisionOfAdvertisment);

            return Ok(decisionOfAdvertismentDTO);
        }


        /// <summary>
        /// Adds a new Decision Of Advertisment to the database
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// \
        /// POST api/DecisionOfAdvertisment
        /// {
        /// "VremeDonosenja":"02-02-2022",
        /// "NazivOdluke":"Prva",
        ///  }
        /// </remarks>
        /// <param name="addDecisionOfAdvertismentRequest"> The DTO containing the information for the new Decision Of Advertisment</param>
        /// <returns>The newly created Decision Of Advertisment DTO</returns>
        /// <response code="201">Returns newly created Decision Of Advertisment</response>


        [HttpPost]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> AddDecisionOfAdvertismentAsync(Models.DTO.AddDecisionOfAdvertismentRequest addDecisionOfAdvertismentRequest)
        {
            var decisionOfAdvertisment = new Models.Domain.DecisionOfAdvertisment()
            {

                //     DocumentId = Guid.NewGuid(),
                VremeDonosenja = addDecisionOfAdvertismentRequest.VremeDonosenja,
                NazivOdluke = addDecisionOfAdvertismentRequest.NazivOdluke,
            };

            decisionOfAdvertisment = await decisionOfAdvertismentRepository.AddAsync(decisionOfAdvertisment);

            var decisionOfAdvertismentDTO = mapper.Map<Models.DTO.DecisionOfAdvertisment>(decisionOfAdvertisment);



            return CreatedAtAction(nameof(GetDecisionOfAdvertismentAsync), new { id = decisionOfAdvertismentDTO.DecisionOfAdvertismentId }, decisionOfAdvertismentDTO);
        }

        /// <summary>
        /// Deletes a specific set of Decision Of Advertisment from the database
        /// </summary>
        /// <param name="id">Id of the Decision Of Advertisment to delete</param>
        /// <returns>An IActionResult containing the deleted Decision Of Advertisment as DecisionOfAdvertismentDTO if successful,or a NotFound error if no Decision Of Advertisment with the given Id are found</returns>
        /// /// <response code="200">returns deleted Decision Of Advertisment and DecisionOfAdvertismentDTO</response>
        /// <responce code="404">Returns NotFund error if no DecisionOfAdvertisment with with the given Id are found</responce> 


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteDecisionOfAdvertismentAsync(Guid id)
        {

            //get doc from database

            var decisionOfAdvertisment = await decisionOfAdvertismentRepository.DeleteAsync(id);

            if (decisionOfAdvertisment == null)
            {
                return NotFound();
            }

            var decisionOfAdvertismentDTO = mapper.Map<Models.DTO.DecisionOfAdvertisment>(decisionOfAdvertisment);


            return Ok(decisionOfAdvertismentDTO);

        }

        /// <summary>
        /// Updates a set of Decision Of Advertisment in the database, changing all the attributes except of the primary key
        /// </summary>
        /// <param name="id"> Id of the Decision Of Advertisment to update</param>
        /// <param name="updateDecisionOfAdvertismentRequest">The updated attributes for Decision Of Advertisment, as a DTO</param>
        /// <returns>An IActionResult containing the updated Decision Of Advertisment as DecisionOfAdvertismentDTO if successful,or a NotFound error if no Decision Of Advertisment with the given Id are found</returns>
        /// <response code="200">returns updated Decision Of Advertisment  ad DecisionOfAdvertismentDTO</response>
        /// <responce code="404">Returns error if no Decision Of Advertisment  with the given Id are found</responce> 


        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> UpdateDecisionOfAdvertismentAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateDecisionOfAdvertismentRequest updateDecisionOfAdvertismentRequest)
        {
            var decisionOfAdvertisment = new Models.Domain.DecisionOfAdvertisment()
            {

                VremeDonosenja = updateDecisionOfAdvertismentRequest.VremeDonosenja,
                NazivOdluke = updateDecisionOfAdvertismentRequest.NazivOdluke,
            };

            decisionOfAdvertisment= await decisionOfAdvertismentRepository.UpdateAsync(id, decisionOfAdvertisment);

            if (decisionOfAdvertisment == null)
            {
                return NotFound();
            }
            var decisionOfAdvertismentDTO = mapper.Map<Models.DTO.DecisionOfAdvertisment>(decisionOfAdvertisment);




            return Ok(decisionOfAdvertismentDTO);

        }
    }
}
