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
    public partial class Profile : System.Web.UI.Page
    {
        OleDbCommand con, con1;
        OleDbCommand cmd, cmd1;
        string Comp_Id;
        string Empid;
        string Adminid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count != 0)
            {

                Adminid = Session["Admin_Id"].ToString();
                Empid = Session["Emp_Id"].ToString();
                Comp_Id = Session["Com_Id"].ToString();
                if (Empid != "")
                {
                    idlabel.Text = "Employee Id: ";
                    OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database\SalesSahayakDatabase.accdb");
                    con.Open();
                    String str = "select * from EmpAuth where Emp_Id="+Empid;
                    cmd = new OleDbCommand(str, con);
                    OleDbDataReader myreader = cmd.ExecuteReader();
                    if (myreader.Read())
                    {
                        Id.Text = myreader["Emp_Id"].ToString();
                        Emp_Name.Text = myreader["Emp_Name"].ToString();
                        Designation.Text = myreader["Designation"].ToString();
                        Email.Text = myreader["Email"].ToString();
                        gender.Text = myreader["Gender"].ToString();
                        Qualification.Text = myreader["Qualification"].ToString();
                        Emp_Age.Text = myreader["Age"].ToString();
                        Mobile_Number.Text = myreader["Mobile_Number"].ToString();
                        Address_Emp.Text = myreader["Address"].ToString();
                        myreader.Close();
                        con.Close();
                    }
                    OleDbConnection con1 = new OleDbConnection(@"Provider =Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database\SalesSahayakDatabase.accdb");
                    con1.Open();
                    String str1 = "select * from company where Company_Id="+Comp_Id;
                    cmd1 = new OleDbCommand(str1, con1);
                    OleDbDataReader myreader1 = cmd1.ExecuteReader();
                    if (myreader1.Read())
                    {
                        Company_Id.Text = myreader1["Company_Id"].ToString();
                        Company_Name.Text = myreader1["Company_Name"].ToString();
                        //Mobile_Number.Text = myreader1["Mobile_Number"].ToString();
                        Address.Text = myreader1["Address"].ToString();
                        myreader1.Close();
                        con1.Close();
                    }
                }
                else
                {
                    
                    OleDbConnection con = new OleDbConnection(@"Provider =Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database\SalesSahayakDatabase.accdb");
                    con.Open();
                    String str = "select * from AdminAuth where Admin_Id="+Adminid;
                    cmd = new OleDbCommand(str, con);
                    OleDbDataReader myreader = cmd.ExecuteReader();
                    if (myreader.Read())
                    {
                        idlabel.Text = "Admin Id: ";
                        Id.Text = myreader["Admin_Id"].ToString();
                        Emp_Name.Text = myreader["Admin_Name"].ToString();
                        Designation.Text = myreader["Designation"].ToString();
                        Email.Text = myreader["Email"].ToString();
                        gender.Text = myreader["Gender"].ToString();
                        Qualification.Text = myreader["Qualification"].ToString();
                        Emp_Age.Text = myreader["Age"].ToString();
                        Mobile_Number.Text = myreader["Mobile_Number"].ToString();
                        Address_Emp.Text = myreader["Address"].ToString();
                        myreader.Close();
                        con.Close();
                    }
                    OleDbConnection con1 = new OleDbConnection(@"Provider =Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database\SalesSahayakDatabase.accdb");
                    con1.Open();
                    String str1 = "select * from company where Company_Id="+Comp_Id;
                    cmd1 = new OleDbCommand(str1, con1);
                    OleDbDataReader myreader1 = cmd1.ExecuteReader();
                    if (myreader1.Read())
                    {
                        Company_Id.Text = myreader1["Company_Id"].ToString();
                        Company_Name.Text = myreader1["Company_Name"].ToString();
                       // Mobile_Number.Text = myreader1["Mobile_Number"].ToString();
                        Address.Text = myreader1["Address"].ToString();
                        myreader1.Close();
                        con1.Close();
                    }
                }
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
        }
    }
}