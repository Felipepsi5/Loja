using System;

namespace Loja.Domain
{
    public class Pedidos
    {
        public int Id { get; set; }
        public int? ClientesId{get;set;}
        public Clientes Clientes{get;}
        public DateTime? DataDoPedido { get; set; }
        public DateTime? DataDeEntrega{get;set;}
        public DateTime? DataDeEnvio { get; set; }
        public decimal Frete { get; set; }
        public string NomeDestinatario { get; set; }
        public string EnderecoDestinatario { get; set; }
        public string CidadeDeDestino { get; set; }
        public string CEPdeDestino { get; set; }
        public string PaisdeDestino { get; set; }
    }
}