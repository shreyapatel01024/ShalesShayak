<%@ Page Title="Login | SalesSahayak" Language="C#" MasterPageFile="~/HeaderFLogin.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="SalesSahayak.Components.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="loginbox">
        <div class="leftSpace">

       
        <asp:Image ID="Image1" runat="server" ImageUrl="../Images/imp2.png" CssClass="user" />
        </div>
            <div class="rightspace">
            <h2 class="log">Login</h2>
            <div class="inputbox">
                
                <asp:TextBox runat="server" Class="txtemail" placeholder="Enter ID" ID="emailtext" OnTextChanged="emailtext_TextChanged"  AutoPostBack="True"></asp:TextBox><div class="icon"><i class='bx bxs-user'></i></div>
            </div>
            <div class="inputbox">
                <asp:TextBox ID="passwordtext" runat="server" Class="txtpass" placeholder="********" type="password"></asp:TextBox><div class="iconp"><i id="lockicon" class='bx bxs-lock-alt'></i></div >
                <div class="eyeicon" onclick="PasswordToggle()">
                   
                        <i id="showHidePassword" class="fa fa-eye"></i>
                   
                     </div>                                                                                                                                                                   
                
            </div>
            <asp:LinkButton ID="LinkButton2" runat="server" Class="btnforgot">Forget Password?</asp:LinkButton>
            <asp:Label ID="Alerts" runat="server" ForeColor="Red"></asp:Label>
            <asp:Button ID="SigninBtn" runat="server"  Text="Sign in" Class="btnsubmit" OnClick="SigninBtn_Click1" />

        </div>


    </div>
        
  
    
</asp:Content>
