using GeekShopping.CartAPI.Data.VOs;
using GeekShopping.CartAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.CartAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController : ControllerBase
    {
        private ICartRepository _repository;

        public CartController(ICartRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("find-cart/{id}")]
        public async Task<ActionResult<CartVO>> FindCart(string userId) 
        {
            CartVO cart = await _repository.FindCartByUserId(userId);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPost("add-cart")]
        public async Task<ActionResult<CartVO>> AddCart([FromBody] CartVO vo)
        {
            CartVO result = await _repository.SaveOrUpdateCart(vo);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut("update-cart")]
        public async Task<ActionResult<CartVO>> UpdateCart([FromBody] CartVO vo)
        {
            CartVO result = await _repository.SaveOrUpdateCart(vo);
            if (result == null) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("remove-cart/{id}")]
        public async Task<ActionResult<CartVO>> RemoveCart(long id)
        {
            bool result = await _repository.RemoveFromCart(id);
            if (!result) return BadRequest();
            return Ok(result);
        }
    }
}
