using Escola.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.DAL
{
    public class AlunoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static bool CadastrarAluno(Aluno aluno)
        {
            if (BuscarAlunoPorCPF(aluno) == null)
            {
                ctx.Alunos.Add(aluno);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static Aluno BuscarAlunoPorCPF(Aluno aluno)
        {
            return ctx.Alunos.FirstOrDefault
                (x => x.CPF.Equals(aluno.Nome));
        }

        public static void RemoverAluno(Aluno aluno)
        {
            ctx.Alunos.Remove(aluno);
            ctx.SaveChanges();
        }

        public static bool AlterarAluno(Aluno aluno)
        {
            Aluno a = BuscarAlunoPorCPF(aluno);
            if (a != null && aluno.CPF == a.CPF || a == null)
            {
                ctx.Entry(aluno).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
            
        public static List<Aluno> RetornarAlunos()
        {
            return ctx.Alunos.ToList();
        }

            

    }

}
