using System;
using System.Collections.Generic;
using System.Text;

namespace CursoOnline.Dominio.Matriculas
{
    public class MatriculaParaListagemDto
    {
        public int Id { get; set; }
        public string NomeDoAluno { get; set; }
        public string NomeDoCurso { get; set; }
        public double Valor { get; set; }
    }
}
