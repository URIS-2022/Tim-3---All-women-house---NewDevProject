using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using URIS_Stages_it24.Repositories;

namespace URIS_Stages_it24.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StageController : Controller
    {
        private readonly IStageRepository stageRepository;
        private readonly IMapper mapper;

        public StageController(IStageRepository stageRepository, IMapper mapper)
        {
            this.stageRepository = stageRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Retrieves all stages from the database and converts them to DTOs.
        /// </summary>
        /// <returns>A list of Stage DTOs.</returns>
        /// <response code="200">Returns a list of stages DTOs.</response>
        [HttpGet]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> GetAllStagesAsync()
        {
            //Fach data from Db
            var stagesEntity = await stageRepository.GetAllAsync();

            //Convert to Dto
            var stagesDto = mapper.Map<List<Models.DTO.Stage>>(stagesEntity);

            return Ok(stagesDto);
        }

        /// <summary>
        /// Retrieves a specific stage from the database by ID and converts it to a DTO.
        /// </summary>
        /// <param name="id">The ID of the stage to retrieve.</param>
        /// <returns>A Stage DTO.</returns>
        /// <response code="200">Returns the Stage DTO.</response>
        /// <response code="404">If no stage is found with the specified ID.</response>
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetStageByIdAsync")]
        public async Task<IActionResult> GetStageByIdAsync(Guid id)
        {
            var stageEntity = await stageRepository.GetByIdAsync(id);

            if (stageEntity == null)
            {
                return NotFound("There is no stage with this id.");
            }

            var stageDto = mapper.Map<Models.DTO.Stage>(stageEntity);
            return Ok(stageDto);
        }
        /// <summary>
        /// Adds a new Stage to the database.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///\
        /// POST api/Stage
        /// {
        /// 
        /// "stageNumber": "1",
        /// "stageDay": "2023-01-16"
        /// }
        /// </remarks>
        /// <param name="addStageRequest">The DTO containing the information for the new Stage.</param>
        /// <returns>The newly created Stage DTO.</returns>
        /// <response code="201">Returns the newly created Stage DTO.</response>
        /// <response code="400">If the request is invalid.</response>
        [HttpPost]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> AddStageAsync(Models.DTO.AddStageRequest addStageRequest)
        {
            //Request(DTO) to Entities model
            var stageEntity = new Models.Entities.Stage()
            {
                StageNumber = addStageRequest.StageNumber,
                StageDay = addStageRequest.StageDay,
            };
            //pass details to Repository
            stageEntity = await stageRepository.AddAsync(stageEntity);

            //Conwert back to DTO
            var stageDto = mapper.Map<Models.DTO.Stage>(stageEntity);

            return CreatedAtAction(nameof(GetStageByIdAsync), new { id = stageDto.StageId }, stageDto);


        }

        /// <summary>
        /// Deletes the Stage entity with the specified ID from the repository.
        /// </summary>
        /// <param name="id">The ID of the Stage entity to be deleted.</param>
        /// <returns>An IActionResult indicating the success of the operation and the deleted Stage entity.</returns>
        /// <response code="200">Returns the deleted Stage DTO.</response>
        /// <response code="404">Returns NotFound error if no Stage with the given ID is found.</response>

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteStageAsync(Guid id)
        {
            //Get stage from Db
            var stageEntity = await stageRepository.DeleteAsync(id);

            //If null NotFound
            if (stageEntity == null)
            {
                return NotFound("There is no stage with this id.");
            }

            //Convert response to DTO
            var stageDto = mapper.Map<Models.DTO.Stage>(stageEntity);
            //Return response
            return Ok(stageDto);
        }


        /// <summary>
        /// Updates an existing Stage in the database.
        /// </summary>
        /// <param name="id">The ID of the Stage to update.</param>
        /// <param name="updateStageRequest">The request data for the updated Stage.</param>
        /// <returns>The updated Stage DTO.</returns>
        /// <response code="200">Returns the updated Stage DTO.</response>
        /// <response code="400">If the request is invalid.</response>
        /// <response code="404">Returns NotFound error if no Stage with the given ID is found.</response>
        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> UpdateStageAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateStageRequest updateStageRequest)
        {
            //Convert DTO to Entities
            var stageEntity = new Models.Entities.Stage()
            {
                StageNumber = updateStageRequest.StageNumber,
                StageDay = updateStageRequest.StageDay,
            };


            //Update Stage using repository

            stageEntity = await stageRepository.UpdateAsync(id, stageEntity);

            //if null NotFound
            if (stageEntity == null)
            {
                return NotFound("There is no stage with this id.");
            }

            //Convert back to DTO
            var stageDto = mapper.Map<Models.DTO.Stage>(stageEntity);
            //Return ok
            return Ok(stageDto);
        }
    }
}
