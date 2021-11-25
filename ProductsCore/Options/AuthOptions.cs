﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsCore.Options
{
    public class AuthOptions
    {
        public string Issuer  { get; set;} 
        public  string Audience { get; set;}
        public string SecretKey { get; set; }
        public int TokenLifeTime { get; set; }
        
    }
}
