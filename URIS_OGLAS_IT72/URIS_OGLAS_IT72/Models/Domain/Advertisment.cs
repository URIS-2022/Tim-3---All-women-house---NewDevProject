namespace URIS_OGLAS_IT72.Models.Domain
{


    ///<summary>
    ///predstavlja Oglas
    ///</summary>
    public class Advertisment
    {
        /// <summary>
        /// ID oglasa
        /// </summary>
        public Guid AdvertismentId { get; set; }
        /// <summary>
        /// pretstavlja tip garanta
        /// </summary>
        public string ?TipGaranta { get; set; }
        /// <summary>
        /// strani kljuc, primarni kljuc u tabeli odluke o oglasu
        /// </summary>
        public Guid DecisionOfAdvertismentId { get; set; }
        /// <summary>
        /// Lista odluke o donosenju oglasa
        /// </summary>
        public DecisionOfAdvertisment DecisionOfAdvertisments { get; set; }
    }
}
