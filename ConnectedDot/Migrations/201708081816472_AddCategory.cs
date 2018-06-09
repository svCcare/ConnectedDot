namespace ConnectedDot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Skills", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Skills", "CategoryId");
            AddForeignKey("dbo.Skills", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Skills", new[] { "CategoryId" });
            DropColumn("dbo.Skills", "CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
