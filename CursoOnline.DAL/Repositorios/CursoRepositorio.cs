using CursoOnline.DAL.Contextos;
using CursoOnline.DAL.Repositorios;
using CursoOnline.Dominio.Cursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CursoOnline.Dados.Repositorios
{
    public class CursoRepositorio : RepositorioBase<Curso>, ICursoRepositorio
    {
        public CursoRepositorio(ApplicationDbContext context) : base(context) { }

        public Curso ObterPeloNome(string nome)
        {
            var entidade = Context.Set<Curso>().Where(c => c.Nome.Contains(nome));
            if (entidade.Any())
            {
                return entidade.First();
            }
            return null;
        }
    }
}
