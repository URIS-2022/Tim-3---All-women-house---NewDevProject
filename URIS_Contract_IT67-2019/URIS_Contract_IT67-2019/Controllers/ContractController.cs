using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics.Contracts;
using URIS_Contract_IT67_2019.Entities;
using URIS_Contract_IT67_2019.Models;
using URIS_Contract_IT67_2019.Repositories;

namespace URIS_Contract_IT67_2019.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractController : Controller
    {
        private readonly IContractRepository contractRepository;
        private readonly IMapper mapper;

        public ContractController(IContractRepository contractRepository, IMapper mapper)
        {
            this.contractRepository = contractRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Kreira listu svih Ugovora.
        /// </summary>
        /// <returns>Lista Ugovora.</returns>
        /// <response code="200">Vraća listu ugovora</response>
        [HttpGet]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> GetAllContracts()
        {
            var contracts = await contractRepository.GetAllContracts();
            var contractsDto = mapper.Map<List<ContractDto>>(contracts);

            return Ok(contractsDto);
        }

        /// <summary>
        /// Vraća jednan ugovor osnovu ID-ja.
        /// </summary>
        /// <param name="ContractId">ID Ugovora</param>
        /// <returns></returns>
        /// <response code="200">Vraća traženi ugovor</response>
        /// <response code="404">Nije pronadjen ugovor</response>
        [HttpGet]
        [Route("{ContractId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetContract(Guid ContractId)
        {
            var contract = await contractRepository.GetContract(ContractId);
            if(contract == null)
            {
                return NotFound();
            }

            var contractsDto = mapper.Map<ContractDto>(contract);
            return Ok(contractsDto);
        }

        /// <summary>
        /// Kreira ugovor.
        /// </summary>
        /// <remarks>
        /// Primer ugovora:
        /// 
        ///     POST api/Contract
        ///     {        
        ///       "ContractName": "Ugovor o zakupu",
        ///       "PaymentGuarantor": "Garancija nekretninom",
        ///       "ReferenceNumber": 225, 
        ///       "DateOfSeduction": "2023-01-12",
        ///       "PlaceOfSigning": "Subotica",
        ///       "DateOfSigning": "2023-01-12"
        ///     }
        /// </remarks>
        /// <response code="201">Vraća kreiran ugovor</response>
        [HttpPost]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> AddContract(AddContractDto addContractDto)
        {
            var contract = new Entities.Contract()
            {
                ContractName = addContractDto.ContractName,
                PaymentGuarantor = addContractDto.PaymentGuarantor,
                ReferenceNumber = addContractDto.ReferenceNumber,
                DateOfSeduction = addContractDto.DateOfSeduction,
                PlaceOfSigning = addContractDto.PlaceOfSigning,
                DateOfSigning = addContractDto.DateOfSigning
            };

            contract = await contractRepository.AddContract(contract);
            var contractsDto = mapper.Map<ContractDto>(contract);
            return CreatedAtAction(nameof(GetContract), new { ContractId = contractsDto.ContractId }, contractsDto);


        }

        /// <summary>
        /// Ažurira jedan ugovor.
        /// </summary>
        /// <param name="updateContractDto">Model ugovora koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom ugovoru.</returns>
        /// <response code="200">Vraća azuriran ugovor</response>
        /// <response code="404">Nije pronadjen ugovor</response>
        [HttpPut]
        [Authorize(Roles = "superuser")]
        [Route("{ContractId:guid}")]
        public async Task<IActionResult> UpdateContract(Guid ContractId, UpdateContractDto updateContractDto)
        {
            var contract = new Entities.Contract()
            {
                ContractName = updateContractDto.ContractName,
                PaymentGuarantor = updateContractDto.PaymentGuarantor,
                ReferenceNumber = updateContractDto.ReferenceNumber,
                DateOfSeduction = updateContractDto.DateOfSeduction,
                PlaceOfSigning = updateContractDto.PlaceOfSigning,
                DateOfSigning = updateContractDto.DateOfSigning
            };
            contract = await contractRepository.UpdateContract(ContractId,contract);

            if(contract == null) 
            {
                return NotFound();
            }
            var contractsDto = mapper.Map<ContractDto>(contract);
            return Ok(contractsDto);
        }

        /// <summary>
        /// Vrši brisanje jednog ugovora na osnovu njegovog ID-ja.
        /// </summary>
        /// <param name="ContractId">ID ugovora</param>
        /// <response code="200">Uspesno obrisan ugovor</response>
        /// <response code="404">Nije pronadjen ugovor</response>
        [HttpDelete]
        [Route("{ContractId:guid}")]
        public async Task<IActionResult> DeleteContract(Guid ContractId)
        {
            var contract = await contractRepository.DeleteContract(ContractId);
            if(contract == null)
            {
                return NotFound();
            }
            var contractsDto = mapper.Map<ContractDto>(contract);
            return Ok(contractsDto);

        }
    }


}
