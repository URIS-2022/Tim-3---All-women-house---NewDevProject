namespace URIS_ProtectedZone_IT67_2019.Models
{
    /// <summary>
    /// Model za azuriranje dokumenta o zasticenim zonama
    /// </summary>
    public class UpdateDocumentProtectedZoneDto
    {
        /// <summary>
        /// Zavodni broj
        /// </summary>
        public int ReferenceNumber { get; set; }

        /// <summary>
        /// Datum
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Datum podnosenja
        /// </summary>
        public DateTime DateOfSubmission { get; set; }

        /// <summary>
        /// Dozvoljeni radovi
        /// </summary>
        public string? PermitedWorks { get; set; }

        /// <summary>
        /// Strani kljuc zasticene zone
        /// </summary>
        public Guid ProtectedZoneId { get; set; }
    }
}
