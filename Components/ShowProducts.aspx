<%@ Page Title="" Language="C#" MasterPageFile="~/Footer.master" AutoEventWireup="true" CodeBehind="ShowProducts.aspx.cs" Inherits="SalesSahayak.Components.ShowProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div class="ShowProductsTableContent">
    <h2>Products </h2>
          <div class="SearchandStatusSelector">
                      <div class="search-bar-box-1">
   <i class="fa fa-search" aria-hidden="true"></i>
   <input type="text" id="enter" onkeyup="searchProduct()" placeholder="Search..."/>
</div>
              </div>
        <div class="showProductsTableContainer">  
<table class="showPaymentTable" id="mytable">
       
    <thead>
            <tr>
        <th>Product_Name</th>
        <th>Product_Price</th>
        
        
        
        
         
    </tr>
</thead>
    <tbody>  
    <asp:Repeater ID="DataRepeater1" runat="server">
         
        <ItemTemplate>
            
            <tr onclick="window.location.href='ShowProductsDetail.aspx?Product_id=<%# Eval("Product_Id") %>';">
                   
                <td ><%# Eval("Product_Name") %></td> 
                <td><%# Eval("Product_Price") %></td>
                
                
                      
                 
            </tr>
              
            
        </ItemTemplate>
     
        
                
            
        
    </asp:Repeater>
           </tbody>
    </table>
           </div>
</div>
     <script type="text/javascript">
    const searchProduct = () => {
        let filter = document.getElementById('enter').value.toUpperCase();
        let mytable = document.getElementById('mytable');
        let tr = mytable.getElementsByTagName('tr');
        for (var i = 0; i < tr.length; i++) {
            let td = tr[i].getElementsByTagName('td')[0];
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
