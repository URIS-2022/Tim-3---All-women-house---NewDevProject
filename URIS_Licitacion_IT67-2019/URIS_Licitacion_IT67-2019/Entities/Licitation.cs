using URIS_Licitacion_IT67_2019.Models;

namespace URIS_Licitacion_IT67_2019.Entities
{
    /// <summary>
    /// Predstavlja licitaciju
    /// </summary>
    public class Licitation
    {
        /// <summary>
        /// ID licitacije
        /// </summary>
        public Guid LicitationId { get; set; }

        /// <summary>
        /// Broj licitacije
        /// </summary>
        public int NumberOfLic { get; set; }

        /// <summary>
        /// Godina izvrsavanja
        /// </summary>
        public string? Year { get; set; }

        /// <summary>
        /// Datum objavljivanja
        /// </summary>
        public DateTime DateOfAnnouncment { get; set; }

        /// <summary>
        /// Rok za podnosenje
        /// </summary>
        public DateTime DeadlineForSubmission { get; set; }

        /// <summary>
        /// Lista dokumenata fizickih lica
        /// </summary>
        public string? ListOfIndividuals { get; set; }

        /// <summary>
        /// Lista dokumenata pravnih lica
        /// </summary>
        public string? ListOfLegalEntity { get; set; }

        /// <summary>
        /// Strani kljuc resenje
        /// </summary>
        public Guid DecisionId { get; set; }

        /// <summary>
        /// Drugi krug licitacije
        /// </summary>
        public bool secondRound { get; set; }
    }
}
