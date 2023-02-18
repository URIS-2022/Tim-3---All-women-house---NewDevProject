using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using URIS_ProtectedZone_IT67_2019.Data;
using URIS_ProtectedZone_IT67_2019.Entities;
using URIS_ProtectedZone_IT67_2019.Models;
using URIS_ProtectedZone_IT67_2019.Repositories;

namespace URIS_ProtectedZone_IT67_2019.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentProtectedZoneController : Controller
    {
        private readonly IDocumentProtectedZoneRepository documentProtectedZoneRepository;
        private readonly IMapper mapper;

        public DocumentProtectedZoneController(IDocumentProtectedZoneRepository documentProtectedZoneRepository, IMapper mapper)
        {
            this.documentProtectedZoneRepository = documentProtectedZoneRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Kreira listu svih Dokumenata o zasticenim zonama.
        /// </summary>
        /// <returns>Lista dokumentacije o zasticenim zonama.</returns>
        [HttpGet]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> GetAllDocumentsProtectedZone()
        {
            var documentProtectedZones = await documentProtectedZoneRepository.GetAllDocumentsProtectedZone();
            var documentProtectedZonesDto = mapper.Map<List<DocumentProtectedZoneDto>>(documentProtectedZones);
            return Ok(documentProtectedZonesDto);
        }

        /// <summary>
        /// Vraća jedan dokument o zasticenim zonama na osnovu ID-ja.
        /// </summary>
        /// <param name="DocumentProtectedZoneId">ID Dokumenta o zasticenim zonama</param>
        /// <returns></returns>
        /// <response code="200">Vraća traženi dokument</response>
        /// <response code="404">Nije pronadjen dokument</response>
        [HttpGet]
        [Route("{DocumentProtectedZoneId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDocumentProtectedZone(Guid DocumentProtectedZoneId)
        {
            var documentProtectedZone = await documentProtectedZoneRepository.GetDocumentProtectedZone(DocumentProtectedZoneId);
            if(documentProtectedZone == null)
            {
                return NotFound();
            }
            var documentProtectedZoneDto = mapper.Map<DocumentProtectedZoneDto>(documentProtectedZone);
            return Ok(documentProtectedZoneDto);
        }

        /// <summary>
        /// Kreira dokument o zasticenim zonama.
        /// </summary>
        /// <remarks>
        /// Primer zahteva:
        /// 
        ///     POST api/DocumentProtectedZone
        ///     {        
        ///       "ReferenceNumber": 23,
        ///       "Date": "2023-01-02",
        ///       "DateOfSubmission": "2023-01-01",
        ///       "PermitedWorks": "Izgradnja novog objekta"
        ///       "ProtectedZoneId": "85ca2e6b-1cc0-49d2-a7ef-92810b63371e"
        ///     }
        /// </remarks>
        /// <response code="201">Vraća kreiran dokument</response>
        [HttpPost]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> AddDocumentProtectedZone(AddDocumentProtectedZoneDto addDocumentProtectedZoneDto)
        {
            var documentProtectedZone = new DocumentProtectedZone()
            {
                ReferenceNumber = addDocumentProtectedZoneDto.ReferenceNumber,
                Date = addDocumentProtectedZoneDto.Date,
                DateOfSubmission = addDocumentProtectedZoneDto.DateOfSubmission,
                PermitedWorks = addDocumentProtectedZoneDto.PermitedWorks,
                ProtectedZoneId = addDocumentProtectedZoneDto.ProtectedZoneId
            };
            documentProtectedZone = await documentProtectedZoneRepository.AddDocumentProtectedZone(documentProtectedZone);
            var documentProtectedZoneDto = mapper.Map<DocumentProtectedZoneDto>(documentProtectedZone);
            return CreatedAtAction(nameof(GetDocumentProtectedZone), new { DocumentProtectedZoneId = documentProtectedZoneDto.DocumentProtectedZoneId }, documentProtectedZoneDto);
        }

        /// <summary>
        /// Ažurira jedan dokument o zasticenim zonama.
        /// </summary>
        /// <remarks>
        /// Primer stranog kljuca:
        ///   
        ///       "ProtectedZoneId": "85ca2e6b-1cc0-49d2-a7ef-92810b63371e"        
        ///     
        /// </remarks>
        /// <param name="updateDocumentProtectedZoneDto">Model dokumenta o zasticenim zonama koji se ažurira</param>
        /// <response code="200">Vraća azuriran dokument</response>
        /// <response code="404">Nije pronadjen dokument</response>
        [HttpPut]
        [Authorize(Roles = "superuser")]
        [Route("{DocumentProtectedZoneId:guid}")]
        public async Task<IActionResult> UpdateDocumentProtectedZone(Guid DocumentProtectedZoneId, UpdateDocumentProtectedZoneDto updateDocumentProtectedZoneDto)
        {
            var documentProtectedZone = new DocumentProtectedZone()
            {
                ReferenceNumber = updateDocumentProtectedZoneDto.ReferenceNumber,
                Date = updateDocumentProtectedZoneDto.Date,
                DateOfSubmission = updateDocumentProtectedZoneDto.DateOfSubmission,
                PermitedWorks = updateDocumentProtectedZoneDto.PermitedWorks,
                ProtectedZoneId = updateDocumentProtectedZoneDto.ProtectedZoneId
            };
            documentProtectedZone = await documentProtectedZoneRepository.UpdateDocumentProtectedZone(DocumentProtectedZoneId,documentProtectedZone);
            if(documentProtectedZone == null)
            {
                return NotFound();
            }
            var documentProtectedZoneDto = mapper.Map<DocumentProtectedZoneDto>(documentProtectedZone);
            return Ok(documentProtectedZoneDto);
        }

        /// <summary>
        /// Vrši brisanje jednog dokumenta o zasticenim zonama na osnovu njegovog ID-ja.
        /// </summary>
        /// <param name="DocumentProtectedZoneId">ID dokumenta o zasticenim zonama</param>
        /// <response code="200">Uspesno obrisan dokument</response>
        /// <response code="404">Nije pronadjen dokument</response>
        [HttpDelete]
        [Route("{DocumentProtectedZoneId:guid}")]
        public async Task<IActionResult> DeleteDocumentProtectedZone(Guid DocumentProtectedZoneId)
        {
            var documentProtectedZone = await documentProtectedZoneRepository.DeleteDocumentProtectedZone(DocumentProtectedZoneId);
            if (documentProtectedZone == null)
            {
                return NotFound();
            }
            var documentProtectedZoneDto = mapper.Map<DocumentProtectedZoneDto>(documentProtectedZone);
            return Ok(documentProtectedZoneDto);
        }
    }
}
