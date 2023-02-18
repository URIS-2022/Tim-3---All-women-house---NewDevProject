﻿namespace URIS_Stages_it24.Models.DTO
{
    public class UpdateStageRequest
    {
        /// <summary>
        /// Gets or sets the stage number, which can be used to order the stages chronologically.
        /// </summary>
        public int StageNumber { get; set; }
        /// <summary>
        /// Gets or sets the date on which the stage is scheduled to take place.
        /// </summary>
        public DateTime StageDay { get; set; }
    }
}
