<%@ Page Title="Add Enquiry | SalesSahayak" Language="C#" MasterPageFile="~/Footer.master" AutoEventWireup="true" CodeBehind="AddEnquiry.aspx.cs" Inherits="SalesSahayak.Components.AddEnquiry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
                    
         <div class="AddEnquiryContainer">
             <h2>Add Enquiry</h2>
             <div class="AddEnquiryInputBox">
        <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name: " CssClass="form-label"></asp:Label>
        <asp:DropDownList ID="dpdnCustomerName" runat="server"></asp:DropDownList>
                 </div>
                  <div class="AddEnquiryInputBox">
        <asp:Label ID="lblIndentorName" runat="server" Text="Indentor Name: " CssClass="form-label"></asp:Label>
        <asp:TextBox ID="Indentor_Name" CssClass="Indentor_Name" runat="server" ></asp:TextBox>
         </div>
                       <div class="AddEnquiryInputBox">
<asp:Label ID="lblIndentorEmail" runat="server" Text="Indentor Email: " CssClass="form-label"></asp:Label>
<asp:TextBox ID="Indentor_Email" CssClass="Indentor_Email" runat="server" ></asp:TextBox>
 </div>
       <div>
     

    <asp:PlaceHolder ID="phProductDropDowns" runat="server" ></asp:PlaceHolder>
            <asp:PlaceHolder ID="phQuantity_Value" runat="server"></asp:PlaceHolder>

    <asp:Button ID="btnAddProduct" runat="server" Text="Add Product" CssClass="EnquiryAddProductBtn" OnClick="btnAddProduct_Click" />

</div>

        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="AddEnquiryBtn" OnClick="btnSubmit_Click" />
    </div>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        
</asp:Content>
