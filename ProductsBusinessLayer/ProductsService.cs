﻿using AutoMapper;
using ProductsBusinessLayer.DTOs;
using ProductsCore.Models;
using ProductsDataLayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsBusinessLayer
{
    public class ProductsService : IProductsService
    {
        private readonly  IProductsReposirory _productsRepository;
        private readonly IMapper _mapper;
        public ProductsService(IProductsReposirory productsRepository,IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
            
        }
        
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
           
            return await _productsRepository.GetAll();
        }

        public async Task<Product> GetProductById(Guid id)
        {
            await Task.CompletedTask;
            return await _productsRepository.GetById(id);
        }

        public async Task<Product> DeleteProductById(Guid id)
        {
            await Task.CompletedTask;
            return await _productsRepository.DeleteById(id);
        }

        public async Task<Guid> CreateProduct(ProductDTO productDTO)
        {
            await Task.CompletedTask;

            var product = _mapper.Map<Product>(productDTO);

            return await _productsRepository.Create(product);

        }

        public async Task<Product> UpdateProduct(Guid id, ProductDTO productDTO)
        {
            await Task.CompletedTask;
            var product = _mapper.Map<Product>(productDTO);
            product.Id = id;

            return await _productsRepository.Update(product);
        }
    }
}
