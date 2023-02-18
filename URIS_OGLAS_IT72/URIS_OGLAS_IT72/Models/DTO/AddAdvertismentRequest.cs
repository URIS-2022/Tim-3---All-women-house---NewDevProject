namespace URIS_OGLAS_IT72.Models.DTO
{
    /// <summary>
    /// zahtev za dodavanje oglasa
    /// </summary>
    public class AddAdvertismentRequest
    {
        /// <summary>
        /// pretstavlja tip garanta
        /// </summary>
        public string ?TipGaranta { get; set; }
        /// <summary>
        /// strani kljuc, primarni kljuc u tabeli odluke o oglasu
        /// </summary>
        public Guid DecisionOfAdvertismentId { get; set; }
    }
}
