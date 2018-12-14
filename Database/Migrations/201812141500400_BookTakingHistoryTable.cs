namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookTakingHistoryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbBookTakingHistories",
                c => new
                    {
                        RowId = c.Int(nullable: false, identity: true),
                        BookCode = c.String(nullable: false),
                        TakenByUser = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RowId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DbBookTakingHistories");
        }
    }
}
