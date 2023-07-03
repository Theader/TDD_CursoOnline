using System;
using System.Collections.Generic;
using System.Text;
using static CursoOnline.DominioTest.Cursos.CursoTest;
using Xunit.Abstractions;
using CursoOnline.Dominio.Cursos;

namespace CursoOnline.DominioTest._Builders
{
    public class CursoBuilder
    {
        private string _nome = "Informática básica";
        private int _cargaHoraria = (int)80;
        private PublicoAlvo _publicoAlvo = PublicoAlvo.Estudante;
        private double _valor = 950.00f;
        private string _descricao = "huebr";

        public static CursoBuilder Novo()
        {
            return new CursoBuilder();
        }
        public Curso Build()
        {
            return new Curso(_nome, _descricao, _cargaHoraria, _publicoAlvo, _valor);
        }
        public CursoBuilder ComNome(string pNome)
        {
            _nome = pNome;
            return this;
        }
        public CursoBuilder ComDescricao(string pDescricao)
        {
            _descricao = pDescricao;
            return this;
        }
        public CursoBuilder ComCargaHoraria(int pCargaHoraria)
        {
            _cargaHoraria = pCargaHoraria;
            return this;
        }
        public CursoBuilder ComValor(double pValor)
        {
            _valor = pValor;
            return this;
        }
        public CursoBuilder ComPublicoAlvo(PublicoAlvo pPublicoAlvo)
        {
            _publicoAlvo = pPublicoAlvo;
            return this;
        }

    }
}
