using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystem.Models
{
    // Model for Profiles table
    public class Profiles
    {
        
        [Key]
        public int id { get; set; }
        public string status_name { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
