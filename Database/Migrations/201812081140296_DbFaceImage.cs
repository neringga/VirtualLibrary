namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbFaceImage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbFaceImages",
                c => new
                    {
                        RowId = c.Int(nullable: false, identity: true),
                        Nickname = c.String(),
                        Bytes = c.Binary(),
                    })
                .PrimaryKey(t => t.RowId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DbFaceImages");
        }
    }
}
