namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableRenaming : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DbBookDbHastags", newName: "DbHastagDbBooks");
            DropPrimaryKey("dbo.DbHastagDbBooks");
            AddPrimaryKey("dbo.DbHastagDbBooks", new[] { "DbHastag_RowId", "DbBook_RowId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.DbHastagDbBooks");
            AddPrimaryKey("dbo.DbHastagDbBooks", new[] { "DbBook_RowId", "DbHastag_RowId" });
            RenameTable(name: "dbo.DbHastagDbBooks", newName: "DbBookDbHastags");
        }
    }
}
