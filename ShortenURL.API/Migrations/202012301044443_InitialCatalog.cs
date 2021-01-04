namespace URLShorten.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCatalog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShortUrls",
                c => new
                    {
                        Key = c.String(nullable: false, maxLength: 128),
                        Url = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Key);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ShortUrls");
        }
    }
}
