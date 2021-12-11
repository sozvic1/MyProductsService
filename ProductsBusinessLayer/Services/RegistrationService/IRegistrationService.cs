using ProductsBusinessLayer.DTOs;
using System;
using System.Threading.Tasks;

namespace ProductsBusinessLayer.Services.RegistrationService
{
    public interface IRegistrationService
    {
        Task<Guid> RegisterUser(AccountInfoDTO accountInfoDTO);
    }
}