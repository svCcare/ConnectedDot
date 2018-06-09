namespace ConnectedDot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonalSkills : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Skills", "UserId");
            AddForeignKey("dbo.Skills", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Skills", new[] { "UserId" });
            DropColumn("dbo.Skills", "UserId");
        }
    }
}
