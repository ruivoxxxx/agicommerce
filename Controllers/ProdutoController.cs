
using agicommerce_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace agicommerce_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _produtoService;
        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProdutos()
        {
            return Ok(await this._produtoService.listar_produtos());
        }
         [HttpGet("{id}")]
        public async Task<IActionResult> GetProdutoById(Guid id)
        {
            return Ok(await this._produtoService.listar_produto_por_id(id));
        }
       
        [HttpPost]
        public async Task<IActionResult> PostProduto(Produto produto)
        {
            await this._produtoService.criar_produto(produto);
            return Ok("Produto criado com sucesso!");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(Guid id, Produto produto)
        {
            await this._produtoService.atualizar_produto(id, produto);
            return Ok("Atualizado com sucesso!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(Guid id)
        {   
            await this._produtoService.deletar_produto(id);
            return Ok("Deletado com sucesso!");  
        }
        
    
}
}