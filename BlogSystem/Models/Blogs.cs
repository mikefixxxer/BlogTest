using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace BlogSystem.Models
{
    //Model for Blogs table
    public class Blogs
    {
        [Key]
        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("Title")]
        public string blog_title { get; set; }
        [DisplayName("Text")]
        public string blog_text { get; set; }
        [DisplayName("User ID")]
        public int user_id { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Creation date")]
        public DateTime creation_date { get; set; }
        [DisplayName("Aproval date ")]
        public DateTime approval_date { get; set; }
        [DisplayName("Last modification date")]
        public DateTime last_mod_date { get; set; }
        [DisplayName("Status")]
        public int status { get; set; }
        
        [ForeignKey("user_id")]
        public virtual Users Users { get; set; }
        [ForeignKey("status")]
        public virtual BlogStatus BlogStatus { get; set; }

        
        public virtual ICollection<Comments> Comments { get; set; }
    }
}
