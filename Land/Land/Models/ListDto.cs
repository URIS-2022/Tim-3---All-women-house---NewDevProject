using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Land.Models
{
    public class ListDto
    {
        /// <summary>
        /// Gets or Sets IdList
        /// </summary>

        [Key]
        [DataMember(Name = "idList")]
        public Guid IdList { get; set; }

        /// <summary>
        /// Gets or Sets SumSurface
        /// </summary>
        /// 
        [Required]
        [DataMember(Name = "sumSurface")]
        public string? SumSurface { get; set; }

        /// <summary>
        /// Gets or Sets LabelLand
        /// </summary>

        [Required]
        [DataMember(Name = "labelLand")]
        public Guid LabelLand { get; set; }
    }
}
