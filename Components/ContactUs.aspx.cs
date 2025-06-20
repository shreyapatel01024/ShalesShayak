using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalesSahayak.Components
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count != 0)
            {
                string Empid = Session["Emp_Id"].ToString();
                string Company_Id = Session["Com_Id"].ToString();
                if (Empid == "" || Company_Id == "")
                {
                    Response.Redirect("LoginPage.aspx");
                }
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
        }
        
    }
}