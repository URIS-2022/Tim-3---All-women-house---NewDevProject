namespace URIS_DEOPARCELE_IT72.Models.DTO
{///<summary>
 ///predstavlja Deo parcele
 ///</summary>
    public class PartOfParcel
    {
        /// <summary>
        /// ID dela parcele
        /// </summary>
        public Guid PartOfParcelID { get; set; }
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
