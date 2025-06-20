<%@ Page Title="Home | SalesSahayak" Language="C#" MasterPageFile="~/Footer.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SalesSahayak.Components.Home" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>


<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>


<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>


<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>


<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>


<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>


<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

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

    <div class="box">

      
       <div class="input-box">
        <div class="1box">
            <div class="box1">
            <asp:Chart ID="Chart1" runat="server"  DataSourceID="AccessDataSource1" CssClass="Box1Chart1">
                <Series>
                    <asp:Series Name="Series1" ChartType="Line" XValueMember="Value" YValueMembers="Value">
                       </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisX Title="student marks"></AxisX>
                        <AxisY Title="total"></AxisY>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
                <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/Database/SalesSahayakDatabase.accdb" SelectCommand="SELECT [Value] FROM [Orders]"></asp:AccessDataSource>
        </div>
        <div class="box1">
            <asp:Chart ID="Chart2" runat="server"  DataSourceID="AccessDataSource1" CssClass="Box1Chart2">
                <Series>
                    <asp:Series Name="Series1" XValueMember="Value" YValueMembers="Value">
                        
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisX Title="student marks"></AxisX>
                        <AxisY Title="total"></AxisY>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
        </div>
            <div class="2box">
        <div class="box2">
            <asp:Chart ID="Chart3" runat="server" DataSourceID="AccessDataSource1" CssClass="Box2Chart3">
                <Series>
                    <asp:Series Name="Series1" ChartType="Bar" XValueMember="Value" YValueMembers="Value">
                       
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisX Title="student marks"></AxisX>
                        <AxisY Title="total"></AxisY>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
        <div class="box2">
            <asp:Chart ID="Chart4" runat="server" DataSourceID="AccessDataSource1" CssClass="Box2Chart4">
                <Series>
                    <asp:Series Name="Series1" ChartType="Pie" Legend="Legend1" XValueMember="Value" YValueMembers="Value">
                        
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisX Title="student marks"></AxisX>
                        <AxisY Title="total"></AxisY>
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend Name="Legend1">
                    </asp:Legend>
                </Legends>
            </asp:Chart>
        </div>
        </div>
            <div class="3box">
        <div class="box3">
            <asp:Chart ID="Chart5" runat="server"  DataSourceID="AccessDataSource1" CssClass="Box3Chart5">
                <Series>
                    <asp:Series Name="Series1" ChartType="Doughnut" Legend="Legend1" XValueMember="Value" YValueMembers="Value">
                        
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisX Title="student marks"></AxisX>
                        <AxisY Title="total"></AxisY>
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend Name="Legend1">
                    </asp:Legend>
                </Legends>
            </asp:Chart>
        </div>
        <div class="box3">
            <asp:Chart ID="Chart6" runat="server"  DataSourceID="AccessDataSource1" CssClass="Box3Chart6">
                <Series>
                    <asp:Series Name="Series1" ChartType="Radar" XValueMember="Value" YValueMembers="Value">
                        
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisX Title="student marks"></AxisX>
                        <AxisY Title="total"></AxisY>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
        </div>
           </div>
    
    </div>
</asp:Content>


