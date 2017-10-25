namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc444 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostingFields", "ArabicFieldName", c => c.String());
            AddColumn("dbo.PostingFields", "ArabicLinkedFieldName", c => c.String());
            AddColumn("dbo.PostingFields", "ArabicDisplayName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostingFields", "ArabicDisplayName");
            DropColumn("dbo.PostingFields", "ArabicLinkedFieldName");
            DropColumn("dbo.PostingFields", "ArabicFieldName");
        }
    }
}
