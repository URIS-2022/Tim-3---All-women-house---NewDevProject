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
    public class PublicBiddingController : Controller
    {
        private readonly IPublicBiddingRepository publicBiddingRepository;
        private readonly IMapper mapper;

        public PublicBiddingController(IPublicBiddingRepository publicBiddingRepository, IMapper mapper)
        {
            this.publicBiddingRepository = publicBiddingRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Retrieves all Public Biddings from the database and returns them as a list of PublicBiddingDTOs.
        /// </summary>
        /// <returns>An IActionResult containing a list of all Public Biddings in the database as PublicBiddingDTOs.</returns>
        /// <response code ="200">Returns list of Public Biddings</response>
        [HttpGet]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> GetAllPublicBiddingsAsync()
        {
            //Fach data from Db
            var publicBiddingEntity = await publicBiddingRepository.GetAllAsync();
            //Convert to DTO
            var publicBiddingDto = mapper.Map<List<Models.DTO.PublicBidding>>(publicBiddingEntity);
            //Return response
            return Ok(publicBiddingDto);
        }

        /// <summary>
        /// Retrieves a specific Public Bidding from the database based on its ID.
        /// </summary>
        /// <param name="id">The ID of the Public Bidding to retrieve.</param>
        /// <returns>An IActionResult containing the retrieved Public Bidding as a PublicBiddingDTO if successful, or a NotFound error if no Public Bidding with the given ID is found.</returns>
        /// <response code ="200">Returns Public Bidding  DTO with the given id</response>
        /// <response code ="404">There is no Public Bidding with this id.</response>
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetPublicBiddingByIdAsync")]
        public async Task<IActionResult> GetPublicBiddingByIdAsync(Guid id)
        {
            //Get data from db
            var publicBiddingEntity = await publicBiddingRepository.GetByIdAsync(id);
            //Convert to DTO
            var publicBiddingDto = mapper.Map<Models.DTO.PublicBidding>(publicBiddingEntity);
            //Return response
            return Ok(publicBiddingDto);

        }
        /// <summary>
        /// Adds a new Public Bidding to the database.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// \
        /// POST api/PublicBidding
        /// {
        /// 
        /// "PriceStep": 100,
        /// "BiddingId": "4fd4a7c9-aed5-4ce5-b2f8-462c09d91bf5"
        /// }
        /// </remarks>
        /// <param name="addPublicBiddingRequest">The DTO containing the information for the new Public Bidding.</param>
        /// <returns>The newly created Public Bidding DTO.</returns>
        /// <response code ="201">Returns newly created Public Bidding</response>
        [HttpPost]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> AddPublicBiddingAsync(Models.DTO.AddPublicBiddingRequest addPublicBiddingRequest)
        {
            //DTO to Entity
            var publicBiddingEntity = new Models.entity.PublicBidding
            {
                PriceStep = addPublicBiddingRequest.PriceStep,
                BiddingId = addPublicBiddingRequest.BiddingId,
            };

            //Pass entity object to repository
            publicBiddingEntity = await publicBiddingRepository.AddAsync(publicBiddingEntity);
            //Convert back to DTO
            var publicBiddingDto = mapper.Map<Models.DTO.PublicBidding>(publicBiddingEntity);
            //Return response
            return CreatedAtAction(nameof(GetPublicBiddingByIdAsync),
                new { id = publicBiddingDto.PublicBiddingId }, publicBiddingDto);
        }


        /// <summary>
        /// Updates a Public Bidding in the database, changing all attributes except for the primary key.
        /// </summary>
        /// <param name="id">The ID of the Public Bidding to update.</param>
        /// <param name="updatePublicBiddingRequest">The updated attributes for the Public Bidding, as a DTO.</param>
        /// <returns>An IActionResult containing the updated Public Bidding as a PublicBiddingDTO if successful, or a NotFound error if no Public Bidding with the given ID is found.</returns>
        /// <response code ="200">Returns updated Public Bidding as a BiddingConditionsDTO</response>
        /// <response code ="404">Returns NotFound error if no Public Bidding with the given ID are found</response>
        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> UpdatePublicBiddingAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdatePublicBiddingRequest updatePublicBiddingRequest)
        {
            //Convert DTO to entity
            var publicBiddingEntity = new Models.entity.PublicBidding
            {
                PriceStep = updatePublicBiddingRequest.PriceStep,
                BiddingId = updatePublicBiddingRequest.BiddingId,
            };
            //Update BiddingConditions using repository
            publicBiddingEntity = await publicBiddingRepository.UpdateAsync(id,publicBiddingEntity);
            //if null NotFound
            if (publicBiddingEntity == null)
            {
                return NotFound("There is no public bidding with this id.");
            }
            //Convert back to DTO
            var publicBiddingDto = mapper.Map<Models.DTO.PublicBidding>(publicBiddingEntity);
            //Return ok
            return Ok(publicBiddingDto);
        }

        /// <summary>
        /// Deletes a specific Public Bidding from the database.
        /// </summary>
        /// <param name="id">The ID of the Public Bidding to delete.</param>
        /// <returns>An IActionResult containing the deleted Public Bidding as a PublicBiddingDTO if successful, or a NotFound error if no Public Bidding with the given ID is found.</returns>
        /// <response code ="200">Returns deleted Public Bidding</response>
        /// <response code ="404">Returns NotFound error if no Public Bidding with the given ID are found</response>
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DelletePublicBiddingAsync(Guid id)
        {
            //Get bidding conditions from Db
            var publicBiddingEntity = await publicBiddingRepository.DeleteAsync(id);
            //If null NotFound
            if (publicBiddingEntity == null)
            {
                return NotFound("There is no public bidding with this id.");
            }
            //Convert response to DTO
            var publicBiddingDto = mapper.Map<Models.DTO.PublicBidding>(publicBiddingEntity);
            //Return response
            return Ok(publicBiddingDto);
        }

    }
}
