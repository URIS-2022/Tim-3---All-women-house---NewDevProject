namespace URIS_DOKUMENTACIJA_IT72.Models.DTO
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
        /// <summary>
        /// Strani kljuc, odnosno primarni u klasi Dokument
        /// </summary>
        public Guid DocumentId { get; set; }

        //property
    }
}
