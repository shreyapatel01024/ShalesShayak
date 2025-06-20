<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="home.WebForm1" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        
        <table class="visiting">
            <tr>
                <td>
                    <asp:Chart ID="Chart1" runat="server">
            <Series>
                <asp:Series Name="Series1" ChartType="Pie" Legend="Legend1">
                <Points>
                <asp:Datapoint AxisLabel="mark" YValues="800" />
                    <asp:Datapoint AxisLabel="mark1" YValues="800" />
                    <asp:Datapoint AxisLabel="mark2" YValues="800" />
                    <asp:Datapoint AxisLabel="mark3" YValues="800" />
                    <asp:Datapoint AxisLabel="mark4" YValues="800" />
                </Points>
                
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                <AxisX Title="student"></AxisX>
                </asp:ChartArea>
            </ChartAreas>
                        <Legends>
                            <asp:Legend Name="Legend1" Title="data">
                            </asp:Legend>
                        </Legends>
        </asp:Chart>

                </td>
                <td>
                    <asp:Chart ID="Chart2" runat="server">
            <Series>
                <asp:Series Name="Series1" YValuesPerPoint="2" ChartType="Bar" Legend="Legend1">
                <Points>
                <asp:Datapoint AxisLabel="mark" YValues="800,0" />
                    <asp:Datapoint AxisLabel="mark1" YValues="700,0" />
                    <asp:Datapoint AxisLabel="mark2" YValues="500,0" />
                    <asp:Datapoint AxisLabel="mark3" YValues="100,0" />
                    <asp:Datapoint AxisLabel="mark4" YValues="1000,0" />
                </Points>
                
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                <AxisX Title="student name"></AxisX>
                <AxisY Title="student marks"></AxisY>
                </asp:ChartArea>
            </ChartAreas>
                        <Legends>
                            <asp:Legend Name="Legend1" Title="data">
                            </asp:Legend>
                        </Legends>
        </asp:Chart>

                </td>
                <td>
                    <asp:Chart ID="Chart3" runat="server">
            <Series>
                <asp:Series Name="Series1">
                <Points>
                <asp:Datapoint AxisLabel="mark" YValues="800" />
                    <asp:Datapoint AxisLabel="mark1" YValues="800" />
                    <asp:Datapoint AxisLabel="mark2" YValues="500" />
                    <asp:Datapoint AxisLabel="mark3" YValues="100" />
                    <asp:Datapoint AxisLabel="mark4" YValues="1000" />
                </Points>
                
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                <AxisX Title="student"></AxisX>
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Chart ID="Chart4" runat="server">
            <Series>
                <asp:Series Name="Series1" ChartType="Pie">
                <Points>
                <asp:Datapoint AxisLabel="mark" YValues="800" />
                    <asp:Datapoint AxisLabel="mark1" YValues="800" />
                    <asp:Datapoint AxisLabel="mark2" YValues="800" />
                    <asp:Datapoint AxisLabel="mark3" YValues="800" />
                    <asp:Datapoint AxisLabel="mark4" YValues="800" />
                </Points>
                
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                <AxisX Title="student"></AxisX>
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
                </td>
                <td><asp:Chart ID="Chart5" runat="server">
            <Series>
                <asp:Series Name="Series1" ChartType="Pie">
                <Points>
                <asp:Datapoint AxisLabel="mark" YValues="800" />
                    <asp:Datapoint AxisLabel="mark1" YValues="800" />
                    <asp:Datapoint AxisLabel="mark2" YValues="800" />
                    <asp:Datapoint AxisLabel="mark3" YValues="800" />
                    <asp:Datapoint AxisLabel="mark4" YValues="800" />
                </Points>
                
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                <AxisX Title="student"></AxisX>
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart></td>
                <td><asp:Chart ID="Chart6" runat="server">
            <Series>
                <asp:Series Name="Series1" ChartType="Pie">
                <Points>
                <asp:Datapoint AxisLabel="mark" YValues="800" />
                    <asp:Datapoint AxisLabel="mark1" YValues="800" />
                    <asp:Datapoint AxisLabel="mark2" YValues="800" />
                    <asp:Datapoint AxisLabel="mark3" YValues="800" />
                    <asp:Datapoint AxisLabel="mark4" YValues="800" />
                </Points>
                
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                <AxisX Title="student"></AxisX>
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart></td>
            </tr>
        </table>
    
        
    </div>
    </form>
</body>
</html>
