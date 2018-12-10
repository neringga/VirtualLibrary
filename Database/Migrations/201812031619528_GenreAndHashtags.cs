namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreAndHashtags : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbHastags",
                c => new
                    {
                        RowId = c.Int(nullable: false, identity: true),
                        Hastag = c.String(),
                    })
                .PrimaryKey(t => t.RowId);
            
            CreateTable(
                "dbo.DbGenres",
                c => new
                    {
                        RowId = c.Int(nullable: false, identity: true),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.RowId);
            
            CreateTable(
                "dbo.DbBookDbHastags",
                c => new
                    {
                        DbBook_RowId = c.Int(nullable: false),
                        DbHastag_RowId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DbBook_RowId, t.DbHastag_RowId })
                .ForeignKey("dbo.DbBooks", t => t.DbBook_RowId, cascadeDelete: true)
                .ForeignKey("dbo.DbHastags", t => t.DbHastag_RowId, cascadeDelete: true)
                .Index(t => t.DbBook_RowId)
                .Index(t => t.DbHastag_RowId);
            
            AddColumn("dbo.DbBooks", "Genre_RowId", c => c.Int());
            CreateIndex("dbo.DbBooks", "Genre_RowId");
            AddForeignKey("dbo.DbBooks", "Genre_RowId", "dbo.DbGenres", "RowId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbBookDbHastags", "DbHastag_RowId", "dbo.DbHastags");
            DropForeignKey("dbo.DbBookDbHastags", "DbBook_RowId", "dbo.DbBooks");
            DropForeignKey("dbo.DbBooks", "Genre_RowId", "dbo.DbGenres");
            DropIndex("dbo.DbBookDbHastags", new[] { "DbHastag_RowId" });
            DropIndex("dbo.DbBookDbHastags", new[] { "DbBook_RowId" });
            DropIndex("dbo.DbBooks", new[] { "Genre_RowId" });
            DropColumn("dbo.DbBooks", "Genre_RowId");
            DropTable("dbo.DbBookDbHastags");
            DropTable("dbo.DbGenres");
            DropTable("dbo.DbHastags");
        }
    }
}
