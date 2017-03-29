using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace onlineGrades.Core.Entity
{
    [DataContract(IsReference = true)]

    public partial class Profesor:User
    {
        public Profesor() { 
            Curs = new HashSet<Curs>();
        }
        public Profesor(User user):base(user)
        {
            Curs = new HashSet<Curs>();
        }

        public virtual ICollection<Curs> Curs { get; set; }//mapat ca many to many
    }
}
