using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystem.Models
{
    // Model for Blog Status table
    public class BlogStatus
    {
        [Key]
        public int id { get; set; }
        public string status_name { get; set; }

        
        public virtual ICollection<Blogs> Blogs { get; set; }
    }
}
