using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Township.Data;
using Township.Entities;
using Township.Models;

namespace Township.Controllers
{
    public class TownshipController : ControllerBase
    {
        private readonly ITownshipRepository townshipRepository;

        public TownshipController(ITownshipRepository townshipRepository)
        {
            this.townshipRepository = townshipRepository;
        }

        /// <summary>
        /// Add a new township
        /// </summary>
        /// <remarks>Add a new township</remarks>
        /// <param name="body">Create a new township</param>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Invalid input</response>
        [HttpPost]
        [Route("/api/v3/township")]
        public virtual IActionResult Addtownship([FromBody] TownshipDto body)
        {
            try
            {
                TownshipDto township = townshipRepository.CreateTownship(body);
                return Ok(township);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Deletes a township
        /// </summary>
        /// <remarks>delete a township</remarks>
        /// <param name="townshipId">township id to delete</param>
        /// <param name="apiKey"></param>
        /// <response code="400">Invalid township value</response>
        [HttpDelete]
        [Route("/api/v3/township/{townshipId}")]
        public virtual IActionResult Deletetownship([FromRoute][Required] Guid townshipId, [FromHeader] string apiKey)
        {
            try
            {
                var township = townshipRepository.GetTownshipById(townshipId);

                if (township == null)
                {
                    return NotFound();
                }

                townshipRepository.DeleteTownship(townshipId);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Find township
        /// </summary>
        /// <remarks>Returns a township</remarks>
        /// <response code="200">successful operation</response>
        /// <response code="404">township not found</response>
        [HttpGet]
        [Route("/api/v3/township")]
        [Authorize(Roles = "superuser")]
        public virtual IActionResult Gettownship()
        {
            var townships = townshipRepository.GetTownships();

            if (townships == null || townships.Count == 0)
            {
                return NotFound();
            }

            return Ok(townships);
        }

        /// <summary>
        /// Find township by ID
        /// </summary>
        /// <remarks>Returns a township</remarks>
        /// <param name="townshipId">ID of township to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        [HttpGet]
        [Route("/api/v3/township/{townshipId}")]
        public virtual IActionResult GettownshipById([FromRoute][Required] Guid townshipId)
        {
            var township = townshipRepository.GetTownshipById(townshipId);

            if (township == null)
            {
                return NotFound();
            }
            return Ok(township);
        }

        /// <summary>
        /// Update an existing township
        /// </summary>
        /// <remarks>Update an existing township by Id</remarks>
        /// <param name="body">Update an existent township</param>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        [HttpPut]
        [Route("/api/v3/township")]
        public virtual IActionResult Updatetownship([FromBody] TownshipDto body)
        {
            var township = townshipRepository.GetTownshipById(body.IdTownship);

            if (township == null)
            {
                return NotFound();
            }

            townshipRepository.UpdateTownship(township, body);
            return Ok(township);
        }
    }
}
