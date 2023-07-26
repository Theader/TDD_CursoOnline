using CursoOnline.Dominio._Base;
using System;

namespace CursoOnline.Dominio.Cursos
{
    public class Curso : Entidade
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public int CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double Valor { get; private set; }

        private Curso(){}
        public Curso(string nome,string descricao, int cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            ValidadorDeRegra.Novo()
                .Quando(string.IsNullOrEmpty(nome), "Nome precisa ser preenchido.")
                .Quando(string.IsNullOrEmpty(descricao), "Descrição precisa ser preenchida.")
                .Quando(cargaHoraria < 1, "CargaHorária precisa ser maior que 0.")
                .Quando(valor < 1, "Valor precisa ser maior que 0.")
                .DispararExcecaoSeExistir();

            this.Nome = nome;
            this.CargaHoraria = cargaHoraria;
            this.PublicoAlvo = publicoAlvo;
            this.Valor = valor;
            this.Descricao = descricao;
        }
    }
    public enum PublicoAlvo
    {
        Estudante,
        Universitario,
        Empregado,
        Empreendedor
    }
}
