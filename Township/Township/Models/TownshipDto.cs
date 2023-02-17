using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Township.Models
{
    public class TownshipDto
    {
        /// <summary>
        /// Gets or Sets IdTownship
        /// </summary>

        [Key]
        [DataMember(Name = "idTownship")]
        public Guid IdTownship { get; set; }

        /// <summary>
        /// Gets or Sets NameOfTownship
        /// </summary>

        [Required]
        [DataMember(Name = "nameOfTownship")]
        public string? NameOfTownship { get; set; }

    }
}
