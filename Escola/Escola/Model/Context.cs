using Escola.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.DAL
{
    public class Context : DbContext
    {
        public Context() : base("DbEscolaWPF") { }
        public DbSet<Aluno> Alunos  { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Turma> Turmas { get; set; }
    }
}
