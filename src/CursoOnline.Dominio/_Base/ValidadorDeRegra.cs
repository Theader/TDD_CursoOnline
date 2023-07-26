using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CursoOnline.Dominio._Base
{
    public class ValidadorDeRegra
    {
        private List<string> _mensagensDeErros;

        private ValidadorDeRegra() 
        {
            _mensagensDeErros = new List<string>();
        }
        public static ValidadorDeRegra Novo()
        {
            return new ValidadorDeRegra();
        }
        public ValidadorDeRegra Quando(bool temErro, string mensagemDeErro)
        {
            if (temErro)
            {
                _mensagensDeErros.Add(mensagemDeErro);
            }
            return this;
        }
        public void DispararExcecaoSeExistir()
        {
            if (_mensagensDeErros.Any())
                throw new ExcecaoDeDominio(_mensagensDeErros);
        }
    }
    public class ExcecaoDeDominio : ArgumentException
    {
        public List<string> MensagensDeErros { get; set; }

        public ExcecaoDeDominio(List<string> mensagensDeErros)
        {
            MensagensDeErros = mensagensDeErros;
        }

    }
}
