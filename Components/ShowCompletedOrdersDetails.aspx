<%@ Page Title="Completed Order Details | SalesSahayak" Language="C#" MasterPageFile="~/Footer.master" AutoEventWireup="true" CodeBehind="ShowCompletedOrdersDetails.aspx.cs" Inherits="SalesSahayak.Components.ShowCompletedOrderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
                    <div class="ShowOrderDetailsContent">  
    <h2 class="">Completed Order Details</h2>
           <div class="ShowOrderDetailsContainer">
               <div class="ShowOrderIdContainer">
               <asp:Label ID="Label10" runat="server" Text="Order Id: " CssClass="ShowOrderIdLabel"></asp:Label>  <asp:Label ID="Ord_Id" runat="server" Text="" CssClass="ShowOrderIdText"></asp:Label>
             
                   </div><br />
<asp:Label ID="Label2" runat="server" Text="Order Date: "></asp:Label><asp:Label ID="Ord_Date" runat="server" Text=""></asp:Label>
             <br />
 <asp:Label ID="Label3" runat="server" Text="Customer ID: "></asp:Label><asp:Label ID="Cust_Id" runat="server" Text=""></asp:Label>
               <br />
        <asp:Label ID="Label13" runat="server" Text="Customer Name: "></asp:Label><asp:Label ID="Cust_Name" runat="server" Text=""></asp:Label>
             <br />
                <asp:Label ID="Label18" runat="server" Text="P.O No: "></asp:Label><asp:Label ID="Purchase_Order_Number" runat="server" Text=""></asp:Label>
   <br />
               <asp:Label ID="Label14" runat="server" Text="Indentor Name: "></asp:Label><asp:Label ID="Indentor_Name" runat="server" Text=""></asp:Label>
      <br />
                <asp:Label ID="Label16" runat="server" Text="Indentor Email: "></asp:Label><asp:Label ID="Indentor_Email" runat="server" Text=""></asp:Label>
      <br />
        
           <asp:Label ID="Label15" runat="server" Text="Total Order Value: "></asp:Label><asp:Label ID="Total_Value" runat="server" Text=""></asp:Label>
 <br />
       
        <br />       
           <asp:Repeater ID="DataRepeater" runat="server" >
       
        <ItemTemplate>
          <div class="ShowProductContainers">
            <asp:Label ID="Label12" runat="server" Text="Product " Font-Bold="True"><%# Convert.ToInt32(Eval("Order_Id").ToString().Substring(9,2))+1 %></asp:Label>
          <br />
           
               
             <asp:Label ID="Label1" runat="server" Text="Product: "></asp:Label>
           
                 <asp:Label ID="Label5" runat="server" Text=""><%# Eval("Product_Name") %></asp:Label>
            <br />
     
   <asp:Label ID="Label9" runat="server" Text="Quantity: "></asp:Label>  
                 <asp:Label ID="Label6" runat="server" Text=""><%# Eval("Quantity") %></asp:Label>
                     <br />
  
<asp:Label ID="Label11" runat="server" Text="Value: "></asp:Label>  
                 <asp:Label ID="Label7" runat="server" Text=""><%# Eval("Value") %></asp:Label>
                 
            </div>
                
        </ItemTemplate>
        
    </asp:Repeater>
           <br />
           <br />
           
       <asp:Label ID="Label4" runat="server" Text="Status: "></asp:Label>    <asp:Label ID="status" runat="server" Text=""></asp:Label>
           <br />    <asp:Label ID="Label17" runat="server" Text="Payment Status: "></asp:Label><asp:Label ID="Payment_Status" runat="server" Text=""></asp:Label>

  <br /><asp:Label ID="Label8" runat="server" Text="Total Payment Received: "></asp:Label><asp:Label ID="TotalPaymentReceived" runat="server" Text=""></asp:Label>
          
               <br />
           <br />
              <asp:Button ID="Back" runat="server" Text="Back" type="submit" OnClick="Back_Click"  CssClass="Back_Btn" />
               </div>
</div>
</asp:Content>
