using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsBusinessLayer.DTOs
{
   public class MailDTO
    {
        public string Body { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
    }
}
