namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newchagnes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostingDetails", "Retries", c => c.Int(nullable: false));
            AddColumn("dbo.PostingDetails", "RetryCount", c => c.Int(nullable: false));
            AddColumn("dbo.PostingDetails", "PostingError", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostingDetails", "PostingError");
            DropColumn("dbo.PostingDetails", "RetryCount");
            DropColumn("dbo.PostingDetails", "Retries");
        }
    }
}
