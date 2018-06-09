namespace ConnectedDot.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateCategories : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO Categories (Name) VALUES ('Development Environment')");
            Sql("INSERT INTO Categories (Name) VALUES ('Programming Languages')");
            Sql("INSERT INTO Categories (Name) VALUES ('Web Technologies')");
            Sql("INSERT INTO Categories (Name) VALUES ('Frameworks')");
            Sql("INSERT INTO Categories (Name) VALUES ('Databases')");
            Sql("INSERT INTO Categories (Name) VALUES ('Version Integrity')");
            Sql("INSERT INTO Categories (Name) VALUES ('Tests')");

        }
        
        public override void Down()
        {
            Sql("DELETE FROM Categories Where Name IN ('Development Environment', 'Programming Languages' ,'Web Technologies' ,'Frameworks', 'Databases', 'Version Integrity',  'Tests')");
        }
    }
}
