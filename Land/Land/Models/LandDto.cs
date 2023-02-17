using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Land.Models
{
    public class LandDto
    {
        /// <summary>
        /// Gets or Sets LabelLand
        /// </summary>

        [Key]
        [DataMember(Name = "labelLand")]
        public Guid LabelLand { get; set; }

        /// <summary>
        /// Gets or Sets Surface
        /// </summary>

        [Required]
        [DataMember(Name = "surface")]
        public string? Surface { get; set; }

        /// <summary>
        /// Gets or Sets SoilCulture
        /// </summary>

        [Required]
        [DataMember(Name = "soilCulture")]
        public string? SoilCulture { get; set; }

        /// <summary>
        /// Gets or Sets _Class
        /// </summary>

        [Required]
        [DataMember(Name = "class")]
        public string? _Class { get; set; }

        /// <summary>
        /// Gets or Sets Workability
        /// </summary>

        [Required]
        [DataMember(Name = "workability")]
        public string? Workability { get; set; }

        /// <summary>
        /// Gets or Sets FormOfProperty
        /// </summary>

        [Required]
        [DataMember(Name = "formOfProperty")]
        public string? FormOfProperty { get; set; }

        /// <summary>
        /// Gets or Sets Drainage
        /// </summary>

        [Required]
        [DataMember(Name = "drainage")]
        public string? Drainage { get; set; }
    }
}
