using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Models
{
    public class Blogs
    {
        public int id { get; set; }
        public string blog_title { get; set; }
        public string blog_text { get; set; }
        public string user_name { get; set; }
        [DataType(DataType.Date)]
        public DateTime creation_date { get; set; }
        public DateTime approval_date { get; set; }
        public DateTime last_mod_date { get; set; }
        public int status { get; set; }
    }
}
