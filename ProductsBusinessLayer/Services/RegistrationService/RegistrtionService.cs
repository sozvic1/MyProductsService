using AutoMapper;
using ProductsBusinessLayer.DTOs;
using ProductsBusinessLayer.Services.SmtpService;
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
        private readonly ISmtpService _smtpService;
        private readonly IMapper _mapper;
        public RegistrationService(IUserRepository userRepository,
            ISmtpService smtpService, IEmailRepository emailRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _emailRepository = emailRepository;
            _mapper = mapper;
            _smtpService = smtpService;
        }
        public async Task<Guid> RegisterUserAsync(AccountInfoDTO accountInfoDTO,string uri)
        {
            int? emailId = null;
            var confirmationMassege = Guid.NewGuid();
            if (!string.IsNullOrEmpty(accountInfoDTO.Email))
            {
                emailId = await SaveUserEmailAsync(accountInfoDTO.Email, confirmationMassege);
            }

            Guid result = await SaveUseInfoAsync(accountInfoDTO, emailId);
            if (emailId.HasValue)
            {
                await SendConfirmationEmail(accountInfoDTO.Email, uri, confirmationMassege);
            }
            return result;
        }
        public async Task<bool> ConfirmEmailAsync(string email,string message)
        {
            var confirmMessage = await _emailRepository.GetConfirmMessageAsync(message);
            var result = confirmMessage == message;
            if (result)
            {
              await  _emailRepository.ConfirmEmailAsync(email);
            }
            return result;
        }

        private async Task<Guid> SaveUseInfoAsync(AccountInfoDTO accountInfoDTO, int? emailId)
        {
            var accountInfo = _mapper.Map<AccountInfo>(accountInfoDTO);
            accountInfo.EmailId = emailId.Value;
            return await _userRepository.AddUserAsync(accountInfo);
        }

        private async Task SendConfirmationEmail(string email,
            string uri,
            Guid confirmationMessage)
        {
            var mailDTO = new MailDTO
            {
                To = email,
                Subject = "",
                Body = $"{uri}/accounts/" +
                $"confirm?email={email}" +
                $"&message={confirmationMessage}"
            };

            await _smtpService.SendMailAsync(mailDTO);
        }

        private async Task<int> SaveUserEmailAsync(string email,Guid confirmtionString)
        {
            var mail = new Email
            {
                PostName = email,
                IsConfirmed = false,
                ConfirmationString = confirmtionString.ToString()
            };

            return await _emailRepository.RegisterEmailAsync(mail);

        }

    }
}
