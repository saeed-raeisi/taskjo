namespace taskjo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmodels : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.group_tbl", newName: "Teams");
            RenameTable(name: "dbo.project_tbl", newName: "Projects");
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
            RenameTable(name: "dbo.Projects", newName: "project_tbl");
            RenameTable(name: "dbo.Teams", newName: "group_tbl");
        }
    }
}
