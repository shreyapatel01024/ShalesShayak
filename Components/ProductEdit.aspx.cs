using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalesSahayak.Components
{
    public partial class ProductEdit : System.Web.UI.Page
    {
        string fetchedProductId; //!--- To Store Fetched Orders Id Temperary

        //!--- To Store Emp_Id and Com_Id from Session
        string Emp_Id;
        string Com_Id;
        //!--- Connection String
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database\SalesSahayakDatabase.accdb";
        //!---OleDb Definitions 
        OleDbConnection conn;
        OleDbCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session.Count != 0)
            {
                Error.Text = "";
                Success.Text = "";
                if (!IsPostBack)
                {
                    Emp_Id = Session["Emp_Id"].ToString();
                    Com_Id = Session["Com_Id"].ToString();

                    //!--- Fetching From Query String
                    fetchedProductId = Request.QueryString["Product_Id"];


                    //!--- Fetching Single load Data from Database
                    fetchsingledata();

                    //!--- populating the Fetched data to textbox
                    Product_Name.Text = fetchedProductName;
                    Product_Price.Text = fetchedProductPrice;
                }
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
        }
        string fetchedProductName;
        string fetchedProductPrice;
        void fetchsingledata()
        {
            OleDbConnection conn = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "Select * from Products where Product_Id=" + fetchedProductId + "";
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                fetchedProductName = reader[1].ToString();
                fetchedProductPrice = reader[2].ToString();
            }

            conn.Close();


        }
        string productname;
        int productprice;
        //!---Function to GetData From Form Textbox and store it in above Global Variables
        void getDataFromTextBoxes()
        {
            try
            {
                productname = Product_Name.Text;
                productprice = Convert.ToInt32(Product_Price.Text);

            }
            catch (Exception ex)
            {
                Error.Text = "Error: " + ex.Message;
            }
        }
        void removeoldproduct()
        {
            fetchedProductId = Request.QueryString["Product_Id"];
            OleDbConnection conn = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "Delete from Products where Product_Id=" + fetchedProductId + "";
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Success.Text = "";
            Error.Text = "";
            try
            {
                fetchedProductId = Request.QueryString["Product_Id"];
                //!---Storing Session Data Com_Id on button click

                Com_Id = Session["Com_Id"].ToString();
                removeoldproduct();

                getDataFromTextBoxes(); //!---Calling getDataFromTextBoxes;

                //!---Storing Customer Details to Database
                conn = new OleDbConnection(connectionString);
                cmd = new OleDbCommand();
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "Insert into Products Values(" + fetchedProductId + ",'" + productname + "'," + productprice + "," + Com_Id + ")";
                cmd.ExecuteNonQuery();
                conn.Close();
                clearall();
                Response.Redirect("ShowProductsDetail.aspx?Product_Id=" + fetchedProductId);
                Success.Text = "Success: Product Successfully Added";

            }
            catch (Exception ex)
            {
                Error.Text = "Error: " + ex.Message;
            }

        }
        void clearall()
        {
            Product_Name.Text = "";
            Product_Price.Text = "";
        }
        protected void BackBtn_Click(object sender, EventArgs e)

        {
            fetchedProductId = Request.QueryString["Ord_id"];
            Response.Redirect("ShowProductsDetail.aspx?Product_Id=" + fetchedProductId);

        }

    }
}