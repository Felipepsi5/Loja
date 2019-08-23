using System;

namespace Loja.Domain
{
    public class Categorias
    {
        public int Id { get; set; }
        public string NomeDaCategoria { get; set; }
        public string Descricao { get; set; }
        public string Figura{ get; set; }
        public DateTime DataCadastro{get;set;} 
    }
}