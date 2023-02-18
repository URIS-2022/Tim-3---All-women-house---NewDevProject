namespace URIS_DOKUMENTACIJA_IT72.Models.Domain
{


    ///<summary>
    ///predstavlja Resenje
    ///</summary>
    public class Decision
    {
        /// <summary>
        /// ID resenje
        /// </summary>
        public Guid DecisionId { get; set; }
        /// <summary>
        /// Broj resenja
        /// </summary>
        public int NumberOfDecision { get; set; }
        /// <summary>
        /// da li je odluka odobrena
        /// </summary>
        public string ?ParliamentaryDecision { get; set; }
        //odobreno, nije odobreno

        /// <summary>
        /// Strani kljuc, odnosno primarni u klasi Dokument
        /// </summary>
        public Guid DocumentId { get; set; }

        /// <summary>
        /// Lista dokumenata
        /// </summary>
        public Document Document { get; set; }

    }
}
