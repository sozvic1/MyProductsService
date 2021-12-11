using AutoMapper;
using ProductsBusinessLayer.DTOs;
using ProductsCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsBusinessLayer.MapperProfile
{
   public class AccountInfoProfile:Profile
    {
        public AccountInfoProfile()
        {
            CreateMap<AccountInfoDTO, AccountInfo>()
          .ForMember(x => x.Isactive, opt => opt.MapFrom(src => false))
          .ForMember(x => x.FirstName, opt => opt.MapFrom(src => src.FirstName))
          .ForMember(x => x.LastName, opt => opt.MapFrom(src => src.LastName))
          .ForMember(x => x.LoginInfo, opt => opt.MapFrom(src => src.LoginInfo))
          .ForMember(x => x.Role, opt => opt.MapFrom(src => Role.User))
          .ForMember(x => x.EmailId, opt => opt.Ignore());
              
        }
    }
}
