namespace URIS_DOKUMENTACIJA_IT72.Models.Domain
{
    ///<summary>
    ///predstavlja listu dokumenata
    ///</summary>
    public class DocumentationList
    {

        /// <summary>
        /// ID liste dokumenata
        /// </summary>
        public Guid DocumentationListId { get; set; }
        /// <summary>
        /// ID liste dokumenata rayumljiv od strane korisnika
        /// </summary>
        public int ListId { get; set; }
        /// <summary>
        /// ime liste
        /// </summary>

        public string ?ListName { get; set; }
        /// <summary>
        /// Navigaciono svojstvo
        /// </summary>
        public IEnumerable<Document> Documents { get; set; }

    }
}
