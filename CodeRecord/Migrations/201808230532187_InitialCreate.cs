namespace CodeRecord.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CodeList",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodeName = c.String(),
                        Code = c.String(),
                        Readmd = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CodeList");
        }
    }
}
