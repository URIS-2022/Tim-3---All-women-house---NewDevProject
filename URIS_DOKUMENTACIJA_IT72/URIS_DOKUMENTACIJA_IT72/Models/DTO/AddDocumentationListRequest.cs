namespace URIS_DOKUMENTACIJA_IT72.Models.DTO
{

    ///<summary>
    ///predstavlja zahtev za dodavanje liste dokumenata
    ///</summary>
    public class AddDocumentationListRequest
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
