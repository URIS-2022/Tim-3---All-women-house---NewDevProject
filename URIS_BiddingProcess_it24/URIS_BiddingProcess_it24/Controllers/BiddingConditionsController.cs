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
    public class BiddingConditionsController : Controller
    {
        private readonly IBiddingConditionsRepository biddingConditionsRepository;
        private readonly IMapper mapper;

        public BiddingConditionsController(IBiddingConditionsRepository biddingConditionsRepository, IMapper mapper)
        {
            this.biddingConditionsRepository = biddingConditionsRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Retrieves all Bidding conditionss from the database.
        /// </summary>
        /// <returns>A list of Bidding conditions DTOs.</returns>
        /// <response code ="200">Returns list of Bidding conditions</response>
        [HttpGet]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> GetAllBiddingConditionsAsync()
        {
            //Fach data from Db
            var biddingConditionsEntity = await biddingConditionsRepository.GetAllAsync();
            //Convert to DTO
            var biddingConditionsDto = mapper.Map<List<Models.DTO.BiddingConditions>>(biddingConditionsEntity);
            //Return response
            return Ok(biddingConditionsDto);
        }

        /// <summary>
        /// Retrieves a specific Bidding conditions from the database based on the given id.
        /// </summary>
        /// <param name="id">The id of the Bidding conditions to retrieve.</param>
        /// <returns>The Bidding conditions DTO with the given id.</returns>
        /// <response code ="200">Returns Bidding conditions DTO with the given id</response>
        /// <response code ="404">There is no bidding conditions with this id.</response>
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetBiddingConditionsByIdAsync")]
        public async Task<IActionResult> GetBiddingConditionsByIdAsync(Guid id)
        {
            //Get data from db
            var biddingConditionsEntity = await biddingConditionsRepository.GetByIdAsync(id);
            //if null NotFound
            if(biddingConditionsEntity== null)
            {
                return NotFound("There is no bidding conditions with this id.");
            }
            //Convert to DTO
            var biddingConditionsDto = mapper.Map<Models.DTO.BiddingConditions>(biddingConditionsEntity);
            //Return response
            return Ok(biddingConditionsDto);

        }
        /// <summary>
        /// Adds a new Bidding Conditions to the database.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// \
        /// POST api/BiddingConditions
        /// {
        /// 
        /// "Price": 1000,
        /// "RentalDuration": "1 godina",
        /// "BiddingId": "4fd4a7c9-aed5-4ce5-b2f8-462c09d91bf5"
        /// }
        /// </remarks>
        /// <param name="addBiddingConditionsRequest">The DTO containing the information for the new Bidding Conditions.</param>
        /// <returns>The newly created Bidding Conditions DTO.</returns>
        /// <response code ="201">Returns newly created Bidding Conditions</response>
        [HttpPost]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> AddBiddingConditionsAsync(Models.DTO.AddBiddingConditionsRequest addBiddingConditionsRequest)
        {
            //DTO to Entity
            var biddingConditionsEntity = new Models.entity.BiddingConditions
            {
                Price = addBiddingConditionsRequest.Price,
                RentalDuration = addBiddingConditionsRequest.RentalDuration,
                BiddingId = addBiddingConditionsRequest.BiddingId,
            };

            //Pass entity object to repository
            biddingConditionsEntity = await biddingConditionsRepository.AddAsync(biddingConditionsEntity);
            //Convert back to DTO
            var biddingConditionsDto = mapper.Map<Models.DTO.BiddingConditions>(biddingConditionsEntity);
            //Return response
            return CreatedAtAction(nameof(GetBiddingConditionsByIdAsync),
                new { id = biddingConditionsDto.BiddingConditionsId }, biddingConditionsDto);
        }

        /// <summary>
        /// Updates a set of Bidding Conditions in the database, changing all attributes except for the primary key.
        /// </summary>
        /// <param name="id">The ID of the Bidding Conditions to update.</param>
        /// <param name="updateBiddingConditionsRequest">The updated attributes for the Bidding Conditions, as a DTO.</param>
        /// <returns>An IActionResult containing the updated Bidding Conditions as a BiddingConditionsDTO if successful, 
        /// or a NotFound error if no Bidding Conditions with the given ID are found.</returns>
        /// <response code ="200">Returns updated Bidding Conditions as a BiddingConditionsDTO</response>
        /// <response code ="404">Returns NotFound error if no Bidding Conditions with the given ID are found</response>
        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> UpdateBiddingConditionsAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateBiddingConditionsRequest updateBiddingConditionsRequest)
        {
            //Convert DTO to entity
            var biddingConditionsEntity = new Models.entity.BiddingConditions
            {
                Price = updateBiddingConditionsRequest.Price,
                RentalDuration = updateBiddingConditionsRequest.RentalDuration,
                BiddingId = updateBiddingConditionsRequest.BiddingId,
            };
            //Update BiddingConditions using repository
            biddingConditionsEntity = await biddingConditionsRepository.UpdateAsync(id, biddingConditionsEntity);
            //if null NotFound
            if (biddingConditionsEntity == null)
            {
                return NotFound("There is no bidding conditions with this id.");
            }
            //Convert back to DTO
            var biddingConditionsDto = mapper.Map<Models.DTO.BiddingConditions>(biddingConditionsEntity);
            //Return ok
            return Ok(biddingConditionsDto);
        }

        /// <summary>
        /// Deletes a specific set of Bidding Conditions from the database.
        /// </summary>
        /// <param name="id">The ID of the Bidding Conditions to delete.</param>
        /// <returns>An IActionResult containing the deleted Bidding Conditions as a BiddingConditionsDTO if successful,
        /// or a NotFound error if no Bidding Conditions with the given ID are found.</returns>
        /// <response code ="200">Returns deleted Bidding Conditions</response>
        /// <response code ="404">Returns NotFound error if no Bidding Conditions with the given ID are found</response>
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DelleteBiddingConditionsAsync(Guid id)
        {
            //Get bidding conditions from Db
            var biddingConditionsEntity = await biddingConditionsRepository.DeleteAsync(id);
            //If null NotFound
            if (biddingConditionsEntity == null)
            {
                return NotFound("There is no bidding conditions with this id.");
            }
            //Convert response to DTO
            var biddingConditionsDto = mapper.Map<Models.DTO.BiddingConditions>(biddingConditionsEntity);
            //Return response
            return Ok(biddingConditionsDto);
        }
    }
}
