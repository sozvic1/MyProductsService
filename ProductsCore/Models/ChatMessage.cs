using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsCore.Models
{
   public class ChatMessage
    {
        public ConsoleColor MessageColor { get; set; }
        public string Sender { get; set; }
        public string Text { get; set; }
    }
}
