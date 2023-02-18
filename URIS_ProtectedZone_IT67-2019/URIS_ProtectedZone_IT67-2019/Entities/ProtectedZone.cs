namespace URIS_ProtectedZone_IT67_2019.Entities
{
    /// <summary>
    /// Predstavlja zasticene zone
    /// </summary>
    public class ProtectedZone
    {
        /// <summary>
        /// ID zasticene zone
        /// </summary>
        public Guid ProtectedZoneId { get; set; }

        /// <summary>
        /// Broj zasticene zone
        /// </summary>
        public int NumberOfZone { get; set; }

        /// <summary>
        /// Dozvoljeni radovi
        /// </summary>
        public string? PermittedWorks { get; set; }

        /// <summary>
        /// Navigacija
        /// </summary>
        public IEnumerable<DocumentProtectedZone> DocumentProtectedZones { get; set; }
    }
}
