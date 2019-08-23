using Loja.Domain;
using Microsoft.EntityFrameworkCore;

namespace Loja.Repository
{
    public class LojaContext : DbContext
    {
       public LojaContext(DbContextOptions<LojaContext> options): base(options){}
       public DbSet<Produtos> Produtos {get;set;}
       public DbSet<Clientes> Clientes {get;set;}
       public DbSet<Fornecedores> Fornecedores {get;set;}
       public DbSet<ItensPedidos> ItensPedidos {get;set;}
       public DbSet<Pedidos> Pedidos {get;set;}
       public DbSet<Categorias> Categorias{get;set;}     
       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
            modelBuilder.Entity<Produtos>().HasKey(PT => new {PT.FornecedoresId, PT.CategoriasId});
            modelBuilder.Entity<ItensPedidos>().HasKey(I => new {I.ProdutosId});
            modelBuilder.Entity<Pedidos>().HasKey(PD => new {PD.ClientesId});     
       }           
    }
}