using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace onlineGrades.MVC.Models
{
    public class ResetPasswordViewModel : Controller
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Tip Cont")]
        public string TipCont { get; set; }
    }
}
