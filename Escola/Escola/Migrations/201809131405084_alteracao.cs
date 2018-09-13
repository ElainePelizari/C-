namespace Escola.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteracao : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Turmas", "Professor_Id", "dbo.Professors");
            DropIndex("dbo.Turmas", new[] { "Professor_Id" });
            AddColumn("dbo.Turmas", "IdProfessor", c => c.Int(nullable: false));
            DropColumn("dbo.Turmas", "Professor_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Turmas", "Professor_Id", c => c.Int());
            DropColumn("dbo.Turmas", "IdProfessor");
            CreateIndex("dbo.Turmas", "Professor_Id");
            AddForeignKey("dbo.Turmas", "Professor_Id", "dbo.Professors", "Id");
        }
    }
}
