using Land.Data;
using Land.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Land.Controllers
{
    public class LandController : Controller
    {
        private readonly ILandRepository landRepository;

        public LandController(ILandRepository landRepository)
        {
            this.landRepository = landRepository;
        }

        /// <summary>
        /// Add a new land
        /// </summary>
        /// <remarks>Add a new land</remarks>
        /// <param name="body">Create a new land</param>
        /// <response code="200">Successful operation</response>
        /// <response code="405">Invalid input</response>
        [HttpPost]
        [Route("/api/v3/land")]
        public virtual IActionResult Addland([FromBody] LandDto body)
        {
            try
            {
                LandDto land = landRepository.CreateLand(body);
                return Ok(land);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Deletes a land
        /// </summary>
        /// <remarks>delete a land</remarks>
        /// <param name="labelLand">labelLand to delete</param>
        /// <param name="apiKey"></param>
        /// <response code="400">Invalid land value</response>
        [HttpDelete]
        [Route("/api/v3/land/{labelLand}")]
        public virtual IActionResult Deleteland([FromRoute][Required] Guid labelLand, [FromHeader] string apiKey)
        {
            try
            {
                var land = landRepository.GetLandById(labelLand);

                if (land == null)
                {
                    return NotFound();
                }

                landRepository.DeleteLand(labelLand);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Find land
        /// </summary>
        /// <remarks>Returns a land</remarks>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid</response>
        [HttpGet]
        [Authorize(Roles = "superuser")]
        [Route("/api/v3/land")]
        public virtual IActionResult Getland()
        {
            var lands = landRepository.GetLand();

            if (lands == null || lands.Count == 0)
            {
                return NotFound();
            }

            return Ok(lands);
        }

        /// <summary>
        /// Find land by ID
        /// </summary>
        /// <remarks>Returns a land</remarks>
        /// <param name="labelLand">labelLand to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        [HttpGet]
        [Route("/api/v3/land/{labelLand}")]
        public virtual IActionResult GetlandById([FromRoute][Required] Guid labelLand)
        {
            var land = landRepository.GetLandById(labelLand);

            if (land == null)
            {
                return NotFound();
            }
            return Ok(land);
        }

        /// <summary>
        /// Update an existing land
        /// </summary>
        /// <remarks>Update an existing land by Id</remarks>
        /// <param name="body">Update an existent land</param>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        [HttpPut]
        [Route("/api/v3/land")]
        public virtual IActionResult Updateland([FromBody] LandDto body)
        {
            var land = landRepository.GetLandById(body.LabelLand);

            if (land == null)
            {
                return NotFound();
            }

            landRepository.UpdateLand(land, body);
            return Ok(land);
        }
    }
}
