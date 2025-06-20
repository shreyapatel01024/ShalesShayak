<%@ Page Title="Show Enquiry | SalesSahayak" Language="C#" MasterPageFile="~/Footer.master" AutoEventWireup="true" CodeBehind="ShowEnquiry.aspx.cs" Inherits="SalesSahayak.Components.ShowEnquiry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
            
       <div class="ShowEnquiryTableContent">
    <h2>All Enquiry Data </h2>
           <div class="SearchandStatusSelector">
                <div class="search-bar-box-1">
               <i class="fa fa-search" aria-hidden="true"></i>
               <input type="text" id="enter" onkeyup="searchenquiry()" placeholder="Search..."/>
            </div>
 
          <div class="EnquiryStatusSelector">
           <asp:Label ID="Statuslabel" runat="server" CssClass="StatusLabel" text="Status:-"></asp:Label>
              <asp:DropDownList ID="DropDownList1" CssClass="DropDownList1" runat="server" AutoPostBack="true" ></asp:DropDownList>
              

                        </div>
               </div>
          
        <div class="showEnquiryTableContainer">  
<table class="showEnquiryTable" id="mytable">
    <thead>
            <tr>
        <th>Enquiry_ID</th>
        <th>Enquiry_Date</th>
      
        <th>Customer_Name</th>
        <th>Indentor_Name</th>
        <th>Product_Name</th>
        <th>Quantity</th>
        <th>Value</th>
        <th>Total_Value</th>
        <th>Status</th>
        <th>Follow_Up</th>
         
    </tr>
</thead>
    <tbody>  
    <asp:Repeater ID="DataRepeater" runat="server">
         
        <ItemTemplate>
            
            <tr onclick="window.location.href='ShowEnquiryDetails.aspx?Eq_id=<%# Eval("Enquiry_Id") %>';">
               
                   
                <td > <a href="ShowEnquiryDetails.aspx?Eq_id=<%# Eval("Enquiry_Id") %>" class="EnquiId"><%# Eval("Enquiry_Id") %></a></td>
                 
                <td><%# Eval("Enquiry_Date","{0:dd/MM/yyyy}") %></td>
               
                <td><%# Eval("Customer_Name") %></td>
                <td><%# Eval("Indentor_Name") %></td>
                <td><%# Eval("Product_Name") %></td>
                <td><%# Eval("Quantity") %></td>
                <td><%# Eval("Value") %></td>
                <td><%# Eval("Total_Value") %></td>
                <td><%# Eval("Status") %></td>
                <td><%# Eval("Follow_UP") %></td>
                      
                 
            </tr>
              
            
        </ItemTemplate>
     
        
                
            
        
    </asp:Repeater>
           </tbody>
    </table>
           </div>
</div>
<script type="text/javascript">
        const searchenquiry = () => {
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
