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
            Empid = Application["Emp_Id"].ToString();
            Company_Id = Application["Com_Id"].ToString();


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
                        ProfileUserName.Text = Namefetched;
                        ProfileMenuUserName.Text = Namefetched;
                    }
                    con.Close();
                }
                else
                {
                    //Connection For Welcome Message With Name |Owner
                    con.Open();
                    cmd.CommandText = "Select Owner_Name from OwnerAuth where Company_Id=" + Company_Id;
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

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {

            Application["Emp_Id"] = "";
            Application["Com_Id"] = "";
            Response.RedirectPermanent("LoginPage.aspx");
        }
    }
}