using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsCore.Models.Requests
{
   public class PasswordChangeRequest
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
