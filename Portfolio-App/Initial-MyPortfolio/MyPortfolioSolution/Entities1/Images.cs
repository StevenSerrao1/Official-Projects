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
        public string? Url { get; set; } // Store image links here

        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; } // Foreign key to Project

        public Project? Project { get; set; } // Navigation property
    }
}
