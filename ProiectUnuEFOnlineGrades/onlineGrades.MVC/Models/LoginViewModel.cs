using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace onlineGrades.MVC.Models
{
    public class LoginViewModel
    {
       [Required]
       [Display(Name ="Username")]
       public string Username { get; set; }
       
       [Required]
       [DataType(DataType.Password)]
       public string Password { get; set; }
    }
}
