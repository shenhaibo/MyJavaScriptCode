namespace Siemens.SCM.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DefaultDatas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DefaultDataTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DefaultDataTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DefaultDataTypes");
            DropTable("dbo.DefaultDatas");
        }
    }
}
