﻿using CursoOnline.DAL.Contextos;
using CursoOnline.DAL.Repositorios;
using CursoOnline.Dominio.Alunos;
using System.Linq;

namespace CursoOnline.Dados.Repositorios
{
    public class AlunoRepositorio : RepositorioBase<Aluno>, IAlunoRepositorio
    {
        public AlunoRepositorio(ApplicationDbContext context) : base(context) { }
        public Aluno ObterPeloCpf(string cpf)
        {
            var alunos = Context.Set<Aluno>().Where(a => a.Cpf == cpf);
            return alunos.Any() ? alunos.First() : null;
        }
    }
}
