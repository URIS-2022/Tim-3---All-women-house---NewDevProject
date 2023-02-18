using AutoMapper;
using IT64_2019_URIS_CustomerRegistration.Data;
using IT64_2019_URIS_CustomerRegistration.Entities;
using IT64_2019_URIS_CustomerRegistration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace IT64_2019_URIS_CustomerRegistration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NaturalPersonController : Controller
    {
        private readonly INaturalPersonRepository naturalPersonRepository;
        private readonly IMapper mapper;

        public NaturalPersonController(INaturalPersonRepository naturalPersonRepository, IMapper mapper)
        {
            this.naturalPersonRepository = naturalPersonRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraca listu evidentiranih fizickih lica.
        /// </summary>
        /// <returns>Lista fizickih lica</returns>
        /// <response code="200">Vraca listu fizickih lica.</response>
        [HttpGet]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> GetAllNaturalPersonsAsync()
        {

            var naturalPerson = await naturalPersonRepository.GetAllAsync();

            var naturalPersonDTO = mapper.Map<List<Models.NaturalPersonDto>>(naturalPerson);

            return Ok(naturalPersonDTO);

        }
        /// <summary>
        /// Vraca jedno fizicko lice na osnovu njegovog ID-ja
        /// </summary>
        /// <param name="naturalPersonId">ID fizickog lica</param>
        /// <response code="200">Vraca trazeno fizicko lice.</response>
        /// <response code="404">Nije pronadjeno ni jedno fizicko lice.</response>
        [HttpGet]
        [Route("{naturalPersonId:guid}")]
        [ActionName("GetNaturalPerson")]
        public async Task<IActionResult> GetNaturalPerson(Guid naturalPersonId)
        {
            var naturalPerson = await naturalPersonRepository.GetAsync(naturalPersonId);

            var naturalPersonDTO = mapper.Map<Models.NaturalPersonDto>(naturalPerson);

            return Ok(naturalPersonDTO);

        }

        /// <summary>
        /// Kreriranje fizickog lica.
        /// </summary>
        /// <param name="naturalPersonAdd">Model za kreiranje fizickog lica</param>
        /// <returns>Potvrda o kreiranju fizickog lica.</returns>
        /// <remarks>
        /// Primjer zahtjeva za kreiranje fizickog lica: 
        /// \
        /// POST api/NaturalPeron
        /// \
        /// { 
        /// 
        ///     "firstName": "Petar",
        ///     "lastName": "Petrovic",
        ///     "jmbg": "1234567890123",
        ///     "streetNP": "Nikole Pasica 1",
        ///     "cityNP": "Novi Sad",
        ///     "stateNP": "Srbija",
        ///     "zipNP": "10000",
        ///     "tel1": "0612227373",
        ///     "tel2": "0662882822",
        ///     "emailNP": "petar@gmail.com",
        ///     "accountNumNP": 12020203,
        ///     "customerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
        /// }
        /// </remarks>
        /// <response code="201">Vraca kreirano fizicko lice.</response>
        /// <response code="500">Doslo je do greske na serveru prilikom unosa podataka o fizickom licu.</response>

        [HttpPost]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> AddNaturalPersonAsync([FromBody] NaturalPersonAddDto naturalPersonAdd)
        {
            var naturalPerson = new NaturalPerson()
            {
                FirstName = naturalPersonAdd.FirstName,
                LastName = naturalPersonAdd.LastName,
                JMBG = naturalPersonAdd.JMBG,
                StreetNP = naturalPersonAdd.StreetNP,
                CityNP = naturalPersonAdd.CityNP,
                StateNP = naturalPersonAdd.StateNP,
                ZipNP = naturalPersonAdd.ZipNP,
                Tel1 = naturalPersonAdd.Tel1,
                Tel2 = naturalPersonAdd.Tel2,
                EmailNP = naturalPersonAdd.EmailNP,
                AccountNumNP = naturalPersonAdd.AccountNumNP,
                CustomerId = naturalPersonAdd.CustomerId,
            };

            naturalPerson = await naturalPersonRepository.AddAsync(naturalPerson);

            var naturalPersonDTO = mapper.Map<Models.NaturalPersonDto>(naturalPerson);

            return CreatedAtAction(nameof(GetNaturalPerson), new { naturalPersonId = naturalPersonDTO.NaturalPersonId }, naturalPersonDTO);
        }
        /// <summary>
        /// Vrsi brisanje jednog fizickog lica osnovu njegovog ID-a.
        /// </summary>
        /// <param name="naturalPersonId">ID fizickog lica</param>
        /// <response code="204">Fizicko lice uspjesno obrisano.</response>
        /// <response code="404">Nije pronadjeno fizicko lice za brisanje.</response>
        /// <response code="500">Doslo je do greske na serveru prilikom brisanja fizickog lica.</response>
        [HttpDelete]
        [Route("{naturalPersonId:guid}")]
        public async Task<IActionResult> DeleteNaturalPersonAsync(Guid naturalPersonId)
        {
            var naturalPerson = await naturalPersonRepository.DeleteAsync(naturalPersonId);

            if (naturalPerson == null)
            {
                return NotFound();
            }

            var naturalPersonDTO = mapper.Map<Models.NaturalPersonDto>(naturalPerson);

            return Ok(naturalPersonDTO);

        }
        /// <summary>
        /// Azurira jednog fizickog lica.
        /// </summary>
        /// <param name="naturalPersonId">ID fizickog lica</param>
        /// <param name="naturalPersonUpdate">Model fizickog lica koji se azurira.</param>
        /// <returns>Potvrdu o modifikovanom fizickom licu.</returns>
        /// <response code="200">Vraca azurirano fizicko lice.</response>
        /// <response code="404">Fizicko lice koje se azurira nije pronadjeno.</response>
        /// <response code="500">Doslo je do greske na serveru prilikom azuriranja fizickog lica.</response>
        [HttpPut]
        [Route("{naturalPersonId:guid}")]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> UpdateNaturalPerson([FromRoute] Guid naturalPersonId, [FromBody] NaturalPersonUpdateDto naturalPersonUpdate)
        {
            var naturalPerson = new NaturalPerson
            {
                FirstName = naturalPersonUpdate.FirstName,
                LastName = naturalPersonUpdate.LastName,
                JMBG = naturalPersonUpdate.JMBG,
                StreetNP = naturalPersonUpdate.StreetNP,
                CityNP = naturalPersonUpdate.CityNP,
                StateNP = naturalPersonUpdate.StateNP,
                ZipNP = naturalPersonUpdate.ZipNP,
                Tel1 = naturalPersonUpdate.Tel1,
                Tel2 = naturalPersonUpdate.Tel2,
                EmailNP = naturalPersonUpdate.EmailNP,
                AccountNumNP = naturalPersonUpdate.AccountNumNP,
                CustomerId = naturalPersonUpdate.CustomerId,
            };

            naturalPerson = await naturalPersonRepository.UpdateAsync(naturalPersonId, naturalPerson);

            if(naturalPerson == null)
            {
                return NotFound();
            }


            var naturalPersonDTO = mapper.Map<Models.NaturalPersonDto>(naturalPerson);
            return Ok(naturalPersonDTO);

        }

    }
}
