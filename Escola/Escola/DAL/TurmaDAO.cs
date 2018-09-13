using Escola.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.DAL
{
    public class TurmaDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static List<Turma> RetornarTurmas()
        {
            return ctx.Turmas.ToList();
        }

        public static bool CadastrarTurma(Turma turma)
        {
            if (BuscarTurmaPorNome(turma) == null)
            {
                ctx.Turmas.Add(turma);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static Turma BuscarTurmaPorNome(Turma turma)
        {
            return ctx.Turmas.FirstOrDefault
                (x => x.NomeTurma.Equals(turma.NomeTurma));
        }

        public static bool AlterarTurma(Turma turma)
        {
            Turma t = BuscarTurmaPorNome(turma);
            if (t != null && turma.NomeTurma == t.NomeTurma || t == null)
            {
                ctx.Entry(turma).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
