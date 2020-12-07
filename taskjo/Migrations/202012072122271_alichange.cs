namespace taskjo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alichange : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.group_tbl", newName: "Teams");
            RenameTable(name: "dbo.project_tbl", newName: "Projects");
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
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        skillId = c.Int(nullable: false, identity: true),
                        SkillName = c.Int(nullable: false),
                        SkillDesc = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.skillId);
            
            CreateTable(
                "dbo.TeamRules",
                c => new
                    {
                        ruleId = c.Int(nullable: false, identity: true),
                        ruleName = c.String(),
                    })
                .PrimaryKey(t => t.ruleId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TeamRules");
            DropTable("dbo.Skills");
            DropTable("dbo.Phases");
            RenameTable(name: "dbo.Projects", newName: "project_tbl");
            RenameTable(name: "dbo.Teams", newName: "group_tbl");
        }
    }
}
