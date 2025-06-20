<%@ Page Title="Add Customer | SaleSahayak" Language="C#" MasterPageFile="~/Footer.master" AutoEventWireup="true" CodeBehind="AddCustomer.aspx.cs" Inherits="SalesSahayak.Components.AddCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

  
    <div class="AddCustomerContent">
        
    <div class="AddCustomerContainer">
        <h2 class="AddCustomerTitle">Add Customer</h2>
       <div class="AllFields">
           
               

               <div class="inputAddCustomer">
                   <span>Customer Name : </span>
                   <asp:TextBox ID="Customer_Name" runat="server" CssClass="text" placeholder="Enter Name"></asp:TextBox>
               </div>
               <div class="inputAddCustomer">
                   <span>Email : </span>
                   <asp:TextBox ID="Email" runat="server" CssClass="text" placeholder="Enter Email"></asp:TextBox>
               </div>
               <div class="inputAddCustomer">
                   <span>Address : </span>
                   <asp:TextBox ID="Address" runat="server" CssClass="text" placeholder="Enter Address"></asp:TextBox>
               </div>
               <div class="inputAddCustomer">
                   <span>City : </span>
                   <asp:TextBox ID="City" runat="server" CssClass="text" placeholder="Enter City"></asp:TextBox>
               </div>
               
                   <div class="inputAddCustomer">
                   <span>State : </span>
                   <asp:TextBox ID="State" runat="server" CssClass="text" placeholder="Enter State"></asp:TextBox>
               </div>
                   <div class="inputAddCustomer">
                   <span>Pincode : </span>
                   <asp:TextBox ID="Pincode" runat="server" CssClass="text" placeholder="Enter Pincode"></asp:TextBox>
               
                   </div>
          <asp:Label runat="server" ID="Status" Text="hello"></asp:Label>
           </div>
           
           
       
               
        
        <asp:Button ID="AddCustomerbtn" runat="server" Text="Submit" CssClass="AddCustomerbtn" OnClick="AddCustomerbtn_Click" />
        </div>
    
    </div>
</asp:Content>
