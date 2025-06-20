using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalesSahayak.Components
{
    public partial class ShowProductsDetail : System.Web.UI.Page
    {
        string Emp_Id;
        string Com_Id;
        string fetchedProduct_Id;
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database\SalesSahayakDatabase.accdb";
        OleDbConnection con;
        OleDbCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count != 0)
            {
                Emp_Id = Session["Emp_Id"].ToString();
                Com_Id = Session["Com_Id"].ToString();
                fetchedProduct_Id = Request.QueryString["Product_Id"];
                BindSingleData1();
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
        }
        void BindSingleData1()
        {
            string query = "Select * from Products where Product_Id=" + fetchedProduct_Id;
            con = new OleDbConnection(connectionString);
            con.Open();
            cmd = new OleDbCommand(query, con);
            OleDbDataReader myreader = cmd.ExecuteReader();
            if (myreader.Read())
            {
                Product_Id.Text = myreader[0].ToString();
                Product_Name.Text = myreader[1].ToString();
                Product_Price.Text = myreader[2].ToString();
            }

            con.Close();


        }
        protected void Back_Click(object sender, EventArgs e)
        {

            Response.Redirect("ShowProducts.aspx");
        }
        protected void Remove_Click(object sender, EventArgs e)
        {

            fetchedProduct_Id = Request.QueryString["Product_Id"];
            OleDbConnection conn = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "Delete from Products where Product_Id=" + fetchedProduct_Id + "";
            cmd.ExecuteNonQuery();

            conn.Close();
            Response.Redirect("ShowProducts.aspx");
        }
        protected void Edit_Btn(object sender, EventArgs e)
        {

            Response.Redirect("ProductEdit.aspx?Product_Id=" + fetchedProduct_Id);
        }

    }
}