using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Complaint.Models
{
    public class ComplaintDto
    {
        /// <summary>
        /// Gets or Sets IdComplaint
        /// </summary>
        
        [Key]
        [DataMember(Name = "idComplaint")]
        public Guid IdComplaint { get; set; }

        /// <summary>
        /// Gets or Sets SubmissionDate
        /// </summary>

        [DataMember(Name = "submissionDate")]
        public DateTime? SubmissionDate { get; set; }

        /// <summary>
        /// Gets or Sets TypeOfComplaint
        /// </summary>

        [Required]
        [DataMember(Name = "typeOfComplaint")]
        public string? TypeOfComplaint { get; set; }

        /// <summary>
        /// Gets or Sets StatusOfComplaint
        /// </summary>

        [Required]
        [DataMember(Name = "statusOfComplaint")]
        public string? StatusOfComplaint { get; set; }
    }
}
