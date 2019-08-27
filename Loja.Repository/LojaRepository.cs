using System.Linq;
using System.Threading.Tasks;
using Loja.Domain;
using Microsoft.EntityFrameworkCore;

namespace Loja.Repository
{
    public class LojaRepository : ILojaRepository
    {
        private readonly LojaContext _context;

        public LojaRepository(LojaContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

         //Categorias
        public async Task<Categorias[]> GetAllCategoriasAsync()
        {
           IQueryable<Categorias> query = _context.Categorias;
          
           query = query.AsNoTracking()
                        .OrderByDescending(x=>x.DataCadastro);

           return await query.ToArrayAsync();

        }
        public async Task<Categorias> GetCategoriasAsyncById(int CategoriasId)
        {
           IQueryable<Categorias> query = _context.Categorias;
          
           query = query.AsNoTracking()
                        .OrderByDescending(x=>x.DataCadastro)
           .Where(x=>x.Id == CategoriasId);

           return await query.FirstOrDefaultAsync();
        }
         //Clientes      
        public async Task<Clientes[]> GetAllClientesAsync()
        {
            IQueryable<Clientes> query = _context.Clientes;

             query = query.AsNoTracking()
                          .OrderByDescending(x=>x.DataCadastro);
            return await query.ToArrayAsync();
        }
        public async Task<Clientes> GetClientesAsyncById(int ClientesId)
        {
             IQueryable<Clientes> query = _context.Clientes;

             query = query.AsNoTracking()
                     .OrderByDescending(x=>x.DataCadastro)
                     .Where(x=>x.Id == ClientesId);
            return await query.FirstOrDefaultAsync();

        }
        //Fornecedores
        public async Task<Fornecedores[]> GetAllFornecedoresAsync()
        {
            IQueryable<Fornecedores> query = _context.Fornecedores;

            query = query.AsNoTracking()
                         .OrderByDescending(x=>x.DataCadastro);

            return await query.ToArrayAsync();
        }
        public async Task<Fornecedores> GetFornecedoresAsyncById(int FornecedoresId)
        {
            IQueryable<Fornecedores> query = _context.Fornecedores;

            query = query.AsNoTracking()
                         .OrderByDescending(x=>x.DataCadastro)
                         .Where(x=>x.Id == FornecedoresId);

            return await query.FirstOrDefaultAsync();
             
        }
        //Itens Pedidos
        public async Task<ItensPedidos[]> GetAllItensPedidosAsync()
        {
           IQueryable<ItensPedidos> query = _context.ItensPedidos
           .Include(i=>i.Pedidos);

            query = query.AsNoTracking()
                         .OrderByDescending(x=>x.DataCadastro);

            return await query.ToArrayAsync();
        }
        public async Task<ItensPedidos> GetItensPedidosAsyncById(int PedidosId)
        {
           IQueryable<ItensPedidos> query = _context.ItensPedidos
           .Include(i=>i.Pedidos);

            query = query.AsNoTracking()
                         .OrderByDescending(x=>x.DataCadastro)
                   .Where(x=>x.Id == PedidosId);

            return await query.FirstOrDefaultAsync();
        }
        //Pedidos       
        public async Task<Pedidos[]> GetAllPedidosAsync()
        {
            IQueryable<Pedidos> query = _context.Pedidos
            .Include(p=>p.Clientes);

            query = query.AsNoTracking()
                         .OrderByDescending(x=>x.DataDoPedido);

            return await query.ToArrayAsync();
        }
        public async Task<Pedidos> GetPedidosAsyncById(int PedidosId)
        {
            IQueryable<Pedidos> query = _context.Pedidos
            .Include(p=>p.Clientes);

            query = query.AsNoTracking()
                         .OrderByDescending(x=>x.DataDoPedido)
            .Where(x=>x.Id == PedidosId);

            return await query.FirstOrDefaultAsync();
        }
        //Produtos
        public async Task<Produtos[]> GetAllProdutosAsync()
        {
             IQueryable<Produtos> query = _context.Produtos
             .Include(p=>p.Categorias)
             .Include(p=>p.Fornecedores);
           
             query = query.AsNoTracking()
                          .OrderByDescending(c=>c.DataCadastro);

             return await query.ToArrayAsync();
        }
        public async Task<Produtos> GetProdutosAsyncById(int ProdutosId)
        {
             IQueryable<Produtos> query = _context.Produtos
             .Include(p=>p.Categorias)
             .Include(p=>p.Fornecedores);
           
             query = query.AsNoTracking()
                          .OrderByDescending(c=>c.DataCadastro)
             .Where(c=>c.Id == ProdutosId);

             return await query.FirstOrDefaultAsync();
        }
      
    }
}