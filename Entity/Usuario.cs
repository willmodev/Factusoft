﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Login
    {
       public string User { get; set; }
       public string Password { get; set; }

       public Login(string user, string password)
       {
           User = user;
           Password = password;
       }
        
    }
}
