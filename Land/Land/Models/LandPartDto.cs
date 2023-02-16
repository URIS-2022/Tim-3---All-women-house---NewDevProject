﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Land.Models
{
    public class LandPartDto
    {
        /// <summary>
        /// Gets or Sets LabelLand
        /// </summary>

        [Key]
        [DataMember(Name = "idLandPart")]
        public Guid idLandPart { get; set; }

        /// <summary>
        /// Gets or Sets Surface
        /// </summary>

        [DataMember(Name = "landQuality")]
        public string landQuality { get; set; }

        /// <summary>
        /// Gets or Sets SoilCulture
        /// </summary>

        [DataMember(Name = "surface")]
        public string surface { get; set; }

        /// <summary>
        /// Gets or Sets _Class
        /// </summary>

        [DataMember(Name = "landId")]
        public Guid landId { get; set; }
    }
}
