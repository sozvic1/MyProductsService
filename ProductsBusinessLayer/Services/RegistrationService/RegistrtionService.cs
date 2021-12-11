using AutoMapper;
using ProductsBusinessLayer.DTOs;
using ProductsCore.Models;
using ProductsDataLayer.Repositories.EmailRepository;
using ProductsDataLayer.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductsBusinessLayer.Services.RegistrationService
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailRepository _emailRepository;
        private readonly IMapper _mapper;
        public RegistrationService(IUserRepository userRepository, IEmailRepository emailRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _emailRepository = emailRepository;
            _mapper = mapper;
        }
        public async Task<Guid> RegisterUser(AccountInfoDTO accountInfoDTO)
        {
            int? emailId = null;
            if (string.IsNullOrEmpty(accountInfoDTO.Email))
            {
                var mail = new Email
                {
                    PostName = accountInfoDTO.Email,
                    IsConfirmed = false,
                    ConfirmationString = "asdasd"
                };
                emailId = await _emailRepository.RegisterEmailAsync(mail);
            }

            var accountInfo = _mapper.Map<AccountInfo>(accountInfoDTO);
            accountInfo.EmailId = emailId.Value;
            return await _userRepository.AddUserAsync(accountInfo);

        }
    }
}
