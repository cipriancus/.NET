using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace onlineGrades.Core.Entity
{
    public class Student : User
    {
        public Student()
        {
            this.StudentId = Guid.NewGuid();
            Nota = new HashSet<Nota>();
            Curs = new HashSet<Curs>();
        }

        public Student(User user):base(user){
            Nota = new HashSet<Nota>();
            Curs = new HashSet<Curs>();
        }

        [Key]
        [Required]
        public Guid StudentId { get; set; }
        [Required]
        public int AnUniversitar { get; set; }

        public virtual ICollection<Nota> Nota { get; set; }// mapat ca one to many
        public virtual ICollection<Curs> Curs { get; set; }//mapat ca many to many
    }
}
