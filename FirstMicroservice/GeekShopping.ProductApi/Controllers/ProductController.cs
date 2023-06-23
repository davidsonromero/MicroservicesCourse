using GeekShopping.ProductApi.Data.VOs;
using GeekShopping.ProductApi.Repository;
using GeekShopping.ProductApi.Ultils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            IEnumerable<ProductVO> products = await _repository.FindAll();
            return Ok(products);
        }

        [HttpGet("{Id}")]
        [Authorize]
        public async Task<ActionResult<ProductVO>> FindById(long Id)
        {
            ProductVO product = await _repository.FindById(Id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ProductVO>> Create([FromBody] ProductVO vo)
        {
            if(vo == null) return BadRequest();
            ProductVO product = await _repository.Create(vo);
            return Ok(product);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<ProductVO>> Update([FromBody] ProductVO vo)
        {
            if (vo == null) return BadRequest();
            ProductVO product = await _repository.Update(vo);
            return Ok(product);
        }

        [HttpDelete("{Id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult> Delete(long Id)
        {
            bool status = await _repository.Delete(Id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
