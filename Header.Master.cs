using SalesSahayak.Components;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalesSahayak
{
    public partial class Header : System.Web.UI.MasterPage
    {

        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataReader myreader;
        string Company_Id;
        string Empid;
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session.Count > 0)
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
                        Product.Visible = false;
                        Product1.Visible = false;
                        //Connection for Welcome with Name |Emp|
                        con.Open();
                        cmd.CommandText = "Select Emp_Name from EmpAuth where Emp_Id=" + Empid;
                        cmd.Connection = con;
                        myreader = cmd.ExecuteReader();
                        if (myreader.Read())
                        {
                            string Namefetched = myreader[0].ToString();
                            ProfileUserName.Text = Namefetched;
                            ProfileMenuUserName.Text = Namefetched;
                        }
                        con.Close();
                    }
                    else
                    {
                        AddEnquirybtn.Visible = false;
                        AddCustomerbtn.Visible = false;
                        AddOrderbtn.Visible = false;
                        AddEnquirybtn1.Visible = false;
                        AddOrderbtn1.Visible = false;
                        AddCustomerbtn1.Visible = false;    
                        //Connection For Welcome Message With Name |Admin
                        con.Open();
                        cmd.CommandText = "Select Admin_Name from AdminAuth where Company_Id=" + Company_Id;
                        cmd.Connection = con;
                        myreader = cmd.ExecuteReader();
                        if (myreader.Read())
                        {
                            string Namefetched = myreader[0].ToString();
                            ProfileUserName.Text = Namefetched;
                            ProfileMenuUserName.Text = Namefetched;

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

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {

            Session["Admin_Id"] = "";
            Session["Emp_Id"] = "";
            Session["Com_Id"] = "";
            Session.Abandon();
            
            Response.Redirect("LoginPage.aspx");
        }
        
         
    }
}