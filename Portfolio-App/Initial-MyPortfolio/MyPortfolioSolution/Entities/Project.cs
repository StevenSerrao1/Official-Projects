using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [StringLength(120)]
        [Required]
        public string? Name { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        public ICollection<Images>? Images { get; set; }

    }
}
