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
            _output = output;
            _output.WriteLine("Construtor on");
            _nome = "Informática básica";
            _cargaHoraria = (int)80;
            _publicoAlvo = PublicoAlvo.Estudante;
            _valor = 950.00f;
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
                   => new Curso(nomeInvalido, _cargaHoraria, _publicoAlvo, _valor))
                   .ExceptionComMensagem("Nome precisa ser preenchido.");
        }

        [Fact]
        public void NaoPermitirCargaHorariaMenorQue1()
        {

            Assert.Throws<ArgumentException>(() 
                   => new Curso(_nome, 0, _publicoAlvo, _valor))
                   .ExceptionComMensagem("CargaHorária precisa ser maior que 0.");
        }
        [Fact]
        public void NaoPermitirValorMenorQue1()
        {
           Assert.Throws<ArgumentException>(() 
                 => new Curso(_nome, _cargaHoraria,_publicoAlvo, 0))
                .ExceptionComMensagem("Valor precisa ser maior que 0.");
        }

        public enum PublicoAlvo
        {
            Estudante, 
            Universitario, 
            Empregado,
            Empreendedor
        }
        public class Curso
        {
            public string Nome { get; private set; }
            public int CargaHoraria { get; private set; }
            public PublicoAlvo PublicoAlvo { get; private set; }
            public double Valor { get; private set; }

            public Curso(string nome, int cargaHoraria, PublicoAlvo publicoAlvo, double valor)
            {
                if (string.IsNullOrEmpty(nome))
                    throw new ArgumentException("Nome precisa ser preenchido.");
                if (cargaHoraria < 1)
                    throw new ArgumentException("CargaHorária precisa ser maior que 0.");
                if (valor < 1)
                    throw new ArgumentException("Valor precisa ser maior que 0.");

                this.Nome = nome;
                this.CargaHoraria = cargaHoraria;
                this.PublicoAlvo = publicoAlvo;
                this.Valor = valor;
            }
        }
    }
}
