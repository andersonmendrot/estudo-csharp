namespace Secao5Udemy
{
    class ProdutoOrdemRecomendada
    {
        //1. Atributos privados
        private string _nome;
        //2. Propriedades autoimplementadas
        public string Quantidade { get; set; }
        //3. Construtores
        public ProdutoOrdemRecomendada(string quantidade)
        {
            Quantidade = quantidade;
        }
        //4. Propriedades customizadas
        public string Nome
        {
            get { return _nome; }
            set
            {
                if (value != null && value.Length > 1)
                {
                    Nome = value;
                }
            }
        }
        //5. Outros métodos da classe
        public override string ToString()
        {
            return $"{Nome}, {Quantidade}";
        }
    }
}
