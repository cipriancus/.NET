using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace onlineGrades.Core.Entity
{
    [DataContract(IsReference = true)]

    public partial class Student : User
    {
        public Student()
        {
            Nota = new HashSet<Nota>();
            Curs = new HashSet<Curs>();
        }

        public Student(User user):base(user){
            Nota = new HashSet<Nota>();
            Curs = new HashSet<Curs>();
        }

        [Required]
        [DataMember]
        public int AnUniversitar { get; set; }

        public virtual ICollection<Nota> Nota { get; set; }// mapat ca one to many
        public virtual ICollection<Curs> Curs { get; set; }//mapat ca many to many
    }
}
