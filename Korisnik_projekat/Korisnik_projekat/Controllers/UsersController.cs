using AutoMapper;
using Korisnik_projekat.Models.DTO;
using Korisnik_projekat.Models.User;
using Korisnik_projekat.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Korisnik_projekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Kreira listu svih korisnika
        /// </summary>
        /// <returns>Lista svih korisnika</returns>
        /// <response code = "200">Vraca listu korisnika</response>
        [HttpGet]
        [Authorize(Roles=("administrator"))]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await userRepository.GetAllAsync();

            // return DTO users
            //users.ToList().ForEach(user =>
            //{
            //    var userDTO = new Models.DTO.User()
            //  { 
            //        UserId = user.UserId,
            //        Name = user.Name,
            //        Surname = user.Surname,
            //        Email = user.Email,
            //        UserName = user.UserName,
            //        Password = user.Password,
            //    };
            //
            //   usersDTO.Add(userDTO);
            //});

            var usersDTO = mapper.Map<List<Models.DTO.User>>(users);
            return Ok(usersDTO);

        }

        /// <summary>
        /// Vraca jednog korisnika na osnovu ID-ja
        /// </summary>
        /// <param name="UserId">ID korisnika</param>
        /// <returns></returns>
        /// <response code="200">Vraca trazenog korisnika</response>
        /// <response code="404">Nije pronadjen korisnik</response>
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetUserAsync")]
        [Authorize(Roles = ("administrator"))]
        public async Task<IActionResult> GetUserAsync(Guid id)
        {
            var user =  await userRepository.GetAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userDTO = mapper.Map<Models.DTO.User>(user);

            return Ok(userDTO);
        }

        /// <summary>
        /// Kreira korisnika
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///         POST api/User
        ///         {
        ///            "Name":"Milana",
        ///            "Surname":"Milic",
        ///            "Email":"milanamilic@gmail.com",
        ///            "UserName":"milanamilic10",
        ///            "Password":"milana12345"
        ///         }
        ///</remarks>
        ///<response code="201">Vraca kreiranog korisnika</response> 
        [HttpPost]
        public async Task<IActionResult> AddUserAsync(Models.DTO.AddUserRequest addUserRequest )
        {
            //Request(DTO) to Domain model
            var user = new Models.User.User()
            {
                Name = addUserRequest.Name,
                Surname = addUserRequest.Surname,
                Email = addUserRequest.Email,
                UserName = addUserRequest.UserName,
                Password = addUserRequest.Password
            };

            //Pass details to Repository
            user = await userRepository.AddAsync(user);

            //Convert back to DTO
            var userDTO = new Models.DTO.User
            {
                UserId = user.UserId,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                UserName = user.UserName,
                Password = user.Password
            };

            return CreatedAtAction(nameof(GetUserAsync), new {id = userDTO.UserId}, userDTO);
        }

        /// <summary>
        /// Vrsi brisanje jednog korisnika na osnovu njegovog ID-ja.
        /// </summary>
        /// <param name="RegistrationFormId"> ID formulara prijave</param>
        /// <response code="200">Uspesno obrisani korisnik</response>
        /// <response code="404">Nije pronadjen korisnik</response>
        
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteUserAsync(Guid id)
        {
            //Get user from database
            var user = await userRepository.DeleteAsync(id);

            //If null NotFound
            if(user == null)
            {
                return NotFound();
            }

            //Convert response back to DTO
            var userDTO = new Models.DTO.User
            {
                UserId = user.UserId,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                UserName = user.UserName,
                Password = user.Password
            };

            //return Ok response
            return Ok(userDTO);
        }

        /// <summary>
        /// Azurira jednog korisnika.
        /// </summary>
        /// <param name="updateUserRequest">Model korisnika koji se azurira</param>
        /// <returns>Potvrda o modifikovanom korisniku.</returns>
        /// <response code="200">Vraca azuriranog korisnika</response>
        /// <response code="404">Nije pronadjen korisnik</response>
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateUserAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateUserRequest updateUserRequest)
        {
            //Convert DTO to Domain model
            var user = new Models.User.User()
            {
                Name = updateUserRequest.Name,
                Surname = updateUserRequest.Surname,
                Email = updateUserRequest.Email,
                UserName = updateUserRequest.UserName,
                Password = updateUserRequest.Password
            };

            //Update User using repository
            user = await userRepository.UpdateAsync(id, user);

            //If Null then NotFound
            if(user == null)
            {
                return NotFound();
            }

            //Convert Domain back to DTO
            var userDTO = new Models.DTO.User
            {
                UserId = user.UserId,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                UserName = user.UserName,
                Password = user.Password
            };

            //Return Ok response
            return Ok(userDTO);
        }
    }
}
