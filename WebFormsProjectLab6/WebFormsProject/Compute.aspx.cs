using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsProject
{
    public partial class Compute : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCompute(object sender, EventArgs e)
        {

            int number1 = Int32.Parse(txtNumber1.Text);
            int number2 = Int32.Parse(txtNumber2.Text);
            int number3 = Int32.Parse(txtNumber3.Text);

            var sum = number1 + number2+number3;
            result.Text = sum.ToString();
        }
    }
}