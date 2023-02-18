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
    public class OpeningOfBidsController : Controller
    {
        private readonly IOpeningOfBidsRepository openingOfBidsRepository;
        private readonly IMapper mapper;

        public OpeningOfBidsController(IOpeningOfBidsRepository openingOfBidsRepository,IMapper mapper)
        {
            this.openingOfBidsRepository = openingOfBidsRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets all OpeningOfBids from the database.
        /// </summary>
        /// <returns>A list of OpeningOfBids DTOs.</returns>
        ///  <response code ="200">Returns list of Opening of bids</response>
        [HttpGet]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> GetAllOpeningOfBidsAsync()
        {
            //Fach data from Db
            var openingOfBidsEntity = await openingOfBidsRepository.GetAllAsync();
            //Convert to DTO
            var openingOfBidsDto = mapper.Map<List<Models.DTO.OpeningOfBids>>(openingOfBidsEntity);
            //Return response
            return Ok(openingOfBidsDto);
        }

        /// <summary>
        /// Gets an OpeningOfBids by ID.
        /// </summary>
        /// <param name="id">The ID of the OpeningOfBids to get.</param>
        /// <returns>The OpeningOfBids DTO with the specified ID.</returns>
        /// <response code ="200">Returns Opening of bids DTO with the given id</response>
        /// <response code ="404">There is no Opening of bids with this id.</response>
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetOpeningOfBidsByIdAsync")]
        public async Task<IActionResult> GetOpeningOfBidsByIdAsync(Guid id)
        {
            //Get data from db
            var openingOfBidsEntity = await openingOfBidsRepository.GetByIdAsync(id);
            //Convert to DTO
            var openingOfBidsDto = mapper.Map<Models.DTO.OpeningOfBids>(openingOfBidsEntity);
            //Return response
            return Ok(openingOfBidsDto);

        }
        /// <summary>
        /// Adds a new Opening of Bids to the database.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// \
        /// POST api/OpeningOfBids
        /// {
        /// 
        /// "ArrivingDate": "2023-02-16",
        /// "ArrivingHour": "14:30",
        /// "BiddingId": "4fd4a7c9-aed5-4ce5-b2f8-462c09d91bf5"
        /// }
        /// </remarks>
        /// <param name="addOpeningOfBidsRequest">The DTO containing the information for the new Opening of Bids.</param>
        /// <returns>The newly created Opening of Bids DTO.</returns>
        /// <returns>The newly created Bidding Conditions DTO.</returns>
        /// <response code ="201">Returns newly created Opening of bids</response>
        [HttpPost]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> AddOpeningOfBidsAsync(Models.DTO.AddOpeningOfBidsRequest addOpeningOfBidsRequest)
        {
            //DTO to Entity
            var openingOfBidsEntity = new Models.entity.OpeningOfBids
            {
                ArrivingDate = addOpeningOfBidsRequest.ArrivingDate,
                ArrivingHour = addOpeningOfBidsRequest.ArrivingHour,
                BiddingId = addOpeningOfBidsRequest.BiddingId,
            };

            //Pass entity object to repository
            openingOfBidsEntity = await openingOfBidsRepository.AddAsync(openingOfBidsEntity);
            //Convert back to DTO
            var openingOfBidsDto = mapper.Map<Models.DTO.OpeningOfBids>(openingOfBidsEntity);
            //Return response
            return CreatedAtAction(nameof(GetOpeningOfBidsByIdAsync),
                new { id = openingOfBidsDto.OpeningOfBidsId }, openingOfBidsDto);
        }

        /// <summary>
        /// Updates an existing OpeningOfBids in the database.
        /// </summary>
        /// <param name="id">The ID of the OpeningOfBids to update.</param>
        /// <param name="updateOpeningOfBidsRequest">The request data for the updated OpeningOfBids.</param>
        /// <returns>The updated OpeningOfBids DTO.</returns>
        /// <response code ="200">Returns updated opening of bids</response>
        /// <response code ="404">Returns NotFound error if no opening of bids with the given ID are found</response>
        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> UpdateOpeningOfBidsAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateOpeningOfBidsRequest updateOpeningOfBidsRequest)
        {
            //Convert DTO to entity
            var openingOfBidsEntity = new Models.entity.OpeningOfBids
            {
                ArrivingDate = updateOpeningOfBidsRequest.ArrivingDate,
                ArrivingHour = updateOpeningOfBidsRequest.ArrivingHour,
                BiddingId = updateOpeningOfBidsRequest.BiddingId,
            };
            //Update OpeningOfBids using repository
            openingOfBidsEntity = await openingOfBidsRepository.UpdateAsync(id, openingOfBidsEntity);
            //if null NotFound
            if (openingOfBidsEntity == null)
            {
                return NotFound("There is no opening of bids with this id.");
            }
            //Convert back to DTO
            var openingOfBidsDto = mapper.Map<Models.DTO.OpeningOfBids>(openingOfBidsEntity);
            //Return ok
            return Ok(openingOfBidsDto);
        }

        /// <summary>
        /// Deletes the  Opening of bids entity with the specified ID from the repository.
        /// </summary>
        /// <param name="id">The ID of the  Opening of bids entity to be deleted.</param>
        /// <returns>An IActionResult indicating the success of the operation and the deleted  Opening of bids entity.</returns>
        /// <response code ="200">Returns deleted Opening of bids</response>
        /// <response code ="404">Returns NotFound error if no Opening of bids with the given ID are found</response>
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DelleteOpeningOfBidsAsync(Guid id)
        {
            //Get bidding conditions from Db
            var openingOfBidsEntity = await openingOfBidsRepository.DeleteAsync(id);
            //If null NotFound
            if (openingOfBidsEntity == null)
            {
                return NotFound("There is no opening of bids with this id.");
            }
            //Convert response to DTO
            var openingOfBidsDto = mapper.Map<Models.DTO.OpeningOfBids>(openingOfBidsEntity);
            //Return response
            return Ok(openingOfBidsDto);
        }
    }
}
