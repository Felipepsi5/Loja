using System;

namespace Loja.Domain
{
    public class Clientes
    {
        public int Id { get; set; } 
        public string Nome{ get; set; }
        public string Endereco { get; set; } 
        public string Cidade { get; set; } 
        public string CEP { get; set; }
        public string UF { get; set; } 
        public string Pais { get; set; } 
        public string Telefone { get; set; }  
        public DateTime DataCadastro{ get ;set; }      
    }
}