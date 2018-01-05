namespace UserDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        FirstName = c.String(maxLength: 10, fixedLength: true),
                        Active = c.Boolean(nullable: false),
                        UserID = c.Int(nullable: false, identity: true),
                        Surname = c.String(maxLength: 10, fixedLength: true),
                        DOB = c.DateTime(storeType: "date"),
                        FirstLineAddress = c.String(maxLength: 10, fixedLength: true),
                        SecondLineAddress = c.String(maxLength: 10, fixedLength: true),
                        PostCode = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
        }
    }
}
