
namespace GeekShopping.CartAPI.Data.VOs
{
    public class CartDetailVO
    {
        public long Id { get; set; }
        public long CartHeaderId { get; set; }
        public CartHeaderVO? CartHeader { get; set; }
        public long ProductId { get; set; }
        public ProductVO? Product { get; set; }
        public long? Count { get; set; }
    }
}
