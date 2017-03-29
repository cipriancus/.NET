using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace onlineGrades.Core.Entity
{
    [DataContract(IsReference = true)]
    public partial class Categorie
    {
        public Categorie()
        {
            Note = new HashSet<Nota>();
            CategorieId = Guid.NewGuid();
        }
        [Key]
        [Required]
        [DataMember]
        public Guid CategorieId { get; set; }
        [Required]
        [StringLength(20)]
        [DataMember]
        public string Nume { get; set; }

        public virtual ICollection<Nota> Note { get; set; }//mapat ca one to many
    }
}
