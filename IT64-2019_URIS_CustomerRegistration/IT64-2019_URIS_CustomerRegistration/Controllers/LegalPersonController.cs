using AutoMapper;
using IT64_2019_URIS_CustomerRegistration.Data;
using IT64_2019_URIS_CustomerRegistration.Entities;
using IT64_2019_URIS_CustomerRegistration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Numerics;

namespace IT64_2019_URIS_CustomerRegistration.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class LegalPersonController : Controller
    {
        private readonly ILegalPersonRepository legalPersonRepository;
        private readonly IMapper mapper;
        public LegalPersonController(ILegalPersonRepository legalPersonRepository, IMapper mapper)
        {
            this.legalPersonRepository = legalPersonRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraca listu evidentiranih pravnih lica.
        /// </summary>
        /// <returns>Lista pravnih lica</returns>
        /// <response code="200">Vraca listu pravnih lica.</response>
        [HttpGet]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> GetAllLegalPersonAsync()
        {
            var legalPerson = await legalPersonRepository.GetAllAsync();

            var legalPersonDTO = mapper.Map<List<Models.LegalPersonDto>>(legalPerson);

            return Ok(legalPersonDTO);
        }
        /// <summary>
        /// Vraca jedno pravo lice na osnovu njegovog ID-ja
        /// </summary>
        /// <param name="legalPersonId"></param>
        /// <returns></returns>
        /// <response code="200">Vraca trazeno pravno lice.</response>
        /// <response code="404">Nije pronadjeno ni jedno pravno lice.</response>
        [HttpGet]
        [Route("{legalPersonId:guid}")]
        [ActionName("GetLegalPerson")]
        public async Task<IActionResult> GetLegalPerson(Guid legalPersonId)
        {
            var legalPerson = await legalPersonRepository.GetAsync(legalPersonId);

            var legalPersonDTO = mapper.Map<Models.LegalPersonDto>(legalPerson);

            return Ok(legalPersonDTO);
        }
        /// <summary>
        /// Kreriranje pravnog lica.
        /// </summary>
        /// <param name="legalPersonAdd">Model za kreiranje pravnog lica</param>
        /// <returns>Potvrda o kreiranju pravnog lica.</returns>
        /// <remarks>
        /// Primjer zahtjeva za kreiranje pravnog lica: 
        /// \
        /// POST api/LegalPerson 
        /// { 
        /// 
        ///     "nameLP": "Preduzece doo", 
        ///     "identificationNumLP": "12345678",
        ///     "streetLP": "Dunavska 1", 
        ///     "cityLP": "Novi Sad", 
        ///     "stateLP": "Srbija", 
        ///     "contactPerson": "Marko Markovic", 
        ///     "positions": "Direktor", 
        ///     "phone": "065625556666", 
        ///     "emailLP": "marko@gmail.com", 
        ///     "fax": "1234567", 
        ///     "accountNumLP": 123456778, 
        ///     "customerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6" 
        /// }
        /// </remarks>
        /// <response code="201">Vraca kreirano pravno lice.</response>
        /// <response code="500">Doslo je do greske na serveru prilikom unosa podataka o pravnom licu.</response>
        [HttpPost]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> AddLegalPersonAsync([FromBody] LegalPersonAddDto legalPersonAdd)
        {
            var legalPerson = new LegalPerson
            {
                NameLP = legalPersonAdd.NameLP,
                IdentificationNumLP = legalPersonAdd.IdentificationNumLP,
                StreetLP = legalPersonAdd.StreetLP,
                CityLP = legalPersonAdd.CityLP,
                StateLP = legalPersonAdd.StateLP,
                ContactPerson = legalPersonAdd.ContactPerson,
                Positions = legalPersonAdd.Positions,
                Phone = legalPersonAdd.Phone,
                EmailLP = legalPersonAdd.EmailLP,
                Fax = legalPersonAdd.Fax,
                AccountNumLP = legalPersonAdd.AccountNumLP,
                CustomerId = legalPersonAdd.CustomerId,
            };

            await legalPersonRepository.AddAsync(legalPerson);

            var legalPersonDTO = mapper.Map<Models.LegalPersonDto>(legalPerson);

            return CreatedAtAction(nameof(GetLegalPerson), new { legalPersonId = legalPersonDTO.LegalPersonId }, legalPersonDTO);
        }

        /// <summary>
        /// Vrsi brisanje jednog pravnog lica osnovu njegovog ID-a.
        /// </summary>
        /// <param name="legalPersonId">ID pravnog lica</param>
        /// <response code="404">Nije pronadjeno pravno lice za brisanje.</response>
        /// <response code="500">Doslo je do greske na serveru prilikom brisanja pravnog lica.</response>
        [HttpDelete]
        [Route("{legalPersonId:guid}")]
        public async Task<IActionResult> DeleteLegalPersonAsync(Guid legalPersonId)
        {
            var legalPerson = await legalPersonRepository.DeleteAsync(legalPersonId);

            if (legalPerson == null)
            {
                return NotFound();
            }

            var legalPersonDTO = mapper.Map<Models.LegalPersonDto>(legalPerson);
            return Ok(legalPersonDTO);
        }

        /// <summary>
        /// Azurira jednog pravnog lica.
        /// </summary>
        /// <param name="legalPersonId">ID pravnog lica</param>
        /// <param name="legalPersonUpdate">Model pravnog lica koji se azurira.</param>
        /// <returns>Potvrdu o modifikovanom pravnom licu.</returns>
        /// <response code="200">Vraca azurirano pravno lice.</response>
        /// <response code="404">Pravno lice koje se azurira nije pronadjeno.</response>
        /// <response code="500">Doslo je do greske na serveru prilikom azuriranja pravnog lica.</response>
        [HttpPut]
        [Route("{legalPersonId:guid}")]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> UpdateLegalPersonAsync([FromRoute] Guid legalPersonId, LegalPersonUpdateDto legalPersonUpdate)
        {
            var legalPerson = new LegalPerson
            {
                NameLP = legalPersonUpdate.NameLP,
                IdentificationNumLP = legalPersonUpdate.IdentificationNumLP,
                StreetLP = legalPersonUpdate.StreetLP,
                CityLP = legalPersonUpdate.CityLP,
                StateLP = legalPersonUpdate.StateLP,
                ContactPerson = legalPersonUpdate.ContactPerson,
                Positions = legalPersonUpdate.Positions,
                Phone = legalPersonUpdate.Phone,
                EmailLP = legalPersonUpdate.EmailLP,
                Fax = legalPersonUpdate.Fax,
                AccountNumLP = legalPersonUpdate.AccountNumLP,
                CustomerId = legalPersonUpdate.CustomerId,

            };

            legalPerson = await legalPersonRepository.UpdateAsync(legalPersonId, legalPerson);

            if(legalPerson == null)
            {
                return NotFound();
            }

            var legalPersonDTO = mapper.Map<Models.LegalPersonDto>(legalPerson);

            return Ok(legalPersonDTO);

        }
   
    }
}
