using BlogModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogRepository
{
    internal class BlogContext : DbContext
    {
        public BlogContext() : base("Blog")
        {
            var dbtype = typeof(System.Data.Entity.SqlServer.SqlFunctions);
        }
        public DbSet<Post> Post { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>().Property(i => i.Author).HasMaxLength(256);
            modelBuilder.Entity<Post>().Property(i => i.Title).HasMaxLength(256);
        }
    }
}
