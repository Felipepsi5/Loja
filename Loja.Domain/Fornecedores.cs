using System;

namespace Loja.Domain
{
    public class Fornecedores
    {
        public int Id { get; set; }
        public string NomeDaEmpresa { get; set; }
        public string NomeDoContato { get; set; }
        public string CargoDoContato { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string Pais { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro{get;set;}
        
    }
}