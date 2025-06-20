<%@ Page Title="Payment | SalesSahayak" Language="C#" MasterPageFile="~/Footer.master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="SalesSahayak.Components.Payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
  
     <div class="AddPaymentContainer">
        
                     
             <h2>Add Payment</h2>
             <div class="AddPaymentInputBox">
        <asp:Label ID="lblPaymentType" runat="server" Text="Payment Type: " CssClass="form-label"></asp:Label>
        <asp:DropDownList ID="dpdnPaymentType" runat="server" CssClass="dpdnPaymentType"></asp:DropDownList>
                   <asp:RequiredFieldValidator runat="server" ErrorMessage="*"  InitialValue="0" ControlToValidate="dpdnPaymentType"></asp:RequiredFieldValidator>  
                 </div>
                               <div class="AddPaymentInputBox">
        <asp:Label ID="lblTransactionId" runat="server" Text="Transaction Id:" CssClass="form-label"></asp:Label>
        <asp:TextBox ID="Transaction_Id" CssClass="Transaction_Id" runat="server" ></asp:TextBox>
                                   <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="Transaction_Id"></asp:RequiredFieldValidator>
         </div>

                  <div class="AddPaymentInputBox">
        <asp:Label ID="lblPaymentValue" runat="server" Text="Payment_Value: " CssClass="form-label"></asp:Label>
        <asp:TextBox ID="Payment_Value" CssClass="Payment_Value" runat="server" ></asp:TextBox>
                      <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="Payment_Value"></asp:RequiredFieldValidator>
         </div>
            <asp:RegularExpressionValidator runat="server" ControlToValidate="Payment_Value" ErrorMessage="*Only Num Allowed" ValidationExpression="^\d+$" CssClass="Payment_Validation"></asp:RegularExpressionValidator>
                   <div class="AddPaymentInputBox">
<asp:Label ID="Label1" runat="server" Text="Payment_Date: " CssClass="form-label"></asp:Label>
                       <asp:TextBox ID="Payment_Date" CssClass="Payment_Value" runat="server" TextMode="Date" ></asp:TextBox>
 
                       <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="Payment_Date"></asp:RequiredFieldValidator>
                                       </div>

          <div class="AddPaymentButtons">
          <asp:Button ID="BackBtn" runat="server" Text="Back" CssClass="ConvertToOrderBtn" OnClick="BackBtn_Click" CausesValidation="false" />
               <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn-payment" OnClick="btnPayment_Click" />
              </div>
        </div>
     
    <asp:Label ID="Status" runat="server" Text=""></asp:Label>

</asp:Content>
