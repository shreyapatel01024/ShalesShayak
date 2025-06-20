using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SalesSahayak.Components
{
    public partial class LoginPage : System.Web.UI.Page
    {
        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataReader myreader;

        protected void Page_Load(object sender, EventArgs e)
        {
            Alerts.Text = "";
        }


        string Emp_Idfetched;
        string Passwordfetched;
        string Owner_Idfetched;
        string Company_Id;
        protected void SigninBtn_Click1(object sender, EventArgs e)
        {


            if (emailtext.Text.Length == 0 || passwordtext.Text.Length == 0)
            {


                Alerts.Text = "Id and Password Can't Be Empty";

            }
            else
            {
                //con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\jhasa\OneDrive\Desktop\SalesSahayak\SalesSahayak\Database\SalesSahayakDatabase.accdb");
                con = new OleDbConnection(@"Provider =Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database\SalesSahayakDatabase.accdb");
                cmd = new OleDbCommand();
                con.Open();
                cmd.CommandText = "Select * from EmpAuth";
                cmd.Connection = con;
                myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    Emp_Idfetched = myreader[0].ToString();
                    Passwordfetched = myreader[4].ToString();
                    Company_Id = myreader[5].ToString();
                    //  Namefetched = myreader[1].ToString();

                    if (emailtext.Text == Emp_Idfetched.ToString())
                    {
                        if (passwordtext.Text == Passwordfetched.ToString())
                        {
                            Application["Emp_Id"] = Emp_Idfetched.ToString();
                            Application["Com_Id"] = Company_Id.ToString();
                            //Response.Redirect("Home.aspx?Emp_Id=" + Emp_Idfetched.ToString() + "&Com_Id=" + Company_Id.ToString());
                            Response.RedirectPermanent("Home.aspx");
                        }
                        else
                        {
                            Alerts.Text = "Please Enter Correct Password";

                        }
                    }
                    else
                    {
                        Alerts.Text = "Please Enter Correct Id";
                    }
                }



                con.Close();

                
                    
                    con.Open();
                    cmd.CommandText = "Select * from OwnerAuth";
                    cmd.Connection = con;
                    myreader = cmd.ExecuteReader();

                    while (myreader.Read())
                    {
                        Owner_Idfetched = myreader[0].ToString();
                        Passwordfetched = myreader[3].ToString();
                        Company_Id = myreader[5].ToString();
                        //  Namefetched = myreader[1].ToString();

                        if (emailtext.Text == Owner_Idfetched.ToString())
                        {
                            if (passwordtext.Text == Passwordfetched.ToString())
                            {
                                Application["Emp_Id"] = "";
                                Application["Com_Id"] = Company_Id.ToString();

                                Response.RedirectPermanent("Home.aspx");
                                // Response.Redirect("Home.aspx?Owner=" + Owner_Idfetched.ToString() + "&Com_Id=" + Company_Id.ToString());
                            }
                            else
                            {
                                Alerts.Text = "Please Enter Correct Password";
                            }
                        }
                        else
                        {
                            Alerts.Text = "Please Enter Correct ID";
                        }
                    }
                    con.Close();


                
            }
        }
        
        protected void emailtext_TextChanged(object sender, EventArgs e)
        {

            
            string emailtextid = emailtext.Text;
            if (!(emailtextid.All(char.IsDigit))){
                Alerts.Text = "Please Enter Valid Id";
            }
            
        }
    }
}