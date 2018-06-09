namespace ConnectedDot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNotesToskills : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Skills", "Notes");
        }
    }
}
