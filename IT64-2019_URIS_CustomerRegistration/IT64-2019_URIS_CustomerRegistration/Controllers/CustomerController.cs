using AutoMapper;
using IT64_2019_URIS_CustomerRegistration.Data;
using IT64_2019_URIS_CustomerRegistration.Entities;
using IT64_2019_URIS_CustomerRegistration.Models;
using IT64_2019_URIS_CustomerRegistration.ServiceCalls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;

namespace IT64_2019_URIS_CustomerRegistration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;
        private readonly IServiceCall<RegistrationFormDto> registrationFormDto;
        private readonly IConfiguration configuration;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper, IServiceCall<RegistrationFormDto> registrationFormDto, IConfiguration configuration) 
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
            this.registrationFormDto = registrationFormDto;
            this.configuration = configuration;
        }

        /// <summary>
        /// Vraca listu svih evidentiranih kupaca (lica).
        /// </summary>
        /// <returns>Lista evidentiranih kupaca</returns>
        /// <response code="200">Vraca listu kupaca (lica).</response>
        [HttpGet]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await customerRepository.GetAllAsync();
            var customerDTO = new List<CustomerDto>();

            string url = configuration["Services:RegistrationForm"];
            foreach (var cust in customers)
            {
                var custDto = mapper.Map<CustomerDto>(cust);
                if (cust.RegistrationFormId != null)
                {
                    var registrationFormDTO = await registrationFormDto.SendGetRequestAsync(url);
                        
                    if (registrationFormDTO != null)
                        custDto.RegistrationForm = registrationFormDTO;
                }
                customerDTO.Add(custDto);
            }

           
            return Ok(customerDTO);


        }
        /// <summary>
        /// Vraca jednog kupaca (lica) na osnovu ID-ja kupca.
        /// </summary>
        /// <param name="customerId">ID kupca</param>
        /// <response code="200">Vraca trazenog kupca (lice).</response>
        /// <response code="404">Nije pronadjen ni jedan kupac (lice).</response>
        [HttpGet]
        [Route("{customerId:guid}")]
        [ActionName("GetCustomerAsync")]
        public async Task<IActionResult> GetCustomerAsync(Guid customerId)
        {
            var customer = await customerRepository.GetAsync(customerId);

            if(customer == null)
            {
                return NotFound();
            }

            var customerDTO = mapper.Map<Models.CustomerDto>(customer);

            return Ok(customerDTO);

        }
        /// <summary>
        /// Kreriranje kupca (lica).
        /// </summary>
        /// <param name="customerAdd">Model za kreiranje kupca (lica)</param>
        /// <returns>Potvrda o kreiranju kupca (lica).</returns>
        ///<remarks>
        ///Primjer zahtjeva za kreiranje kupca (lica): 
        /// \
        ///POST api/Customer
        ///  \
        /// {  
        /// 
        ///     "person": "Pravno lice", 
        ///     "realizedArea": 10000, 
        ///     "authorizedPerson": "Marko Markovic", 
        ///     "payments": 200000, 
        ///     "priority": 1, 
        ///     "guarantor": "Jamstvo" 
        /// }
        /// </remarks>
        /// <response code="201">Vraca kreiranog kupca (lice).</response>
        /// <response code="500">Doslo je do greske na serveru prilikom unosa podataka o kupcu (licu).</response>
        [HttpPost]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> AddCustomerAsync(CustomerAddDto customerAdd)
        {
            var customer = new Customer()
            {
                Person = customerAdd.Person,
                RealizedArea = customerAdd.RealizedArea,
                AuthorizedPerson = customerAdd.AuthorizedPerson,
                Payments = customerAdd.Payments,
                Priority = customerAdd.Priority,
                Guarantor = customerAdd.Guarantor,
                RegistrationFormId = customerAdd.RegistrationFormId
            };


            customer = await customerRepository.AddAsync(customer);

            var customerDTO = mapper.Map<Models.CustomerDto>(customer);
            
            return CreatedAtAction(nameof(GetCustomerAsync), new { customerId = customerDTO.CustomerId }, customerDTO);
        }
        /// <summary>
        /// Vrsi brisanje jednog kupcana osnovu njegovog ID-a.
        /// </summary>
        /// <param name="customerId">ID kupca</param>
        /// <response code="404">Nije pronadjen kupac (lice) za brisanje.</response>
        /// <response code="500">Doslo je do greske na serveru prilikom brisanja kupca (lica).</response>
        [HttpDelete]
        [Route("{customerId:guid}")]
        public async Task<IActionResult> DeleteCustomerAsync(Guid customerId)
        {
            var customer = await customerRepository.DeleteAsync(customerId);

            if(customer == null)
            {
                return NotFound();
            }

            var customerDTO = mapper.Map<Models.CustomerDto>(customer);
            return Ok(customerDTO);

            
        }
        /// <summary>
        /// Azurira jednog kupca.
        /// </summary>
        /// <param name="customerId">ID kupca</param>
        /// <param name="customerUpdate">Model kupca koji se azurira.</param>
        /// <returns>Potvrdu o modifikovanom kupcu (licu).</returns>
        /// <response code="200">Vraca azuriranog kupca (lica).</response>
        /// <response code="404">Kupac (lice) koje se azurira nije pronadjeno.</response>
        /// <response code="500">Doslo je do greske na serveru prilikom azuriranja kupca (lica).</response>
        [HttpPut]
        [Route("{customerId:guid}")]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> UpdateCustomerAsync([FromRoute] Guid customerId, [FromBody] CustomerUpdateDto customerUpdate)
        {
            var customer = new Customer
            {
                Person = customerUpdate.Person,
                RealizedArea = customerUpdate.RealizedArea,
                AuthorizedPerson = customerUpdate.AuthorizedPerson,
                Payments = customerUpdate.Payments,
                Priority = customerUpdate.Priority,
                Guarantor = customerUpdate.Guarantor,
                RegistrationFormId = customerUpdate.RegistrationFormId

            };

            customer = await customerRepository.UpdateAsync(customerId, customer);

            if(customer == null)
            {
                return NotFound();
            }

            var customerDTO = mapper.Map<Models.CustomerDto>(customer);

            return Ok(customerDTO);
        }

      

    }
}
