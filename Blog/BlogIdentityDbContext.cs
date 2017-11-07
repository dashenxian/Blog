using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity.EntityFramework;

namespace Blog
{
    public class BlogIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public BlogIdentityDbContext() : base("Blog",false)
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogIdentityDbContext, Migrations.Configuration>());
            modelBuilder.Entity<IdentityUserRole>().HasKey(i => i.RoleId).HasKey(i => i.UserId);
            modelBuilder.Entity<IdentityUserLogin>().HasKey(i => i.UserId);
        }
    }
}
