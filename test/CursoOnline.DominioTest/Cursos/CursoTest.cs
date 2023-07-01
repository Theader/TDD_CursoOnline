using Bogus;
using CursoOnline.Dominio.Cursos;
using CursoOnline.DominioTest._Builders;
using CursoOnline.DominioTest._Util;
using ExpectedObjects;
using System;
using Xunit;
using Xunit.Abstractions;

namespace CursoOnline.DominioTest.Cursos
{
    public class CursoTest : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly string _nome;
        private readonly int _cargaHoraria;
        private readonly PublicoAlvo _publicoAlvo;
        private readonly double _valor;

        public CursoTest(ITestOutputHelper output)
        {
            var faker = new Faker();

            _output = output;
            _output.WriteLine("Construtor on");
            _nome = faker.Random.Word();
            _cargaHoraria = faker.Random.Int(50,100);
            _publicoAlvo = PublicoAlvo.Estudante;
            _valor = faker.Random.Double(100, 1000);

            _output.WriteLine($"Double :, { faker.Random.Double(1,100)}");
            _output.WriteLine($"Cpmpany :, {faker.Company.CompanyName()}");
            _output.WriteLine($"Email :, {faker.Person.Email}");

        }
        public void Dispose()
        {
            _output.WriteLine("Dispose sendo executado");
        }

        [Fact]
        public void CriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = _nome,
                CargaHoraria = _cargaHoraria,
                PublicoAlvo = _publicoAlvo,
                Valor = _valor
            };

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoPermitirNomeInvalido(string nomeInvalido)
        {
            Assert.Throws<ArgumentException>(()
                   => CursoBuilder.Novo().ComNome(nomeInvalido)
                   .Build())
                .ExceptionComMensagem("Nome precisa ser preenchido.");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-23)]
        public void NaoPermitirCargaHorariaMenorQue1(int pCargaHorariaInvalida)
        {

            Assert.Throws<ArgumentException>(()
                   => CursoBuilder.Novo().ComCargaHoraria(pCargaHorariaInvalida)
                   .Build())
                 .ExceptionComMensagem("CargaHorária precisa ser maior que 0.") ;
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void NaoPermitirValorMenorQue1(double pValorInvalido)
        {
            Assert.Throws<ArgumentException>(()
                  => CursoBuilder.Novo().ComValor(pValorInvalido)
                  .Build())
                .ExceptionComMensagem("Valor precisa ser maior que 0.");
        }
    }
}
