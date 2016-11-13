using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsProject
{
    public partial class NumberInput : System.Web.UI.UserControl
    {
        public string myID { get; set; }

        public string Value { get { return this.txtNumber.Text; } set { this.txtNumber.Text = value; } }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}