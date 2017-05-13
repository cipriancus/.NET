using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using onlineGrades.Core.Entity;

namespace onlineGrades.Core.Session_Data
{
    public class SessionData
    {
        public Student student { get; set; }
        public Profesor profesor { get; set; }

        public bool isLogged()
        {
            return profesor != null ? true : (student != null ? true : false);
        }


    }
}
