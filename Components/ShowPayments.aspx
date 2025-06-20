<%@ Page Title="" Language="C#" MasterPageFile="~/Footer.master" AutoEventWireup="true" CodeBehind="ShowPayments.aspx.cs" Inherits="SalesSahayak.Components.ShowPayments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
          <div class="ShowPaymentTableContent">
    <h2>All Payments Data </h2>
          <div class="SearchandStatusSelector">
                      <div class="search-bar-box-1">
   <i class="fa fa-search" aria-hidden="true"></i>
   <input type="text" id="enter" onkeyup="searchPayment()" placeholder="Search..."/>
</div>
              </div>
        <div class="showPaymentTableContainer">  
<table class="showPaymentTable" id="mytable">
       
    <thead>
            <tr>
        <th>Payment_ID</th>
        <th>Payment_Date</th>
        
        <th>Transaction /Cheque Id</th> 
        <th>Payment_Value</th> 
        <th>Order_Id</th> 
        
        
         
    </tr>
</thead>
    <tbody>  
    <asp:Repeater ID="DataRepeater1" runat="server">
         
        <ItemTemplate>
            
            <!--<tr onclick="window.location.href='ShowPaymentDetails.aspx?Payment_id=';">-->
               
                   
                <td ><%# Eval("Payment_Id") %></></td>
                 
                <td><%# Eval("Payment_Date","{0:dd/MM/yyyy}") %></td>
                <td><%# Eval("Transaction_Id/Cheque_No") %></td>
                <td><%# Eval("Payment_Value") %></td>
                <td><%# Eval("Order_Id") %></td>
                
                
                      
                 
            </tr>
              
            
        </ItemTemplate>
     
        
                
            
        
    </asp:Repeater>
           </tbody>
    </table>
           </div>
</div>
     <script type="text/javascript">
    const searchPayment = () => {
        let filter = document.getElementById('enter').value.toUpperCase();
        let mytable = document.getElementById('mytable');
        let tr = mytable.getElementsByTagName('tr');
        for (var i = 0; i < tr.length; i++) {
            let td = tr[i].getElementsByTagName('td')[4];
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
