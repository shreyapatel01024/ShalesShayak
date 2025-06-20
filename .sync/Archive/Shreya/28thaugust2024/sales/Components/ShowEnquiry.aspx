<%@ Page Title="Show Enquiry | SalesSahayak" Language="C#" MasterPageFile="~/Footer.master" AutoEventWireup="true" CodeBehind="ShowEnquiry.aspx.cs" Inherits="SalesSahayak.Components.ShowEnquiry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
            
       <div class="ShowEnquiryTableContent">
    <h2>All Enquiry Data </h2>
          <!-- <div class="EnquiryStatusSelector">
           
               <asp:DropDownList ID="DropDownList1" CssClass="DropDownList1" runat="server"  ></asp:DropDownList>
               
          

               </div>
-->
        <div class="showEnquiryTableContainer">  
<table class="showEnquiryTable">
    <thead>
            <tr>
        <th>Enquiry_ID</th>
        <th>Enquiry_Date</th>
        <th>Customer_ID</th>
        <th>Customer_Name</th> 
        <th>Product_Name</th>
        <th>Quantity</th>
        <th>Value</th>
        <th>Status</th>
        <th>Follow_Up</th>
         
    </tr>
</thead>
    <tbody>  
    <asp:Repeater ID="DataRepeater" runat="server">
         
        <ItemTemplate>
            
            <tr onclick="window.location.href='ShowEnquiryDetails.aspx?Eq_id=<%# Eval("Enquiry_Id") %>';">
               
                   
                <td > <a href="ShowEnquiryDetails.aspx?Eq_id=<%# Eval("Enquiry_Id") %>" class="EnquiId"><%# Eval("Enquiry_Id") %></a></td>
                 
                <td><%# Eval("Enquiry_Date") %></td>
                <td><%# Eval("Customer_Id") %></td>
                <td><%# Eval("Customer_Name") %></td>
                <td><%# Eval("Product_Name") %></td>
                <td><%# Eval("Quantity") %></td>
                <td><%# Eval("Value") %></td>
                <td><%# Eval("Status") %></td>
                <td><%# Eval("Follow_UP") %></td>
                      
                 
            </tr>
              
            
        </ItemTemplate>
     
        
                
            
        
    </asp:Repeater>
           </tbody>
    </table>
           </div>
</div>
    
</asp:Content>
