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
     //!---OleDb Definitions
        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataReader myreader;

     //!---Database Connection String
        string connectionString = @"Provider =Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database\SalesSahayakDatabase.accdb";
     
     //!--- PageLoad    
        protected void Page_Load(object sender, EventArgs e)
        {
            Alerts.Text = "";
        }

    //!---Global Variables Definitions for storing Data like EmpId,Password,AdminId,Company_Id
        string Emp_Idfetched;
        string Passwordfetched;
        string Admin_Idfetched;
        string Company_Id;
        bool isemp;

        

     //!---Signin button Starts here
        protected void SigninBtn_Click1(object sender, EventArgs e)
        {
          //!---If Block for Checking if the email or password length is 0
            if (idText.Text.Length == 0 || passwordText.Text.Length == 0)
            {


                if (idText.Text.Length == 0 && passwordText.Text.Length>0)
                {
                    Alerts.Text = "Id Can't be Empty";
                }
                else if (passwordText.Text.Length == 0 && idText.Text.Length>0)
                {
                    Alerts.Text = "Password Can't be Empty";
                }
                else
                {
                    Alerts.Text = "Id and Password Can't Be Empty";
                    
                }
                }

            //!---Else Block for Fetching Id and Password and comparing it with User Entered Data and Redirect to home page if matched
            else
                {

                //!--- Auth For Employee

              //!---Fetching Id and Password from Database
                //con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\jhasa\OneDrive\Desktop\SalesSahayak\SalesSahayak\Database\SalesSahayakDatabase.accdb");
                con = new OleDbConnection(connectionString);
                cmd = new OleDbCommand();
                con.Open();
                cmd.CommandText = "Select * from EmpAuth";
                cmd.Connection = con;
                myreader = cmd.ExecuteReader();
                
                    while (myreader.Read())
                    {

                        Emp_Idfetched = myreader["Emp_Id"].ToString();
                        Passwordfetched = myreader["Password"].ToString();
                        Company_Id = myreader["Company_Id"].ToString();
                        //  Namefetched = myreader[1].ToString();

                        //!---Checking if User Entered Id is Matching with Fetched Id from Database
                        if (idText.Text == Emp_Idfetched.ToString())
                        {
                          
                            //!---Checking if User Entered Password is Matching with Fetched Password from Database
                            if (passwordText.Text == Passwordfetched.ToString())
                            {
                                //!---Storing Emp Id and Company Id in Session
                                Session["Admin_Id"] = "";
                                Session["Emp_Id"] = Emp_Idfetched.ToString();
                                Session["Com_Id"] = Company_Id.ToString();
                                //Response.Redirect("Home.aspx?Emp_Id=" + Emp_Idfetched.ToString() + "&Com_Id=" + Company_Id.ToString());

                                //!---Redirecting to Home page
                                Response.Redirect("Home.aspx");
                            }
                            else
                            {
                            isemp = true;
                                Alerts.Text = "Please Enter Correct Password";

                            break;


                            }
                        }
                        else
                        {
                        isemp = false;
                            Alerts.Text = "Please Enter Correct Id";

                           
                            
                       
                        }
                    }


                    
                    con.Close();

                    //!---Auth for Admin 

                    //!---Fetching Id and Password from Database
                    con.Open();
                    cmd.CommandText = "Select * from AdminAuth";
                    cmd.Connection = con;
                    myreader = cmd.ExecuteReader();
                if (isemp != true)
                {
                    while (myreader.Read())
                    {
                        Admin_Idfetched = myreader["Admin_Id"].ToString();
                        Passwordfetched = myreader["Password"].ToString();
                        Company_Id = myreader["Company_Id"].ToString();
                        //  Namefetched = myreader[1].ToString();

                        //!---Checking if User Entered Id is Matching with Fetched Id from Database
                        if (idText.Text == Admin_Idfetched.ToString())
                        {
                            //!---Checking if User Entered Password is Matching with Fetched Password from Database
                            if (passwordText.Text == Passwordfetched.ToString())
                            {
                                //!---Storing Emp Id and Company Id in Session
                                Session["Emp_Id"] = "";
                                Session["Admin_Id"] = Admin_Idfetched.ToString();
                                Session["Com_Id"] = Company_Id.ToString();
                                //!---Redirecting to Home page
                                Response.Redirect("Home.aspx");
                                // Response.Redirect("Home.aspx?Admin=" + Admin_Idfetched.ToString() + "&Com_Id=" + Company_Id.ToString());
                            }
                            else
                            {
                                Alerts.Text = "Please Enter Correct Password";
                                break;


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
        }
        //!---idText Change event
        protected void idText_TextChanged(object sender, EventArgs e)
        {

            
            string idTextfetched = idText.Text;
            if (!(idTextfetched.All(char.IsDigit))){
                Alerts.Text = "Please Enter Valid Id";
            }
            
        }
    }
}