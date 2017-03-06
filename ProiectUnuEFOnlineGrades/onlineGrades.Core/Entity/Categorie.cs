using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace onlineGrades.Core.Entity
{
    public class Categorie
    {
        public Categorie()
        {
            Note = new HashSet<Nota>();
            CategorieId = Guid.NewGuid();
        }
        [Key]
        [Required]
        public Guid CategorieId { get; set; }
        [Required]
        [StringLength(20)]
        public string Nume { get; set; }

        public virtual ICollection<Nota> Note { get; set; }//mapat ca one to many
    }
}
