using System.Reflection.Metadata;

namespace URIS_Licitacion_IT67_2019.Models
{
    public class Decision
    {
        public Guid DecisionId { get; set; }
        public int NumberOfDecisions { get; set; }

        public string? ParlamentaryDecision { get; set; }

        public Guid DocumentId { get; set; }

    }
}
