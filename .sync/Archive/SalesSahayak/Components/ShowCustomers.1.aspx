<%@ Page Title="Show Customer | SalesSahayak" Language="C#" MasterPageFile="~/Footer.master" AutoEventWireup="true" CodeBehind="ShowCustomers.aspx.cs" Inherits="SalesSahayak.Components.ShowCustomers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
       
       <div class="ShowCustomerTableContent">
    <h2>All Customer Data </h2>
        <div class="showCustomerTableContainer">  
<table class="showCustomerTable">
    <thead>
            <tr>
        <th>Customer_ID</th>
        <th>Customer_Name</th> 
        <th>Type</th>
        <th>Email</th>
        <th>Address</th>
        <th>City</th>
        <th>State</th>
         
    </tr>
</thead>
    <tbody>  
    <asp:Repeater ID="DataRepeater3" runat="server">
         
        <ItemTemplate>
            
            <tr onclick="window.location.href='ShowEnquiryDetails.aspx?Eq_id=<%# Eval("Customer_Id") %>';">
               
                   
                <td > <a href="ShowEnquiryDetails.aspx?Eq_id=<%# Eval("Customer_Id") %>" class="CustId"><%# Eval("Customer_Id") %></a></td>
                 
                <td><%# Eval("Customer_Name") %></td>
                <td><%# Eval("Type") %></td>
                <td><%# Eval("Email") %></td>
                <td><%# Eval("Address") %></td>
                <td><%# Eval("City") %></td>
                <td><%# Eval("State") %></td>
                      
                 
            </tr>
              
            
        </ItemTemplate>        
        
    </asp:Repeater>
           </tbody>
    </table>
           </div>
</div>
</asp:Content>
