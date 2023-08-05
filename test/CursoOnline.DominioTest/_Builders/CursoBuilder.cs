using CursoOnline.Dominio.Cursos;
using System;

namespace CursoOnline.DominioTest._Builders
{
    public class CursoBuilder
    {
        private int _id;
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
            var curso = new Curso(_nome, _descricao, _cargaHoraria, _publicoAlvo, _valor);
            if(_id > 0)
            {
                var propertyInfo = curso.GetType().GetProperty("Id");
                propertyInfo.SetValue(curso, Convert.ChangeType(_id, propertyInfo.PropertyType), null);
            }

            return curso;   
        }
        public CursoBuilder ComId(int id)
        {
            _id = id;
            return this;
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
