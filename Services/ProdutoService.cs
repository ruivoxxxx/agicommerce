
using Microsoft.EntityFrameworkCore;

namespace agicommerce_api.Services
{
    public class ProdutoService
    {
        private readonly AppDbContext _database;
        public ProdutoService(AppDbContext database)
        {
            _database = database;
        }
        public async Task<List<Produto>> listar_produtos(
        string? categoria,
        string? ordenar,
        string? nome)
{
    var query = _database.Produtos.AsQueryable();

    
    if (!string.IsNullOrEmpty(categoria))
    {
        query = query.Where(p => p.Categoria == categoria);
    }

    
    if (!string.IsNullOrEmpty(ordenar))
    {
        if (ordenar == "recentes")
            query = query.OrderByDescending(p => p.DataCadastro);

        if (ordenar == "antigos")
            query = query.OrderBy(p => p.DataCadastro);
    }
    if(!string.IsNullOrEmpty(nome))
    {
        query = query.Where(p => p.Nome.Contains(nome));
    }

    return await query.ToListAsync();
}

        
        public async Task<Produto> listar_produto_por_id(Guid id)
        {
            var produto = await _database.Produtos.FirstOrDefaultAsync(p => p.Id == id);
            if (produto == null)
            {
                throw new  KeyNotFoundException("Produto não encontrado!");
            }
            return produto;
        }
        public async Task<Produto> criar_produto(Produto produto)
        {
            _database.Produtos.Add(produto);
            await _database.SaveChangesAsync();
            return produto;
        }
         public async Task<Produto> atualizar_produto(Guid id, Produto produtoAtualizado)
        {
            var produto = await _database.Produtos.FirstOrDefaultAsync(p => p.Id == id);
            if (produto == null)
            {
                throw new KeyNotFoundException("Produto não encontrado!");
            }
            produto.Nome = produtoAtualizado.Nome;
            produto.Descricao = produtoAtualizado.Descricao;
            produto.Preco = produtoAtualizado.Preco;
            await _database.SaveChangesAsync();
            return produto;
        }
        public async Task<bool> deletar_produto(Guid id)
        {
            var produto = await _database.Produtos.FirstOrDefaultAsync(p => p.Id == id);
            if (produto == null)
            {
                throw new KeyNotFoundException("Produto não encontrado!");
            }
            _database.Produtos.Remove(produto);
            await _database.SaveChangesAsync();
            return true;
        }
       
        
    }
}