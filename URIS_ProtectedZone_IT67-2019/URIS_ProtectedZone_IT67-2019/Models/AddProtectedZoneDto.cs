namespace URIS_ProtectedZone_IT67_2019.Models
{
    /// <summary>
    /// Model za kreiranje zasticene zone
    /// </summary>
    public class AddProtectedZoneDto
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
