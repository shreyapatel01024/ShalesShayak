<%@ Page Title="Order Edit | SalesSahayak" Language="C#" MasterPageFile="~/Footer.master" AutoEventWireup="true" CodeBehind="OrderEdit.aspx.cs" Inherits="SalesSahayak.Components.OrderEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="EditOrderContainer">
        <h2>Edit Order</h2>
        <div class="EditOrderInputBox">
            <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name: " CssClass="form-label"></asp:Label>
            <asp:DropDownList ID="dpdnCustomerName" runat="server" CssClass="dpdnCustomerName"></asp:DropDownList>
               <asp:RequiredFieldValidator runat="server" ErrorMessage="*"  InitialValue="0" ControlToValidate="dpdnCustomerName"></asp:RequiredFieldValidator>  
            </div>
        <div class="EditOrderInputBox">
            <asp:Label ID="lblPurchaseOrderNumber" runat="server" Text="P.O No. " CssClass="form-label"></asp:Label>
            <asp:TextBox ID="PurchaseOrder_Number" CssClass="PurchaseOrder_Number" runat="server"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="PurchaseOrder_Number" ErrorMessage="*"></asp:RequiredFieldValidator>

            </div>

        <div class="EditOrderInputBox">
            <asp:Label ID="lblIndentorName" runat="server" Text="Indentor Name: " CssClass="form-label"></asp:Label>
            <asp:TextBox ID="Indentor_Name" CssClass="Indentor_Name" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Indentor_Name" ErrorMessage="*"></asp:RequiredFieldValidator>
        </div>
        <div class="EditOrderInputBox">
            <asp:Label ID="lblIndentorEmail" runat="server" Text="Indentor Email: " CssClass="form-label"></asp:Label>
            <asp:TextBox ID="Indentor_Email" CssClass="Indentor_Email" runat="server"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Indentor_Email" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
        <div class="EditOrderInputBox">
            <asp:Label ID="lblAdvancePayment" runat="server" Text="Advance Payment: " CssClass="form-label"></asp:Label>
            <asp:TextBox ID="Advance_Payment" CssClass="Advance_Payment" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Advance_Payment" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
        <asp:RegularExpressionValidator runat="server" ControlToValidate="Advance_Payment" ErrorMessage="*Only Num Allowed" ValidationExpression="^\d+$" CssClass="Advance_Payment_Validation"></asp:RegularExpressionValidator>
        <div>


            <asp:PlaceHolder ID="phProductDropDowns" runat="server"></asp:PlaceHolder>
            <asp:PlaceHolder ID="phQuantity_Value" runat="server"></asp:PlaceHolder>


            <asp:Button ID="btnAddProduct" runat="server" Text="Add Product" CssClass="OrderAddProductBtn" OnClick="btnAddProduct_Click" CausesValidation="false" />

        </div>
         <asp:Label ID="Error" runat="server" Text="" CssClass="Error"></asp:Label>
 <asp:Label ID="Success" runat="server" Text="" CssClass="Success"></asp:Label>
        <div class="EditOrderButtons">


            <asp:Button ID="BackBtn" runat="server" Text="Back" CssClass="EditOrderBtn" OnClick="BackBtn_Click" CausesValidation="false" />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="EditOrderBtn" OnClick="btnSubmit_Click" />

        </div>
    </div>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</asp:Content>
