using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortfolioSolution.Entities1
{
    public class Images
    {
        [Key]
        public int ImageId { get; set; }

        [StringLength(200)]
        [Url]
        public string ImageUrl { get; set; } = string.Empty; // Store image links here

        [StringLength(200)]
        public string Caption { get; set; } = string.Empty;

        [StringLength(600)]
        public string AltText { get; set; } = string.Empty;    

        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; } // Foreign key to Project

        public Project? Project { get; set; } // Navigation property
    }
}
