using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsProject.Services;

namespace WebFormsProject
{
    public partial class Compute : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddNumbers(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var number1 = double.Parse(numberInput1.Value);
                var number2 = double.Parse(numberInput2.Value);
                var number3 = double.Parse(numberInput3.Value);
                Sumator sumator = new Sumator(number1, number2, number3);

                lblResult.Text = sumator.GetSum().ToString();
                lblResult.Visible = true;
            }
        } 
    }
}