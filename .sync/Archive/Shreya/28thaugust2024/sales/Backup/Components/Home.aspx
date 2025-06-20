<%@ Page Title="Home | SalesSahayak" Language="C#" MasterPageFile="~/Footer.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SalesSahayak.Components.Home" %>


<asp:Content ID="Content2" runat="server"
    ContentPlaceHolderID="ContentPlaceHolder2">

    <p style="height: 34px; width: 100%; margin-left: 0px";>
        <asp:Label runat="server" ID="WelcomeTextLeft">Welcome </asp:Label>
        <asp:Label runat="server" ID="UserName"  Font-Bold="True"> </asp:Label>
        <asp:Label runat="server" ID="WelcomeTextRight"> to Sales Sahayak</asp:Label>
    </p>
    <div class="Containers">
        <a href="ShowEnquiry.aspx">
        <div class="EnquiryContainer">
            
            <asp:Label ID="EnquiryTxt" runat="server" Text="Enquires" CssClass="Enquirytxt"></asp:Label>

            <asp:Label ID="TotalEnquiryTxt" runat="server" Text="0" CssClass="TotalEnquirytxt"></asp:Label>
            
        </div>
        </a>
        <a href="ShowOrders.aspx">
        <div class="OrderContainer">
            <asp:Label ID="OrderTxt" runat="server" Text="Orders" CssClass="Ordertxt"></asp:Label>

            <asp:Label ID="TotalOrderTxt" runat="server" Text="0" CssClass="TotalOrdertxt"></asp:Label>


        </div>
            </a>
        <a href="ShowCompletedOrders.aspx">
        <div class="CompletedOrderContainer">
            <asp:Label ID="CompletedOrderTxt" runat="server" Text="Completed Orders" CssClass="CompletedOrdertxt"></asp:Label>

            <asp:Label ID="TotalCompletedOrderTxt" runat="server" Text="0" CssClass="TotalCompletedOrdertxt"></asp:Label>
           
        </div>
             </a>
    </div>
</asp:Content>


