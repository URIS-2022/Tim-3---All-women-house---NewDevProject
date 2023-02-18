namespace URIS_DEOPARCELE_IT72.Models.DTO
{
    /// <summary>
    /// zahtev za dodavanje
    /// </summary>
    public class AddPartOfParcelRequest
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
