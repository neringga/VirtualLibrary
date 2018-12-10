namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TypoFix : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DbHastags", newName: "DbHashtags");
            RenameTable(name: "dbo.DbHastagDbBooks", newName: "DbHashtagDbBooks");
            RenameColumn(table: "dbo.DbHashtagDbBooks", name: "DbHastag_RowId", newName: "DbHashtag_RowId");
            RenameIndex(table: "dbo.DbHashtagDbBooks", name: "IX_DbHastag_RowId", newName: "IX_DbHashtag_RowId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.DbHashtagDbBooks", name: "IX_DbHashtag_RowId", newName: "IX_DbHastag_RowId");
            RenameColumn(table: "dbo.DbHashtagDbBooks", name: "DbHashtag_RowId", newName: "DbHastag_RowId");
            RenameTable(name: "dbo.DbHashtagDbBooks", newName: "DbHastagDbBooks");
            RenameTable(name: "dbo.DbHashtags", newName: "DbHastags");
        }
    }
}
