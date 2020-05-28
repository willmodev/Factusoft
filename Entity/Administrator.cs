using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Administrator
    {
        public Login Login { get; set; }

        public Administrator(string user, string password)
        {
            Login = new Login(user, password);
        }

    }
}
