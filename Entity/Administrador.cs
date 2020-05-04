using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Administrador
    {
        public Login Login { get; set; }

        public Administrador(string user, string password)
        {
            Login = new Login(user, password);
        }

    }
}
