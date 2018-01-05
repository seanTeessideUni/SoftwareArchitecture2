namespace UserDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteflag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Deleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Deleted");
        }
    }
}
