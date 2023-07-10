using Bogus;
using CursoOnline.Dominio.Cursos;
using Moq;
using System;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class ArmazenadorDeCursoTest
    {
        private readonly CursoDTO _cursoDTO;
        private readonly Mock<ICursoRepositorio> _cursoRepositorioMock;
        private readonly ArmazenadorDeCurso _armazenadorDeCurso;

        public ArmazenadorDeCursoTest()
        {
            var fake = new Faker();
            _cursoDTO = new CursoDTO
            {
                Nome = fake.Random.Word(),
                CargaHoraria = fake.Random.Int(20),
                PublicoAlvoId =(int)PublicoAlvo.Estudante,
                Valor = fake.Random.Double(20,100),
                Descricao = fake.Lorem.Word()
            };
             _cursoRepositorioMock = new Mock<ICursoRepositorio>();
             _armazenadorDeCurso = new ArmazenadorDeCurso(_cursoRepositorioMock.Object);

        }
        [Fact]
        public void DeveAdicionarCurso()
        {
            
            _armazenadorDeCurso.Armazenar(_cursoDTO);
            _cursoRepositorioMock.Verify(x => x.Adicionar(It.Is<Curso>
                (c => c.Nome == _cursoDTO.Nome
                && c.Descricao == _cursoDTO.Descricao
                //&& c.PublicoAlvo == PublicoAlvo.Estudante
                //&& c.CargaHoraria == CursoDTO.CargaHoraria
                //&& c.Valor == CursoDTO.Valor
                )),Times.AtLeast(1));
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
