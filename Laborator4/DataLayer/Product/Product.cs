using System;
using System.ComponentModel.DataAnnotations;

namespace Laborator4
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get;  set; }

        public string description { get; set; }

        [Required]
        public DateTime StardDate { get;  set; }

        public DateTime EndDate { get;  set; }

        [Required]
        public int Price { get;  set; }

        [Required]
        public double Vat { get;  set; }

    }
}
