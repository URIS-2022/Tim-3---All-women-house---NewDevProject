using AutoMapper;
using IT64_2019_URIS_ExpertCommission.Data;
using IT64_2019_URIS_ExpertCommission.Entities;
using IT64_2019_URIS_ExpertCommission.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace IT64_2019_URIS_ExpertCommission.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpertCommissionController : Controller
    {
        private readonly IExpertCommissionRepository expertCommissionRepository;
        private readonly IMapper mapper;

        public ExpertCommissionController(IExpertCommissionRepository expertCommissionRepository, IMapper mapper)
        {
            this.expertCommissionRepository = expertCommissionRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraca listu evidentirane strucne komisije.
        /// </summary>
        /// <returns>Lista strucne komisije</returns>
        /// <response code="200">Vraca listu strucne komisije.</response>
        [HttpGet]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> GetAllExpertCommissionAsync()
        {
            var expertCommissions = await expertCommissionRepository.GetAllAsync();

            var expertCommissionsDTO = mapper.Map<List<Models.ExpertCommissionDto>>(expertCommissions);

            return Ok(expertCommissionsDTO);
        }
        /// <summary>
        /// Vraca jednu strucnu komisiju na osnovu njenog ID-ja
        /// </summary>
        /// <param name="expertCommissionId">ID strucne komisije</param>
        /// <response code="200">Vraca trazenu strucnu komisiju.</response>
        /// <response code="404">Nije pronadjeno ni jedna strucna komisija.</response>
        [HttpGet]
        [Route("{expertCommissionId:guid}")]
        [ActionName("GetExpertCommission")]
        public async Task<IActionResult> GetExpertCommission(Guid expertCommissionId)
        {
            var expertCommission = await expertCommissionRepository.GetAsync(expertCommissionId);

            if(expertCommission == null)
            {
                return NotFound();
            }

            var expertCommissionDTO = mapper.Map<Models.ExpertCommissionDto>(expertCommission);

            return Ok(expertCommissionDTO);
        }
        /// <summary>
        /// Kreriranje strucne komisije.
        /// </summary>
        /// <param name="expertCommissionAdd">Model za kreiranje strucne komisije</param>
        /// <returns>Potvrda o kreiranju strucne komisije.</returns>
        /// <remarks>
        /// Primjer zahtjeva za kreiranje strucne komisije:
        /// \
        /// POST api/ExpertCommission
        /// \
        /// {
        /// 
        ///     "expertCommissionName": "Komisija 1",
        ///     "presidentName": "Marko Markovic",
        ///     "numberOfMembers": 2
        /// }
        /// </remarks>
        /// <response code="201">Vraca kreiranu strucnu komisiju.</response>
        /// <response code="500">Doslo je do greske na serveru prilikom unosa podataka o strucnoj komisiji.</response>
        [HttpPost]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> AddExpertCommissionAsync(ExpertCommissionAddDto expertCommissionAdd)
        {
            var expertCommission = new ExpertCommission()
            {
                ExpertCommissionName = expertCommissionAdd.ExpertCommissionName,
                PresidentName = expertCommissionAdd.PresidentName,
                NumberOfMembers = expertCommissionAdd.NumberOfMembers
            };

            expertCommission = await expertCommissionRepository.AddAsync(expertCommission);

            var expertCommissionDTO = mapper.Map<Models.ExpertCommissionDto>(expertCommission);

            return CreatedAtAction(nameof(GetExpertCommission), new { expertCommissionId = expertCommissionDTO.ExpertCommissionId }, expertCommissionDTO);


        }
        /// <summary>
        /// Vrsi brisanje jedne strucne komisije osnovu njegovog ID-a.
        /// </summary>
        /// <param name="expertCommissionId">ID strucne komisije</param>
        /// <response code="204">Strucna komisija uspjesno obrisana.</response>
        /// <response code="404">Nije pronadjena strucna komisija za brisanje.</response>
        /// <response code="500">Doslo je do greske na serveru prilikom brisanja strucne komisije.</response>
        [HttpDelete]
        [Route("{expertCommissionId:guid}")]
        public async Task<IActionResult> DeleteExpertCommissionAsync(Guid expertCommissionId)
        {
            var expertCommission = await expertCommissionRepository.DeleteAsync(expertCommissionId);

            if(expertCommission == null)
            {
                NotFound();
            }

            var expertCommissionDTO = mapper.Map<Models.ExpertCommissionDto>(expertCommission);

            return Ok(expertCommissionDTO);

        }
        /// <summary>
        /// Azurira jedne strucne komisije.
        /// </summary>
        /// <param name="expertCommissionId">ID strucne komisije</param>
        /// <param name="expertCommissionUpdate">Model strucne komisije koja se azurira.</param>
        /// <returns>Potvrdu o modifikovanoj strucnoj komisiji.</returns>
        /// <response code="200">Vraca azuriranu strucnu komisiju.</response>
        /// <response code="404">Strucna komisija koje se azurira nije pronadjena.</response>
        /// <response code="500">Doslo je do greske na serveru prilikom azuriranja strucne komisije.</response>
        [HttpPut]
        [Route("{expertCommissionId:guid}")]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> UpdateExpertCommissionAsync(Guid expertCommissionId, ExpertCommissionUpdateDto expertCommissionUpdate)
        {
            var expertCommission = new ExpertCommission
            {
                ExpertCommissionName = expertCommissionUpdate.ExpertCommissionName,
                PresidentName = expertCommissionUpdate.PresidentName,
                NumberOfMembers = expertCommissionUpdate.NumberOfMembers
            };

            expertCommission = await expertCommissionRepository.UpdateAsync(expertCommissionId, expertCommission);

            if(expertCommission == null)
            {
                return NotFound();
            }

            var expertCommissionDTO = mapper.Map<Models.ExpertCommissionDto>(expertCommission);
            return Ok(expertCommissionDTO);
        }

    }
}
