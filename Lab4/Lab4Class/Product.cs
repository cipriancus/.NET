using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab4Class
{
    public class Product
    {  
        public Guid Id { get; private set; }

        [Required]
        [StringLength(50)]
        public string Name { get; private set; }

        public string Description { get; private set; }

        [Required]
        public DateTime StartDate { get; private set; }

        public DateTime? EndDate { get; private set; }

        [Required]
        public double Price { get; private set; }

        [Required]
        public int Vat { get; private set; }
        
    }
}
