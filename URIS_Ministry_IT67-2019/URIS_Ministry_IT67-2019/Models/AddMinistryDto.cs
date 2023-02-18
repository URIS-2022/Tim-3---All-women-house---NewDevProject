namespace URIS_Ministry_IT67_2019.Models
{   
    /// <summary>
    /// Model za kreiranje ministarstva
    /// </summary>
    public class AddMinistryDto
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
