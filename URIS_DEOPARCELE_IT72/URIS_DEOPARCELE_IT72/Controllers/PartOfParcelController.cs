using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using URIS_DEOPARCELE_IT72.Models.DTO;
using URIS_DEOPARCELE_IT72.Repositories;

namespace URIS_DEOPARCELE_IT72.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PartOfParcelController: Controller
    {
        private readonly IPartOfParcelRepository partOfParcelRepository;
        private readonly IMapper mapper;

        public PartOfParcelController(IPartOfParcelRepository partOfParcelRepository, IMapper mapper)

        {
            this.partOfParcelRepository = partOfParcelRepository;
            this.mapper = mapper;
        }



        ///<summary>
        ///Retrives all Part of parcel from the database
        ///</summary>>
        ///<returns> A list of Part of parcel DTOs.</returns>
        ///<response code="200">Returns a list of Part of parcel</response>


        [HttpGet]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> GetPartOfParcelAsync()
        {
            var partOfParcel = await partOfParcelRepository.GetAllAsync();



            var partOfParcelDTO = mapper.Map<List<Models.DTO.PartOfParcel>>(partOfParcel);


            return Ok(partOfParcel);
        }
        /// <summary>
        /// Retrives specific Part of parcel from the database based on given Id
        /// </summary>
        /// 
        /// <param name="id"> The id of Part of parcel to retrive</param>
        /// <returns>The Part of parcel DTO with the given id</returns>
        /// <response code="200">returns PartOfParcelDTO with the given id</response>
        /// <responce code="404">there is no Part of parcel with given id</responce>

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetPartOfParcelAsync")]
        public async Task<IActionResult> GetPartOfParcelAsync(Guid id)
        {
            var partOfParcel = await partOfParcelRepository.GetAsync(id);

            if (partOfParcel == null)
            {

                return NotFound();
            }


            var partOfParcelDTO = mapper.Map<Models.DTO.PartOfParcel>(partOfParcel);

            return Ok(partOfParcelDTO);
        }



        /// <summary>
        /// Adds a new Part of parcel to the database
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// \
        /// POST api/PartOfParcel
        /// {
        /// "KvalitetZemljiste": "prva klasa",
        /// "PovrsinaDelaParcele": "20"
        /// }
        /// </remarks>
        /// <param name="addPartOfParcelRequest"> The DTO containing the information for the new Part of parcel</param>
        /// <returns>The newly created Part of parcel DTO</returns>
        /// <response code="201">Returns newly created Part of parcel</response>


        [HttpPost]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> AddPartOfParcelAsync([FromBody] Models.DTO.AddPartOfParcelRequest addPartOfParcelRequest)
        {
            var partOfParcel = new Models.Domain.PartOfParcel
            {

                //     DocumentId = Guid.NewGuid(),
                KvalitetZemljiste = addPartOfParcelRequest.KvalitetZemljiste,
                PovrsinaDelaParcele = addPartOfParcelRequest.PovrsinaDelaParcele,
            };
            partOfParcel = await partOfParcelRepository.AddAsync(partOfParcel);

            var partOfParcelDTO = mapper.Map<Models.DTO.PartOfParcel>(partOfParcel);





            return CreatedAtAction(nameof(GetPartOfParcelAsync), new { id = partOfParcelDTO.PartOfParcelID }, partOfParcelDTO);
        }

        /// <summary>
        /// Deletes a specific set of Part of parcel from the database
        /// </summary>
        /// <param name="id">Id of the Part of parcel to delete</param>
        /// <returns>An IActionResult containing the deleted Part of parcel as PartOfParcelDTO if successful,or a NotFound error if no Part of parcel with the given Id are found</returns>
        /// /// <response code="200">returns deleted Part of parcel and PartOfParcelDTO</response>
        /// <responce code="404">Returns NotFund error if no Part of parcel with the given Id are found</responce> 


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeletePartOfParcelAsync(Guid id)
        {

            //get doc from database

            var partOfParcel = await partOfParcelRepository.DeleteAsync(id);

            if (partOfParcel == null)
            {
                return NotFound();
            }

            var partOfParcelDTO = mapper.Map<Models.DTO.PartOfParcel>(partOfParcel);

            return Ok(partOfParcelDTO);

        }

        /// <summary>
        /// Updates a set of Part of parcel in the database, changing all the attributes except of the primary key
        /// </summary>
        /// <param name="id"> Id of the Part of parcel to update</param>
        /// <param name="updatePartOfParcelRequest">The updated attributes for Part of parcel, as a DTO</param>
        /// <returns>An IActionResult containing the updated Part of parcel as PartOfParcelDTO if successful,or a NotFound error if no Part of parcel with the given Id are found</returns>
        /// <response code="200">returns updated Part of parcel ad PartOfParcelDTO</response>
        /// <responce code="404">Returns error if no Part of parcel with the given Id are found</responce> 


        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> UpdatePartOfParcelAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdatePartOfParcelRequest updatePartOfParcelRequest)
        {
            var partOfParcel = new Models.Domain.PartOfParcel()
            {

                //     DocumentId = Guid.NewGuid(),

                KvalitetZemljiste = updatePartOfParcelRequest.KvalitetZemljiste,
                PovrsinaDelaParcele = updatePartOfParcelRequest.PovrsinaDelaParcele,
            };

            partOfParcel=await partOfParcelRepository.UpdateAsync(id, partOfParcel);

            if (partOfParcel == null)
            {
                return NotFound();
            }
            var partOfParcelDTO = mapper.Map<Models.DTO.PartOfParcel>(partOfParcel);



            return Ok(partOfParcelDTO);

        }

    }
}
