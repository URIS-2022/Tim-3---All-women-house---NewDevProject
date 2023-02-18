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
    public class MemberController : Controller
    {
        private readonly IMemberRepository memberRepository;
        private readonly IMapper mapper;
        public MemberController(IMemberRepository memberRepository, IMapper mapper )
        {
            this.memberRepository = memberRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraca listu evidentiranog clana strucne komisije.
        /// </summary>
        /// <returns>Lista clanova strucne komisije</returns>
        /// <response code="200">Vraca listu clanova strucne komisije.</response>
        [HttpGet]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> GetMembersAsync()
        {
            var members = await memberRepository.GetAllAsync();

            var memberDTO = mapper.Map<List<Models.MemberDto>>(members);

            return Ok(memberDTO);
            
        }
        /// <summary>
        /// Vraca jedng clana strucne komisije na osnovu njegovog ID-ja
        /// </summary>
        /// <param name="memberId">ID clana strucne komisije</param>
        /// <response code="200">Vraca trazenog clana strucne komisije.</response>
        /// <response code="404">Nije pronadjen ni jedan clan strucne komisije.</response>
        [HttpGet]
        [Route("{memberId:guid}")]
        [ActionName("GetMemberAsync")]
        public async Task<IActionResult> GetMemberAsync(Guid memberId)
        {
            var member = await memberRepository.GetAsync(memberId);

            if(member == null)
            {
                NotFound();
            }

            var memberDTO = mapper.Map<Models.MemberDto>(member);
            return Ok(memberDTO);
        }
        /// <summary>
        /// Kreriranje clana strucne komisije.
        /// </summary>
        /// <param name="memberAdd">Model za kreiranje clana strucne komisije</param>
        /// <returns>Potvrda o kreiranju clana strucne komisije.</returns>
        /// <remarks>
        /// Primjer zahtjeva za kreiranje clana strucne komisije:
        /// \
        /// POST api/Member
        ///  \
        /// {
        /// 
        ///     "firstName": "Petar",
        ///     "lastName": "Petrovic",
        ///     "phone": "0455677990",
        ///     "email": "petar@gmail.com",
        ///     "expertCommissionId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
        ///  }
        /// </remarks>
        [HttpPost]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> AddMemberAsync(MemberAddDto memberAdd)
        {
            var member = new Member
            {
                FirstName = memberAdd.FirstName,
                LastName = memberAdd.LastName,
                Phone = memberAdd.Phone,
                Email = memberAdd.Email,
                ExpertCommissionId = memberAdd.ExpertCommissionId

            };

            member = await memberRepository.AddAsync(member);
            var memberDTO = mapper.Map<Models.MemberDto>(member);

            return CreatedAtAction(nameof(GetMemberAsync), new { memberId = memberDTO.MemberId }, memberDTO);
        }
        /// <summary>
        /// Vrsi brisanje jednog clana strucne komisije osnovu njegovog ID-a.
        /// </summary>
        /// <param name="memberId">ID clana strucne komisije</param>
        /// <response code="204">Clan strucne komisije uspjesno obrisan.</response>
        /// <response code="404">Nije pronadjen clan strucna komisija za brisanje.</response>
        /// <response code="500">Doslo je do greske na serveru prilikom brisanja clana strucne komisije.</response>
        [HttpDelete]
        [Route("{memberId:guid}")]
        public async Task<IActionResult> DeleteMemberAsync(Guid memberId)
        {
            var member = await memberRepository.DeleteAsync(memberId);

            if (member == null)
            {
                return NotFound();
            }

            var memberDTO = mapper.Map<Models.MemberDto>(member);
            return Ok(memberDTO);
        }

        /// <summary>
        /// Azurira jednog clana strucne komisije.
        /// </summary>
        /// <param name="memberId">ID clana strucne komisije</param>
        /// <param name="memberUpdate">Model clana strucne komisije koja se azurira.</param>
        /// <returns>Potvrdu o modifikovanom clanu strucne komisije.</returns>
        /// <response code="200">Vraca azuriranu strucnu komisiju.</response>
        /// <response code="404">Clan strucne komisije koje se azurira nije pronadjen.</response>
        /// <response code="500">Doslo je do greske na serveru prilikom azuriranja clana strucne komisije.</response>
        [HttpPut]
        [Route("{memberId:guid}")]
        [Authorize(Roles = "superuser")]
        public async Task<IActionResult> UpdateMemberAsync(Guid memberId, MemberUpdateDto memberUpdate)
        {
            var member = new Member
            {
                FirstName = memberUpdate.FirstName,
                LastName = memberUpdate.LastName,
                Phone = memberUpdate.Phone,
                Email = memberUpdate.Email,
                ExpertCommissionId = memberUpdate.ExpertCommissionId

            };

            member = await memberRepository.UpdateAsync(memberId,member);
            if(member == null)
            {
                return NotFound();
            }

            var memberDTO = mapper.Map<Models.MemberDto>(member);
            return Ok(memberDTO);

        }

  


    }
}
