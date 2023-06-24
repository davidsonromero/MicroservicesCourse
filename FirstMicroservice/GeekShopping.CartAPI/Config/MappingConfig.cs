using AutoMapper;
using GeekShopping.CartAPI.Data.VOs;
using GeekShopping.CartAPI.Model;

namespace GeekShopping.CartAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            MapperConfiguration mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<CartDetailVO, CartDetail>().ReverseMap();
                config.CreateMap<CartHeader, CartHeaderVO>().ReverseMap();
                config.CreateMap<ProductVO, Product>().ReverseMap();
                config.CreateMap<Cart, CartVO>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
