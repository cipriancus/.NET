using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace onlineGrades.Core.Entity
{
    [DataContract(IsReference = true)]
    public partial class Nota
    {
        public Nota()
        {
            NotaId = Guid.NewGuid();
        }
        [Key]
        [Required]
        [DataMember]
        public Guid NotaId { get; set; }
        [Required]
        [DataMember]
        public float Valoare { get; set; }
        [Required]
        [DataMember]
        public Guid CursId { get; set; }// maparea se va face dupa ID-ul cursului
        [Required]
        [DataMember]
        public Curs Curs { get; set; }//mapat ca one to many
        [Required]
        [DataMember]
        public Guid StudentId { get; set; }// maparea se va face dupa ID-ul studentului
        [Required]
        [DataMember]
        public Student Student { get; set; }//mapat ca one to many
        [Required]
        [DataMember]
        public Guid CategorieId { get; set; }
        [Required]
        [DataMember]
        public Categorie Categorie {get;set; }//mapat ca one to many
    }
}
