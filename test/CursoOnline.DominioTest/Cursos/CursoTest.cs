using Bogus;
using CursoOnline.Dominio._Base;
using CursoOnline.Dominio.Cursos;
using CursoOnline.Dominio.PublicosAlvo;
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
        private readonly Faker faker;
        private readonly ITestOutputHelper _output;
        private readonly string _nome;
        private readonly string _descricao;
        private readonly int _cargaHoraria;
        private readonly PublicoAlvo _publicoAlvo;
        private readonly double _valor;

        public CursoTest(ITestOutputHelper output)
        {
            faker = new Faker();

            _output = output;
            _output.WriteLine("Construtor on");
            _nome = faker.Random.Word();
            _descricao = faker.Random.Word();
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
                Valor = _valor,
                Descricao = _descricao
            };

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.Descricao, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoPermitirNomeInvalido(string nomeInvalido)
        {
            Assert.Throws<ExcecaoDeDominio>(()
                   => CursoBuilder.Novo().ComNome(nomeInvalido)
                   .Build())
                .ExceptionComMensagem(Resource.NomeInvalido);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoPermitirDescricaoInvalida(string descricaoInvalido)
        {
            Assert.Throws<ExcecaoDeDominio>(()
                   => CursoBuilder.Novo().ComDescricao(descricaoInvalido)
                   .Build())
                .ExceptionComMensagem(Resource.DescricaoInvalida);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-23)]
        public void NaoPermitirCargaHorariaMenorQue1(int pCargaHorariaInvalida)
        {

            Assert.Throws<ExcecaoDeDominio>(()
                   => CursoBuilder.Novo().ComCargaHoraria(pCargaHorariaInvalida)
                   .Build())
                 .ExceptionComMensagem(Resource.CargaHorariaInvalida) ;
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void NaoPermitirValorMenorQue1(double pValorInvalido)
        {
            Assert.Throws<ExcecaoDeDominio>(()
                  => CursoBuilder.Novo().ComValor(pValorInvalido)
                  .Build())
                .ExceptionComMensagem(Resource.ValorInvalido);
        }
        [Fact]
        public void DeveAlterarNome()
        {
            var nomeEsperado = faker.Name.FullName();
            var curso = CursoBuilder.Novo().Build();

            curso.AlterarNome(nomeEsperado);
            Assert.Equal(nomeEsperado, curso.Nome);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoAlterarComNomeInvalido(string nomeInvalido)
        {
            var curso = CursoBuilder.Novo().Build();

            Assert.Throws<ExcecaoDeDominio>(()
                   => curso.AlterarNome(nomeInvalido))
                .ExceptionComMensagem(Resource.NomeInvalido);
        }
        [Fact]
        public void DeveAlterarCargaHoraria()
        {
            var cargaHorariaEsperada = faker.Random.Int(20,10000);
            var curso = CursoBuilder.Novo().Build();

            curso.AlterarCargaHoraria(cargaHorariaEsperada);
            Assert.Equal(cargaHorariaEsperada, curso.CargaHoraria);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-23)]
        public void NaoDeveAlterarComCargaHorariaInvalida(int pCargaHorariaInvalida)
        {
            var curso = CursoBuilder.Novo().Build();
            Assert.Throws<ExcecaoDeDominio>(()
                   => curso.AlterarCargaHoraria(pCargaHorariaInvalida))
                 .ExceptionComMensagem(Resource.CargaHorariaInvalida);
        }
        [Fact]
        public void DeveAlterarValor()
        {
            var valorEsperado = faker.Random.Double(10,10000);

            var curso = CursoBuilder.Novo().Build();

            curso.AlterarValor(valorEsperado);

            Assert.Equal(valorEsperado, curso.Valor);

        }
        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void NaoDeveAlterarComValorInvalido(double pValorInvalido)
        {
            var curso = CursoBuilder.Novo().Build();

            Assert.Throws<ExcecaoDeDominio>(()
                  => curso.AlterarValor(pValorInvalido))
                .ExceptionComMensagem(Resource.ValorInvalido);
        }
    }
}
