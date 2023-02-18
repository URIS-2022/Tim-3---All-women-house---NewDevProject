namespace URIS_DEOPARCELE_IT72.Models.DTO
{
    /// <summary>
    /// zahtev za izmenu
    /// </summary>
    public class UpdatePartOfParcelRequest
    {
        ///<summary>
        ///kvalitet zemljista
        /// </summary>
        public string ?KvalitetZemljiste { get; set; }

        ///<summary>
        ///povrsina dela parcele
        /// </summary>
        public string ?PovrsinaDelaParcele { get; set; }
    }
}
