using Escola.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.DAL
{
    public class ProfessorDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static bool CadastrarProfessor(Professor professor)
        {
            if (BuscarProfessorPorCPF(professor) == null)
            {
                ctx.Professores.Add(professor);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static Professor BuscarProfessorPorCPF(Professor professor)
        {
            return ctx.Professores.FirstOrDefault
                (x => x.CPF.Equals(professor.CPF));
        }

        public static void RemoverProfessor(Professor professor)
        {
            ctx.Professores.Remove(professor);
            ctx.SaveChanges();
        }

        public static bool AlterarProfessor(Professor professor)
        {
            Professor p = BuscarProfessorPorCPF(professor);
            if (p != null && professor.CPF == p.CPF || p == null)
            {
                ctx.Entry(professor).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static List<Professor> RetornaProfessor()
        {
            return ctx.Professores.ToList();
        }
    }
}
