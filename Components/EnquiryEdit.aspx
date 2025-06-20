<%@ Page Title="Enquiry Edit | SalesSahayak" Language="C#" MasterPageFile="~/Footer.master" AutoEventWireup="true" CodeBehind="EnquiryEdit.aspx.cs" Inherits="SalesSahayak.Components.EnquiryEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
             <div class="EditEnquiryContainer">
             <h2>Edit Enquiry</h2>
             <div class="EditEnquiryInputBox">
        <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name: " CssClass="form-label"></asp:Label>
        <asp:DropDownList ID="dpdnCustomerName" runat="server" CssClass="dpdnCustomerName"></asp:DropDownList>
           <asp:RequiredFieldValidator runat="server" ErrorMessage="*"  InitialValue="0" ControlToValidate="dpdnCustomerName"></asp:RequiredFieldValidator>          
             </div>
                  <div class="EditEnquiryInputBox">
        <asp:Label ID="lblIndentorName" runat="server" Text="Indentor Name: " CssClass="form-label"></asp:Label>
        <asp:TextBox ID="Indentor_Name" CssClass="Indentor_Name" runat="server" ></asp:TextBox>
       <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="Indentor_Name"></asp:RequiredFieldValidator>

                      </div>
                       <div class="EditEnquiryInputBox">
<asp:Label ID="lblIndentorEmail" runat="server" Text="Indentor Email: " CssClass="form-label"></asp:Label>
<asp:TextBox ID="Indentor_Email" CssClass="Indentor_Email" runat="server" ></asp:TextBox>
   <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="Indentor_Email"></asp:RequiredFieldValidator>
                       </div>
       <div>
    
          
    <asp:PlaceHolder ID="phProductDropDowns" runat="server" ></asp:PlaceHolder>
            <asp:PlaceHolder ID="phQuantity_Value" runat="server"></asp:PlaceHolder>
         
           
    <asp:Button ID="btnAddProduct" runat="server" Text="Add Product" CssClass="EnquiryEditProductBtn" OnClick="btnAddProduct_Click" CausesValidation="false" />

</div>
                  <asp:Label ID="Error" runat="server" Text="" CssClass="Error"></asp:Label>
 <asp:Label ID="Success" runat="server" Text="" CssClass="Success"></asp:Label>
                 <div class="EditEnquiryButtons">

                 
             <asp:Button ID="BackBtn" runat="server" Text="Back" CssClass="EditEnquiryBtn" OnClick="BackBtn_Click" CausesValidation="false" />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="EditEnquiryBtn" OnClick="btnSubmit_Click" />
         
                 </div></div>
    <asp:Label ID="AlertStatus" runat="server" Text=""></asp:Label>
</asp:Content>
