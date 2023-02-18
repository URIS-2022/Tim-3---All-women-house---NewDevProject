using System.Reflection.Metadata;

namespace URIS_OGLAS_IT72.Models.Domain
{
    ///<summary>
    ///predstavlja listu odluka o dokumentu
    ///</summary>
    public class DecisionOfAdvertisment
    {
        /// <summary>
        /// Id odluke o raspisivanju oglasa
        /// </summary>
        public Guid DecisionOfAdvertismentId { get; set;}

        /// <summary>
        /// vreme donosenja odluke
        /// </summary>
        public DateTime VremeDonosenja { get; set;}


        /// <summary>
        /// naziv odluke
        /// </summary>
        public string ?NazivOdluke { get; set; }

        /// <summary>
        /// Navigaciono svojstvo
        /// </summary>
        public IEnumerable<Advertisment> Advertisments { get; set; }
    }
}
