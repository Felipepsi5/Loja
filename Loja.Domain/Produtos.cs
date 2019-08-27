using System;

namespace Loja.Domain
{
    public class Produtos
    {
        public int Id { get; set; }
        public string NomedoProduto { get; set; }
        public int? FornecedoresId { get; set; }
        public Fornecedores Fornecedores{get;}
        public int? CategoriasId { get; set; }
        public Categorias Categorias{get;}
        public int QuantidadePorUnidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int UnidadesEmEstoque { get; set; }
        public int UnidadesPedidas { get; set; }
        public byte Descontinuado { get; set; }
        public DateTime? DataCadastro { get; set; }

    }
}