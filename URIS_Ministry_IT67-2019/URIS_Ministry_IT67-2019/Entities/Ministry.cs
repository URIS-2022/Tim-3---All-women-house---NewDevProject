namespace URIS_Ministry_IT67_2019.Entities
{
    /// <summary>
    /// Predstavlja ministarstvo
    /// </summary>
    public class Ministry
    {
        /// <summary>
        /// ID ministarstva
        /// </summary>
        public Guid MinistryId { get; set; }

        /// <summary>
        /// Naziv ministarstva
        /// </summary>
        public string? MinistryName { get; set; }

        /// <summary>
        /// Naziv ministra
        /// </summary>
        public string? Minister { get; set; }

        /// <summary>
        /// Saglasnost
        /// </summary>
        public string? Consent { get; set; }
    }
}
