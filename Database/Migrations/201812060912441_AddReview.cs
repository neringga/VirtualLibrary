namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReview : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbReviews",
                c => new
                    {
                        RowId = c.Int(nullable: false, identity: true),
                        BookCode = c.String(),
                        User = c.String(),
                        Review = c.String(),
                    })
                .PrimaryKey(t => t.RowId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DbReviews");
        }
    }
}
