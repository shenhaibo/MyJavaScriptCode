using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace Siemens.SCM.Model
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Role> Roles { get; set; }

         protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {
             //配置用户角色关系表
             modelBuilder.Entity<Role>().HasMany(p => p.Users).WithMany(p => p.Roles).Map(m => { m.ToTable("webpages_UsersInRoles"); m.MapLeftKey("UserId"); m.MapRightKey("RoleId"); });
             base.OnModelCreating(modelBuilder);
         }

    }
    
}
