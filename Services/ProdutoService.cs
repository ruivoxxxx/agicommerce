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
        public async Task<List<Produto>> ListaProdutos()
        {
            return await _database.Produtos.ToListAsync();
        }
    }
}