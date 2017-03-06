using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace onlineGrades.Core.Entity
{
    public class Nota
    {
        public Nota()
        {
            NotaId = Guid.NewGuid();
        }
        [Key]
        [Required]

        public Guid NotaId { get; set; }
        [Required]
        public float Valoare { get; set; }
        [Required]
        public Guid CursId { get; set; }// maparea se va face dupa ID-ul cursului
        [Required]
        public Curs Curs { get; set; }//mapat ca one to many
        [Required]
        public Guid StudentId { get; set; }// maparea se va face dupa ID-ul studentului
        [Required]
        public Student Student { get; set; }//mapat ca one to many
        [Required]
        public Guid CategorieId { get; set; }
        [Required]
        public Categorie Categorie {get;set; }//mapat ca one to many
    }
}
