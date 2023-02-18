using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using URIS_BiddingProcess_it24.Models.DTO;
using URIS_BiddingProcess_it24.Repositories;

namespace URIS_BiddingProcess_it24.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BiddingsController : Controller
    {
        private readonly IBiddingRepository biddingRepository;
        private readonly IMapper mapper;

        public BiddingsController(IBiddingRepository biddingRepository, IMapper mapper)
        {
            this.biddingRepository = biddingRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Retrieves all Biddings from the database.
        /// </summary>
        /// <returns>A list of Bidding DTOs.</returns>
        /// <response code ="200">Returns list of Biddings</response>
        [HttpGet]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> GetAllBiddingsAsync()
        {
            var biddingsEntity = await biddingRepository.GetAllAsync();

            //return DTO Bidding
            

            var biddingsDto = mapper.Map<List<Models.DTO.Bidding>>(biddingsEntity);

            return Ok(biddingsDto);
        }

        /// <summary>
        /// Retrieves a specific Bidding from the database based on the given id.
        /// </summary>
        /// <param name="id">The id of the Bidding to retrieve.</param>
        /// <returns>The Bidding DTO with the given id.</returns>
        /// <response code ="200">Returns Bidding  DTO with the given id</response>
        /// <response code ="404">There is no bidding with given id.</response>
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetBiddingByIdAsync")]
        public async Task<IActionResult> GetBiddingByIdAsync(Guid id)
        {
            var biddingEntity = await biddingRepository.GetByIdAsync(id);

            if(biddingEntity == null)
            {
                return NotFound("There is no bidding with this id.");
            }

            var biddingDto = mapper.Map<Models.DTO.Bidding>(biddingEntity);
            return Ok(biddingDto);
        }

        /// <summary>
        /// Creates a new Bidding entity from the provided DTO and adds it to the repository.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// \
        /// POST api/Bidding
        /// {
        /// 
        ///		"biddingCode": "002",
        ///		"type": "Javna licitacija",
        ///		"status": "Prvi krug",
        ///		"excepted": true,
        ///		"startingPrice": 12000,
        ///		"dateOfMaintenance": "2023-01-16",
        ///		"startTime": "2023-01-16T12:00:00",
        ///		"endTime": "2023-01-16T12:00:00"
        /// }
        /// </remarks>
        /// <param name="addBiddingRequest">The DTO containing details for the new Bidding entity.</param>
        /// <returns>An IActionResult indicating the success of the operation and the newly created Bidding entity.</returns>
        /// <response code ="201">Returns newly created Bidding </response>

        [HttpPost]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> AddBiddingAsync(Models.DTO.AddBiddingRequest addBiddingRequest)
        {
            //Request(DTO) to entity model
            var biddingEntity = new Models.entity.Bidding()
            {
                BiddingCode= addBiddingRequest.BiddingCode,
                Type=addBiddingRequest.Type,
                Status=addBiddingRequest.Status,
                Excepted=addBiddingRequest.Excepted,
                StartingPrice=addBiddingRequest.StartingPrice,
                DateOfMaintenance=addBiddingRequest.DateOfMaintenance,
                StartTime=addBiddingRequest.StartTime,
                EndTime=addBiddingRequest.EndTime,
            };
            //pass details to Repository
            biddingEntity = await biddingRepository.AddAsync(biddingEntity);

            //Conwert back to DTO
            var biddingDto = mapper.Map<Models.DTO.Bidding>(biddingEntity);

            return CreatedAtAction(nameof(GetBiddingByIdAsync), new {id=biddingDto.BiddingId},biddingDto);


        }

        /// <summary>
        /// Deletes the Bidding entity with the specified ID from the repository.
        /// </summary>
        /// <param name="id">The ID of the Bidding entity to be deleted.</param>
        /// <returns>An IActionResult indicating the success of the operation and the deleted Bidding entity.</returns>
        /// <response code ="200">Returns deleted Bidding</response>
        /// <response code ="404">Returns NotFound error if no Bidding with the given ID are found</response>
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteBiddingAsync(Guid id)
        {
            //Get bidding from Db
            var biddingEntity = await biddingRepository.DeleteAsync(id);

            //If null NotFound
            if(biddingEntity== null)
            {
                return NotFound("There is no bidding with this id.");
            }

            //Convert response to DTO
            var biddingDto = mapper.Map<Models.DTO.Bidding>(biddingEntity);
            //Return response
            return Ok(biddingDto);
        }

        /// <summary>
        /// Updates the specified Bidding entity in the repository with the provided DTO values.
        /// </summary>
        /// <param name="id">The ID of the Bidding entity to be updated.</param>
        /// <param name="updateBiddingRequest">The DTO containing the updated details for the Bidding entity.</param>
        /// <returns>An IActionResult indicating the success of the operation and the updated Bidding entity.</returns>
        /// <response code ="200">Returns updated Bidding as a BiddingDTO</response>
        /// <response code ="404">Returns NotFound error if no Bidding with the given ID are found</response>
        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> UpdateBiddingAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateBiddingRequest updateBiddingRequest)
        {
            //Convert DTO to entity
            var biddingEntity = new Models.entity.Bidding()
            {
                BiddingCode = updateBiddingRequest.BiddingCode,
                Type = updateBiddingRequest.Type,
                Status = updateBiddingRequest.Status,
                Excepted = updateBiddingRequest.Excepted,
                StartingPrice = updateBiddingRequest.StartingPrice,
                DateOfMaintenance = updateBiddingRequest.DateOfMaintenance,
                StartTime = updateBiddingRequest.StartTime,
                EndTime = updateBiddingRequest.EndTime,
            };


            //Update Bidding using repository

            biddingEntity = await biddingRepository.UpdateAsync(id, biddingEntity);

            //if null NotFound
            if(biddingEntity== null) 
            {
                return NotFound("There is no bidding with this id.");
            }

            //Convert back to DTO
            var biddingDto = mapper.Map<Models.DTO.Bidding>(biddingEntity);
            //Return ok
            return Ok(biddingDto);
        }
    }
}
