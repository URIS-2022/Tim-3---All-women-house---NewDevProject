namespace URIS_DOKUMENTACIJA_IT72.Models.Domain
{

    ///<summary>
    ///predstavlja program licitacije
    ///</summary>

    public class BiddingProgram
    {
        /// <summary>
        /// ID programa
        /// </summary>
        public Guid BiddingProgramId { get; set; }
        /// <summary>
        /// Broj kruga
        /// </summary>
        public int RoundNumber { get; set; }


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
