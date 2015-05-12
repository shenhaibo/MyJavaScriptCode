using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Siemens.SCM.Model.DataModel;

namespace Siemens.SCM.Model
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        //
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Privilege> Privileges { get; set; }

        //
        public DbSet<DefaultData> DefaultDatas { get; set; }
        public DbSet<DefaultDataType> DefaultDataTypes { get; set; }


         protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {
             //配置用户角色关系表
             modelBuilder.Entity<Role>().HasMany(p => p.Users).WithMany(p => p.Roles).Map(m => { m.ToTable("webpages_UsersInRoles"); m.MapLeftKey("UserId"); m.MapRightKey("RoleId"); });
             modelBuilder.Entity<Role>().HasMany(p => p.Privileges).WithMany(p => p.Roles).Map(m => { m.ToTable("webpages_PrivilegesInRoles"); m.MapLeftKey("RoleId"); m.MapRightKey("PrivilegeID"); });

             modelBuilder.Entity<DefaultData>().HasRequired<DefaultDataType>(p => p.defaultDataType);

             base.OnModelCreating(modelBuilder);

         }

    }
    
}
