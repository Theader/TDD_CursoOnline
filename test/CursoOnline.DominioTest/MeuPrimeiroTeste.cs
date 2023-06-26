using System;
using Xunit;

namespace CursoOnline.DominioTest
{
    public class MeuPrimeiroTeste
    {
        [Fact(DisplayName = "Testar2")]
        public void Testar()
        {
            //Organização
            var v1 = 1;
            var v2 = 2;
            //Ação
            v1 = v2; 
            //Assert
            Assert.True(v1 == v2);
        }
    }
}
