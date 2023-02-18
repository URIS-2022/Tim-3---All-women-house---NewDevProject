namespace URIS_Contract_IT67_2019.Models
{
    /// <summary>
    /// Model za dodavanje ugovora
    /// </summary>
    public class AddContractDto
    {
        /// <summary>
        /// Garant placanja
        /// </summary>
        public string? PaymentGuarantor { get; set; }

        /// <summary>
        /// Naziv ugovora
        /// </summary>
        public string? ContractName { get; set; }

        /// <summary>
        /// Zavodni broj
        /// </summary>
        public int ReferenceNumber { get; set; }

        /// <summary>
        /// Datum podnosenja
        /// </summary>
        public DateTime DateOfSeduction { get; set; }

        /// <summary>
        /// Mesto potpisivanja
        /// </summary>
        public string? PlaceOfSigning { get; set; }

        /// <summary>
        /// Datum potpisivanja
        /// </summary>
        public DateTime DateOfSigning { get; set; }
    }
}
