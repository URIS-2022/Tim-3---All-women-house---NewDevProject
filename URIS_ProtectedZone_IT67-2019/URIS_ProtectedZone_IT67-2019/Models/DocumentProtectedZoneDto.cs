using URIS_ProtectedZone_IT67_2019.Entities;

namespace URIS_ProtectedZone_IT67_2019.Models
{
    /// <summary>
    /// DTO dokumenta o zasticenim zonama
    /// </summary>
    public class DocumentProtectedZoneDto
    {
        /// <summary>
        /// ID dokumenta o zasticenim zonama
        /// </summary>
        public Guid DocumentProtectedZoneId { get; set; }

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
