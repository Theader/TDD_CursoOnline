using CursoOnline.Dominio.Cursos;
using Moq;
using System;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class ArmazenadorDeCursoTest
    {
        [Fact]
        public void DeveAdicionarCurso()
        {
            var CursoDTO = new CursoDTO
            {
                Nome = "Curso a",
                CargaHoraria = 50,
                PublicoAlvoId = 1,
                Valor = (double)50.00,
                Descricao = "HUEBR"
            };
            var CursoRepositorioMock = new Mock<ICursoRepositorio>();
            var ArmazenadorDeCurso = new ArmazenadorDeCurso(CursoRepositorioMock.Object);
            ArmazenadorDeCurso.Armazenar(CursoDTO);
            CursoRepositorioMock.Verify(x => x.Adicionar(It.IsAny<Curso>()));
        }
        public class ArmazenadorDeCurso 
        {
            private readonly ICursoRepositorio CursoRepository;

            public ArmazenadorDeCurso(ICursoRepositorio _CursoRepository)
            {
                this.CursoRepository = _CursoRepository;
            }

            public void Armazenar(CursoDTO cursoDTO)
            {
                var curso =
                    new Curso(cursoDTO.Nome, cursoDTO.Descricao, cursoDTO.CargaHoraria
                             ,PublicoAlvo.Estudante, cursoDTO.Valor);
                CursoRepository.Adicionar(curso);
            }
        }
        public interface ICursoRepositorio
        {
            void Adicionar(Curso curso);
        }
        public class CursoDTO
        {
            public string Nome { get; internal set; }
            public int CargaHoraria { get; internal set; }
            public int PublicoAlvoId { get; internal set; }
            public double Valor { get; internal set; }
            public string Descricao { get; internal set; }
        }
    }
}
