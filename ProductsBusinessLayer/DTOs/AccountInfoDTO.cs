using MyProductsService.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsBusinessLayer.DTOs
{
   public class AccountInfoDTO
    {
        public LoginInfo LoginInfo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
     

    }
}

