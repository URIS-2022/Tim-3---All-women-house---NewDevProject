namespace URIS_DOKUMENTACIJA_IT72.Models.DTO
{
    ///<summary>
    ///zahtev ya iymenu Dokumenta
    ///</summary>
    public class UpdateDocumentRequest
    {
        /// <summary>
        ///broj dokumenta
        /// </summary>
        public int ReferenceNumber { get; set; }
        /// <summary>
        /// trenutno vreme
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// vreme kreiranja dokumenta
        /// </summary>
        public DateTime CreatingDate { get; set; }
        /// <summary>
        /// Strani kljuc, odnosno primarni u klasi Dokumentation list
        /// </summary>
        public Guid DocumentationListId { get; set; }

    }
}
