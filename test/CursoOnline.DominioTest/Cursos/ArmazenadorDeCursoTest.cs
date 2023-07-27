using Bogus;
using CursoOnline.Dominio._Base;
using CursoOnline.Dominio.Cursos;
using CursoOnline.DominioTest._Builders;
using CursoOnline.DominioTest._Util;
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
                PublicoAlvo = "Estudante",
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
        [Fact]
        public void NaoDeveAdicionarComPublicoAlvoInvalido()
        {
            _cursoDTO.PublicoAlvo = "Medico";
            Assert.Throws<ExcecaoDeDominio>(() => _armazenadorDeCurso.Armazenar(_cursoDTO))
                .ExceptionComMensagem("Publico Alvo Inválido!");
        }
        [Fact]
        public void NaoDeveAdicionarCursoComNomeJaExistente()
        {
            var cursoJaSalvo = CursoBuilder.Novo().ComNome(_cursoDTO.Nome).Build();
            _cursoRepositorioMock.Setup(x => x.ObterPeloNome(_cursoDTO.Nome)).Returns(cursoJaSalvo);

            Assert.Throws<ExcecaoDeDominio>(() => _armazenadorDeCurso.Armazenar(_cursoDTO))
            .ExceptionComMensagem("Nome do Curso já existe na base!");
        }

    }
}
