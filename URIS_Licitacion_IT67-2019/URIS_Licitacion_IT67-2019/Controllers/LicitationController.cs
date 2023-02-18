using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Data;
using URIS_Licitacion_IT67_2019.CallServices;
using URIS_Licitacion_IT67_2019.Entities;
using URIS_Licitacion_IT67_2019.Models;
using URIS_Licitacion_IT67_2019.Repositories;

namespace URIS_Licitacion_IT67_2019.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LicitationController : Controller
    {
        private readonly ILicitationRepository licitationRepository;
        private readonly IMapper mapper;
        private readonly IServiceCall<Decision> serviceCall;
        private readonly IConfiguration configuration;

        public LicitationController(ILicitationRepository licitationRepository, IMapper mapper,IServiceCall<Decision> serviceCall, IConfiguration configuration)
        {
            this.licitationRepository = licitationRepository;
            this.mapper = mapper;
            this.serviceCall = serviceCall;
            this.configuration = configuration;
        }

        /// <summary>
        /// Kreira listu svih Licitacija.
        /// </summary>
        /// <returns>Lista Licitacija.</returns>
        /// <response code="200">Vraća listu licitacija</response>
        [HttpGet]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> GetAllLicitacions()
        {
            var licitacions = await licitationRepository.GetAll();

            
            var licitationDto = new List<LicitationDto>();
            Uri url = new Uri($"{configuration["Services:Decisions"]}/api/Decisions");
            foreach (var lic in licitacions)
            {
                var licDto = mapper.Map<LicitationDto>(lic);
                if (lic.DecisionId != null)
                {
                    var decisionDto = await serviceCall.SendGetRequest(url +"/"+ lic.DecisionId);

                    if (decisionDto != null)
                    {
                        licDto.Decision = decisionDto;
                    }
                }
                licitationDto.Add(licDto);
            }

            //var licitacionsDto = mapper.Map<List<LicitationDto>>(licitacions);
            return Ok(licitationDto);

        }


        /// <summary>
        /// Vraća jednu licitaciju osnovu ID-ja.
        /// </summary>
        /// <param name="LicitationId">ID Licitacije</param>
        /// <returns></returns>
        /// <response code="200">Vraća traženu licitaciju</response>
        /// <response code="404">Nije pronadjena licitacija</response>
        [HttpGet]
        [Route("{LicitationId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLicitation(Guid LicitationId)
        {
            var licitation = await licitationRepository.GetById(LicitationId);
            
            if(licitation == null)
            {
                return NotFound();
            }

            var licitationDto = mapper.Map<LicitationDto>(licitation);
            return Ok(licitationDto);
        }

        /// <summary>
        /// Kreira licitaciju.
        /// </summary>
        /// <remarks>
        /// Primer zahteva:
        /// 
        ///     POST api/Licitation
        ///     {
        ///           "numberOfLic": 11,
        ///           "year": "2023",
        ///           "dateOfAnnouncment": "2023-01-15",
        ///           "deadlineForSubmission": "2023-01-15",
        ///           "listOfIndividuals": "Skenirana licna",
        ///           "listOfLegalEntity": "Izvod",
        ///           "rescript": true,
        ///           "secondRound": false
        ///      }
        /// </remarks>
        /// <response code="201">Vraća kreiranu licitaciju</response>
        [HttpPost]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> AddLicitation(AddLicitationDto addLicitationDto)
        {
            var licitation = new Licitation()
            {
                NumberOfLic = addLicitationDto.NumberOfLic,
                Year = addLicitationDto.Year,
                DateOfAnnouncment = addLicitationDto.DateOfAnnouncment,
                ListOfIndividuals = addLicitationDto.ListOfIndividuals,
                ListOfLegalEntity = addLicitationDto.ListOfLegalEntity,
                DeadlineForSubmission = addLicitationDto.DeadlineForSubmission,
                DecisionId = addLicitationDto.DecisionId,
                secondRound = addLicitationDto.secondRound
            };

            licitation = await licitationRepository.AddLicitation(licitation);

            var licitationDto = mapper.Map<LicitationDto>(licitation);
           
            return CreatedAtAction(nameof(GetLicitation), new { LicitationId = licitationDto.LicitationId }, licitationDto);
        }

        /// <summary>
        /// Vrši brisanje jedne licitacije na osnovu njenog ID-ja.
        /// </summary>
        /// <param name="LicitationId">ID licitacije</param>
        /// <response code="200">Vraća azurirano licitaciju</response>
        /// <response code="404">Nije pronadjena licitacija</response>
        [HttpDelete]
        [Route("{LicitationId:guid}")]
        public async Task<IActionResult> DeleteLicitation(Guid LicitationId)
        {
            var licitation = await licitationRepository.DeleteLicitation(LicitationId);
            
            if(licitation == null)
            {
                return NotFound();
            }

            var licitationDto = mapper.Map<LicitationDto>(licitation);

            return Ok(licitationDto);

        }

        /// <summary>
        /// Ažurira jednu licitaciju.
        /// </summary>
        /// <param name="updateLicitationDto">Model licitacije koji se ažurira</param>
        /// <response code = "200" > Uspesno obrisana licitacija</response>
        /// <response code="404">Nije pronadjena licitacija</response>
        [HttpPut]
        [Authorize(Roles = "superuser")]
        [Route("{LicitationId:guid}")]
        public async Task<IActionResult> UpdateLicitacion([FromRoute] Guid LicitationId,[FromBody] UpdateLicitacionDto updateLicitationDto)
        {
            var licitation = new Licitation()
            {
                NumberOfLic = updateLicitationDto.NumberOfLic,
                Year = updateLicitationDto.Year,
                DateOfAnnouncment = updateLicitationDto.DateOfAnnouncment,
                ListOfIndividuals = updateLicitationDto.ListOfIndividuals,
                ListOfLegalEntity = updateLicitationDto.ListOfLegalEntity,
                DeadlineForSubmission = updateLicitationDto.DeadlineForSubmission,
                DecisionId = updateLicitationDto.DecisionId,
                secondRound = updateLicitationDto.secondRound
            };

            licitation = await licitationRepository.UpdateLicitation(LicitationId, licitation);
        
            if(licitation == null )
            {
                return NotFound();
            }

            var licitationDto = mapper.Map<LicitationDto>(licitation);

            return Ok(licitationDto);


        }
    }
}
