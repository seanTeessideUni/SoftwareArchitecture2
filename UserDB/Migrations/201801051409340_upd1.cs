namespace UserDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upd1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "FirstName", c => c.String(nullable: false, maxLength: 10, fixedLength: true));
            AlterColumn("dbo.User", "Surname", c => c.String(nullable: false, maxLength: 10, fixedLength: true));
            AlterColumn("dbo.User", "DOB", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.User", "FirstLineAddress", c => c.String(nullable: false, maxLength: 10, fixedLength: true));
            AlterColumn("dbo.User", "SecondLineAddress", c => c.String(nullable: false, maxLength: 10, fixedLength: true));
            AlterColumn("dbo.User", "PostCode", c => c.String(nullable: false, maxLength: 10, fixedLength: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "PostCode", c => c.String(maxLength: 10, fixedLength: true));
            AlterColumn("dbo.User", "SecondLineAddress", c => c.String(maxLength: 10, fixedLength: true));
            AlterColumn("dbo.User", "FirstLineAddress", c => c.String(maxLength: 10, fixedLength: true));
            AlterColumn("dbo.User", "DOB", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.User", "Surname", c => c.String(maxLength: 10, fixedLength: true));
            AlterColumn("dbo.User", "FirstName", c => c.String(maxLength: 10, fixedLength: true));
        }
    }
}
