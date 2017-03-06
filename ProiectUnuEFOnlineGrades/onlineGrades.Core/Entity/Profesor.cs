using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace onlineGrades.Core.Entity
{
    public class Profesor:User
    {
        public Profesor()
        {
            this.ProfesorId = Guid.NewGuid();
            Curs = new HashSet<Curs>();
        }
        public Profesor(User user):base(user)
        {
            Curs = new HashSet<Curs>();
        }
        [Key]
        [Required]
        public Guid ProfesorId { get; set; }
      
        public virtual ICollection<Curs> Curs { get; set; }//mapat ca many to many
    }
}
