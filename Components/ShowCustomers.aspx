<%@ Page Title="Show Customer | SalesSahayak" Language="C#" MasterPageFile="~/Footer.master" AutoEventWireup="true" CodeBehind="ShowCustomers.aspx.cs" Inherits="SalesSahayak.Components.ShowCustomers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
       
       <div class="ShowCustomerTableContent">
    <h2>All Customer Data </h2>
           <div class="SearchandStatusSelector">
     <div class="search-bar-box-1">
    <i class="fa fa-search" aria-hidden="true"></i>
    <input type="text" id="enter" onkeyup="searchcustomer()" placeholder="Search..."/>
 </div>
              </div>
        <div class="showCustomerTableContainer">  
<table class="showCustomerTable" id="mytable">
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
            
           <!-- <tr onclick="window.location.href='ShowEnquiryDetails.aspx?Eq_id=';">-->
               
                   
                <td ><%# Eval("Customer_Id") %></td>
                 
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
           <script type="text/javascript">
        const searchcustomer = () => {
            let filter = document.getElementById('enter').value.toUpperCase();
            let mytable = document.getElementById('mytable');
            let tr = mytable.getElementsByTagName('tr');
            for (var i = 0; i < tr.length; i++) {
                let td = tr[i].getElementsByTagName('td')[1];
                if (td) {
                    let textvalue = td.textContent || td.innerHTML;
                    if (textvalue.toUpperCase().indexOf(filter) > -1) {
                        tr[i].style.display = "";
                    }
                    else {
                        tr[i].style.display = "none";
                    }
                }
            }
        }
           </script>
</asp:Content>
