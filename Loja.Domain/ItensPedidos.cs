using System;

namespace Loja.Domain
{
    public class ItensPedidos
    {
        public int Id { get; set; }
        public int? ProdutosId { get; set; }
        public Pedidos Pedidos{ get; set;}
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
        public int Desconto { get; set; }    
        public DateTime DataCadastro { get; set; }    
    }
}