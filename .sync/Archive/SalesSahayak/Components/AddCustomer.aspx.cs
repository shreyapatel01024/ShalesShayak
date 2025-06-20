using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace SalesSahayak.Components
{
    public partial class AddCustomer : System.Web.UI.Page
    {
        OleDbConnection conn;
        OleDbCommand cmd;
        string Comp_Id;
        string Empid;
        int Employee_Id;
        int Company_Id;
        string CustomerId;
        string fetchedcustomerid;
        string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database\SalesSahayakDatabase.accdb";
        string prefix;
        int pureid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Empid = Application["Emp_Id"].ToString();
                Comp_Id = Application["Com_Id"].ToString();
                Employee_Id = Convert.ToInt32(Empid);
                Company_Id = Convert.ToInt32(Comp_Id);
            }
            }

        void getmaxCustId()
        {
            conn = new OleDbConnection(connString);
            cmd = new OleDbCommand();
            cmd.Connection= conn;
            conn.Open();
            cmd.CommandText = "Select max(Customer_Id) from Customer where Emp_Id=" + Employee_Id+" and Company_Id="+Company_Id;
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                fetchedcustomerid = dr[0].ToString();
                
            }
           
            
            
            conn.Close();
        }
        string CustomerNametxt, Type, Emailtxt, Addresstxt, Citytxt, Statetxt;
        int Pincodetxt;
        void getdatafromtextboxes()
        {
            CustomerNametxt = Customer_Name.Text;
            Type = "New";
            Emailtxt = Email.Text;
            Addresstxt= Address.Text;
            Citytxt = City.Text;
            Statetxt= State.Text;
            Pincodetxt = Convert.ToInt32(Pincode.Text);
        }
        protected void AddCustomerbtn_Click(object sender, EventArgs e)
        {
            getmaxCustId();
            pureid++;
            CustomerId = prefix + String.Format("{0:0000}", pureid);
            Status.Text = CustomerId;
            getdatafromtextboxes();
            conn = new OleDbConnection(connString);
            cmd = new OleDbCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "Insert into Customer Values('" + CustomerId + "','" + CustomerNametxt + "','" + Type + "','" + Emailtxt + "','" + Addresstxt + "','" + Citytxt + "','" + Statetxt + "'," + Pincodetxt + ","+Empid+","+Company_Id+")";
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}