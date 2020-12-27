using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlogSystem.Models;

namespace BlogSystem.Data
{
    public class BlogSystemContext : DbContext
    {
        public BlogSystemContext(DbContextOptions<BlogSystemContext> options)
            : base(options)
        {
        }

        public DbSet<Blogs> Blogs { get; set; }


    }
}
