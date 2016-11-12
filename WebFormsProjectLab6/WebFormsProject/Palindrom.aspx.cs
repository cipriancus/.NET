using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsProject.Class;

namespace WebFormsProject
{
    public partial class Palindrom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPalindrom(object sender, EventArgs e)
        {
         if (Palindrome.check(palindromTxt.Text)==true)
                result.Text = "Is a palindrome";
            else
                result.Text = "Is not a palindrome";
        }
    }
}