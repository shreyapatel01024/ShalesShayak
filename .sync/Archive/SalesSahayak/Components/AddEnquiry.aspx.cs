using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SalesSahayak.Components
{
    public partial class AddEnquiry : System.Web.UI.Page
    {
        private int ControlCounter
        {
            get { return (int)(ViewState["ControlCounter"] ?? 1); }
            set { ViewState["ControlCounter"] = value; }
        }

        private List<string> SelectedValues
        {
            get { return (List<string>)Session["SelectedValues"] ?? new List<string>(); }
            set { Session["SelectedValues"] = value; }
        }

        string id;
        string idinner;
        string prefix;
        string enquiryIdh;
        int i, j;
        string connectionString = @"Provider =Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database\SalesSahayakDatabase.accdb";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Recreate controls on postback
            for (int i = 1; i < ControlCounter; i++)
            {
                CreateDropDownList(i);
            }
            if (!IsPostBack)
            {
                customernamedropdown();
            }
        }

        void customernamedropdown()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                string cmdstring = "SELECT Customer_Name FROM Customer WHERE Company_Id = ?";
                OleDbCommand cmd = new OleDbCommand(cmdstring, conn);
                cmd.Parameters.AddWithValue("@Company_Id", 102);
                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dpdnCustomerName.Items.Insert(0, "Select Customer");
                    dpdnCustomerName.Items.Add(reader[0].ToString());
                }
            }
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            CreateDropDownList(ControlCounter);
            ControlCounter++;
        }

        void addproductcontent()
        {
            HtmlGenericControl AddProductContent = new HtmlGenericControl("div");
            AddProductContent.ID = "AddProductContent";
            phProductDropDowns.Controls.Add(AddProductContent);
        }

        private void CreateDropDownList(int index)
        {
            DropDownList ddl = new DropDownList();
            Label lbproduct = new Label();
            TextBox tbQuanity = new TextBox();
            Button btnremove = new Button();
            Literal lt = new Literal();
            Literal lt1 = new Literal();
            HtmlGenericControl AddProductContainer = new HtmlGenericControl("div");

            if (index == 1)
            {
                addproductcontent();
            }

            AddProductContainer.ID = "AddProductContainer" + index;
            lt.ID = "Product Name" + index;
            lt.Text = "Product Name :  ";
            lt1.ID = "Quantity" + index;
            lt1.Text = "Quantity :  ";
            btnremove.ID = index.ToString();
            btnremove.Text = "Remove";
            btnremove.Click += Removebutton_click;
            btnremove.CommandArgument = index.ToString();
            ddl.CssClass = "ProductDropdown";
            ddl.ID = "ddl_" + index;
            ddl.Items.Insert(0, "Select Product");
            lbproduct.ID = "Product" + index;
            lbproduct.Text = "Product" + index + ": ";
            tbQuanity.ID = "Product" + index + "Quantity";

            string query = "SELECT Product_Name FROM Products WHERE Company_Id = ?";
            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand(query, con);
                cmd.Parameters.AddWithValue("@Company_Id", 102);
                con.Open();
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ddl.Items.Add(dr[0].ToString());
                }
            }

            // Retain selected value
            if (IsPostBack && Request.Form[ddl.UniqueID] != null)
            {
                ddl.SelectedValue = Request.Form[ddl.UniqueID];
            }

            AddProductContainer.Attributes.CssStyle.Add("display", "flex");
            AddProductContainer.Attributes.CssStyle.Add("flex-direction", "column");
            AddProductContainer.Attributes.CssStyle.Add("flex", "1");
            AddProductContainer.Attributes.CssStyle.Add("margin", "15px");
            AddProductContainer.Attributes.CssStyle.Add("width", "290px");
            AddProductContainer.Attributes.CssStyle.Add("border-radius", "7px");
            AddProductContainer.Attributes.CssStyle.Add("background-color", "#CBC3E3");
            AddProductContainer.Attributes.CssStyle.Add("padding", "15px");
            AddProductContainer.Attributes.CssStyle.Add("gap", "15px");
            AddProductContainer.Attributes.CssStyle.Add("box-shadow", "0 4px 8px rgba(0, 0, 0, 0.1)");

           /* btnremove.Attributes.CssStyle.Add("transition", "0.3s");
            btnremove.Attributes.CssStyle.Add("width", "120px");
            btnremove.Attributes.CssStyle.Add("height", "45px");
            btnremove.Attributes.CssStyle.Add("background-color", "#FF474D");
            btnremove.Attributes.CssStyle.Add("box-shadow", "0 0 10px rgba(0,0,0,.1)");
            btnremove.Attributes.CssStyle.Add("cursor", "pointer");
            btnremove.Attributes.CssStyle.Add("font-size", "14px");
           */

            phProductDropDowns.FindControl("AddProductContent").Controls.Add(AddProductContainer);
            phProductDropDowns.FindControl("AddProductContainer" + index).Controls.Add(lbproduct);
            phProductDropDowns.FindControl("AddProductContainer" + index).Controls.Add(lt);
            phProductDropDowns.FindControl("AddProductContainer" + index).Controls.Add(ddl);
            phProductDropDowns.FindControl("AddProductContainer" + index).Controls.Add(lt1);
            phProductDropDowns.FindControl("AddProductContainer" + index).Controls.Add(tbQuanity);
            phProductDropDowns.FindControl("AddProductContainer" + index).Controls.Add(btnremove);
        }
      /*  void addSelectedValues()
        {
            int index = ControlCounter;
            for (int i = 1; i <= index; i++)
            {
                Control containers = phProductDropDowns.FindControl("AddProductContainer" + index);
                DropDownList dp = containers.Controls.OfType<DropDownList>().FirstOrDefault();
                SelectedValues.Add(dp.SelectedValue);
            }
        }
      */
        private void Removebutton_click(object sender, EventArgs e)
        {
            //addSelectedValues();
            Button clickedButton = sender as Button;
            Control container = phProductDropDowns.FindControl("AddProductContainer" + clickedButton.ID);
            if (container != null)
            {
                phProductDropDowns.Controls.Remove(container);
            }

            int index = int.Parse(clickedButton.CommandArgument);

            // Remove the dropdown and shift values
            RemoveDropDownAndShiftValues(index);

            // Recreate controls after removal
            RecreateDropDownLists();
        }

        private void RemoveDropDownAndShiftValues(int indexToRemove)
        {
            if (indexToRemove - 1 < SelectedValues.Count)
            {
                SelectedValues.RemoveAt(indexToRemove - 1);

                // Shift the values from below to fill the gap
                for (int i = indexToRemove - 1; i < SelectedValues.Count; i++)
                {
                    SelectedValues[i] = SelectedValues[i];
                }
            }

            ControlCounter--;
        }

        private void RecreateDropDownLists()
        {
            phProductDropDowns.Controls.Clear();

            // Recreate all dropdowns with their updated values
            for (int i = 1; i < ControlCounter; i++)
            {
                CreateDropDownList(i);
            }
        }

        void fetchenquiryid()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "SELECT MAX(Enquiry_Id) FROM Enquiry WHERE Enquiry_Type = ? AND Company_Id = ? AND Emp_Id = ?";
                cmd.Parameters.AddWithValue("@Enquiry_Type", "MAIN");
                cmd.Parameters.AddWithValue("@Company_Id", 102);
                cmd.Parameters.AddWithValue("@Emp_Id", 2001);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    enquiryIdh = reader[0].ToString();
                    prefix = enquiryIdh.Substring(0, 3);
                    i = Convert.ToInt32(enquiryIdh.Substring(3, 4));
                    j = Convert.ToInt32(enquiryIdh.Substring(7, 2));
                }
            }
        }
        string selectedValue;
        int quantity;
        string customer_id;
        int product_price;
        string getcustomerid(string customername)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "SELECT Customer_Id FROM Customer WHERE Customer_Name = ?";
                cmd.Parameters.AddWithValue("@Customer_Name", customername);
                OleDbDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    return r[0].ToString();
                }
            }
            return null;
        }

        int getproductprice(string ProductName)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "SELECT Product_Price FROM Products WHERE Product_Name = ?";
                cmd.Parameters.AddWithValue("@Product_Name", ProductName);
                OleDbDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    return Convert.ToInt32(r[0]);
                }
            }
            return 0;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            fetchenquiryid();
            i++;
            // Handle the submit event and access the selected values
            for (int z = 1; z < ControlCounter; z++)
            {
                DropDownList ddl = (DropDownList)phProductDropDowns.FindControl("ddl_" + z);
                TextBox tbQuanity = (TextBox)phProductDropDowns.FindControl("Product" + z + "Quantity");
                if (ddl != null && tbQuanity != null)
                {
                    selectedValue = ddl.SelectedValue;
                    quantity = Convert.ToInt32(tbQuanity.Text);
                    if (j == 0)
                    {
                        OleDbConnection conn = new OleDbConnection(connectionString);
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = conn;
                        conn.Open();
                        id = String.Format("{0:0000}", i);
                        idinner = String.Format("{0:00}", j);
                        string enquiry_id = prefix + id + idinner;
                        Label1.Text = enquiry_id;

                        string customername = dpdnCustomerName.SelectedValue;
                        string customerid = getcustomerid(customername);
                        int productprice = getproductprice(selectedValue);
                        int TotalValue = productprice * quantity;
                        DateTime dt = DateTime.Now;
                        var date = dt.Date;
                        cmd.CommandText = "Insert into Enquiry Values('" + enquiry_id + "','" + date + "','" + customerid + "','"+Indentor_Name.Text+"','"+Indentor_Email.Text+"','" + selectedValue + "'," + quantity + "," + TotalValue + ",'" + "Open" + "','" + "Not Done" + "'," + 2001 + "," + 102 + ",'" + "MAIN" + "','" + date + "')";
                        cmd.ExecuteNonQuery();
                        conn.Close();

                    }
                    else
                    {
                        OleDbConnection conn = new OleDbConnection(connectionString);
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = conn;
                        conn.Open();
                        id = String.Format("{0:0000}", i);
                        idinner = String.Format("{0:00}", j);
                        string enquiry_id = prefix + id + idinner;
                        Label1.Text = enquiry_id;
                        string customername = dpdnCustomerName.SelectedValue;
                        string customerid = getcustomerid(customername);
                        int productprice = getproductprice(selectedValue);
                        int TotalValue = productprice * quantity;
                        DateTime dt = DateTime.Now;
                        var date = dt.Date;
                        cmd.CommandText = "Insert into Enquiry Values('" + enquiry_id + "','" + date + "','" + customerid + "','" + Indentor_Name.Text + "','" + Indentor_Email.Text + "','" + selectedValue + "'," + quantity + "," + TotalValue + ",'" + "Open" + "','" + "Not Done" + "'," + 2001 + "," + 102 + ",'" + "PART" + "','" + date + "')";
                        cmd.ExecuteNonQuery();
                        conn.Close();

                    }
                    j++;

                }
            }
            Label1.Text = "Enquiry Added Successfully to Database";
            ControlCounter = 1;
            phProductDropDowns.Controls.Clear();
        }
    }
}