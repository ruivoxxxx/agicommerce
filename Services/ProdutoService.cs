using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<List<Produto>> listar_produtos()
        {
            return await _database.Produtos.ToListAsync();
        }
        
        public async Task<Produto> criar_produto(Produto produto)
        {
            _database.Produtos.Add(produto);
            await _database.SaveChangesAsync();
            return produto;
        }
    }
}