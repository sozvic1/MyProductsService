using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsCore.Options
{
    public class SmtpOptions
    {
        public string SenderMail { get; set; }
        public string SenderPassword { get; set; }
        public string SenderName { get; set; }
    }
}
