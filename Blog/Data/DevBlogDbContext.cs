using Blog.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data
{
    public class DevBlogDbContext:DbContext
    {
        public DevBlogDbContext(DbContextOptions options) : base(options) { 
            
        }

        public DbSet<Post>  Posts { get; set; }
    }
}
