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
    public class RegistrationFormsController : Controller
    {
        private readonly IRegistrationFormRepository registrationFormRepository;
        private readonly IMapper mapper;
        public RegistrationFormsController(IRegistrationFormRepository registrationFormRepository, IMapper mapper)
        {
            this.registrationFormRepository = registrationFormRepository;
            this.mapper = mapper;

        }

        /// <summary>
        /// Kreira listu svih formulara prijave
        /// </summary>
        /// <returns>Lista svih formulara prijave</returns>
        /// <response code="200">Vraca listu formulara prijave</response>
        [HttpGet]
        [Authorize(Roles = "tehnicki_sekretar")]
        public async Task<IActionResult> GetAllRegistrationFormsAsync()
        {
            var registrationForms = await registrationFormRepository.GetAllAsync();

            //return DTO registrationForms
            //registrationForms.ToList().ForEach(registrationForm =>
            //{
            //    var registrationFormDTO = new Models.DTO.RegistrationForm()
            //   { 
            //        RegistrationFormId = registrationForm.RegistrationFormId,
            //        Name = registrationForm.Name,
            //        Surname = registrationForm.Surname,
            //        Address = registrationForm.Address,
            //        Username = registrationForm.Username,
            //        JMBG = registrationForm.JMBG,
            //        Country = registrationForm.Country,
            //    };
            //    registrationFormsDTO.Add(registrationFormDTO);
            //    });

            var registrationFormsDTO = mapper.Map<List<Models.DTO.RegistrationForm>>(registrationForms);

            return Ok(registrationFormsDTO);
        }

        /// <summary>
        /// Vraca jedan formular za prijavu na osnovu ID-ja
        /// </summary>
        /// <param name="RegistrationFormId">ID formulara prijave</param>
        /// <returns></returns>
        /// <response code="200">Vraca trazeni formular prijave</response>
        /// <resonse code="404">Nije pronadjen formular prijave</resonse>
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegistrationFormAsync")]
        [Authorize(Roles = "tehnicki_sekretar")]
        public async Task<IActionResult> GetRegistrationFormAsync(Guid id)
        {
            //Get Registration object from database
            var registrationForms = await registrationFormRepository.GetAsync(id);

            //Convert object to DTO
            var registrationFormDTO = mapper.Map<Models.DTO.RegistrationForm>(registrationForms);

            //Return response
            return Ok(registrationFormDTO);
        }

        /// <summary>
        /// Kreira formular prijave
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///         POST api/RegistrationForm
        ///         {
        ///             "Name": "Marija",
        ///             "Surname": "Jovanovic",
        ///             "Address": "Svetog Save 25 Novi Sad",
        ///             "JMBG": "1211198145623",
        ///             "Email": "marijajovanovic@gmail.com",
        ///             "Username": "marijajovanovic12",
        ///             "Password": "marija1211",
        ///             "Country": "Serbia"
        ///         }
        ///</remarks>
        ///<response code="201">Vraca kreirani formular prijave</response>
        [HttpPost]
        public async Task<IActionResult> AddRegistrationFormAsync([FromBody] Models.DTO.AddRegistrationFormRequest addRegistrationFormRequest)
        {
            // Convert DTO to Domain Object
            var registrationForms = new Models.RegistrationForm
            {
                Name = addRegistrationFormRequest.Name,
                Surname = addRegistrationFormRequest.Surname,
                Address = addRegistrationFormRequest.Address,
                JMBG = addRegistrationFormRequest.JMBG,
                Country = addRegistrationFormRequest.Country,
                Email = addRegistrationFormRequest.Email,
                Username = addRegistrationFormRequest.Username,
                Password = addRegistrationFormRequest.Password

            };

            //Pass domain object to Repository to persist this
            registrationForms = await registrationFormRepository.AddAsync(registrationForms);

            //Convert the Domain object back to DTO
            var registrationFormDTO = new Models.DTO.RegistrationForm
            {
                RegistrationFormId = registrationForms.RegistrationFormId,
                Name = registrationForms.Name,
                Surname = registrationForms.Surname,
                Address = registrationForms.Address,
                JMBG = registrationForms.JMBG,
                Country = registrationForms.Country,
                Username = registrationForms.Username,
                Email = registrationForms.Email,
                Password = registrationForms.Password
            };

            //Send DTO response back to Client
            return CreatedAtAction(nameof(GetRegistrationFormAsync), new { id = registrationFormDTO.RegistrationFormId }, registrationFormDTO);
        }

        /// <summary>
        /// Azurira jedan formular prijave.
        /// </summary>
        /// <param name="updateRegistrationFormRequest">Model formulara prijave koji se azurira</param>
        /// <returns>Potvrda o modifikovanom formularu prijave.</returns>
        /// <response code="200">Vraca azurirani formular prijave</response>
        /// <response code="404">Nije pronadjen formular prijave</response>
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegistrationFormAsync([FromRoute] Guid id,
            [FromBody] Models.DTO.UpdateRegistrationFormRequest updateRegistrationFormRequest)
        {
            //Convert DTO to Domain object
            var registrationForms = new Models.RegistrationForm
            {
                Name = updateRegistrationFormRequest.Name,
                Surname = updateRegistrationFormRequest.Surname,
                Address = updateRegistrationFormRequest.Address,
                JMBG = updateRegistrationFormRequest.JMBG,
                Country = updateRegistrationFormRequest.Country,
                Email = updateRegistrationFormRequest.Email,
                Username = updateRegistrationFormRequest.Username,
                Password = updateRegistrationFormRequest.Password

            };

            //Pass details to Repository - Get Domain object in response (or null)
            registrationForms = await registrationFormRepository.UpdateAsync(id, registrationForms);

            //Handle Null (not found)
            if (registrationForms == null)
            {
                return NotFound();
            }

            //Convert back Domain to DTO
            var registrationFormDTO = new Models.DTO.RegistrationForm
            {
                RegistrationFormId = registrationForms.RegistrationFormId,
                Name = registrationForms.Name,
                Surname = registrationForms.Surname,
                Address = registrationForms.Address,
                JMBG = registrationForms.JMBG,
                Country = registrationForms.Country,
                Username = registrationForms.Username,
                Password = registrationForms.Password,
                Email = registrationForms.Email,
            };

            //Return Response
            return Ok(registrationFormDTO);


        }


        /// <summary>
        /// Vrsi brisanje jednog formulara prijave na osnovu njegovog ID-ja.
        /// </summary>
        /// <param name="RegistrationFormId"> ID formulara prijave</param>
        /// <response code="404">Nije pronadjen formular prijave</response>
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegistrationFormAsync(Guid id)
        {
            // call Repository to delete registration
            var registrationForms = await registrationFormRepository.DeleteAsync(id);

            if (registrationForms == null)
            {
                return NotFound();
            }

            var registrationFormDTO = mapper.Map<Models.DTO.RegistrationForm>(registrationForms);

            return Ok(registrationFormDTO);
        }
    }
}
