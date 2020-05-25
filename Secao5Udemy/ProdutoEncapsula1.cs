namespace Secao5Udemy
{
    class ProdutoEncapsula1
    {
        //Primeira forma
        
        private string _nome;
        private int _quantidade;
        private double _preco;

        public string GetNome()
        {
            return _nome;
        }

        public void SetNome(string nome)
        {
            if (_nome != null && _nome.Length > 1)
            {
                _nome = nome;
            }
        }
    }
}
