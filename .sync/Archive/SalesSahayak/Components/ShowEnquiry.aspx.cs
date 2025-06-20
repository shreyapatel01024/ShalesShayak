using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalesSahayak.Components
{
    public partial class ShowEnquiry : System.Web.UI.Page
    {
        string Comp_Id;
        string Empid;
        int Employee_Id;
        int Company_Id;
        string EnquiryStatus;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                Empid = Application["Emp_Id"].ToString();
                Comp_Id = Application["Com_Id"].ToString();
                // DropDownList1.Items.Add("Open");
                //DropDownList1.Items.Add("Closed");
                //DropDownList1.SelectedIndex = 1;
                //EnquiryStatus = DropDownList1.SelectedValue;
                EnquiryStatus = "Open";
                Company_Id = Convert.ToInt32(Comp_Id);
                if (Empid != "")
                {
                    Employee_Id = Convert.ToInt32(Empid);
                    BindDataEmployee(EnquiryStatus);
                }
                else
                {
                    BindDataOwner(EnquiryStatus);
                }
                
            }
            


        }
       
        
       
            private void BindDataEmployee(string EnquiryStatus)
        {
            Status.Text = EnquiryStatus;
            string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database\SalesSahayakDatabase.accdb";
            //string query = "SELECT Enquiry_Id, Enquiry_Date,Customer_Id, Product_Name, Quantity,Value,Status,Follow_Up FROM Enquiry where Company_Id=" +Company_Id+ " and Enquiry_Type='" + "MAIN" + "' and Emp_Id="+Empid;
            string query = "SELECT Enquiry.Enquiry_Id,Enquiry.Enquiry_Date,Enquiry.Customer_Id,Enquiry.Indentor_Name,Customer.Customer_Name,Enquiry.Product_Name, Enquiry.Quantity,Enquiry.Value,Enquiry.Status,Enquiry.Follow_Up FROM Customer,Enquiry where Enquiry.Customer_Id=" +"Customer.Customer_Id"+ " and  Enquiry.Company_Id=" +Company_Id+ " and Enquiry.Enquiry_Type='" + "MAIN" + "' and Enquiry.Emp_Id="+Employee_Id+" and Enquiry.Status='"+EnquiryStatus+"'";
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    conn.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {

                        // Create a DataTable to hold the data
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        // Bind the DataTable to the Repeater
                        DataRepeater.DataSource = dt;
                        DataRepeater.DataBind();



                    }
                }
                conn.Close();
            }
            
        }
        private void BindDataOwner(string EnquiryStatus)
        {

            string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database\SalesSahayakDatabase.accdb";
           // string query = "SELECT Enquiry_Id, Enquiry_Date,Customer_Id, Product_Name, Quantity,Value,Status,Follow_Up FROM Enquiry where Company_Id=" + Company_Id + " and Enquiry_Type='" + "MAIN" + "'";
           string query = "SELECT Enquiry.Enquiry_Id,Enquiry.Enquiry_Date,Enquiry.Customer_Id,Enquiry.Indentor_Name,Customer.Customer_Name,Enquiry.Product_Name, Enquiry.Quantity,Enquiry.Value,Enquiry.Status,Enquiry.Follow_Up FROM Customer,Enquiry  where Enquiry.Customer_Id='"+"Customer.Customer_Id"+ "' and  Enquiry.Company_Id=" +Company_Id+ "and Enquiry.Enquiry_Type='" + "MAIN" + "' and Enquiry.Status='" + EnquiryStatus + "'"; ;
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    conn.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        // Create a DataTable to hold the data
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        // Bind the DataTable to the Repeater
                        DataRepeater.DataSource = dt;
                        DataRepeater.DataBind();
                    }
                    conn.Close();
                }
            }
        }

      /*  protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

           
       
            EnquiryStatus = DropDownList1.SelectedValue;
            //string EnquiryStatus = "Open";
           
            
            if (Empid != "")
            {
              //  Employee_Id = Convert.ToInt32(Empid);
                BindDataEmployee(EnquiryStatus);
            }
            else
            {
                BindDataOwner(EnquiryStatus);
            }
        }
      */
    }
}