
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
        public async Task<IActionResult> CriarProduto(Produto produto)
        {

            return Ok(await this._produtoService.criar_produto(produto));
        }
        
        
    
}
}