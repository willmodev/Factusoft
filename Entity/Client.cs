﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Client
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string Cedula { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBorn { get; set; }
        public string Telephone { get; set; }
        public string E_mail { get; set; }
        public int Address_ID { get; set; }

        public decimal Age { get { return (((DateTime.Now - DateOfBorn).Days) / 365); } }
        

    }
}
