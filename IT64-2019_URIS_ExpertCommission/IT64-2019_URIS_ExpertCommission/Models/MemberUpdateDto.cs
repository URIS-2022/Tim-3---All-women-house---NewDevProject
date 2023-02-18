namespace IT64_2019_URIS_ExpertCommission.Models
{
    public class MemberUpdateDto
    {
        /// <summary>
        /// Ime clana strucne komisije
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Prezime strucne komisije
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
        /// ID strucne komisije
        /// </summary>
        public Guid ExpertCommissionId { get; set; }
    }
}
