namespace Secao5Udemy
{
    class ProdutoEncapsulaProperties
    {
        //Propriedades implementadas

        private string _nome;
        private int _quantidade;
        private double _valor;

        //a palavra reservada value representa o parâmetro de entrada do método set
        public string Nome
        {
            get { return _nome; }
            set
            {
                if (value != null && value.Length > 1)
                    _nome = value;
            }

        }
    }
}
