using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using URIS_OGLAS_IT72.Models.DTO;
using URIS_OGLAS_IT72.Repositories;

namespace URIS_OGLAS_IT72.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AdvertismentController : Controller
    {
        private readonly IAdvertismentRepository advertismentRepository;
        private readonly IMapper mapper;

        public AdvertismentController(IAdvertismentRepository advertismentRepository, IMapper mapper)

        {
            this.advertismentRepository = advertismentRepository;
            this.mapper = mapper;
        }



        ///<summary>
        ///Retrives all Advertisments from the database
        ///</summary>>
        ///<returns> A list of Advertisments DTOs.</returns>
        ///<response code="200">Returns a list of Advertisments</response>


        [HttpGet]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> GetAdvertismentsAsync()
        {
            var advertisment = await advertismentRepository.GetAllAsync();



            var advertismentsDTO = mapper.Map<List<Models.DTO.Advertisment>>(advertisment);


            return Ok(advertisment);
        }
        /// <summary>
        /// Retrives specific advertisment from the database based on given Id
        /// </summary>
        /// <param name="id"> The id of advertisment to retrive</param>
        /// <returns>The advertisment DTO with the given id</returns>
        /// <response code="200">returns AdvertismentDTO with the given id</response>
        /// <responce code="404">there is no Advertisment with given id</responce>

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetAdvertismentAsync")]
        public async Task<IActionResult> GetAdvertismentAsync(Guid id)
        {
            var advertisment = await advertismentRepository.GetAsync(id);

            if (advertisment == null)
            {

                return NotFound();
            }


            var advertismentDTO = mapper.Map<Models.DTO.Advertisment>(advertisment);

            return Ok(advertismentDTO);
        }


        /// <summary>
        /// Adds a new Advertisment to the database
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// \
        /// POST api/Advertisment
        /// {
        /// "TipGaranta": 0,
        /// "DecisionOfAdvertismentId": "329dce4d-0f3c-4242-8e3d-083622fa298b"
        /// }
        /// </remarks>
        /// <param name="addAdvertismentRequest"> The DTO containing the information for the new Advertisment</param>
        /// <returns>The newly created Advertisment DTO</returns>
        /// <response code="201">Returns newly created Advertisment</response>


        [HttpPost]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> AddAdvertismentAsync([FromBody] Models.DTO.AddAdvertismentRequest addAdvertismentRequest)
        {
            var advertisment = new Models.Domain.Advertisment
            {

                //     DocumentId = Guid.NewGuid(),
                TipGaranta = addAdvertismentRequest.TipGaranta,
                DecisionOfAdvertismentId = addAdvertismentRequest.DecisionOfAdvertismentId,
            };
            advertisment = await advertismentRepository.AddAsync(advertisment);

            var advertismentDTO = mapper.Map<Models.DTO.Advertisment>(advertisment);





            return CreatedAtAction(nameof(GetAdvertismentAsync), new { id = advertismentDTO.AdvertismentId }, advertismentDTO);
        }

        /// <summary>
        /// Deletes a specific set of Advertisment from the database
        /// </summary>
        /// <param name="id">Id of the Advertisment to delete</param>
        /// <returns>An IActionResult containing the deleted Advertisment as AdvertismentDTO if successful,or a NotFound error if no Advertisment with the given Id are found</returns>
        /// /// <response code="200">returns deleted Advertisment and AdvertismentDTO</response>
        /// <responce code="404">Returns NotFund error if no Advertisment with the given Id are found</responce> 


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteAdvertismentAsync(Guid id)
        {

            //get doc from database

            var advertisment = await advertismentRepository.DeleteAsync(id);

            if (advertisment == null)
            {
                return NotFound();
            }

            var advertismentDTO = mapper.Map<Models.DTO.Advertisment>(advertisment);

            return Ok(advertismentDTO);

        }


        /// <summary>
        /// Updates a set of Advertisment in the database, changing all the attributes except of the primary key
        /// </summary>
        /// <param name="id"> Id of the Advertisment to update</param>
        /// <param name="updateAdvertismentRequest">The updated attributes for Advertisment, as a DTO</param>
        /// <returns>An IActionResult containing the updated Advertisment as AdvertismentDTO if successful,or a NotFound error if no Advertisment with the given Id are found</returns>
        /// <response code="200">returns updated Advertisment ad DocumentDTO</response>
        /// <responce code="404">Returns error if no Advertisment with the given Id are found</responce> 


        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> UpdateAdvertismentAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateAdvertismentRequest updateAdvertismentRequest)
        {
            var advertisment = new Models.Domain.Advertisment()
            {

                //     DocumentId = Guid.NewGuid(),

                TipGaranta = updateAdvertismentRequest.TipGaranta,
                DecisionOfAdvertismentId = updateAdvertismentRequest.DecisionOfAdvertismentId,
            };

            advertisment=await advertismentRepository.UpdateAsync(id, advertisment);

            if (advertisment == null)
            {
                return NotFound();
            }
            var advertismentDTO = mapper.Map<Models.DTO.Advertisment>(advertisment);



            return Ok(advertismentDTO);

        }
    }
}
