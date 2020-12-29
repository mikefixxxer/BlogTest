using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystem.Models
{
    // Model for comments table
    public class Comments
    {
        [Key]
        public int id { get; set; }
        public int blog_id { get; set; }
        public string alt_name { get; set; }
        public int user_id { get; set; }
        public string comment { get; set; }
        public DateTime comment_date { get; set; }

        [ForeignKey("blog_id")]
        public virtual Blogs Blogs { get; set; }
        
    }
}
