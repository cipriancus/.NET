using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lab4Class
{
    public class Customer
    {   
        public Guid Id { get;  set; }

        public string Name { get;  set; }

        public string address { get;  set; }

        public string phonenumber { get;  set; }

        public string email { get;  set; }
    }
}
