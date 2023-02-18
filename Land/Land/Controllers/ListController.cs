using Land.Data;
using Land.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Land.Controllers
{
    public class ListController : Controller
    {
        private readonly IListRepository listRepository;

        public ListController(IListRepository listRepository)
        {
            this.listRepository = listRepository;
        }

        /// <summary>
        /// Add a new list
        /// </summary>
        /// <remarks>Add a new list</remarks>
        /// <param name="body">Create a new list</param>
        /// <response code="200">Successful operation</response>
        /// <response code="405">Invalid input</response>
        [HttpPost]
        [Route("/api/v3/list")]
        [Authorize(Roles = "superuser")]
        public virtual IActionResult Addlist([FromBody] ListDto body)
        {
            try
            {
                ListDto list = listRepository.CreateList(body);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Deletes a list
        /// </summary>
        /// <remarks>delete a list</remarks>
        /// <param name="listId">list id to delete</param>
        /// <param name="apiKey"></param>
        /// <response code="400">Invalid list value</response>
        [HttpDelete]
        [Route("/api/v3/list/{listId}")]
        public virtual IActionResult Deletelist([FromRoute][Required] Guid listId, [FromHeader] string apiKey)
        {
            try
            {
                var list = listRepository.GetListById(listId);

                if (list == null)
                {
                    return NotFound();
                }

                listRepository.DeleteList(listId);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Find list
        /// </summary>
        /// <remarks>Returns a list</remarks>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid</response>
        [HttpGet]
        [Route("/api/v3/list")]
        public virtual IActionResult Getlist()
        {
            var list = listRepository.GetList();

            if (list == null || list.Count == 0)
            {
                return NotFound();
            }

            return Ok(list);
        }

        /// <summary>
        /// Find list by ID
        /// </summary>
        /// <remarks>Returns a list</remarks>
        /// <param name="listId">ID of list to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        [HttpGet]
        [Route("/api/v3/list/{listId}")]
        public virtual IActionResult GetlistById([FromRoute][Required] Guid listId)
        {
            var list = listRepository.GetListById(listId);

            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }

        /// <summary>
        /// Update an existing list
        /// </summary>
        /// <remarks>Update an existing list by Id</remarks>
        /// <param name="body">Update an existent list</param>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        [HttpPut]
        [Route("/api/v3/list")]
        public virtual IActionResult Updatelist([FromBody] ListDto body)
        {
            var list = listRepository.GetListById(body.IdList);

            if (list == null)
            {
                return NotFound();
            }

            listRepository.UpdateList(list, body);
            return Ok(list);
        }

        /// <summary>
        /// Deletes a list
        /// </summary>
        /// <remarks>delete a list</remarks>
        /// <param name="idLandPart">list id to delete</param>
        /// <param name="apiKey"></param>
        /// <response code="400">Invalid list value</response>
        [HttpDelete]
        [Route("/api/v3/list/sold/{idLandPart}")]
        public virtual IActionResult Delete([FromRoute][Required] Guid idLandPart, [FromHeader] string apiKey)
        {
            try
            {
                Guid? landId = listRepository.GetLandId(idLandPart);
                if (landId == null)
                {
                    return NotFound("Land not found");
                }

                var landParts = listRepository.GetLandParts((Guid)landId);
                if (landParts == "" || landParts == null)
                {
                    return NotFound("Land parts not found");
                }

                try
                {
                    dynamic data = JsonConvert.DeserializeObject<List<LandPartDto>>(landParts) ?? throw new ArgumentException("Land parts not found");
                    foreach (var landPart in data)
                    {
                        bool? status = listRepository.GetStatus(landPart.idLandPart);

                        if (status == null)
                        {
                            return NotFound("Status of land part" + landPart.idLandPart + "not found");
                        }

                        if ((bool)!status)
                        {
                            return Ok("Not all parts are sold.");
                        }
                    }
                    ListDto list = listRepository.GetListByLandId((Guid)landId) ?? throw new Exception("List not found");
                    listRepository.DeleteList(list.IdList);
                    return Ok("All parts of land are sold");

                } catch (Exception ex) {
                    return BadRequest(ex.ToString());
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }
    }
}
