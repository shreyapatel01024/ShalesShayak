using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalesSahayak.Components
{
    public partial class privacy_policy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Empid = Application["Emp_Id"].ToString();
            string Company_Id = Application["Com_Id"].ToString();
            if (Empid == "" || Company_Id == "")
            {
                Response.Redirect("LoginPage.aspx");
            }
        }
    }
}