using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using URIS_DOKUMENTACIJA_IT72.Repositories;

namespace URIS_DOKUMENTACIJA_IT72.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DecisionsController : Controller
    {
        private readonly IDecisionRepository decisionRepository;
        public readonly IMapper mapper;


        public DecisionsController(IDecisionRepository decisionRepository, IMapper mapper)

        {
            this.decisionRepository = decisionRepository;
            this.mapper = mapper;
        }
        ///<summary>
        ///Retrives all Decisions from the database
        ///</summary>>
        ///<returns> A list of Decisions DTOs.</returns>
        ///<response code="200">Returns a list of Decisions</response>
        [HttpGet]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> GetDecisionsAsync()
        {


            var decisionDomain = await decisionRepository.GetAllAsync();


            var decisionDTO = mapper.Map<List<Models.DTO.Decision>>(decisionDomain);


            return Ok(decisionDTO);
        }

        /// <summary>
        /// Retrives specific Decisions from the database based on given DecisionId
        /// </summary>
        /// 
        /// <param name="id"> The id of Decision to retrive</param>
        /// <returns>The Decision DTO withthe given id</returns>
        /// <response code="200">returns DecisionDTO with the given id</response>
        /// <responce code="404">there is no Decision with given id</responce>

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetDecisionAsync")]
        public async Task<IActionResult> GetDecisionAsync(Guid id)
        {
            var decision = await decisionRepository.GetAsync(id);

            if (decision == null)
            {

                return NotFound();
            }


            var decisionDTO = mapper.Map<Models.DTO.Decision>(decision);

            return Ok(decisionDTO);
        }

        /// <summary>
        /// Adds a new Decision to the database
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// \
        /// POST api/Decision
        /// {
        /// 
        /// "NumberOfDecision":1,
        /// "ParliamentaryDecision":"Yes",
        /// "DocumentId":"7ab11d6f-c08c-4df0-b7ac-6518b356e206"
        /// }
        /// </remarks>
        /// <param name="addDecisionRequest"> The DTO containing the information for the new Decision</param>
        /// <returns>The newly created Decision DTO</returns>
        /// <response code="201">Returns newly created Decision</response>



        [HttpPost]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> AddDecisionAsync(Models.DTO.AddDecisionRequest addDecisionRequest)
        {
            var decisionn = new Models.Domain.Decision()
            {

                
               NumberOfDecision=addDecisionRequest.NumberOfDecision,
               ParliamentaryDecision=addDecisionRequest.ParliamentaryDecision,
               DocumentId=addDecisionRequest.DocumentId,
            };
                decisionn = await decisionRepository.AddAsync(decisionn);

            var decisionDTO = mapper.Map<Models.DTO.Decision>(decisionn);
            

            return CreatedAtAction(nameof(GetDecisionAsync), new { id = decisionDTO.DecisionId }, decisionDTO );
        }

        /// <summary>
        /// Deletes a specific set of Decision from the database
        /// </summary>
        /// <param name="id">Id of the Decision to delete</param>
        /// <returns>An IActionResult containing the deleted Decision as DecisionDTO if successful,or a NotFound error if no Decision with the given Id are found</returns>
        /// /// <response code="200">returns deleted Decision ad DecisionDTO</response>
        /// <responce code="404">Returns NotFund error if no Decisionwith with the given Id are found</responce> 

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteDecisionAsync(Guid id)
        {

           

            var decisiom = await decisionRepository.DeleteAsync(id);

            if (decisionRepository == null)
            {
                return NotFound();
            }

            var decisionDTO = mapper.Map<Models.DTO.Decision>(decisiom);
           

            return Ok(decisionDTO);

        }


        /// <summary>
        /// Updates a set of Decision in the database, changing all the attributes except of the primary key
        /// </summary>
        /// <param name="id"> Id of the Decision to update</param>
        /// <param name="updateDecisionRequest">The updated attributes for Decision, as a DTO</param>
        /// <returns>An IActionResult containing the updated Decision as DecisionDTO if successful,or a NotFound error if no Decision with the given Id are found</returns>
        /// <response code="200">returns update Decision ad DecisionDTO</response>
        /// <responce code="404">Returns error if no Decisionwith the given Id are found</responce> 


        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> UpdateDecisionAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateDecisionRequest updateDecisionRequest)
        {
            var decision = new Models.Domain.Decision()
            {

                //     DocumentId = Guid.NewGuid(),
                NumberOfDecision = updateDecisionRequest.NumberOfDecision,
                ParliamentaryDecision = updateDecisionRequest.ParliamentaryDecision,
                DocumentId = updateDecisionRequest.DocumentId,
            };

            decision=await decisionRepository.UpdateAsync(id, decision);

            if (decision == null)
            {
                return NotFound();
            }
            var decisionDTO = mapper.Map<Models.DTO.Decision>(decision);
            



            return Ok(decisionDTO);

        }
    }
}
