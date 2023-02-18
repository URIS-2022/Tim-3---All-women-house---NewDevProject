namespace IT64_2019_URIS_ExpertCommission.Models
{
    public class ExpertCommissionAddDto
    {
        /// <summary>
        /// Naziv strucne komisije
        /// </summary>
        public string ExpertCommissionName { get; set; }
        /// <summary>
        /// Ime i prezime predsjednika strucne komisije
        /// </summary>
        public string PresidentName { get; set; }
        /// <summary>
        /// Broj clanova strucne komisije
        /// </summary>
        public int NumberOfMembers { get; set; }

    }
}
