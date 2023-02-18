using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Registration_projekat.Models;
using Registration_projekat.Models.DTO;
using Registration_projekat.Repositories;

namespace Registration_projekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationsController : Controller
    {
        private readonly IRegistrationRepository registrationRepository;
        private readonly IMapper mapper;

        public RegistrationsController(IRegistrationRepository registrationRepository, IMapper mapper)
        {
            this.registrationRepository = registrationRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Kreira listu svih prijava
        /// </summary>
        /// <returns>Lista svih prijava</returns>
        /// <response code="200">Vraca listu prijava</response>
        [HttpGet]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> GetAllRegistrationsAsync()
        {
            var registrations = await registrationRepository.GetAllAsync();

            // return DTO registrations
            //registrations.ToList().ForEach(registration =>
            //{
            //    var registrationDTO = new Models.DTO.Registration()
            //    {
            //        RegistrationId = registration.RegistrationId,
            //       DateOfRegistration = registration.DateOfRegistration,
            //        Location = registration.Location,
            //        RegistrationFormId = registration.RegistrationFormId,
            //    };
            //
            //    registrationsDTO.Add(registrationDTO);
            //
            //});

            var registrationsDTO = mapper.Map<List<Models.DTO.Registration>>(registrations);

            return Ok(registrationsDTO);
        }

        /// <summary>
        /// Vraca jednu prijavu na osnovu ID-ja
        /// </summary>
        /// <param name="RegistrationId">ID prijave</param>
        /// <returns></returns>
        /// <response code="200">Vraca trazenu prijavu</response>
        /// <response code="404">Nije pronadjena prijava</response>
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegistrationAsync")]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> GetRegistrationAsync(Guid id)
        {
            //Get Registration object from database
            var registrations = await registrationRepository.GetAsync(id);

            //Convert object to DTO
            var registrationDTO = mapper.Map<Models.DTO.Registration>(registrations);

            //Return response
            return Ok(registrationDTO);
        }

        /// <summary>
        /// Kreira prijavu
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///         POST api/Registration
        ///         {
        ///             "DateOfRegistration":"2023-02-08 00:00:00",
        ///             "Location":"Subotica",
        ///             "RegistrationFormId":"205c7611-853d-4394-8c2f-7a730a3d0f5d"
        ///         }
        ///</remarks>
        ///<response code="201">Vraca kreiranu prijavu</response>
     
        [HttpPost]
        [Authorize(Roles = "operater")]
        public async Task<IActionResult> AddRegistrationAsync([FromBody] Models.DTO.AddRegistrationRequest addRegistrationRequest)
        {
            // Convert DTO to Domain Object
            var registrations = new Models.Registration
            {
                DateOfRegistration = addRegistrationRequest.DateOfRegistration,
                Location = addRegistrationRequest.Location,
                RegistrationFormId = addRegistrationRequest.RegistrationFormId

            };

            //Pass domain object to Repository to persist this
            registrations = await registrationRepository.AddAsync(registrations);

            //Convert the Domain object back to DTO
            var registrationDTO = new Models.DTO.Registration
            {
                RegistrationId = registrations.RegistrationId,
                Location = registrations.Location,
                DateOfRegistration = registrations.DateOfRegistration,
                RegistrationFormId = registrations.RegistrationFormId
            };

            //Send DTO response back to Client
            return CreatedAtAction(nameof(GetRegistrationAsync), new { id = registrationDTO.RegistrationId }, registrationDTO);
        }

        /// <summary>
        /// Azurira jednu prijavu.
        /// </summary>
        /// <param name="updateRegistrationRequest">Model prijave koji se azurira</param>
        /// <returns>Potvrda o modifikovanoj prijavi.</returns>
        /// <response code="200">Vraca azuriranu prijavu</response>
        /// <response code="404">Nije pronadjena prijava</response>
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegistrationAsync([FromRoute] Guid id,
            [FromBody] Models.DTO.UpdateRegistrationRequest updateRegistrationRequest)
        {
            //Convert DTO to Domain object
            var registrations = new Models.Registration
            {
                DateOfRegistration = updateRegistrationRequest.DateOfRegistration,
                Location = updateRegistrationRequest.Location,
                RegistrationFormId = updateRegistrationRequest.RegistrationFormId
            };

            //Pass details to Repository - Get Domain object in response (or null)
            registrations = await registrationRepository.UpdateAsync(id, registrations);

            //Handle Null (not found)
            if (registrations == null)
            {
                return NotFound();
            }

            //Convert back Domain to DTO
            var registrationDTO = new Models.DTO.Registration
            {
                RegistrationId = registrations.RegistrationId,
                Location = registrations.Location,
                DateOfRegistration = registrations.DateOfRegistration,
                RegistrationFormId = registrations.RegistrationFormId
            };

            //Return Response
            return Ok(registrationDTO);


        }

        /// <summary>
        /// Vrsi brisanje jedne prijave na osnovu njegovog ID-ja.
        /// </summary>
        /// <param name="RegistrationId"> ID prijave</param>
        /// <response code="200">Uspesno obrisana prijava</response>
        /// <response code="404">Nije pronadjena prijava</response>
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegistrationAsync(Guid id)
        {
            // call Repository to delete registration
           var registrations =  await registrationRepository.DeleteAsync(id);

            if(registrations == null)
            {
                return NotFound();
            }

            var registrationDTO = mapper.Map<Models.DTO.Registration>(registrations);

            return Ok(registrationDTO);
        }

    }
}