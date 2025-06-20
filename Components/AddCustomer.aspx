<%@ Page Title="Add Customer | SalesSahayak" Language="C#" MasterPageFile="~/Footer.master" AutoEventWireup="true" CodeBehind="AddCustomer.aspx.cs" Inherits="SalesSahayak.Components.AddCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

  
    <div class="AddCustomerContent">

       
    <div class="AddCustomerContainer">
        <h2 class="AddCustomerTitle">Add Customer</h2>
       <div class="AllFields">
           
               

               <div class="inputAddCustomer">
                   <span>Customer Name : </span>
                   <asp:TextBox ID="Customer_Name" runat="server" CssClass="text" placeholder="Enter Name"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="Customer_Name" ForeColor="Red"></asp:RequiredFieldValidator></div>
               <div class="inputAddCustomer">
                   <span>Email : </span>
                   <asp:TextBox ID="Email" runat="server" CssClass="text" placeholder="Enter Email"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="Email" ForeColor="Red"></asp:RequiredFieldValidator></div>
               
               <div class="inputAddCustomer">
                   <span>Address : </span>
                   <asp:TextBox ID="Address" runat="server" CssClass="text" placeholder="Enter Address"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="Address" ForeColor="Red"></asp:RequiredFieldValidator></div>
               
               <div class="inputAddCustomer">
                   <span>City : </span>
                   <asp:TextBox ID="City" runat="server" CssClass="text" placeholder="Enter City"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="City" ForeColor="Red"></asp:RequiredFieldValidator></div>
               
               
                <div class="inputAddCustomer">
                   <span>State : </span>
                   <asp:TextBox ID="State" runat="server" CssClass="text" placeholder="Enter State"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="State" ForeColor="Red"></asp:RequiredFieldValidator></div>
               <div class="inputAddCustomer">
                       <span>Mobile No. : </span>
                       <asp:TextBox ID="Mob_No" runat="server" CssClass="text" placeholder="Enter Mobile No"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="Mob_No" ForeColor="Red"></asp:RequiredFieldValidator></div>
           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Only Num Allowed" ControlToValidate="Mob_No" ValidationExpression="^\d+$" ForeColor="Red"></asp:RegularExpressionValidator>
                   <div class="inputAddCustomer">
                   <span>Pincode : </span>
                   <asp:TextBox ID="Pincode" runat="server" CssClass="text" placeholder="Enter Pincode"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="Pincode" ForeColor="Red"></asp:RequiredFieldValidator></div>
           <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*Only Num Allowed" ControlToValidate="Pincode" ValidationExpression="^\d+$" ForeColor="Red"></asp:RegularExpressionValidator>    
               
         <asp:Label runat="server" ID="Success" Text="" CssClass="Success"></asp:Label>
         <asp:Label runat="server" ID="Error" Text="" CssClass="Error"></asp:Label>
        <asp:Button ID="AddCustomerbtn" runat="server" Text="Submit" CssClass="AddCustomerbtn" OnClick="AddCustomerbtn_Click" />
       
    </div>
           </div>
        </div>
   
</asp:Content>
