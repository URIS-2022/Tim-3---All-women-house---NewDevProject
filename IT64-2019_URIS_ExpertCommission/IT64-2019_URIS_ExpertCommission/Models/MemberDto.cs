using IT64_2019_URIS_ExpertCommission.Entities;

namespace IT64_2019_URIS_ExpertCommission.Models
{
    public class MemberDto
    {
        /// <summary>
        /// ID clana strucne komisije
        /// </summary>
        public Guid MemberId { get; set; }
        /// <summary>
        /// Ime clana strucne komisije
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Prezime clana strucne komisije
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Broj telefona
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// ID strucne komsije
        /// </summary>
        public Guid ExpertCommissionId { get; set; }
        public ExpertCommission ExpertCommission { get; set; }
    }
}
