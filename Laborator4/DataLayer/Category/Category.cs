using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Laborator4
{
    public class Category
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public string description { get; set; }

        public virtual ICollection<Product> allProductsInCategory { get; set; }

        [Required]
        public string ExtraInfo;
    }
}
