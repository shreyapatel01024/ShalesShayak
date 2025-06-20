<%@ Page Title="" Language="C#" MasterPageFile="~/Footer.master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SalesSahayak.Components.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <asp:Chart ID="Chart13" runat="server" DataSourceID="AccessDataSource1">
        <Series>
            <asp:Series Name="Series1">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
    <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/Database/SalesSahayakDatabase.accdb" SelectCommand="SELECT [Quantity] FROM [Orders]"></asp:AccessDataSource>

</asp:Content>
