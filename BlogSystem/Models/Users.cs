using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystem.Models
{
    // Model for Users table
    public class Users
    {
        [Key]
        public int id { get; set; }
        public string full_name { get; set; }
        public string user_name { get; set; }
        public string email { get; set; }
        public byte[] password_hash { get; set; }
        public byte[] password_salt { get; set; }
        public int profile { get; set; }
        public string password { get; set; }

        [ForeignKey("profile")]
        public virtual Profiles Profiles { get; set; }

        public virtual ICollection<Blogs> Blogs { get; set; }
   
    }
}
