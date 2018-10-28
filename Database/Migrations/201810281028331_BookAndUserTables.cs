namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookAndUserTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbBooks",
                c => new
                    {
                        RowId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        Code = c.String(),
                        DaysForBorrowing = c.Int(nullable: false),
                        IsTaken = c.Boolean(nullable: false),
                        TakenByUser = c.String(),
                        TakenWhen = c.DateTime(),
                        HasToBeReturned = c.DateTime(),
                    })
                .PrimaryKey(t => t.RowId);
            
            CreateTable(
                "dbo.DbUsers",
                c => new
                    {
                        RowId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        DateOfBirth = c.String(),
                        Password = c.String(),
                        Nickname = c.String(),
                        Language = c.String(),
                    })
                .PrimaryKey(t => t.RowId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DbUsers");
            DropTable("dbo.DbBooks");
        }
    }
}
