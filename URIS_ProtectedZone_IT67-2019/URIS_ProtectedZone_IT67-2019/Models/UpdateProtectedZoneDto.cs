namespace URIS_ProtectedZone_IT67_2019.Models
{
    /// <summary>
    /// Model za azuriranje zasticene zone
    /// </summary>
    public class UpdateProtectedZoneDto
    {
        /// <summary>
        /// Broj zasticene zone
        /// </summary>
        public int NumberOfZone { get; set; }

        /// <summary>
        /// Dozvoljeni radovi
        /// </summary>
        public string? PermittedWorks { get; set; }
    }
}
