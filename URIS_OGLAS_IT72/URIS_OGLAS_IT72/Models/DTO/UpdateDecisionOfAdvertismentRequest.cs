namespace URIS_OGLAS_IT72.Models.DTO
{
    /// <summary>
    /// zahtev za izmenu
    /// </summary>
    public class UpdateDecisionOfAdvertismentRequest
    {
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
