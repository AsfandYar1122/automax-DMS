namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VIRs", "Severity", c => c.Double(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VIRs", "Severity", c => c.String());
        }
    }
}
