<%@ Page Title="Completed Orders | SalesSahayak" Language="C#" MasterPageFile="~/Footer.master" AutoEventWireup="true" CodeBehind="ShowCompletedOrders.aspx.cs" Inherits="SalesSahayak.Components.ShowCompletedOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
      <div class="ShowCompletedOrderTableContent">
    <h2>All Completed Orders Data </h2>
        <div class="showCompletedOrderTableContainer">  
<table class="showCompletedOrderTable">
    <thead>
            <tr>
        <th>Order_ID</th>
        <th>Order_Date</th>
        <th>Customer_ID</th>
        <th>Customer_Name</th> 
        <th>Product_Name</th>
        <th>Quantity</th>
        <th>Value</th>
        <th>Status</th>
        
         
    </tr>
</thead>
    <tbody>  
    <asp:Repeater ID="DataRepeater2" runat="server">
         
        <ItemTemplate>
            
            <tr onclick="window.location.href='ShowEnquiryDetails.aspx?Od_id=<%# Eval("Order_Id") %>';">
               
                   
                <td > <a href="ShowEnquiryDetails.aspx?Od_id=<%# Eval("Order_Id") %>" class="CompletedOrderId"><%# Eval("Order_Id") %></a></td>
                 
                <td><%# Eval("Order_Date") %></td>
                <td><%# Eval("Customer_Id") %></td>
                <td><%# Eval("Customer_Name") %></td>
                <td><%# Eval("Product_Name") %></td>
                <td><%# Eval("Quantity") %></td>
                <td><%# Eval("Value") %></td>
                <td><%# Eval("Status") %></td>
                
                      
                 
            </tr>

        </ItemTemplate>        
    </asp:Repeater>
           </tbody>
    </table>
           </div>
</div>
</asp:Content>
