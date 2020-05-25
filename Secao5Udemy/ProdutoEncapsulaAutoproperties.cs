using System;
using System.Collections.Generic;
namespace Secao5Udemy
{
    class ProdutoEncapsulaAutoproperties
    {
        //Propriedades autoimplementadas
        //Forma simplificada de se declarar propriedades que não necessitam de lógicas particulares de get e set
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
    }
}
