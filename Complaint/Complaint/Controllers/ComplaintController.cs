using Complaint.Data;
using Complaint.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Complaint.Controllers
{
    public class ComplaintController : ControllerBase
    {
        private readonly IComplaintRepository complaintRepository;

        public ComplaintController(IComplaintRepository complaintRepository)
        {
            this.complaintRepository = complaintRepository;
        }

        /// <summary>
        /// Add a new complaint
        /// </summary>
        /// <remarks>Add a new complaint</remarks>
        /// <param name="body">Create a new complaint</param>
        /// <response code="200">Successful operation</response>
        /// <response code="405">Invalid input</response>
        [HttpPost]
        [Route("/api/v3/complaint")]
        public virtual IActionResult Addcomplaint([FromBody] ComplaintDto body)
        {
            try
            {
                ComplaintDto complaint = complaintRepository.CreateComplaint(body);
                return Ok(complaint);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Deletes a complaint
        /// </summary>
        /// <remarks>delete a complaint</remarks>
        /// <param name="complaintId">complaint id to delete</param>
        /// <param name="apiKey"></param>
        /// <response code="400">Invalid complaint value</response>
        [HttpDelete]
        [Route("/api/v3/complaint/{complaintId}")]
        public virtual IActionResult Deletecomplaint([FromRoute][Required] Guid complaintId, [FromHeader] string apiKey)
        {
            try
            {
                var complaint = complaintRepository.GetComplaintById(complaintId);

                if (complaint == null)
                {
                    return NotFound();
                }

                complaintRepository.DeleteComplaint(complaintId);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Find complaint
        /// </summary>
        /// <remarks>Returns a complaint</remarks>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid</response>
        [HttpGet]
        [Route("/api/v3/complaint")]
        [Authorize(Roles = "superuser")]
        public virtual IActionResult Getcomplaint()
        {
            var complaints = complaintRepository.GetComplaints();

            if (complaints == null || complaints.Count == 0)
            {
                return NotFound();
            }

            return Ok(complaints);
        }

        /// <summary>
        /// Find complaint by ID
        /// </summary>
        /// <remarks>Returns a complaint</remarks>
        /// <param name="complaintId">ID of complaint to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        [HttpGet]
        [Route("/api/v3/complaint/{complaintId}")]
        public virtual IActionResult GetcomplaintById([FromRoute][Required] Guid complaintId)
        {
            var complaint = complaintRepository.GetComplaintById(complaintId);

            if (complaint == null)
            {
                return NotFound();
            }
            return Ok(complaint);
        }

        /// <summary>
        /// Update an existing complaint
        /// </summary>
        /// <remarks>Update an existing complaint by Id</remarks>
        /// <param name="body">Update an existent complaint</param>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        [HttpPut]
        [Route("/api/v3/complaint")]

        public virtual IActionResult Updatecomplaint([FromBody] ComplaintDto body)
        {
            var complaint = complaintRepository.GetComplaintById(body.IdComplaint);

            if (complaint == null)
            {
                return NotFound();
            }

            complaintRepository.UpdateComplaint(complaint, body);
            return Ok(complaint);
        }
    }
}
