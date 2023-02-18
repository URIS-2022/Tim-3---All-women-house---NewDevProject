using Complaint.Data;
using Complaint.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Complaint.Controllers
{
    public class DecisionController : ControllerBase
    {
        private readonly IDecisionRepository decisionRepository;

        public DecisionController(IDecisionRepository decisionRepository)
        {
            this.decisionRepository = decisionRepository;
        }

        /// <summary>
        /// Add a new decision
        /// </summary>
        /// <remarks>Add a new decision</remarks>
        /// <param name="body">Create a new decision</param>
        /// <response code="200">Successful operation</response>
        /// <response code="405">Invalid input</response>
        [HttpPost]
        [Route("/api/v3/decision")]
        public virtual IActionResult Adddecision([FromBody] DecisionDto body)
        {
            try
            {
                DecisionDto decision = decisionRepository.CreateDecision(body);
                return Ok(decision);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Deletes a decision
        /// </summary>
        /// <remarks>delete a decision</remarks>
        /// <param name="decisionId">decision id to delete</param>
        /// <param name="apiKey"></param>
        /// <response code="400">Invalid decision value</response>
        [HttpDelete]
        [Route("/api/v3/decision/{decisionId}")]
        public virtual IActionResult Deletedecision([FromRoute][Required] Guid decisionId, [FromHeader] string apiKey)
        {
            try
            {
                var decision = decisionRepository.GetDecisionById(decisionId);

                if (decision == null)
                {
                    return NotFound();
                }

                decisionRepository.DeleteDecision(decisionId);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Find decision
        /// </summary>
        /// <remarks>Returns a decision</remarks>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid</response>
        [HttpGet]
        [Route("/api/v3/decision")]
        [Authorize(Roles = "superuser")]
        public virtual IActionResult Getdecision()
        {
            var decisions = decisionRepository.GetDecisions();

            if (decisions == null || decisions.Count == 0)
            {
                return NotFound();
            }

            return Ok(decisions);
        }

        /// <summary>
        /// Find decision by ID
        /// </summary>
        /// <remarks>Returns a decision</remarks>
        /// <param name="decisionId">ID of decision to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">decision not found</response>
        [HttpGet]
        [Route("/api/v3/decision/{decisionId}")]
        public virtual IActionResult GetdecisionById([FromRoute][Required] Guid decisionId)
        {
            var decision = decisionRepository.GetDecisionById(decisionId);

            if (decision == null)
            {
                return NotFound();
            }
            return Ok(decision);
        }

        /// <summary>
        /// Update an existing decision
        /// </summary>
        /// <remarks>Update an existing decision by Id</remarks>
        /// <param name="body">Update an existent decision</param>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">decision not found</response>
        /// <response code="405">Validation exception</response>
        [HttpPut]
        [Route("/api/v3/decision")]
        public virtual IActionResult Updatedecision([FromBody] DecisionDto body)
        {
            var decision = decisionRepository.GetDecisionById(body.IdDecision);

            if (decision == null)
            {
                return NotFound();
            }

            decisionRepository.UpdateComplaint(decision, body);
            return Ok(decision);
        }
    }
}
