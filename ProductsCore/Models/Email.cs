using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsCore.Models
{
   public class Email
    {
        public int Id { get; set; }
        public string PostName { get; set; }
        public string ConfirmationString { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
