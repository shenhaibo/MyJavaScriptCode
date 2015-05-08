namespace Siemens.SCM.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReference : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.DefaultDatas", "DefaultDataTypeID", "dbo.DefaultDataTypes", "ID", cascadeDelete: true);
            CreateIndex("dbo.DefaultDatas", "DefaultDataTypeID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.DefaultDatas", new[] { "DefaultDataTypeID" });
            DropForeignKey("dbo.DefaultDatas", "DefaultDataTypeID", "dbo.DefaultDataTypes");
        }
    }
}
