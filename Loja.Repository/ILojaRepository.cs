using System.Threading.Tasks;
using Loja.Domain;

namespace Loja.Repository
{
    public interface ILojaRepository
    {
    //Geral
    void Add<T>(T entity) where T : class;
    void Update<T>(T entity) where T: class;
    void Delete<T>(T entity) where T : class;
    Task<bool>SaveChangesAsync();    
    Task<Clientes[]>GetAllClientesAsync();
    Task<Clientes>GetClientesAsyncById(int ClientesId);
    Task<Categorias[]>GetAllCategoriasAsync();
    Task<Categorias>GetCategoriasAsyncById(int CategoriasId);
    Task<Fornecedores[]>GetAllFornecedoresAsync();
    Task<Fornecedores>GetFornecedoresAsyncById(int FornecedoresId);
    Task<ItensPedidos[]>GetAllItensPedidosAsync();
    Task<ItensPedidos>GetItensPedidosAsyncById(int PedidosId);
    Task<Produtos[]>GetAllProdutosAsync();
    Task<Produtos>GetProdutosAsyncById(int ProdutosId);
    Task<Pedidos[]>GetAllPedidosAsync();
    Task<Pedidos>GetPedidosAsyncById(int PedidosId);
    
    }
}