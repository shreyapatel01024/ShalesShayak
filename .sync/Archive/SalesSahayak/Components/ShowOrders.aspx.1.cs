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
    public partial class ShowOrders : System.Web.UI.Page
    {
        string Comp_Id;
        string Empid;
        int Employee_Id;
        int Company_Id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Empid = Application["Emp_Id"].ToString();
                Comp_Id = Application["Com_Id"].ToString();
               
                Company_Id = Convert.ToInt32(Comp_Id);
                if (Empid != "")
                {
                    Employee_Id = Convert.ToInt32(Empid);
                    BindDataEmployee();
                }
                else
                {
                    BindDataOwner();
                }

            }
        }
        private void BindDataEmployee()
        {
            string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database\SalesSahayakDatabase.accdb";
            //string query = "SELECT Enquiry_Id, Enquiry_Date,Customer_Id, Product_Name, Quantity,Value,Status,Follow_Up FROM Enquiry where Company_Id=" +Company_Id+ " and Enquiry_Type='" + "MAIN" + "' and Emp_Id="+Empid;
            string query = "SELECT Orders.Order_Id,Orders.Order_Date,Orders.Customer_Id,Customer.Customer_Name,Orders.Product_Name, Orders.Quantity,Orders.Value,Orders.Status,Orders.Payment_Received,Orders.Payment_Status FROM Customer,Orders where Orders.Customer_Id=" + "Customer.Customer_Id" + " and  Orders.Company_Id=" + Company_Id + " and Orders.Order_Type='" + "MAIN" + "' and Orders.Emp_Id=" + Employee_Id+" and Orders.Payment_Status='"+"Not Done"+"'";
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
                        DataRepeater1.DataSource = dt;
                        DataRepeater1.DataBind();
                    }
                }
            }
        }
        private void BindDataOwner()
        {
            string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database\SalesSahayakDatabase.accdb";
            // string query = "SELECT Enquiry_Id, Enquiry_Date,Customer_Id, Product_Name, Quantity,Value,Status,Follow_Up FROM Enquiry where Company_Id=" + Company_Id + " and Enquiry_Type='" + "MAIN" + "'";
            string query = "SELECT Orders.Order_Id,Orders.Order_Date,Orders.Customer_Id,Customer.Customer_Name,Orders.Product_Name,Orders.Quantity,Orders.Value,Orders.Status,Orders.Payment_Received,Orders.Payment_Status FROM Customer,Orders  where Orders.Customer_Id='" + "Customer.Customer_Id" + "' and  Orders.Company_Id=" + Company_Id + " and Orders.Order_Type='" + "MAIN" + "'";
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
                        DataRepeater1.DataSource = dt;
                        DataRepeater1.DataBind();
                    }
                }
            }
        }
    }
}