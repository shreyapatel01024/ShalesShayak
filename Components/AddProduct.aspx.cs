using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalesSahayak.Components
{
    public partial class AddProduct : System.Web.UI.Page
    {

        //!---OleDb Definitions 
        OleDbConnection conn;
        OleDbCommand cmd;


        //!---DatabaseConnectionString
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database\SalesSahayakDatabase.accdb";

        //!---Global Variable Definitions 
        //!---Variables for Storing CompanyId and EmployeeId
        string Com_Id;
        string Emp_Id;

        int fetchedProductId;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session.Count != 0)
                {
                    Success.Text = "";
                    Error.Text = "";
                    //!---If Block For First time Page Load
                    //!---Storing Session Variables Data into Emp_Id and Com_Id
                    Emp_Id = Session["Emp_Id"].ToString();
                    Com_Id = Session["Com_Id"].ToString();


                    if (Emp_Id == "" && Com_Id == "")
                    {
                        Response.Redirect("LoginPage.aspx");
                    }
                }
                else
                {
                    Response.Redirect("LoginPage.aspx");
                }
            }
            catch (Exception ex)
            {
                Error.Text = "Error: " + ex.Message;
            }
        }
        //!---Function to Get the Latest CustomerId from Database
        void getMaxProductId()
        {
            try
            {
                //!---Fetching Latest or Max Customer Id from DataBase
                conn = new OleDbConnection(connectionString);
                cmd = new OleDbCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "Select MAX(Product_Id) from Products";
                OleDbDataReader reader1 = cmd.ExecuteReader();
                if (reader1.Read())
                {
                    fetchedProductId = Convert.ToInt32(reader1[0]);
                }
            }
            catch (Exception ex)
            {
                Error.Text = "Error: " + ex.Message;
            }
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Success.Text = "";
            Error.Text = "";
            try
            {  //!---Storing Session Data Com_Id on button click

                Com_Id = Session["Com_Id"].ToString();

                getMaxProductId(); //!---Calling getMaxProductId function to get Latest Customer Id from Database
                fetchedProductId++; //!---Increasing Id by one

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
    }
}