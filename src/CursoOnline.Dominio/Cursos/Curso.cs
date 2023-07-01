using System;

namespace CursoOnline.Dominio.Cursos
{
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
    public enum PublicoAlvo
    {
        Estudante,
        Universitario,
        Empregado,
        Empreendedor
    }
}
