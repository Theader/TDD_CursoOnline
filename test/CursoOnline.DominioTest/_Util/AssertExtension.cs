using CursoOnline.Dominio._Base;
using System;
using Xunit;

namespace CursoOnline.DominioTest._Util
{
    public static class AssertExtension
    {
        public static void ExceptionComMensagem(this ExcecaoDeDominio exception, string mensagem)
        {
            if (exception.MensagensDeErros.Contains(mensagem))
                Assert.True(true);
            else
                Assert.False(true, $"Esperava a mensagem: '{mensagem}'");
        }
    }
}
