using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using URIS_DOKUMENTACIJA_IT72.Repositories;

namespace URIS_DOKUMENTACIJA_IT72.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BiddingProgramController:Controller
    {
        private readonly IBiddingProgramRepository biddingProgramRepository;
        public readonly IMapper mapper;


        public BiddingProgramController(IBiddingProgramRepository biddingProgramRepository, IMapper mapper)

        {
            this.biddingProgramRepository = biddingProgramRepository;
            this.mapper = mapper;
        }

        ///<summary>
        ///Retrives all Bidding Programs from the database
        ///</summary>>
        ///<returns> A list of Bidding Program DTOs.</returns>
        ///<response code="200">Returns a list of Bidding Programs</response>
        [HttpGet]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> GetBiddingProgramsAsync()
        {
            var biddingProgram = await biddingProgramRepository.GetAllAsync();


            var biddingProgramDTO = mapper.Map<List<Models.DTO.BiddingProgram>>(biddingProgram);


            return Ok(biddingProgram);
        }
        /// <summary>
        /// Retrives specific Bidding Program from the database based on given Bidding ProgramId
        /// </summary>
        /// 
        /// <param name="id"> The id of Bidding Program to retrive</param>
        /// <returns>The Bidding Program DTO withthe given id</returns>
        /// <response code="200">returns Bidding ProgramDTO with the given id</response>
        /// <responce code="404">there is no Bidding Program with given id</responce>

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetBiddingProgramAsync")]

        public async Task<IActionResult> GetBiddingProgramAsync(Guid id)
        {
            var biddingProgram = await biddingProgramRepository.GetAsync(id);

            if (biddingProgram == null)
            {

                return NotFound();
            }


            var biddingProgramDTO = mapper.Map<Models.DTO.BiddingProgram>(biddingProgram);

            return Ok(biddingProgramDTO);
        }

        /// <summary>
        /// Adds a new Bidding Program to the database
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// \
        /// POST api/BiddingProgram
        /// {
        /// 
        /// "RoundNumber":1,
        /// "DocumentId":"7ab11d6f-c08c-4df0-b7ac-6518b356e206"
        /// }
        /// </remarks>
        /// <param name="addBiddingProgram"> The DTO containing the information for the new Bidding Program</param>
        /// <returns>The newly created Bidding Program DTO</returns>
        /// <response code="201">Returns newly created Bidding Program</response>



        [HttpPost]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> AddBiddingProgramAsync(Models.DTO.AddBiddingProgram addBiddingProgram)
        {
            var biddingProgram = new Models.Domain.BiddingProgram()
            {

                RoundNumber = addBiddingProgram.RoundNumber,
                DocumentId = addBiddingProgram.DocumentId,
            };
            biddingProgram = await biddingProgramRepository.AddAsync(biddingProgram);

            var biddingProgramDTO = mapper.Map<Models.DTO.BiddingProgram>(biddingProgram);
           




            return CreatedAtAction(nameof(GetBiddingProgramAsync), new { id = biddingProgramDTO.BiddingProgramId }, biddingProgramDTO );
        }

        /// <summary>
        /// Deletes a specific set of the Bidding Program from the database
        /// </summary>
        /// <param name="id">Id of the Bidding Program to delete</param>
        /// <returns>An IActionResult containing the deleted Bidding Program as BiddingProgramDTO if successful,or a NotFound error if no Bidding Program with the given Id are found</returns>
        /// /// <response code="200">returns deleted BiddingProgram ad BiddingProgramDTO</response>
        /// <responce code="404">Returns NotFund error if no Bidding Program with with the given Id are found</responce> 


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteBiddingProgramAsync(Guid id)
        {

            //get doc from database

            var biddingProgram = await biddingProgramRepository.DeleteAsync(id);

            if (biddingProgramRepository == null)
            {
                return NotFound();
            }

            var biddingProgramDTO = mapper.Map<Models.DTO.BiddingProgram>(biddingProgram);
           

            return Ok(biddingProgramDTO);

        }

        /// <summary>
        /// Updates a set of Bidding Program in the database, changing all the attributes except of the primary key
        /// </summary>
        /// <param name="id"> Id of the Bidding Program to update</param>
        /// <param name="updateBiddingProgram">The updated attributes for Bidding Program, as a DTO</param>
        /// <returns>An IActionResult containing the updated Bidding Program as BiddingProgramDTO if successful,or a NotFound error if no Bidding Program with the given Id are found</returns>
        /// <response code="200">returns updated Bidding Program ad BiddingProgramDTO</response>
        /// <responce code="404">Returns error if no Bidding Program with the given Id are found</responce> 


        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> UpdateBiddingProgramAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateBiddingProgram updateBiddingProgram)
        {
            var biddingProgram = new Models.Domain.BiddingProgram()
            {

                RoundNumber = updateBiddingProgram.RoundNumber,
                DocumentId = updateBiddingProgram.DocumentId,

            };

            biddingProgram=await biddingProgramRepository.UpdateAsync(id, biddingProgram);

            if (biddingProgram == null)
            {
                return NotFound();
            }
            var biddingProgramDTO = mapper.Map<Models.DTO.BiddingProgram>(biddingProgram);



            return Ok(biddingProgramDTO);

        }
    }
}
