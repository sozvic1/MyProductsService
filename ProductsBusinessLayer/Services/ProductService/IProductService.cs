﻿using ProductsBusinessLayer.DTOs;
using ProductsCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsBusinessLayer.Services.ProductService
{
    public interface IProductService
    {
        Task<Guid> CreateProduct(ProductDTO productDTO);
        Task<Product> DeleteProductById(Guid id);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(Guid id);
        Task<Product> UpdateProduct(Guid id, ProductDTO productDTO);
    }
}