namespace Escola.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IniciaBanco : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Alunoes", "Turma_Id", "dbo.Turmas");
            DropIndex("dbo.Alunoes", new[] { "Turma_Id" });
            AddColumn("dbo.Alunoes", "IdTurma", c => c.Int(nullable: false));
            AddColumn("dbo.Turmas", "NomeTurma", c => c.String());
            DropColumn("dbo.Alunoes", "Turma_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Alunoes", "Turma_Id", c => c.Int());
            DropColumn("dbo.Turmas", "NomeTurma");
            DropColumn("dbo.Alunoes", "IdTurma");
            CreateIndex("dbo.Alunoes", "Turma_Id");
            AddForeignKey("dbo.Alunoes", "Turma_Id", "dbo.Turmas", "Id");
        }
    }
}
