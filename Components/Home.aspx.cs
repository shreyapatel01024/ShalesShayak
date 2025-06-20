using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace SalesSahayak.Components
{
    public partial class Home : System.Web.UI.Page
    {
        
       
        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataReader myreader;
        string Company_Id;
        string Empid;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session.Count != 0)
            {
                Empid = Session["Emp_Id"].ToString();
                Company_Id = Session["Com_Id"].ToString();

                // con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\jhasa\OneDrive\Desktop\SalesSahayak\SalesSahayak\Database\SalesSahayakDatabase.accdb");
                con = new OleDbConnection(@"Provider =Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database\SalesSahayakDatabase.accdb");
                cmd = new OleDbCommand();
                if (Empid == "" && Company_Id == "")
                {
                    Response.Redirect("LoginPage.aspx");
                }
                //string Empid = Request.QueryString["Emp_Id"];
                //string Company_Id = Request.QueryString["Com_Id"];
                else
                {
                    //Emp Connections
                    if (Empid != "")
                    {
                        //Connection for Welcome with Name |Emp|
                        con.Open();
                        cmd.CommandText = "Select Emp_Name from EmpAuth where Emp_Id=" + Empid;
                        cmd.Connection = con;
                        myreader = cmd.ExecuteReader();
                        if (myreader.Read())
                        {
                            string Namefetched = myreader[0].ToString();
                            UserName.Text = Namefetched;
                        }
                        con.Close();


                        //Connection for Enquiry |Emp|
                        con.Open();
                        cmd.CommandText = "Select count(Enquiry_Id) from Enquiry where Emp_Id=" + Empid + "and Company_Id=" + Company_Id + " and Status='" + "Open" + "' and Enquiry_Type='" + "MAIN" + "'";
                        cmd.Connection = con;
                        myreader = cmd.ExecuteReader();
                        if (myreader.Read())
                        {
                            string TotalEnquiry = myreader[0].ToString();
                            TotalEnquiryTxt.Text = TotalEnquiry;
                        }
                        con.Close();


                        //Connection for Order |Emp|
                        con.Open();
                        cmd.CommandText = "Select count(Order_Id) from Orders where Emp_Id=" + Empid + "and Company_Id=" + Company_Id + " and Order_Type='" + "MAIN" + "' and Order_Completed='"+"FALSE"+"'";
                        cmd.Connection = con;
                        myreader = cmd.ExecuteReader();
                        if (myreader.Read())
                        {
                            string TotalOrder = myreader[0].ToString();
                            TotalOrderTxt.Text = TotalOrder;
                        }
                        con.Close();
                        //Connection for CompletedOrder |Emp|
                        con.Open();
                        cmd.CommandText = "Select count(Order_Id) from Orders where Emp_Id=" + Empid + "and Company_Id=" + Company_Id + " and Status='" + "Delivered" + "' and Payment_Status='" + "Done" + "' and Order_Type='" + "MAIN" + "' and Order_Completed='"+"TRUE"+"'";
                        cmd.Connection = con;
                        myreader = cmd.ExecuteReader();
                        if (myreader.Read())
                        {
                            string TotalCompletedOrder = myreader[0].ToString();
                            TotalCompletedOrderTxt.Text = TotalCompletedOrder;
                        }
                        con.Close();

                    }
                    //Admin Connections
                    else
                    {
                        //string AdminId = Request.QueryString["Admin"];

                        //Connection For Welcome Message With Name |Admin
                        con.Open();
                        cmd.CommandText = "Select Admin_Name from AdminAuth where Company_Id=" + Company_Id;
                        cmd.Connection = con;
                        myreader = cmd.ExecuteReader();
                        if (myreader.Read())
                        {
                            string Namefetched = myreader[0].ToString();
                            UserName.Text = Namefetched;
                        }
                        con.Close();


                        //Connection For Enquiry |Admin|
                        con.Open();
                        cmd.CommandText = "Select count(Enquiry_Id) from Enquiry where Company_Id=" + Company_Id + " and Status='" + "Open" + "' and Enquiry_Type='" + "MAIN" + "'"; ;
                        cmd.Connection = con;
                        myreader = cmd.ExecuteReader();
                        if (myreader.Read())
                        {
                            string TotalEnquiry = myreader[0].ToString();
                            TotalEnquiryTxt.Text = TotalEnquiry;
                        }
                        con.Close();


                        //Connection For Order |Admin|   
                        con.Open();
                        cmd.CommandText = "Select count(Order_Id) from Orders where Company_Id=" + Company_Id + " and Order_Type='" + "MAIN" + "' and Order_Completed='" + "FALSE" + "'"; ;
                        cmd.Connection = con;
                        myreader = cmd.ExecuteReader();
                        if (myreader.Read())
                        {
                            string TotalOrder = myreader[0].ToString();
                            TotalOrderTxt.Text = TotalOrder;
                        }
                        con.Close();
                        //Connection for CompletedOrder |Admin|
                        con.Open();
                        cmd.CommandText = "Select count(Order_Id) from Orders where Company_Id=" + Company_Id + " and Status='" + "Delivered" + "' and Payment_Status='" + "Done" + "' and Order_Type='"+"MAIN"+ "' and Order_Completed='" + "TRUE" + "'";
                        cmd.Connection = con;
                        myreader = cmd.ExecuteReader();
                        if (myreader.Read())
                        {
                            string TotalCompletedOrder = myreader[0].ToString();
                            TotalCompletedOrderTxt.Text = TotalCompletedOrder;
                        }
                        con.Close();


                    }
                }
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
            
        }

        protected void AccessDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}