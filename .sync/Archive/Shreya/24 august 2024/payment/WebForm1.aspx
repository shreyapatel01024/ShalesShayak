<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="payment.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    
    <form id="form1" runat="server" class="container">
    <div class="fc">
       <div class="row"">
           <div class="column">
               <h3 class="title">billing address</h3>

               <div class="input-box">
                   <span>company name: </span>
                   <asp:TextBox ID="TextBox1" runat="server" CssClass="text" placeholder="name"></asp:TextBox>
               </div>
               <div class="input-box">
                   <span>company email: </span>
                   <asp:TextBox ID="TextBox2" runat="server" CssClass="text" placeholder="example@example.com"></asp:TextBox>
               </div>
               <div class="input-box">
                   <span>company address: </span>
                   <asp:TextBox ID="TextBox3" runat="server" CssClass="text" placeholder="name"></asp:TextBox>
               </div>
               <div class="input-box">
                   <span>city name: </span>
                   <asp:TextBox ID="TextBox4" runat="server" CssClass="text" placeholder="city"></asp:TextBox>
               </div>
               <div class="flex">
                   <div class="input-box">
                   <span>state name: </span>
                   <asp:TextBox ID="TextBox5" runat="server" CssClass="text" placeholder="name"></asp:TextBox>
               </div>
                   <div class="input-box">
                   <span>zip code: </span>
                   <asp:TextBox ID="TextBox6" runat="server" CssClass="text" placeholder="name"></asp:TextBox>
               </div>
               </div>
           </div>
           <div class="column">
               <h3 class="title">payment</h3>

               <div class="input-box">
                   <span>payment accepted: </span>
                   <asp:Image ID="Image1" runat="server" ImageUrl="~/cash.jpeg" class="img"/>
               </div>
               <div class="input-box">
                   <span>payment mode: </span>
                   <asp:TextBox ID="TextBox8" runat="server" CssClass="text" placeholder="cheque"></asp:TextBox>
               </div>
               <div class="input-box">
                   <span>name </span>
                   <asp:TextBox ID="TextBox9" runat="server" CssClass="text" placeholder="xzy xyz"></asp:TextBox>
               </div>
               <div class="input-box">
                   <span>number: </span>
                   <asp:TextBox ID="TextBox10" runat="server" CssClass="text" placeholder="1234 5678 9012 3456"></asp:TextBox>
               </div>
               <div class="flex">
                   <div class="input-box">
                   <span>recived date: </span>
                   <asp:TextBox ID="TextBox11" runat="server" CssClass="text" placeholder="01/01/2024"></asp:TextBox>
               </div>
                   <div class="input-box">
                   <span>amount: </span>
                   <asp:TextBox ID="TextBox12" runat="server" CssClass="text" placeholder="name"></asp:TextBox>
               </div>
               </div>
           </div>
       </div>
        
        <asp:Button ID="Button1" runat="server" Text="submit" CssClass="btn" />
        </div>
    </form>
</body>
</html>
