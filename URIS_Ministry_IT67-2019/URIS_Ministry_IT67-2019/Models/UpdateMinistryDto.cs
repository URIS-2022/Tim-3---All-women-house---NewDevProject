namespace URIS_Ministry_IT67_2019.Models
{
    /// <summary>
    /// Model za azuriranje ministarstva
    /// </summary>
    public class UpdateMinistryDto
    {
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
