namespace Siemens.SCM.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserCode = c.String(),
                        Status = c.Int(nullable: false),
                        Email = c.String(),
                        Gender = c.Int(),
                        CreatorId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.webpages_Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        RoleName = c.String(nullable: false),
                        TreeLevel = c.Int(nullable: false),
                        TreePath = c.String(),
                        Status = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.webpages_Roles", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Privileges",
                c => new
                    {
                        PrivilegeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ControlName = c.String(maxLength: 100),
                        ActionName = c.String(maxLength: 100),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.PrivilegeID);
            
            CreateTable(
                "dbo.DefaultDatas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DefaultDataTypeID = c.Int(nullable: false),
                        Name = c.String(),
                        Characterization = c.String(),
                        Enabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DefaultDataTypes", t => t.DefaultDataTypeID, cascadeDelete: true)
                .Index(t => t.DefaultDataTypeID);
            
            CreateTable(
                "dbo.DefaultDataTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Enabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.webpages_UsersInRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.webpages_Roles", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfile", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.webpages_PrivilegesInRoles",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        PrivilegeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.PrivilegeID })
                .ForeignKey("dbo.webpages_Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Privileges", t => t.PrivilegeID, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.PrivilegeID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.webpages_PrivilegesInRoles", new[] { "PrivilegeID" });
            DropIndex("dbo.webpages_PrivilegesInRoles", new[] { "RoleId" });
            DropIndex("dbo.webpages_UsersInRoles", new[] { "RoleId" });
            DropIndex("dbo.webpages_UsersInRoles", new[] { "UserId" });
            DropIndex("dbo.DefaultDatas", new[] { "DefaultDataTypeID" });
            DropIndex("dbo.webpages_Roles", new[] { "ParentId" });
            DropForeignKey("dbo.webpages_PrivilegesInRoles", "PrivilegeID", "dbo.Privileges");
            DropForeignKey("dbo.webpages_PrivilegesInRoles", "RoleId", "dbo.webpages_Roles");
            DropForeignKey("dbo.webpages_UsersInRoles", "RoleId", "dbo.UserProfile");
            DropForeignKey("dbo.webpages_UsersInRoles", "UserId", "dbo.webpages_Roles");
            DropForeignKey("dbo.DefaultDatas", "DefaultDataTypeID", "dbo.DefaultDataTypes");
            DropForeignKey("dbo.webpages_Roles", "ParentId", "dbo.webpages_Roles");
            DropTable("dbo.webpages_PrivilegesInRoles");
            DropTable("dbo.webpages_UsersInRoles");
            DropTable("dbo.DefaultDataTypes");
            DropTable("dbo.DefaultDatas");
            DropTable("dbo.Privileges");
            DropTable("dbo.webpages_Roles");
            DropTable("dbo.UserProfile");
        }
    }
}
