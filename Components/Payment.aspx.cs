using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalesSahayak.Components
{
    public partial class Payment : System.Web.UI.Page
    {
        string Emp_Id;
        string Com_Id;
        string prefix;
        string PA;
        int i;
        int j;
        string payment_Id;
     //   string Order_id;
        string fetchedOrders_Id;
        int fetchedPayment_Received;
      //  int z = 1;

        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database\SalesSahayakDatabase.accdb";
        OleDbConnection con;
        OleDbCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count != 0)
            {
                if (!IsPostBack)
                {
                    dpdnPaymentType.Items.Add("Cheque");
                    dpdnPaymentType.Items.Add("NEFT");
                    dpdnPaymentType.Items.Add("UPI");
                   // dpdnPaymentType.Items.Add("Bank Transfer");
                    dpdnPaymentType.Items.Add("Cash");
                    dpdnPaymentType.Items.Insert(0, new ListItem("Select Payment Type","0"));

                }
                fetchedOrders_Id = Request.QueryString["Ord_id"];

                Emp_Id = Session["Emp_Id"].ToString();
                Com_Id = Session["Com_Id"].ToString();
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }

        }

        void getPaymentId()
        {
            con = new OleDbConnection(connectionString);
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Select MAX(Payment_Id) from Payment where Company_Id=" + Com_Id;
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read() && !reader.IsDBNull(0)) {
               payment_Id=reader[0].ToString();
                
            }
            else
            {
                fetchedOrders_Id = Request.QueryString["Ord_id"];
                prefix = fetchedOrders_Id.Substring(0, 3);
                PA = "PA";
                string id = "0000";
                payment_Id = prefix + PA + id;
            }
            prefix = payment_Id.Substring(0, 3);
            PA = payment_Id.Substring(3, 2);
            i = Convert.ToInt32(payment_Id.Substring(5, 4));

            con.Close();
        }
        void AddPaymentamttoOrder()
        {
            int TotalPaymentReceived = fetchedPayment_Received + Convert.ToInt32(Payment_Value.Text);
            con = new OleDbConnection(connectionString);
            cmd = new OleDbCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "Update Orders Set Payment_Received=" + TotalPaymentReceived + " where Order_Id='" + fetchedOrders_Id + "'";
            cmd.ExecuteNonQuery();
            con.Close();
        }
        void getpaymentreceived()
        {
           
            con = new OleDbConnection(connectionString);
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Select Payment_Received from Orders where Order_Id='" + fetchedOrders_Id + "'";
            OleDbDataReader reader= cmd.ExecuteReader();
            if (reader.Read())
            {
                fetchedPayment_Received= Convert.ToInt32(reader[0].ToString());
            }
            con.Close();
        }
        string id;

        protected void BackBtn_Click(object sender, EventArgs e)

        {
            fetchedOrders_Id = Request.QueryString["Ord_id"];
            Response.Redirect("ShowOrderDetails.aspx?Ord_id=" + fetchedOrders_Id);
        }
        protected void btnPayment_Click(object sender, EventArgs e)
        {
            getPaymentId();
            i++;
            getpaymentreceived();
            AddPaymentamttoOrder();
            id = String.Format("{0:0000}", i);
            payment_Id = prefix + PA + id;
            con = new OleDbConnection(connectionString);
            cmd = new OleDbCommand();
            DateTime Paymentdatetemp = DateTime.Parse(Payment_Date.Text);
            var PaymentDate = Paymentdatetemp.Date;
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "Insert into Payment Values('" + payment_Id + "','" + dpdnPaymentType.SelectedValue + "','" + Transaction_Id.Text + "'," + Payment_Value.Text + ",'"+ PaymentDate + "','" + fetchedOrders_Id + "',"+Emp_Id+","+Com_Id+")";
            cmd.ExecuteNonQuery();
            con.Close();
            fetchedOrders_Id = Request.QueryString["Ord_id"];
            Response.Redirect("ShowOrderDetails.aspx?Ord_id=" + fetchedOrders_Id);
           
        }

        
    }
}