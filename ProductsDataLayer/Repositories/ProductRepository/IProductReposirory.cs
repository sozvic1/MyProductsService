using ProductsCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsDataLayer.Repository.ProductRepository
{
    public interface IProductReposirory
    {
        Task<Guid> Create(Product product);
        Task<Product> DeleteById(Guid id);
        Task<List<Product>> GetAll();
        Task<Product> GetById(Guid id);
        Task<Product> Update(Product product);
    }
}