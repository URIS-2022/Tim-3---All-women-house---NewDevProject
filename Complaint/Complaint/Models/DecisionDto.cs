using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Complaint.Models
{
    public class DecisionDto
    {
        /// <summary>
        /// Gets or Sets IdDecision
        /// </summary>

        [Key]
        [DataMember(Name = "idDecision")]
        public Guid IdDecision { get; set; }

        /// <summary>
        /// Gets or Sets DecisionDate
        /// </summary>

        [DataMember(Name = "decisionDate")]
        public DateTime? DecisionDate { get; set; }

        /// <summary>
        /// Gets or Sets MinistryOpinion
        /// </summary>

        [DataMember(Name = "ministryOpinion")]
        public bool? MinistryOpinion { get; set; }
    }
}
