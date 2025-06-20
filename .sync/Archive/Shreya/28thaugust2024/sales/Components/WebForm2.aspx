<%@ Page Title="" Language="C#" MasterPageFile="~/Footer.master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="SalesSahayak.Components.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container-pay">
        
    <div class="fc">
       <div class="row"">
           <div class="column">
               <h3 class="title">billing address</h3>

               <div class="input-box-pay">
                   <span>company name: </span>
                   <asp:TextBox ID="TextBox1" runat="server" CssClass="text" placeholder="name"></asp:TextBox>
               </div>
               <div class="input-box-pay">
                   <span>company email: </span>
                   <asp:TextBox ID="TextBox2" runat="server" CssClass="text" placeholder="example@example.com"></asp:TextBox>
               </div>
               <div class="input-box-pay">
                   <span>company address: </span>
                   <asp:TextBox ID="TextBox3" runat="server" CssClass="text" placeholder="name"></asp:TextBox>
               </div>
               <div class="input-box-pay">
                   <span>city name: </span>
                   <asp:TextBox ID="TextBox4" runat="server" CssClass="text" placeholder="city"></asp:TextBox>
               </div>
               <div class="flex">
                   <div class="input-box-pay">
                   <span>state name: </span>
                   <asp:TextBox ID="TextBox5" runat="server" CssClass="text" placeholder="name"></asp:TextBox>
               </div>
                   <div class="input-box-pay">
                   <span>zip code: </span>
                   <asp:TextBox ID="TextBox6" runat="server" CssClass="text" placeholder="name"></asp:TextBox>
               </div>
               </div>
           </div>
           <div class="column">
               <h3 class="title">payment</h3>

               <div class="input-box-pay">
                   <span>payment accepted: </span>
                   <asp:Image ID="Image1" runat="server" ImageUrl="~/cash.jpeg" class="img"/>
               </div>
               <div class="input-box-pay">
                   <span>payment mode: </span>
                   <asp:TextBox ID="TextBox8" runat="server" CssClass="text" placeholder="cheque"></asp:TextBox>
               </div>
               <div class="input-box-pay">
                   <span>name </span>
                   <asp:TextBox ID="TextBox9" runat="server" CssClass="text" placeholder="xzy xyz"></asp:TextBox>
               </div>
               <div class="input-box-pay">
                   <span>number: </span>
                   <asp:TextBox ID="TextBox10" runat="server" CssClass="text" placeholder="1234 5678 9012 3456"></asp:TextBox>
               </div>
               <div class="flex">
                   <div class="input-box-pay">
                   <span>recived date: </span>
                   <asp:TextBox ID="TextBox11" runat="server" CssClass="text" placeholder="01/01/2024"></asp:TextBox>
               </div>
                   <div class="input-box-pay">
                   <span>amount: </span>
                   <asp:TextBox ID="TextBox12" runat="server" CssClass="text" placeholder="name"></asp:TextBox>
               </div>
               </div>
           </div>
       </div>
        
        <asp:Button ID="Button1" runat="server" Text="submit" CssClass="btn-pay" />
        </div>
    
    </div>
</asp:Content>
