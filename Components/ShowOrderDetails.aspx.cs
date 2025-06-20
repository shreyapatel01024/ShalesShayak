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
    public partial class ShowOrderDetails : System.Web.UI.Page
    {
        string id;
        string idinner;
        string prefix;
        string OD;
        int i;
        int j;
        string Order_id;
        string fetchedOrders_Id;
        int z = 1;
        string Emp_Id;
        string Com_Id;

        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database\SalesSahayakDatabase.accdb";
        OleDbConnection con;
        OleDbCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count != 0)
            {
                Emp_Id = Session["Emp_Id"].ToString();
                Com_Id = Session["Com_Id"].ToString();
                fetchedOrders_Id = Request.QueryString["Ord_id"];
                prefix = fetchedOrders_Id.Substring(0, 3);
                OD = fetchedOrders_Id.Substring(3, 2);
                i = Convert.ToInt32(fetchedOrders_Id.Substring(5, 4));
                j = Convert.ToInt32(fetchedOrders_Id.Substring(9, 2));

                CheckOrderStatus();
                BindData();
                BindSingleData();
               
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
        }
        bool loop = true;
        string Statustemp;
        int Payment_Receivedtemp;
        int Total_Valuetemp;
        string PaymentStatustemp;
        void CheckOrderStatus()
        {
            
            string query = "Select * from Orders where Order_Id='"+fetchedOrders_Id+"'";
            //string query = "SELECT Orders_Id, Orders_Date, Customer_Id,Status,Follow_Up,FollowUpDate FROM Orders where Orders_Id='" + ll + "'";
            con = new OleDbConnection(connectionString);
            con.Open();
            cmd = new OleDbCommand(query, con);
            OleDbDataReader myreader = cmd.ExecuteReader();
            if (myreader.Read())
            {
                //System.Diagnostics.Debug.WriteLine(" Check Order Status Run");
                Statustemp = myreader["Status"].ToString();
                Payment_Receivedtemp = Convert.ToInt32(myreader["Payment_Received"].ToString());
               
                Total_Valuetemp = Convert.ToInt32(myreader["Total_Value"].ToString());
                PaymentStatustemp = myreader["Payment_Status"].ToString();
            }
            
            if (Payment_Receivedtemp >= Total_Valuetemp && PaymentStatustemp!="Done")
            {
             //   System.Diagnostics.Debug.WriteLine("Payment Received vs Total value Run");
                UpdatePaymentStatus();
                BindSingleData();
            }
            if (Statustemp == "Delivered" && Payment_Receivedtemp >= Total_Valuetemp)
            {
                //System.Diagnostics.Debug.WriteLine("Statustemp and PaymentReceived run");
                CompleteOrder();
            }
            con.Close();
            BindSingleData();


        }
        void UpdatePaymentStatus()
        {
            string query = "Update Orders Set Payment_Status='" + "Done" + "' where Order_Id='"+fetchedOrders_Id+"'";
            //string query = "SELECT Orders_Id, Orders_Date, Customer_Id,Status,Follow_Up,FollowUpDate FROM Orders where Orders_Id='" + ll + "'";
            con = new OleDbConnection(connectionString);
            con.Open();
            cmd = new OleDbCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            BindSingleData();
        }
        void CompleteOrder()
        {
            string query = "Update Orders Set Order_Completed='" + "TRUE" + "' where Order_Id='"+fetchedOrders_Id+"'";
            //string query = "SELECT Orders_Id, Orders_Date, Customer_Id,Status,Follow_Up,FollowUpDate FROM Orders where Orders_Id='" + ll + "'";
            con = new OleDbConnection(connectionString);
            con.Open();
            cmd = new OleDbCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("ShowCompletedOrdersDetails.aspx?Ord_id=" + fetchedOrders_Id);
           
        }
        void BindSingleData()
        {




            string query = "SELECT Orders.Order_Id,Orders.Order_Date,Orders.Customer_Id,Customer.Customer_Name,Orders.Indentor_Name,Orders.Indentor_Email,Orders.Status,Orders.Payment_Received,Orders.Total_Value,Orders.Payment_Status, Orders.Purchase_Order_Number, Orders.Enquiry_Id FROM Customer,Orders where Orders.Customer_Id=" + "Customer.Customer_Id" + " and Orders.Order_Id='" + fetchedOrders_Id + "'";
            //string query = "SELECT Orders_Id, Orders_Date, Customer_Id,Status,Follow_Up,FollowUpDate FROM Orders where Orders_Id='" + ll + "'";
            con = new OleDbConnection(connectionString);
            con.Open();
            cmd = new OleDbCommand(query, con);
            OleDbDataReader myreader = cmd.ExecuteReader();
            if (myreader.Read())
            {
                
                Ord_Id.Text = myreader["Order_Id"].ToString();
                Ord_Date.Text = myreader["Order_Date"].ToString();
                Cust_Id.Text = myreader["Customer_Id"].ToString();
                Cust_Name.Text = myreader["Customer_Name"].ToString();
                Indentor_Name.Text = myreader["Indentor_Name"].ToString();
                Indentor_Email.Text = myreader["Indentor_Email"].ToString();
                status.Text = myreader["Status"].ToString();
                TotalPaymentReceived.Text = myreader["Payment_Received"].ToString();
                Total_Value.Text = myreader["Total_Value"].ToString();
                Payment_Status.Text = myreader["Payment_Status"].ToString();
                Purchase_Order_Number.Text = myreader["Purchase_Order_Number"].ToString();
                Enquiry_Id.Text = myreader["Enquiry_Id"].ToString();
                            }

            con.Close();
            
            if (Emp_Id == "" && Com_Id != "")
            {
                Order_Buttons.Visible = false;
            }




        }
        List<string> Products = new List<string>();
        void BindData()
        {



            DataTable dataTable = new DataTable();

            while (loop)
            {


                id = String.Format("{0:0000}", i);
                idinner = String.Format("{0:00}", j);
                Order_id = prefix +OD+ id + idinner;
                string query = "SELECT  Order_Id,Product_Name, Quantity,Value FROM Orders where Order_Id='" + Order_id + "'";



                try
                {
                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        using (OleDbCommand command = new OleDbCommand(query, connection))
                        {
                            connection.Open();
                            using (OleDbDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    dataTable.Load(reader);

                                }
                                else
                                {
                                    // Handle the case where no data is found

                                    break;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that might have occurred
                    Response.Write("Error: " + ex.Message);
                }


                // Bind the data to the Repeater
                j++;

            }
            DataRepeater.DataSource = dataTable;
            DataRepeater.DataBind();



        }
      



       
       
       
        protected void Back_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("ShowOrders.aspx");
        }
        protected void Edit_Btn(object sender, EventArgs e)
        {
            Response.Redirect("OrderEdit.aspx?Ord_id=" + fetchedOrders_Id);
        }
        protected void OrderDelivered_Click(object sender, EventArgs e)
        {
            string query = "Update Orders set Status='" + "Delivered" + "' where Order_Id='" + fetchedOrders_Id + "'";
            OleDbConnection con = new OleDbConnection(connectionString);
            con.Open();
            OleDbCommand cmd = new OleDbCommand(query, con);
            cmd.ExecuteNonQuery();

            con.Close();

            CheckOrderStatus();
            BindSingleData();
        }
        protected void AddPayment_Click(object sender, EventArgs e)
        {
            Response.Redirect("Payment.aspx?Ord_id=" + fetchedOrders_Id);
        }
    }
}