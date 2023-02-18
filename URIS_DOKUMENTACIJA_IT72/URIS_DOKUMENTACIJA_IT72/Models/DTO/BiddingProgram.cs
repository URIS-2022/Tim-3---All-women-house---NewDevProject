namespace URIS_DOKUMENTACIJA_IT72.Models.DTO
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


    }
}
