
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
            var produtos = await _produtoService.ListaProdutos();
            return Ok(produtos);
        }
    }
}