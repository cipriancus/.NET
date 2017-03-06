using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace onlineGrades.Core.Entity
{
    public class Curs
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
        public Guid CursId { get; set; }
        [Required]
        [StringLength(50)]
        public string Nume { get; set; }
        [Required]
        public int Credite { get; set; }

        public virtual ICollection<Student> Student { get; set; }//mapat ca many to many
        public virtual ICollection<Nota> Note { get; set; }//mapat ca one to many
        public virtual ICollection<Profesor> Profesor { get; set; }//mapat ca many to many  
    }
}
