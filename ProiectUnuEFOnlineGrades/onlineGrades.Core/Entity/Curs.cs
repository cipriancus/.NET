using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace onlineGrades.Core.Entity
{
    [DataContract(IsReference = true)]
    public partial class Curs
    {
        public Curs()
        {
            this.CursId = Guid.NewGuid();
            Student = new HashSet<Student>();
            Note = new HashSet<Nota>();
            Profesor = new HashSet<Profesor>();
        }
        [Key]
        [Required]
        [DataMember]
        public Guid CursId { get; set; }
        [Required]
        [StringLength(50)]
        [DataMember]
        public string Nume { get; set; }
        [Required]
        [DataMember]
        public int Credite { get; set; }

        public virtual ICollection<Student> Student { get; set; }//mapat ca many to many
        public virtual ICollection<Nota> Note { get; set; }//mapat ca one to many
        public virtual ICollection<Profesor> Profesor { get; set; }//mapat ca many to many  
    }
}
