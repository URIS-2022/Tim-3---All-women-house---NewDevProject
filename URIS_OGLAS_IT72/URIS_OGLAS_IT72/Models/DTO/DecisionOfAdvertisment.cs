namespace URIS_OGLAS_IT72.Models.DTO
{
    public class DecisionOfAdvertisment
    {

        /// <summary>
        /// Id odluke o raspisivanju oglasa
        /// </summary>
        public Guid DecisionOfAdvertismentId { get; set; }

        /// <summary>
        /// vreme donosenja odluke
        /// </summary>
        public DateTime VremeDonosenja { get; set; }

        /// <summary>
        /// naziv odluke
        /// </summary>
        public string ?NazivOdluke { get; set; }


    }
}
