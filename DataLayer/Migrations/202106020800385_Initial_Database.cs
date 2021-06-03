namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.terminal_detail",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        group_id = c.Guid(nullable: false),
                        acceptor = c.String(),
                        terminal_number = c.String(nullable: false, maxLength: 150),
                        place_name = c.String(),
                        place_phone = c.String(),
                        serial_number = c.String(),
                        is_access = c.String(),
                        is_authenticate = c.String(),
                        createDate = c.String(),
                        modifiedDate = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.terminal_groups", t => t.group_id, cascadeDelete: true)
                .Index(t => t.group_id);
            
            CreateTable(
                "dbo.terminal_groups",
                c => new
                    {
                        group_id = c.Guid(nullable: false),
                        group_name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.group_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.terminal_detail", "group_id", "dbo.terminal_groups");
            DropIndex("dbo.terminal_detail", new[] { "group_id" });
            DropTable("dbo.terminal_groups");
            DropTable("dbo.terminal_detail");
        }
    }
}
