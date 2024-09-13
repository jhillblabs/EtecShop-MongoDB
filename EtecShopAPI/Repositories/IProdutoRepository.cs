using EtecShopAPI.Collections;

namespace EtecShopAPI.Repositories;

public interface IProdutoRepository
{
    Task<List<Produto>> GetAllAsync();
    Task<Produto> GetByIdAsync(string id);
    Task CreateAsync(Produto produto);
    Task UpdateAsync(Produto produto);
    Task DeleteAsync(string id);
}
