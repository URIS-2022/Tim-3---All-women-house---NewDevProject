namespace URIS_DOKUMENTACIJA_IT72.Models.DTO
{

    /// <summary>
    /// Zahtev za odavanje programa licitacije
    /// </summary>
    public class AddBiddingProgram
    {
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
