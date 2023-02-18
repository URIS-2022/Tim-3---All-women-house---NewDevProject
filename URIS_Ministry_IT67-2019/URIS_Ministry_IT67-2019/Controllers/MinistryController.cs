using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using URIS_Ministry_IT67_2019.Entities;
using URIS_Ministry_IT67_2019.Models;
using URIS_Ministry_IT67_2019.Repositories;

namespace URIS_Ministry_IT67_2019.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MinistryController : Controller
    {
        private readonly IMinistryRepository ministryRepository;
        private readonly IMapper mapper;

        //
        public MinistryController(IMinistryRepository ministryRepository, IMapper mapper)
        {
            this.ministryRepository = ministryRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Kreira listu svih Ministarstava.
        /// </summary>
        /// <returns>Lista Ministarstava.</returns>
        /// <response code="200">Vraća listu ministarstava</response>
        [HttpGet]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> GetAllMinistries()
        {
            var ministries = await ministryRepository.GetAllMinistries();
            var ministriesDto = mapper.Map<List<MinistryDto>>(ministries);
            return Ok(ministriesDto);
        }


        /// <summary>
        /// Vraća jedno ministarstvo osnovu ID-ja.
        /// </summary>
        /// <param name="MinistryId">ID Ministartsva</param>
        /// <returns></returns>
        /// <response code="200">Vraća traženo ministarstvo</response>
        /// <response code="404">Nije pronadjeno ministarstvo</response>
        [HttpGet]
        [Route("{MinistryId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMinistry(Guid MinistryId)
        {
            var ministry = await ministryRepository.GetMinistry(MinistryId);
            if(ministry == null)
            {
                return NotFound();
            }
            var ministryDto = mapper.Map<MinistryDto>(ministry);    
            return Ok(ministryDto);
        }


        /// <summary>
        /// Kreira ministarstvo.
        /// </summary>
        /// <remarks>
        /// Primer zahteva:
        /// 
        ///     POST api/Ministry
        ///     {        
        ///       "ministryName": "Ministarstvo poljoprivrede, zemljista i vocarstva",
        ///       "minister": "Marko Markovic",
        ///       "consent": "odbijeno"        
        ///     }
        /// </remarks>
        /// <response code="201">Vraća kreirano ministarstvo</response>
        [HttpPost]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> AddMinistry(AddMinistryDto addMinistryDto)
        {
            var ministry = new Ministry()
            {
                MinistryName = addMinistryDto.MinistryName,
                Minister = addMinistryDto.Minister,
                Consent = addMinistryDto.Consent
            };

            ministry = await ministryRepository.AddMinistry(ministry);
            var ministryDto = mapper.Map<MinistryDto>(ministry);
            return CreatedAtAction(nameof(GetMinistry), new { MinistryId = ministryDto.MinistryId }, ministryDto);
        }

        /// <summary>
        /// Ažurira jedno ministarstvo.
        /// </summary>
        /// <param name="updateMinistryDto">Model ministarstva koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom ministarstvu.</returns>
        /// <response code="200">Vraća azurirano ministarstvo</response>
        /// <response code="404">Nije pronadjeno ministarstvo</response>
        [HttpPut]
        [Authorize(Roles = "superuser")]
        [Route("{MinistryId:guid}")]
        public async Task<IActionResult> UpdateMinistry(Guid MinistryId, UpdateMinistryDto updateMinistryDto)
        {
            var ministry = new Ministry()
            {
                MinistryName = updateMinistryDto.MinistryName,
                Minister = updateMinistryDto.Minister,
                Consent = updateMinistryDto.Consent
            };
            ministry = await ministryRepository.UpdateMinistry(MinistryId, ministry);
            if(ministry == null)
            {
                return NotFound();
            }
            var ministerDto = mapper.Map<MinistryDto>(ministry);
            return Ok(ministerDto);
        }

        /// <summary>
        /// Vrši brisanje jednog ministarstva na osnovu njegovog ID-ja.
        /// </summary>
        /// <param name="MinistryId">ID ministarstva</param>
        /// <response code="200">Uspesno obrisano ministarstvo</response>
        /// <response code="404">Nije pronadjeno ministarstvo</response>
        [HttpDelete]
        [Route("{MinistryId:guid}")]
        public async Task<IActionResult> DeleteMinistry(Guid MinistryId)
        {
            var ministry = await ministryRepository.DeleteMinistry(MinistryId);
            if(ministry == null)
            {
                return NotFound();
            }
            var ministryDto = mapper.Map<MinistryDto>(ministry);
            return Ok(ministryDto);
        }
    }
}
