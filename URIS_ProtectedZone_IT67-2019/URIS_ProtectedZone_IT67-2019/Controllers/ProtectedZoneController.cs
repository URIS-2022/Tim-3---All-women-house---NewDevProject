using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;
using URIS_ProtectedZone_IT67_2019.Entities;
using URIS_ProtectedZone_IT67_2019.Models;
using URIS_ProtectedZone_IT67_2019.Repositories;

namespace URIS_ProtectedZone_IT67_2019.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProtectedZoneController : Controller
    {
        private readonly IProtectedZoneRepository protectedZoneRepository;
        private readonly IMapper mapper;

        public ProtectedZoneController(IProtectedZoneRepository protectedZoneRepository, IMapper mapper)
        {
            this.protectedZoneRepository = protectedZoneRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Kreira listu svih zasticenih zona.
        /// </summary>
        /// <response code="200">Vraća listu zasticenih zona</response>
        [HttpGet]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> GetAllProtectedZones()
        {
            var protectedZones = await protectedZoneRepository.GetAllProtectedZones();
            var protectedZonesDto = mapper.Map<List<ProtectedZoneDto>>(protectedZones);
            return Ok(protectedZonesDto);
        }

        /// <summary>
        /// Vraća jednu zasticenu zonu na osnovu ID-ja.
        /// </summary>
        /// <param name="ProtectedZoneId">ID Zasticene zone</param>
        /// <returns></returns>
        /// <response code="200">Vraća traženu zonu</response>
        /// <response code="404">Nije pronadjena zona</response>
        [HttpGet]
        [Route("{ProtectedZoneId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProtectedZone(Guid ProtectedZoneId)
        {
            var protectedZone = await protectedZoneRepository.GetProtectedZone(ProtectedZoneId);
            if(protectedZone == null)
            {
                return NotFound();
            }
            var protectedZoneDto = mapper.Map<ProtectedZone>(protectedZone);
            return Ok(protectedZoneDto);
        }

        /// <summary>
        /// Kreira zasticenu zonu.
        /// </summary>
        /// <remarks>
        /// Primer zahteva:
        /// 
        ///     POST api/ProtectedZone
        ///     {        
        ///       "NumberOfZone": 23,
        ///       "PermittedWorks": "Izgradnja novog objekta"
        ///     }
        /// </remarks>
        /// <response code="201">Vraća kreiranu zonu</response>
        [HttpPost]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> AddProtectedZone(AddProtectedZoneDto addProtectedZoneDto)
        {
            var protectedZone = new ProtectedZone()
            {
                NumberOfZone = addProtectedZoneDto.NumberOfZone,
                PermittedWorks = addProtectedZoneDto.PermittedWorks,
            };

            protectedZone = await protectedZoneRepository.AddProtectedZone(protectedZone);
            var protectedZoneDto = mapper.Map<ProtectedZoneDto>(protectedZone); 
            return Ok(protectedZoneDto);
        }

        /// <summary>
        /// Ažurira jednu zasticenu zonu.
        /// </summary>
        /// <param name="updateProtectedZoneDto">Model zasticene zone koji se azurira</param>
        /// <response code="200">Vraća azuriranu zonu</response>
        /// <response code="404">Nije pronadjena zona</response>
        [HttpPut]
        [Authorize(Roles = "superuser")]
        [Route("{ProtectedZoneId:guid}")]
        public async Task<IActionResult> UpdateProtectedZone(Guid ProtectedZoneId, UpdateProtectedZoneDto updateProtectedZoneDto)
        {
            var protectedZone = new ProtectedZone()
            {
                NumberOfZone = updateProtectedZoneDto.NumberOfZone,
                PermittedWorks = updateProtectedZoneDto.PermittedWorks
            };
            protectedZone = await protectedZoneRepository.UpdateProtectedZone(ProtectedZoneId, protectedZone);
            if(protectedZone == null)
            {
                return NotFound();
            }
            var protectedZoneDto = mapper.Map<ProtectedZone>(protectedZone);
            return Ok(protectedZoneDto);
        }


        /// <summary>
        /// Vrši brisanje jedne zasticene zone na osnovu njenog ID-ja.
        /// </summary>
        /// <param name="ProtectedZoneId">ID zasticene zone</param>
        /// <response code="200">Uspesno obrisana zona</response>
        /// <response code="404">Nije pronadjena zona</response>
        [HttpDelete]
        [Route("{ProtectedZoneId:guid}")]
        public async Task<IActionResult> DeleteProtectedZone(Guid ProtectedZoneId)
        {
            var protectedZone = await protectedZoneRepository.DeleteProtectedZone(ProtectedZoneId);
            if(protectedZone == null )
            {
                return NotFound();
            }
            var protectedZoneDto = mapper.Map<ProtectedZone>(protectedZone);
            return Ok(protectedZoneDto);
        }
    }
}
