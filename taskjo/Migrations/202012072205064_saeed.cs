namespace taskjo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saeed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Phases",
                c => new
                    {
                        phaseId = c.Int(nullable: false, identity: true),
                        phaseName = c.String(),
                        phaseTitle = c.String(),
                        phasePicture = c.String(),
                        phaseBacklog = c.String(),
                    })
                .PrimaryKey(t => t.phaseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Phases");
        }
    }
}
