using AutoMapper;
using ProductsBusinessLayer.DTOs;
using ProductsCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsBusinessLayer.MapperProfile
{
    public class ProductsProfile:Profile
    {
        public ProductsProfile()
        {
            CreateMap<ProductDTO, Product>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Category, opt => opt.MapFrom(src => ToCategory(src.Category)))
                .ForMember(x => x.IsAvailableToBuy, opt => opt.MapFrom(src => true))
                .ForMember(x => x.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(x => x.Title, opt => opt.MapFrom(src => src.Title));
        }
        private Category ToCategory(string category)
        {
            return Enum.TryParse(typeof(Category), category, out var result)
                ? (Category)result
                : default;
                

            
        }
    }
}
