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
    public partial class AddOrder : System.Web.UI.Page
    {
        //!---ControlCounter for Counting the Products Containers
        private int ControlCounter
        {
            get { return (int)(ViewState["ControlCounter"] ?? 1); }
            set { ViewState["ControlCounter"] = value; }
        }

        //!---This is to Store Selected Values of Select Product Dropdown menu
        private List<string> SelectedValues
        {
            get { return (List<string>)Session["SelectedValues"] ?? new List<string>(); }
            set { Session["SelectedValues"] = value; }
        }

        //!---Global Variables to Store OrdersId Parts
        string id; //!--- To store Main Orders Id
        string idinner;//!--- To store Part Orders Id
        string prefix;//!--- To store Prefix of the Company
        string OD;//!--- To Store OD 
        string fetchedOrderId; //!--- To Store Fetched Orders Id Temperary

        //!--- To Store Emp_Id and Com_Id from Session
        string Emp_Id;
        string Com_Id;

        //!--- To Store Main OrdersId,Part Orders Id
        int i, j;

        //!--- Connection String
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database\SalesSahayakDatabase.accdb";

        //!--- For Shifting the Values from one dropdown and textbox to other when one add product container is removed 
        bool recreation = false;
        bool recreationRE = false;

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session.Count != 0)
            {
                Error.Text = "";
                Success.Text = "";
                if (!IsPostBack)
                {
                    Emp_Id = Session["Emp_Id"].ToString();
                    Com_Id = Session["Com_Id"].ToString();
                    dpdnCustomerName.Items.Insert(0, new ListItem("Select Customer", "0"));
                    customernamedropdown();
                }
                

                if (Emp_Id == "" && Com_Id == "")
                {
                    Response.Redirect("LoginPage.aspx");
                }

                for (int i = 1; i < ControlCounter; i++)
                {
                    CreateDropDownList(i);
                }
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
        }

        //!--- CustomerDropdown Populating 
        void customernamedropdown()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                string cmdstring = "SELECT Customer_Name FROM Customer WHERE Company_Id = ? and Emp_Id= ?";
                OleDbCommand cmd = new OleDbCommand(cmdstring, conn);
                cmd.Parameters.AddWithValue("@Company_Id", Com_Id);
                cmd.Parameters.AddWithValue("@Emp_Id", Emp_Id);
                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {


                    dpdnCustomerName.Items.Add(reader[0].ToString());
                }
            }
        }
        //!--- AddProduct Button Clickevent
        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            Emp_Id = Session["Emp_Id"].ToString();
            Com_Id = Session["Com_Id"].ToString();
            Error.Text = "";
            Success.Text = "";
            CreateDropDownList(ControlCounter);
            ControlCounter++;
        }

        //!--- Adding one main Content div in which all the product containers will be stored in webpage
        void addproductcontent()
        {
            HtmlGenericControl AddProductContent = new HtmlGenericControl("div");
            AddProductContent.ID = "AddProductContent";
            phProductDropDowns.Controls.Add(AddProductContent);
        }

        //!--- Lists for Storing Product Dropdown selected Value and Quantity textbox Value in these
        List<int> ProductList = new List<int>();
        List<string> ProductQuantityList = new List<string>();
        List<int> ProductList0 = new List<int>();
        List<string> ProductQuantityList0 = new List<string>();

        //!--- Main CreateDropDownList function which is responsible for all dynamically added components on webpage
        private void CreateDropDownList(int index)
        {
            //!--- Fetching Emp_Id and Com_Id from Session 
            Emp_Id = Session["Emp_Id"].ToString();
            Com_Id = Session["Com_Id"].ToString();

            //!--- All Controls Definition
            DropDownList ddlProduct = new DropDownList();
            HtmlGenericControl ddlproductdiv = new HtmlGenericControl("div");
            HtmlGenericControl quantitydiv = new HtmlGenericControl("div");
            Label lbproduct = new Label();
            TextBox tbQuanity = new TextBox();
            Button btnremove = new Button();
            Literal lt = new Literal();
            Literal lt1 = new Literal();
            RequiredFieldValidator requiredfvddlproduct = new RequiredFieldValidator();
            RequiredFieldValidator requiredfvquantity = new RequiredFieldValidator();
            RegularExpressionValidator regularev = new RegularExpressionValidator();



            //!--- Creating the Container for one product dropdown, textbox for quantity and remove button
            HtmlGenericControl AddProductContainer = new HtmlGenericControl("div");

            //!--- Add Content div when we first click on the add product button
            if (index == 1)
            {
                addproductcontent();
            }

            AddProductContainer.ID = "AddProductContainer" + index; //!--- Container Id Assigning

            lt.ID = "Product Name" + index; //!--- Assigning the Id to Label(Product)
            lt.Text = "Product Name :  ";  //!--- Assigning Text to Label(Product)
            lt1.ID = "Quantity" + index;   //!--- Assigning the Id to Label(Quantity)
            lt1.Text = "Quantity :  ";     //!--- Assigning the Text to Label(Quantity)

            btnremove.ID = index.ToString();  //!--- Assigning Id to remove Button
            btnremove.Text = "Remove";         //!--- Assigning Text to remove Button
            btnremove.Click += Removebutton_click;    //!--- Assigning ClickEvent to remove Button 
            btnremove.CommandArgument = index.ToString();   //!--- Some Command Argument in which the number will be passed to the click event to know which remove button is clicked
            btnremove.CausesValidation = false;

            ddlProduct.CssClass = "ProductDropdown";  //!--- Product DropdownList Css Class   
            ddlProduct.ID = "ddlProduct_" + index;   //!--- Assigning Id to Product DropdownList 
            ddlProduct.Items.Insert(0, new ListItem("Select Product", "0"));  //!--- Inserting one Default Select Product on first position

            lbproduct.ID = "Product" + index;   //!--- Assigning Id to Label(Product)
            lbproduct.Text = "Product " + index + ": "; //!--- Assigning text to Label(Product)
            tbQuanity.ID = "Product" + index + "Quantity";  //!--- Assigning Id to Label(Quantity)

            //!--- Validations for Controls
            requiredfvddlproduct.ControlToValidate = ddlProduct.ID;
            requiredfvddlproduct.ErrorMessage = "*";
            requiredfvddlproduct.InitialValue = "0";
            requiredfvddlproduct.ForeColor = System.Drawing.Color.Red;
            requiredfvquantity.ControlToValidate = tbQuanity.ID;
            requiredfvquantity.ErrorMessage = "*";
            requiredfvquantity.ForeColor = System.Drawing.Color.Red;
            regularev.ControlToValidate = tbQuanity.ID;
            regularev.ErrorMessage = "*Only Num Allowed";
            regularev.ForeColor = System.Drawing.Color.Red;
            regularev.ValidationExpression = "^\\d+$";

            //!--- Assigning Id to Div Quantity and Ddl product
            ddlproductdiv.ID = "ddlproduct" + index;
            quantitydiv.ID = "ddlquantity" + index;

            //!--- Connection for Fetching and Populating the Product Dropdownlist
            string query = "SELECT Product_Name FROM Products WHERE Company_Id =" + Com_Id;
            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand(query, con);

                con.Open();
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ddlProduct.Items.Add(dr[0].ToString());
                }
            }

            // Retain selected value
            if (IsPostBack && Request.Form[ddlProduct.UniqueID] != null)
            {
                ddlProduct.SelectedValue = Request.Form[ddlProduct.UniqueID];
            }

            //!--- If Condition if Remove Button Clicked
            if (recreationRE == true)
            {
                ddlProduct.SelectedIndex = ProductList0[index - 1];
                tbQuanity.Text = ProductQuantityList0[index - 1];
            }
            if (recreation == true)
            {

                ddlProduct.SelectedIndex = ProductList[index - ProductList0.Count - 1];
                tbQuanity.Text = ProductQuantityList[index - ProductList0.Count - 1];
            }

            //!--- AddProductContainer Css attributes
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

            //!--- ddlProduct Css Attributes
            ddlProduct.Attributes.CssStyle.Add("box-shadow", "0 1px 8px 0 rgba(0, 0, 0, 0), 0 2px 10px 0 rgba(0, 0, 0, 0.19)");
            ddlProduct.Attributes.CssStyle.Add("background", "white");
            ddlProduct.Attributes.CssStyle.Add("border", "2px");
            ddlProduct.Attributes.CssStyle.Add("border-color", "mediumpurple");
            ddlProduct.Attributes.CssStyle.Add("border-radius", "5px");
            ddlProduct.Attributes.CssStyle.Add("height", "23px");
            ddlProduct.Attributes.CssStyle.Add("Width", "100%");


            //!--- tbQuantity Css Attributes
            tbQuanity.Attributes.CssStyle.Add("width", "100%");

            //!--- ddlproductdiv
            ddlproductdiv.Attributes.CssStyle.Add("display", "flex");

            //!--- quantitydiv
            quantitydiv.Attributes.CssStyle.Add("display", "flex");
            //!---btnremove css Attributes


            //!--- requiredfvddlproduct Css Attributes
            requiredfvddlproduct.Attributes.CssStyle.Add("margin-left", "2px");

            //!--- requiredfvquantity Css Attributes
            requiredfvquantity.Attributes.CssStyle.Add("margin-left", "2px");


            //!--- regularev Css Attribues
            regularev.Attributes.CssStyle.Add("font-size", "small");
            regularev.Attributes.CssStyle.Add("margin-top", "-10px");


            //!--- Label Product Css Attributes
            lbproduct.Attributes.CssStyle.Add("font-weight", "bold");
            /* btnremove.Attributes.CssStyle.Add("transition", "0.3s");
             btnremove.Attributes.CssStyle.Add("width", "120px");
             btnremove.Attributes.CssStyle.Add("height", "45px");
             btnremove.Attributes.CssStyle.Add("background-color", "#FF474D");
             btnremove.Attributes.CssStyle.Add("box-shadow", "0 0 10px rgba(0,0,0,.1)");
             btnremove.Attributes.CssStyle.Add("cursor", "pointer");
             btnremove.Attributes.CssStyle.Add("font-size", "14px");
            */

            //!--- For Storing the Controls to Placeholder
            phProductDropDowns.FindControl("AddProductContent").Controls.Add(AddProductContainer);

            phProductDropDowns.FindControl("AddProductContainer" + index).Controls.Add(lbproduct);
            phProductDropDowns.FindControl("AddProductContainer" + index).Controls.Add(lt);
            phProductDropDowns.FindControl("AddProductContainer" + index).Controls.Add(ddlproductdiv);
            phProductDropDowns.FindControl("ddlproduct" + index).Controls.Add(ddlProduct);
            phProductDropDowns.FindControl("ddlproduct" + index).Controls.Add(requiredfvddlproduct);
            phProductDropDowns.FindControl("AddProductContainer" + index).Controls.Add(lt1);
            phProductDropDowns.FindControl("AddProductContainer" + index).Controls.Add(quantitydiv);
            phProductDropDowns.FindControl("ddlquantity" + index).Controls.Add(tbQuanity);
            phProductDropDowns.FindControl("ddlquantity" + index).Controls.Add(requiredfvquantity);
            phProductDropDowns.FindControl("AddProductContainer" + index).Controls.Add(regularev);

            phProductDropDowns.FindControl("AddProductContainer" + index).Controls.Add(btnremove);
        }



        int counter;

        //!--- Remove Button Click Event
        private void Removebutton_click(object sender, EventArgs e)
        {
            //!--- Fetching Emp_Id and Com_Id from Session 
            Emp_Id = Session["Emp_Id"].ToString();
            Com_Id = Session["Com_Id"].ToString();

            //!--- Get the button that was clicked
            Button removeButton = (Button)sender;
            int indexToRemove = Convert.ToInt32(removeButton.CommandArgument);
            System.Diagnostics.Debug.WriteLine("Indextoremove" + indexToRemove);

            //!--- Loop through the controls starting from the index to remove 
            //!--- If Condition if we are removing the First Product Container 
            if (indexToRemove == 1)
            {
                for (int i = indexToRemove; i < ControlCounter - 1; i++)
                {
                    //!--- Get the current dropdown and quantity textbox
                    DropDownList currentDropdown = (DropDownList)phProductDropDowns.FindControl("ddlProduct_" + i);
                    TextBox currentTextbox = (TextBox)phProductDropDowns.FindControl("Product" + i + "Quantity");

                    //!--- Get the next dropdown and quantity textbox
                    DropDownList nextDropdown = (DropDownList)phProductDropDowns.FindControl("ddlProduct_" + (i + 1));
                    TextBox nextTextbox = (TextBox)phProductDropDowns.FindControl("Product" + (i + 1) + "Quantity");


                    //!--- If the next controls exist, shift the values to the current controls
                    if (nextDropdown != null && nextTextbox != null)
                    {
                        currentDropdown.SelectedValue = nextDropdown.SelectedValue;
                        currentTextbox.Text = nextTextbox.Text;

                        //!--- Storing the Product Dropdown selected value to list Product List
                        ProductList.Add(currentDropdown.SelectedIndex);

                        //!--- Storing the Quantity Textbox value to list ProductQuantity List
                        ProductQuantityList.Add(currentTextbox.Text);

                    }
                }
            }
            //!--- If Condition if we are removeing some other container but not first
            else if (indexToRemove > 1)
            {
                //!--- Loop till we reach to Indextoremove Container this
                for (int j = 1; j < indexToRemove; j++)
                {
                    DropDownList currentDropdown = (DropDownList)phProductDropDowns.FindControl("ddlProduct_" + j);
                    TextBox currentTextbox = (TextBox)phProductDropDowns.FindControl("Product" + j + "Quantity");

                    //!--- Storing the Product Dropdown selected value to list Product0 List
                    ProductList0.Add(currentDropdown.SelectedIndex);

                    //!--- Storing the Quantity Textbox value to list ProductQuantity0 List
                    ProductQuantityList0.Add(currentTextbox.Text);


                }

                //!--- Main Loop for Shifting Values to above Product Container
                for (int i = indexToRemove; i < ControlCounter - 1; i++)
                {
                    // Get the current dropdown and quantity textbox
                    DropDownList currentDropdown = (DropDownList)phProductDropDowns.FindControl("ddlProduct_" + i);
                    TextBox currentTextbox = (TextBox)phProductDropDowns.FindControl("Product" + i + "Quantity");

                    // Get the next dropdown and quantity textbox
                    DropDownList nextDropdown = (DropDownList)phProductDropDowns.FindControl("ddlProduct_" + (i + 1));
                    TextBox nextTextbox = (TextBox)phProductDropDowns.FindControl("Product" + (i + 1) + "Quantity");


                    // If the next controls exist, shift the values to the current controls
                    if (nextDropdown != null && nextTextbox != null)
                    {
                        currentDropdown.SelectedValue = nextDropdown.SelectedValue;
                        currentTextbox.Text = nextTextbox.Text;

                        //!--- Storing the Product Dropdown selected value to list Product List
                        ProductList.Add(currentDropdown.SelectedIndex);

                        //!--- Storing the Quantity Textbox value to list ProductQuantity List
                        ProductQuantityList.Add(currentTextbox.Text);

                    }
                }
            }


            // Now remove the last control (since its value has been shifted up)
            Control Container = phProductDropDowns.FindControl("AddProductContainer" + (ControlCounter - 1));
            Control lastDropdown = phProductDropDowns.FindControl("ddlProduct_" + (ControlCounter - 1));
            Control lastTextbox = phProductDropDowns.FindControl("Product" + (ControlCounter - 1) + "Quantity");
            Control lastRemoveButton = phProductDropDowns.FindControl((ControlCounter - 1).ToString());
            phProductDropDowns.Controls.Remove(Container);
            //if (lastDropdown != null) phProductDropDowns.Controls.Remove(lastDropdown);
            //if (lastTextbox != null) phProductDropDowns.Controls.Remove(lastTextbox);
            //if (lastRemoveButton != null) phProductDropDowns.Controls.Remove(lastRemoveButton);
            phProductDropDowns.Controls.Clear();
            // Decrease the control counter
            ControlCounter--;

            //!--- If Index to Remove is Greater then 1
            if (indexToRemove > 1)
            {
                //!--- Loop For recreation of Containers till IndextoRemove
                for (int i = 1; i < indexToRemove; i++)
                {
                    recreationRE = true;
                    CreateDropDownList(i);

                }
                if (ProductList.Count > 0)
                {

                    recreationRE = false;
                    //!--- Loop For Recreation of Containers from Index to Remove
                    for (int i = indexToRemove; i < ControlCounter; i++)
                    {
                        recreation = true;
                        CreateDropDownList(i);
                    }
                }
            }
            //!--- If Index to Remove is 1 or less
            else
            {
                //!-- For Recretion of Containers 
                for (int i = 1; i < ControlCounter; i++)
                {
                    recreation = true;
                    CreateDropDownList(i);
                }
            }
            recreation = false;
            recreationRE = false;


        }


        //!--- Function For Fetching the Last or Max Orders Id in Database
        void fetchedorderid()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd1 = new OleDbCommand();
                cmd1.Connection = conn;
                conn.Open();
                cmd1.CommandText = "SELECT MAX(Order_Id) FROM Orders WHERE Order_Type = ? AND Company_Id =" + Com_Id;
                cmd1.Parameters.AddWithValue("@Order_Type", "MAIN");

                OleDbDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read() && !reader1.IsDBNull(0))
                {
                    fetchedOrderId = reader1[0].ToString();
                    prefix = fetchedOrderId.Substring(0, 3);
                    OD= fetchedOrderId.Substring(3, 2);
                    i = Convert.ToInt32(fetchedOrderId.Substring(5, 4));
                    j = Convert.ToInt32(fetchedOrderId.Substring(9, 2));
                }
                else
                {

                    conn.Close();
                    OleDbCommand cmd2 = new OleDbCommand();
                    conn.Open();
                    cmd2.Connection = conn;
                    cmd2.CommandText = "SELECT Short_Identifier FROM Company WHERE Company_Id =" + Com_Id;

                    OleDbDataReader reader2 = cmd2.ExecuteReader();
                    if (reader2.Read())
                    {
                        prefix = reader2[0].ToString();
                        OD = "OD";
                        i = 0;
                        j = 0;
                    }
                    conn.Close();
                }
            }
        }
        //!--- Global Varibales for Storing Some Important Data Temperary
        string selectedValue;
        int TotalOrdersValue=0;
        int quantity;
        string customer_id;
        int product_price;

        //!--- Function to Get Total Value of Orders
        int getTotalOrdersValue()
        {
            for (int z = 1; z < ControlCounter; z++)
            {
                DropDownList ddlProduct = (DropDownList)phProductDropDowns.FindControl("ddlProduct_" + z);
                TextBox tbQuanity = (TextBox)phProductDropDowns.FindControl("Product" + z + "Quantity");
                string customername = dpdnCustomerName.SelectedValue;
                string customerid = getcustomerid(customername);
                selectedValue = ddlProduct.SelectedValue;
                quantity = Convert.ToInt32(tbQuanity.Text);
                int productprice = getproductprice(selectedValue);
                int TotalProductValue = productprice * quantity;
                TotalOrdersValue += TotalProductValue;
            }
            return TotalOrdersValue;

        }

        bool CheckForEmptyFields()
        {

            for (int z = 1; z < ControlCounter; z++)
            {
                DropDownList ddlProduct = (DropDownList)phProductDropDowns.FindControl("ddlProduct_" + z);
                TextBox tbQuanity = (TextBox)phProductDropDowns.FindControl("Product" + z + "Quantity");

                if (ddlProduct.SelectedIndex == 0 || tbQuanity.Text == "")
                {
                    return false;
                }


            }
            return true;
        }

        //!--- Function to Get CustomerId using Customer Name ,Returns String
        string getcustomerid(string customername)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "SELECT Customer_Id FROM Customer WHERE Customer_Name = ? AND Company_Id=" + Com_Id;
                cmd.Parameters.AddWithValue("@Customer_Name", customername);
                OleDbDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    return r[0].ToString();
                }
            }
            return null;
        }

        //!--- Function to Get the Product Price using Product Name ,Returns Int
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

        //!--- Submit Button Click Event
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //!--- Fetching Emp_Id and Com_Id from Session 
            Emp_Id = Session["Emp_Id"].ToString();
            Com_Id = Session["Com_Id"].ToString();
            
               
                fetchedorderid(); //!--- Calling the fetchedorderid to get Last or Max Orders Id

                i++;  //!--- Increaing the Main Orders Id by one

                // Handle the submit event and access the selected values
                if (ControlCounter > 1)
                {
                Error.Text = "";
                Success.Text = "";
                for (int z = 1; z < ControlCounter; z++)
                    {
                        //!--- Getting Controls From Placeholderr
                        DropDownList ddlProduct = (DropDownList)phProductDropDowns.FindControl("ddlProduct_" + z);
                        TextBox tbQuanity = (TextBox)phProductDropDowns.FindControl("Product" + z + "Quantity");

                        if (ddlProduct != null && tbQuanity != null)
                        {
                            //!--- Getting Values from Product Dropdown list and Quantity textbox to Variables
                            selectedValue = ddlProduct.SelectedValue;
                            quantity = Convert.ToInt32(tbQuanity.Text);

                            //!-- Connection and Storing the Orders for Main Orders
                            if (j == 0)
                            {
                                OleDbConnection conn = new OleDbConnection(connectionString);
                                OleDbCommand cmd = new OleDbCommand();
                                cmd.Connection = conn;
                                conn.Open();

                                id = String.Format("{0:0000}", i);
                                idinner = String.Format("{0:00}", j);
                                string Orders_id = prefix + OD + id + idinner;  //!--- Merging all the Parts of Orders Id 
                                                                                //Label1.Text = Orders_id;

                                string customername = dpdnCustomerName.SelectedValue;   //!--- Storing Customer Dropdown Selected Value to Variable
                                string customerid = getcustomerid(customername);     //!--- Calling the GetCustomerId function and storing return value to variable
                                int productprice = getproductprice(selectedValue);   //!--- Calling the get Productprice function and storing retunr value to varible
                                int TotalProductValue = productprice * quantity;     //!--- To get TotalProductValue
                                TotalOrdersValue = getTotalOrdersValue();           //!--- Calling get TotalOrdersValue to get Total OrdersValue 
                                int ReceivedPayment = Convert.ToInt32(Advance_Payment.Text);
                                string PaymentStatus = "Not Done";
                                selectedValue = ddlProduct.SelectedValue;
                                quantity = Convert.ToInt32(tbQuanity.Text);
                                if (ReceivedPayment >= TotalOrdersValue)
                                {
                                    PaymentStatus = "Done";
                                }
                                //!--- For getting Current Time
                                DateTime dt = DateTime.Now;
                                var date = dt.Date;
                                cmd.CommandText = "Insert into Orders Values('" + Orders_id + "','" + date + "','" + PurchaseOrder_Number.Text + "','" + customerid + "','" + Indentor_Name.Text + "','" + Indentor_Email.Text + "','" + selectedValue + "'," + quantity + "," + TotalProductValue + "," + TotalOrdersValue + ",'" + "Received" + "','" + Advance_Payment.Text + "','" + PaymentStatus + "','" + "MAIN" + "'," + Emp_Id + ",'" + "NULL" + "'," + Com_Id + ",'" + "FALSE" + "')";
                                cmd.ExecuteNonQuery();
                                conn.Close();

                            }

                            //!--- Connection and Storing the Orders for Part Orders
                            else
                            {
                                OleDbConnection conn = new OleDbConnection(connectionString);
                                OleDbCommand cmd = new OleDbCommand();
                                cmd.Connection = conn;
                                conn.Open();

                                id = String.Format("{0:0000}", i);
                                idinner = String.Format("{0:00}", j);
                                string Orders_id = prefix + OD + id + idinner;  //!--- Merging all the Parts of Orders Id 
                                                                                // Label1.Text = Orders_id;
                                string customername = dpdnCustomerName.SelectedValue; //!--- Storing Customer Dropdown Selected Value to Variable
                                string customerid = getcustomerid(customername);   //!--- Calling the GetCustomerId function and storing return value to variable
                                int productprice = getproductprice(selectedValue);  //!--- Calling the get Productprice function and storing retunr value to varible
                                int TotalProductValue = productprice * quantity;  //!--- To get TotalProductValue
                                int ReceivedPayment = Convert.ToInt32(Advance_Payment.Text);
                                string PaymentStatus = "Not Done";
                                if (ReceivedPayment >= TotalOrdersValue)
                                {
                                    PaymentStatus = "Done";
                                }

                                selectedValue = ddlProduct.SelectedValue;
                                quantity = Convert.ToInt32(tbQuanity.Text);
                                //!--- For getting Current Time
                                DateTime dt = DateTime.Now;
                                var date = dt.Date;
                                cmd.CommandText = "Insert into Orders Values('" + Orders_id + "','" + date + "','" + PurchaseOrder_Number.Text + "','" + customerid + "','" + Indentor_Name.Text + "','" + Indentor_Email.Text + "','" + selectedValue + "'," + quantity + "," + TotalProductValue + "," + 0 + ",'" + "Received" + "','" + Advance_Payment.Text + "','" + PaymentStatus + "','" + "PART" + "'," + Emp_Id + ",'" + "NULL" + "'," + Com_Id + ",'" + "FALSE" + "')";
                                cmd.ExecuteNonQuery();
                                conn.Close();

                            }
                            j++;   //!--- Increaing the Part Orders Value 

                        }
                    }
                Success.Text = "Order Added Successfully to Database";
                clearall();
            }
                else
                {
                Error.Text = "*Please Add Minimum One Product";
            }
            

        }

      

        void clearall()
        {
            ControlCounter = 1;
            phProductDropDowns.Controls.Clear();
            dpdnCustomerName.SelectedIndex = 0;
            Indentor_Email.Text = "";
            Indentor_Name.Text = "";
            PurchaseOrder_Number.Text = "";
            Advance_Payment.Text = "";
        }

    }
}