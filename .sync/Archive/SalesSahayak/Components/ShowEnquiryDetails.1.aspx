<%@ Page Title="Show Enquiry Details | SalesSahayak" Language="C#" MasterPageFile="~/Footer.master" AutoEventWireup="true" CodeBehind="ShowEnquiryDetails.aspx.cs" Inherits="SalesSahayak.Components.ShowEnquiryDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
            
       
            <div class="EnquiryDetailsContent">  
    <h2 class="">Enquiry Details</h2>
           <div class="EnquiryDetailsContainer">
               <div class="EnquiryIdContainer">
               <asp:Label ID="Label10" runat="server" Text="Enquiry Id: " CssClass="EnquiryIdLabel"></asp:Label>  <asp:Label ID="Enq_Id" runat="server" Text="" CssClass="EnquiryIdText"></asp:Label>
             
                   </div><br />
<asp:Label ID="Label2" runat="server" Text="Enquiry Date: "></asp:Label><asp:Label ID="Eq_Date" runat="server" Text=""></asp:Label>
             <br />
 <asp:Label ID="Label3" runat="server" Text="Customer ID: "></asp:Label><asp:Label ID="Cust_Id" runat="server" Text=""></asp:Label>
               <br />
        <asp:Label ID="Label13" runat="server" Text="Customer Name: "></asp:Label><asp:Label ID="Cust_Name" runat="server" Text=""></asp:Label>
             <br />
 <asp:Label ID="Label14" runat="server" Text="Indentor Name: "></asp:Label><asp:Label ID="Indentor_Name" runat="server" Text=""></asp:Label>
      <br />
                <asp:Label ID="Label16" runat="server" Text="Indentor Email: "></asp:Label><asp:Label ID="Indentor_Email" runat="server" Text=""></asp:Label>
      <br />
       
               
           <asp:Repeater ID="DataRepeater" runat="server" >
       
        <ItemTemplate>
          <br />
            <br />
            <asp:Label ID="Label12" runat="server" Text="Product " Font-Bold="True"><%# Convert.ToInt32(Eval("Enquiry_Id").ToString().Substring(7,2))+1 %></asp:Label>
          <br />
           
               
             <asp:Label ID="Label1" runat="server" Text="Product: "></asp:Label>
           
                 <asp:Label ID="Label5" runat="server" Text=""><%# Eval("Product_Name") %></asp:Label>
            <br />
     
   <asp:Label ID="Label9" runat="server" Text="Quantity: "></asp:Label>  
                 <asp:Label ID="Label6" runat="server" Text=""><%# Eval("Quantity") %></asp:Label>
                     <br />
  
<asp:Label ID="Label11" runat="server" Text="Value: "></asp:Label>  
                 <asp:Label ID="Label7" runat="server" Text=""><%# Eval("Value") %></asp:Label>
                 
            
                
        </ItemTemplate>
        
    </asp:Repeater>
           <br />
           <br />
           <br />
       <asp:Label ID="Label4" runat="server" Text="Status: "></asp:Label>    <asp:Label ID="status" runat="server" Text=""></asp:Label>
  <br /><asp:Label ID="Label8" runat="server" Text="FollowUp: "></asp:Label><asp:Label ID="Followup" runat="server" Text=""></asp:Label>
           <br />
           <br />
               <div class="ButtonsContainer">
<asp:Button ID="Button1" runat="server" Text="FollowUp" type="submit" OnClick="FollowUp_Click" CssClass="FollowUp_Btn" />   

<asp:Button ID="Edit" runat="server" Text="Edit" type="submit" CssClass="Edit_Btn"/>
 
<asp:Button ID="OrderConvert" runat="server" Text="OrderConvert" type="submit"  CssClass="OrderConvert_Btn" />

<asp:Button ID="EnquiryClosed" runat="server" Text="EnquiryClosed" type="submit" OnClick="EnquiryClosed_Click"  CssClass="EnquiryClosed_Btn"/>

<asp:Button ID="Back" runat="server" Text="Back" type="submit" OnClick="Back_Click"  CssClass="Back_Btn" />
<br />
                   </div>
               </div>
</div>
               
</asp:Content>
