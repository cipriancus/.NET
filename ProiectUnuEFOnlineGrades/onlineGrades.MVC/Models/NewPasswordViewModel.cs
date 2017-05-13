using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace onlineGrades.MVC.Models
{
    public class NewPasswordViewModel : Controller
    {
        [Required]
        [Display(Name = "Parola")]
        public string Parola { get; set; }

        [Required]
        [Display(Name = "Confirmare Parola")]
        public string ParolaC { get; set; }
    }
}
