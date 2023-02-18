using AutoMapper;
using AuctioneerRegistration.Data;
using AuctioneerRegistration.Entities;
using AuctioneerRegistration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AuctioneerRegistration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuctioneerController : Controller
    {
        private readonly IAuctioneerRepository auctioneerRepository;
        private readonly IMapper mapper;
        public AuctioneerController(IAuctioneerRepository auctioneerRepository, IMapper mapper)
        {
            this.auctioneerRepository = auctioneerRepository;
            this.mapper = mapper;
        }
        /// <summary>
        /// Vraca listu svih evidentiranih licitera.
        /// </summary>
        /// <returns>Lista evidentiranih licitera</returns>
        /// <response code="200">Vraca listu licitera.</response>
        [HttpGet]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> GetAuctioneersAsync()
        {
            var auctioneer = await auctioneerRepository.GetAllAsync();

            var auctioneerDTO = mapper.Map<List<Models.AuctioneerDto>>(auctioneer);
            return Ok(auctioneerDTO);
        }
        /// <summary>
        /// Vraca jednog licitera na osnovu ID-ja kupca.
        /// </summary>
        /// <param name="auctioneerId">ID licitera</param>
        /// <response code="200">Vraca trazenog licitera.</response>
        /// <response code="404">Nije pronadjen ni jedan liciter.</response>
        [HttpGet]
        [Route("{auctioneerId:guid}")]
        [ActionName("GetAuctioneerAsync")]
        public async Task<IActionResult> GetAuctioneerAsync(Guid auctioneerId)
        {
            var auctioneer = await auctioneerRepository.GetAsync(auctioneerId);
            
            if(auctioneer == null)
            {
                return NotFound();
            }

            var auctioneerDTO = mapper.Map<Models.AuctioneerDto>(auctioneer);
            return Ok(auctioneerDTO);
        }

        /// <summary>
        /// Kreriranje licitera.
        /// </summary>
        /// <param name="auctioneerAdd">Model za kreiranje licitera</param>
        /// <returns>Potvrda o kreiranju licitera.</returns>
        ///<remarks>
        ///Primjer zahtjeva za kreiranje licitera: 
        /// \
        ///POST api/Auctioneer
        /// \
        /// {
        /// 
        ///     "firstName": "Marko",
        ///     "lastName": "Markovic",
        ///     "jmbg": "1234567890123",
        ///     "street": "Dunavska 1",
        ///     "city": "Novi Sad",
        ///     "state": "Srbija",
        ///     "passportNum": "12345678"
        /// }
        ///</remarks>
        /// <response code="201">Vraca kreiranog licitera.</response>
        /// <response code="500">Doslo je do greske na serveru prilikom unosa podataka o liciteru.</response>
        [HttpPost]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> AddAuctioneerAsync(AuctioneerAddDto auctioneerAdd)
        {
            var auctioneer = new Auctioneer
            {
                FirstName = auctioneerAdd.FirstName,
                LastName = auctioneerAdd.LastName,
                JMBG = auctioneerAdd.JMBG,
                Street = auctioneerAdd.Street,
                City = auctioneerAdd.City,
                State = auctioneerAdd.State,
                PassportNum = auctioneerAdd.PassportNum

            };

            auctioneer = await auctioneerRepository.AddAsync(auctioneer);

            var auctioneerDTO = mapper.Map<Models.AuctioneerDto>(auctioneer);

            return CreatedAtAction(nameof(GetAuctioneerAsync), new { auctioneerId = auctioneerDTO.AuctioneerId }, auctioneerDTO);

        }
        /// <summary>
        /// Vrsi brisanje jednog licitera na osnovu njegovog ID-a.
        /// </summary>
        /// <param name="auctioneerId">ID licitera</param>
        /// <response code="404">Nije pronadjen liciter za brisanje.</response>
        /// <response code="500">Doslo je do greske na serveru prilikom brisanja licitera.</response>
        [HttpDelete]
        [Route("{auctioneerId:guid}")]
        public async Task<IActionResult> DeleteAuctioneerAsync(Guid auctioneerId)
        {
            var auctioneer = await auctioneerRepository.DeleteAsync(auctioneerId);

            if (auctioneer == null)
            {
                return NotFound();
            }
            var auctioneerDTO = mapper.Map<Models.AuctioneerDto>(auctioneer);
            return Ok(auctioneerDTO);

        }
        /// <summary>
        /// Azurira jednog licitera.
        /// </summary>
        /// <param name="auctioneerId">ID licitera</param>
        /// <param name="auctioneerUpdate">Model licitera koji se azurira.</param>
        /// <returns>Potvrdu o modifikovanom liciteru.</returns>
        /// <response code="200">Vraca azuriranog licitera.</response>
        /// <response code="404">Liciter koji se azurira nije pronadjen.</response>
        /// <response code="500">Doslo je do greske na serveru prilikom azuriranja licitera.</response>
        [HttpPut]
        [Route("{auctioneerId:guid}")]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> UpdateAuctioneerAsync(Guid auctioneerId, AuctioneerUpdateDto auctioneerUpdate)
        {
            var auctioneer = new Auctioneer
            {
                FirstName = auctioneerUpdate.FirstName,
                LastName = auctioneerUpdate.LastName,
                JMBG = auctioneerUpdate.JMBG,
                Street = auctioneerUpdate.Street,
                City = auctioneerUpdate.City,
                State = auctioneerUpdate.State,
                PassportNum = auctioneerUpdate.PassportNum

            };

            auctioneer = await auctioneerRepository.UpdateAsync(auctioneerId,auctioneer);

            if(auctioneer == null)
            {
                return NotFound();
            }

            var auctioneerDTO = mapper.Map<Models.AuctioneerDto>(auctioneer);
            return Ok(auctioneerDTO);

        }
  
    }
}
