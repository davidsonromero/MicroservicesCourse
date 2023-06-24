using GeekShopping.CartAPI.Data.VOs;

namespace GeekShopping.CartAPI.Repository
{
    public interface ICartRepository
    {
        Task<CartVO> FindCartByUserId (string userId);
        Task<CartVO> SaveOrUpdateCart (CartVO vo);
        Task<bool> RemoveFromCart (long cartDetailsId);
        Task<bool> ApplyCupon (string userId, string cuponCode);
        Task<bool> RemoveCupon (string userId);
        Task<bool> ClearCart(string  userId);
    }
}
