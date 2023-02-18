namespace URIS_DOKUMENTACIJA_IT72.Models.DTO
{
    ///<summary>
    ///predstavlja zahtev ya izmenu liste dokumenata
    ///</summary>
    public class UpdateDocumentationListRequest
    {
        /// <summary>
        /// ID liste dokumenata rayumljiv od strane korisnika
        /// </summary>
        public int ListId { get; set; }
        /// <summary>
        /// ime liste
        /// </summary>
        public string ?ListName { get; set; }
    }
}
