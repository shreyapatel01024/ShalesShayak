﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Footer.master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="SalesSahayak.Components.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div class="AddProductContainer">
             <h2>Add Product</h2>
            
      
                  <div class="AddProductInputBox">
        <asp:Label ID="lblProductName" runat="server" Text="Product Name: " CssClass="form-label"></asp:Label>
        <asp:TextBox ID="Product_Name" CssClass="Product_Name" runat="server" ></asp:TextBox>
                      <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="Product_Name"></asp:RequiredFieldValidator>
         </div>
            
                       <div class="AddProductInputBox">
<asp:Label ID="lblProductPrice" runat="server" Text="Product Price: " CssClass="form-label"></asp:Label>
<asp:TextBox ID="Product_Price" CssClass="Product_Price" runat="server" ></asp:TextBox>
                           <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="Product_Price"></asp:RequiredFieldValidator>
                            
 </div>
                  <asp:RegularExpressionValidator runat="server" ControlToValidate="Product_Price" ErrorMessage="*Only Num Allowed" ValidationExpression="^\d+$" CssClass="ProductPrice_Validation"></asp:RegularExpressionValidator>
       
    
          
             <asp:Label ID="Error" runat="server" Text="" CssClass="Error"></asp:Label>
             <asp:Label ID="Success" runat="server" Text="" CssClass="Success"></asp:Label>

        <asp:Button ID="btnSubmit" runat="server" Text="Submit"  CssClass="AddProductBtn" OnClick="btnSubmit_Click" />
             
       
                 </div>
</asp:Content>
