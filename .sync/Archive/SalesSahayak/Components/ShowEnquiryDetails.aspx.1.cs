using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalesSahayak.Components
{
    public partial class ShowEnquiryDetails : System.Web.UI.Page
    {
        string id;
        string idinner;
        string prefix;
        int i;
        int j;
        string Enqui_id;
        string fetchedEnquiry_Id;
        int z = 1;

        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\jhasa\OneDrive\Desktop\SalesSahayak\SalesSahayak\App_Data\Database\SalesSahayakDatabase.accdb";
        OleDbConnection con;
        OleDbCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            fetchedEnquiry_Id = Request.QueryString["Eq_id"];
            prefix = fetchedEnquiry_Id.Substring(0, 3);

            i = Convert.ToInt32(fetchedEnquiry_Id.Substring(3, 4));
            j = Convert.ToInt32(fetchedEnquiry_Id.Substring(7, 2));
            

            BindData();
            BindSingleData();

        }
        bool loop = true;
        string followfetcheddate;
        string followuptext;
        void updatefollowup(int result, string followuptext)
        {
            if (result < 0 || result == 0 && followuptext != "Not Done")
            {
                string query = "Update Enquiry set Follow_Up='" + "Not Done" + "' where Enquiry_Id='" + fetchedEnquiry_Id + "'";
                con = new OleDbConnection(connectionString);
                con.Open();
                cmd = new OleDbCommand(query, con);
                
                cmd.ExecuteNonQuery();

                con.Close();
                updatefollowuplabel();

            }

        }

        void updatefollowuplabel()
        {
            string query = "SELECT Follow_Up FROM Enquiry where Enquiry_Id='" + fetchedEnquiry_Id + "'";
            con = new OleDbConnection(connectionString);
            con.Open();
            cmd = new OleDbCommand(query, con);
            OleDbDataReader myreader = cmd.ExecuteReader();
            if (myreader.Read())
            {

                followuptext = myreader[0].ToString();
                Followup.Text= followuptext;
            }
            con.Close();

        }
        void BindSingleData()
        {




            string query = "SELECT Enquiry.Enquiry_Id,Enquiry.Enquiry_Date,Enquiry.Customer_Id,Customer.Customer_Name,Enquiry.Indentor_Name,Enquiry.Indentor_Email,Enquiry.Status,Enquiry.Follow_Up,Enquiry.FollowUpDate FROM Customer,Enquiry where Enquiry.Customer_Id=" + "Customer.Customer_Id"+" and Enquiry.Enquiry_Id='"+ fetchedEnquiry_Id + "'";
            //string query = "SELECT Enquiry_Id, Enquiry_Date, Customer_Id,Status,Follow_Up,FollowUpDate FROM Enquiry where Enquiry_Id='" + ll + "'";
            con = new OleDbConnection(connectionString);
            con.Open();
            cmd = new OleDbCommand(query, con);
            OleDbDataReader myreader = cmd.ExecuteReader();
            if (myreader.Read())
            {
                Enq_Id.Text = myreader[0].ToString();
                Eq_Date.Text = myreader[1].ToString();
                Cust_Id.Text = myreader[2].ToString();
                Cust_Name.Text = myreader[3].ToString();
                Indentor_Name.Text = myreader[4].ToString();
                Indentor_Email.Text = myreader[5].ToString();
                status.Text = myreader[6].ToString();
                followuptext = myreader[7].ToString();
                Followup.Text = followuptext;
                followfetcheddate = myreader[8].ToString();
            }
            con.Close();

            int result;
            DateTime followupdatedate = DateTime.Parse(followfetcheddate);
            result= DateTime.Compare(followupdatedate, DateTime.Now);
            updatefollowup(result, followuptext);




        }
        void BindData()
        {


          
            DataTable dataTable = new DataTable();
            
            while (loop)
            {

                
                id = String.Format("{0:0000}", i);
                idinner = String.Format("{0:00}", j);
                Enqui_id = prefix + id + idinner;
                string query = "SELECT  Enquiry_Id,Product_Name, Quantity,Value FROM Enquiry where Enquiry_Id='" + Enqui_id + "'";


                
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

        protected void FollowUp_Click(object sender, EventArgs e)
        {
            DateTime dd = DateTime.Now;
            DateTime dd1 = dd.AddDays(7);
            string date = dd1.ToString("M/d/yyyy");

            string query = "Update Enquiry set Follow_Up='" + "Done" + "',FollowUpDate='" + date + "' where Enquiry_Id='" + fetchedEnquiry_Id + "'";
            OleDbConnection con = new OleDbConnection(connectionString);
            con.Open();
            OleDbCommand cmd = new OleDbCommand(query, con);
            cmd.ExecuteNonQuery();

            con.Close();

            BindSingleData();

            /*  
               query = "Update Enquiry set FollowUpDate='"+date+ "' where Enquiry_Id='" + ll + "'";
               con = new OleDbConnection(connectionString);
              con.Open();
               cmd = new OleDbCommand(query, con);
              cmd.ExecuteNonQuery();

              con.Close();
            */



        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowEnquiry.aspx");
        }

        protected void EnquiryClosed_Click(object sender, EventArgs e)
        {
            string query = "Update Enquiry set Status='" + "Closed" + "' where Enquiry_Id='" + fetchedEnquiry_Id + "'";
            OleDbConnection con = new OleDbConnection(connectionString);
            con.Open();
            OleDbCommand cmd = new OleDbCommand(query, con);
            cmd.ExecuteNonQuery();

            con.Close();

            BindSingleData();
        }
    }
}