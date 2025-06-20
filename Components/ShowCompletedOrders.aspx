<%@ Page Title="Completed Orders | SalesSahayak" Language="C#" MasterPageFile="~/Footer.master" AutoEventWireup="true" CodeBehind="ShowCompletedOrders.aspx.cs" Inherits="SalesSahayak.Components.ShowCompletedOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
      <div class="ShowCompletedOrderTableContent">
    <h2>All Completed Orders Data </h2>
                    <div class="SearchandStatusSelector">
                      <div class="search-bar-box-1">
   <i class="fa fa-search" aria-hidden="true"></i>

   <input type="text" id="enter" onkeyup="searchcompletedorder()" placeholder="Search..."/>
</div>
              </div>
        <div class="showCompletedOrderTableContainer">  
<table class="showCompletedOrderTable" id="mytable">
    <thead>
            <tr>
        <th>Order_ID</th>
     <th>Order_Date</th>
     <th>Customer_Name</th> 
     <th>PO No.</th> 
     <th>Indentor_Name</th> 
     <th>Total_Value</th>
     <th>Status</th>
     <th>Payment_Status</th>
        
         
    </tr>
</thead>
    <tbody>  
    <asp:Repeater ID="DataRepeater2" runat="server">
         
        <ItemTemplate>
            
            <tr onclick="window.location.href='ShowCompletedOrdersDetails.aspx?Ord_id=<%# Eval("Order_Id") %>';">
               
                   
                <td > <a href="ShowCompletedOrdersDetails.aspx?Ord_id=<%# Eval("Order_Id") %>" class="CompletedOrderId"><%# Eval("Order_Id") %></a></td>
                 
                <td><%# Eval("Order_Date","{0:dd/MM/yyyy}") %></td>
                <td><%# Eval("Customer_Name") %></td>
                <td><%# Eval("Purchase_Order_Number") %></td>
                <td><%# Eval("Indentor_Name") %></td>

                <td><%# Eval("Total_Value") %></td>
                <td><%# Eval("Status") %></td>
               
                <td><%# Eval("Payment_Status") %></td>
                
                      
                 
            </tr>

        </ItemTemplate>        
    </asp:Repeater>
           </tbody>
    </table>
           </div>
</div>
     <script type="text/javascript">
const searchcompletedorder = () => {
    let filter = document.getElementById('enter').value.toUpperCase();
    let mytable = document.getElementById('mytable');
    let tr = mytable.getElementsByTagName('tr');
    for (var i = 0; i < tr.length; i++) {
        let td = tr[i].getElementsByTagName('td')[2];
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
