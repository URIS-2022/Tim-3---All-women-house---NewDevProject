namespace URIS_DOKUMENTACIJA_IT72.Models.Domain
{

    ///<summary>
    ///predstavlja Dokument
    ///</summary>
    public class Document
    {
        /// <summary>
        /// ID dokumenta
        /// </summary>
        public Guid DocumentId { get; set; }
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

        /// <summary>
        /// navigaciono svojstvo 
        /// </summary>
        public IEnumerable<Decision> Decisions { get; set; }

        /// <summary>
        /// Navigaciono svojstvo
        /// </summary>
        public IEnumerable<BiddingProgram> BiddingPrograms{ get; set; }

        /// <summary>
        /// Lista liste dokumenata
        /// </summary>
        public DocumentationList DocumentationLists { get; set; }

    }
}
