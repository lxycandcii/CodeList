namespace CodeRecord.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _08231 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CodeList", "CreateTime", c => c.DateTime());
            AlterColumn("dbo.CodeList", "UpdateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CodeList", "UpdateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CodeList", "CreateTime", c => c.DateTime(nullable: false));
        }
    }
}
