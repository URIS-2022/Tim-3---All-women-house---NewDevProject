using System.ComponentModel.DataAnnotations.Schema;

namespace URIS_ProtectedZone_IT67_2019.Entities
{
    /// <summary>
    /// Predstavlja dokument o zasticenim zonama
    /// </summary>
    public class DocumentProtectedZone
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

        /// <summary>
        /// Lista zasticenih zona
        /// </summary>
        public ProtectedZone ProtectedZone { get; set; }
    }
}
