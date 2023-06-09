﻿using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/product";

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<ProductModel> CreateProduct(ProductModel model)
        {
            HttpResponseMessage response = await _client.PostAsJson(BasePath, model);
            if(response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductModel>();
            throw new Exception("Something went wrong while calling API");
        }

        public async Task<bool> DeleteProductById(long Id)
        {
            HttpResponseMessage response = await _client.DeleteAsync(BasePath + $"/{Id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            throw new Exception("Something went wrong while calling API");
        }

        public async Task<IEnumerable<ProductModel>> FindAllProducts()
        {
            HttpResponseMessage response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> FindProductById(long Id)
        {
            HttpResponseMessage  response = await _client.GetAsync(BasePath + $"/{Id}");
            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<ProductModel> UpdateProduct(ProductModel model)
        {
            HttpResponseMessage response = await _client.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductModel>();
            throw new Exception("Something went wrong while calling API");
        }
    }
}
