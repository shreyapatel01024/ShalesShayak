using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Runtime.Remoting.Messaging;

namespace SalesSahayak.Components
{
    public partial class AddCustomer : System.Web.UI.Page
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
        
            string CustomerId; //!---Variable for Storing New Made CustomerId
            string fetchedCustomerId; //!---Variable for Storing Fetched CustomerId from Database
            string prefix; //!---Variable for Storing Prefix of Company 
            int pureid;//!---Variable for Storing Main Id of Customer in numeric 
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
        void getMaxCustId()
        {
            try
            {
                //!---Fetching Latest or Max Customer Id from DataBase
                conn = new OleDbConnection(connectionString);
                cmd = new OleDbCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "Select MAX(Customer_Id) from Customer where Company_Id=" + Com_Id;
                OleDbDataReader reader1 = cmd.ExecuteReader();
                if(reader1.Read() && !reader1.IsDBNull(0))
                {
                    fetchedCustomerId = reader1[0].ToString();
                    //!---Making Substring of CustomerId to Do Upgrades
                    prefix = fetchedCustomerId.Substring(0, 3);
                    pureid = Convert.ToInt32(fetchedCustomerId.Substring(3, 4));

                }
                else
                {

                    conn.Close();
                    OleDbCommand cmd2 = new OleDbCommand();
                    conn.Open();
                    cmd2.Connection = conn;
                    cmd2.CommandText = "SELECT Short_Identifier FROM Company WHERE Company_Id =" + Com_Id;

                    OleDbDataReader reader2 = cmd2.ExecuteReader();
                    if (reader2.Read())
                    {
                        prefix = reader2[0].ToString();
                        pureid = 0;
                    }
                    conn.Close();
                }



                conn.Close();
            }
            catch (Exception ex)
            {
                Error.Text="Error: "+ ex.Message;
            }
        }

        //!---Some Global variables For Storing Form Data Temporarily
        string CustomerNametxt, Type, Emailtxt, Addresstxt, Citytxt, Statetxt,Mobtxt;
        int Pincodetxt;

        //!---Function to GetData From Form Textbox and store it in above Global Variables
        void getDataFromTextBoxes()
        {
            try
            {
                CustomerNametxt = Customer_Name.Text;
                Type = "New";
                Emailtxt = Email.Text;
                Addresstxt = Address.Text;
                Citytxt = City.Text;
                Statetxt = State.Text;
                Mobtxt = Mob_No.Text;
                Pincodetxt = Convert.ToInt32(Pincode.Text);
            }
            catch (Exception ex)
            { 
                Error.Text ="Error: "+ex.Message;
            }
        }
        //!---Form Submit Button
        protected void AddCustomerbtn_Click(object sender, EventArgs e)
        {
            Success.Text = "";
            Error.Text = "";
            try
            {  //!---Storing Session Data into Emp_Id and Com_Id on button click
                Emp_Id = Session["Emp_Id"].ToString();
                Com_Id = Session["Com_Id"].ToString();

                getMaxCustId(); //!---Calling getMaxCustId function to get Latest Customer Id from Database
                pureid++; //!---Increasing Id by one
                CustomerId = prefix + String.Format("{0:0000}", pureid); //!--- Appending the prefix and updated Customer id and storing it to Customer Id
                getDataFromTextBoxes(); //!---Calling getDataFromTextBoxes;

                //!---Storing Customer Details to Database
                conn = new OleDbConnection(connectionString);
                cmd = new OleDbCommand();
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "Insert into Customer Values('" + CustomerId + "','" + CustomerNametxt + "','" + Type + "','" + Emailtxt + "','" + Addresstxt + "','" + Citytxt + "','" + Statetxt + "',"+Mobtxt+","+ Pincodetxt + "," + Emp_Id + "," + Com_Id + ")";
                cmd.ExecuteNonQuery();
                conn.Close();
                clearall();
                Success.Text = "Success: Customer Details Successfully Entered";
                
            }
            catch (Exception ex)
            {
                Error.Text="Error: " + ex.Message;
            }
        }
        void clearall()
        {
            Customer_Name.Text = "";
            Email.Text = "";
            Address.Text = "";
            City.Text = "";
            State.Text = "";
            Mob_No.Text = "";
            Pincode.Text = "";
        }
    }
}