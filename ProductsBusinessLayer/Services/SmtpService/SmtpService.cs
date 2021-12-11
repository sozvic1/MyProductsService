﻿using Microsoft.Extensions.Options;
using ProductsBusinessLayer.DTOs;
using ProductsCore.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProductsBusinessLayer.Services.SmtpService
{
    public class SmtpService : ISmtpService
    {
        private readonly SmtpOptions _smtpOptions;
        public SmtpService(IOptions<SmtpOptions> smtpOptions)
        {
            _smtpOptions = smtpOptions.Value;
        }
        public async Task SendMailAsync(MailDTO mailDTO)
        {

            SmtpClient SmtpServer = new SmtpClient
            {
                UseDefaultCredentials = false,
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential(
                    _smtpOptions.SenderMail,
                    _smtpOptions.SenderPassword),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
            };

            var fromMeilAddress = new MailAddress(_smtpOptions.SenderMail, _smtpOptions.SenderName);
            var toMailAddress = new MailAddress(mailDTO.To);
            var mailMessage = new MailMessage
            {
                From = fromMeilAddress,
                Subject = mailDTO.Subject,
                Body = mailDTO.Body
            };

            mailMessage.To.Add(toMailAddress);

            await SmtpServer.SendMailAsync(mailMessage);
        }
    }
}
