using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsProject.Services;

namespace WebFormsProject
{
    public partial class Palindrome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CheckIfPalindrome(object sender, EventArgs e)
        {
            if (IsValid)
            {
                PalindromTester tester = new PalindromTester(this.txtWord.Text);
                var isIt = tester.IsItPalindrome();

                this.lblResult.Visible = true;
                switch (isIt)
                {
                    case true:
                        this.lblResult.ForeColor = System.Drawing.Color.Green;
                        this.lblResult.Text = "The word is palindrome.";
                        break;
                    case false:
                        this.lblResult.ForeColor = System.Drawing.Color.Red;
                        this.lblResult.Text = "The word is not palindrome.";
                        break;
                    default:
                        break;
                }
            }
        } 
    }
}