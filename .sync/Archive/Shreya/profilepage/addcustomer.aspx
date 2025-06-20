<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addcustomer.aspx.cs" Inherits="profilepage.addcustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="addcustomer.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-pay">
        
    <div class="fc">
       <div class="row">
           <div class="column">
               <h3 class="title">customer information</h3>

               <div class="input-box-pay">
                   <span>company id: </span>
                   <asp:TextBox ID="TextBox1" runat="server" CssClass="text" placeholder="123[0-9]"></asp:TextBox>
               </div>
               <div class="input-box-pay">
                   <span>company name: </span>
                   <asp:TextBox ID="TextBox2" runat="server" CssClass="text" placeholder="Nilkamal"></asp:TextBox>
               </div>
               <div class="input-box-pay">
                   <span>company email: </span>
                   <asp:TextBox ID="TextBox3" runat="server" CssClass="text" placeholder="nilkamal@gmail.com"></asp:TextBox>
               </div>
               <div class="input-box-pay">
                   <span>employee id: </span>
                   <asp:TextBox ID="TextBox4" runat="server" CssClass="text" placeholder="NIL000400"></asp:TextBox>
               </div>
               <div class="flex">
                   <div class="input-box-pay">
                   <span>type: </span>
                   <asp:TextBox ID="TextBox5" runat="server" CssClass="text" placeholder="regular/irregular"></asp:TextBox>
               </div>
                   <div class="input-box-pay">
                   <span>date: </span>
                   <asp:TextBox ID="TextBox6" runat="server" CssClass="text" placeholder="DD/MM/YYYY"></asp:TextBox>
               </div>
               </div>
           </div>
           <div class="column">
               <h3 class="title">details</h3>

               <div class="input-box-pay">
                   <span>customer id: </span>
                   <asp:TextBox ID="TextBox7" runat="server" CssClass="text" placeholder="xyz[0-9]"></asp:TextBox>
               </div>
               <div class="input-box-pay">
                   <span>customer name: </span>
                   <asp:TextBox ID="TextBox8" runat="server" CssClass="text" placeholder="NILKAMAL"></asp:TextBox>
               </div>
               <div class="input-box-pay">
                   <span>company address: </span>
                   <asp:TextBox ID="TextBox9" runat="server" CssClass="text" placeholder="xzy xyz"></asp:TextBox>
               </div>
               <div class="input-box-pay">
                   <span>state name: </span>
                   <asp:TextBox ID="TextBox10" runat="server" CssClass="text" placeholder="gujarat"></asp:TextBox>
               </div>
               <div class="flex">
                   <div class="input-box-pay">
                   <span>city name: </span>
                   <asp:TextBox ID="TextBox11" runat="server" CssClass="text" placeholder="bharuch"></asp:TextBox>
               </div>
                   <div class="input-box-pay">
                   <span>pincode: </span>
                   <asp:TextBox ID="TextBox12" runat="server" CssClass="text" placeholder="392001"></asp:TextBox>
               </div>
               </div>
           </div>
       </div>
        
        <asp:Button ID="Button1" runat="server" Text="submit" CssClass="btn-pay" />
        </div>
    
    </div>
    </form>
</body>
</html>
