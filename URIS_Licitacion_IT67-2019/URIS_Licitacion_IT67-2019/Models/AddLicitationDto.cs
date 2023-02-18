namespace URIS_Licitacion_IT67_2019.Models
{
    /// <summary>
    /// Model za dodavanje licitacije
    /// </summary>
    public class AddLicitationDto
    {
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
