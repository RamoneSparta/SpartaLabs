using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab25_First_Website
{
    public partial class HelloWorld : System.Web.UI.Page
    {
        public static int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Button1_Click(object sender, EventArgs e)
        {
            i++;
            Label1.Text = "Hey You Clicked the button " + i + " Times";
        }
    }
}