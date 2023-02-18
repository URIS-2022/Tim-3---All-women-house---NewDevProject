namespace IT64_2019_URIS_ExpertCommission.Models
{
    public class ExpertCommissionDto
    {
        /// <summary>
        /// ID strucne komisije
        /// </summary>
        public Guid ExpertCommissionId { get; set; }
        /// <summary>
        /// Naziv strucne komisije
        /// </summary>
        public string ExpertCommissionName { get;set; }
        /// <summary>
        /// Ime i prezime predsjednika strucne komsije
        /// </summary>
        public string PresidentName { get; set; }

        /// <summary>
        /// Broj clanova strucne komisije
        /// </summary>
        public int NumberOfMembers { get; set; }

    }
}
