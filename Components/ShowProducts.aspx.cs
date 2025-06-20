using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalesSahayak.Components
{
    public partial class ShowProducts : System.Web.UI.Page
    {
        string Comp_Id;

        int Company_Id;
        string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database\SalesSahayakDatabase.accdb";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count != 0)
            {
                if (!IsPostBack)
                {

                    Comp_Id = Session["Com_Id"].ToString();

                    Company_Id = Convert.ToInt32(Comp_Id);

                    BindDataOwner();


                }
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
        }



        private void BindDataOwner()
        {

            // string query = "SELECT Enquiry_Id, Enquiry_Date,Customer_Id, Product_Name, Quantity,Value,Status,Follow_Up FROM Enquiry where Company_Id=" + Company_Id + " and Enquiry_Type='" + "MAIN" + "'";
            string query = "SELECT * from Products  where Company_Id=" + Comp_Id;
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    conn.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        // Create a DataTable to hold the data
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        // Bind the DataTable to the Repeater
                        DataRepeater1.DataSource = dt;
                        DataRepeater1.DataBind();
                    }
                }
            }
        }
    }
}