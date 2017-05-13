using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace onlineGrades.MVC.Models
{
    public class RegisterViewModel : Controller
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Re_Password { get; set; }

        [Required]
        [Display(Name = "Nume")]
        public string Nume { get; set; }

        [Required]
        [Display(Name = "Prenume")]
        public string Prenume { get; set; }

        [Required]
        [Display(Name = "InitialaTata")]
        public string InitialaTata { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "DataNasterii")]
        public DateTime DataNasterii { get; set; }

        [Required]
        [Display(Name = "Mama")]
        public String Mama { get; set; }

        [Required]
        [Display(Name = "Tata")]
        public String Tata { get; set; }

        [Required]
        [Display(Name = "Nationalitate")]
        public String Nationalitate { get; set; }

        [Required]
        [Display(Name = "Cetatenie")]
        public String Cetatenie { get; set; }
        [Required]
        [Display(Name = "TipCont")]
        public String TipCont { get; set; }
    }
}
