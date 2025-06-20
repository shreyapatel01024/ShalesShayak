<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="home.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="box">
       <div class="input-box">
        <div class="1box">
            <div class="box1">
            <asp:Chart ID="Chart1" runat="server" Width="500px" DataSourceID="AccessDataSource1">
                <Series>
                    <asp:Series Name="Series1" ChartType="Line">
                        <Points>
                            <asp:DataPoint AxisLabel="mark" YValues="800" />
                            <asp:DataPoint AxisLabel="mark1" YValues="1000" />
                            <asp:DataPoint AxisLabel="mark2" YValues="400" />
                            <asp:DataPoint AxisLabel="mark3" YValues="100" />
                            <asp:DataPoint AxisLabel="mark4" YValues="0" />
                        </Points>
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
        <div class="box1">
            <asp:Chart ID="Chart2" runat="server" Width="500px">
                <Series>
                    <asp:Series Name="Series1">
                        <Points>
                            <asp:DataPoint AxisLabel="mark" YValues="800" />
                            <asp:DataPoint AxisLabel="mark1" YValues="1000" />
                            <asp:DataPoint AxisLabel="mark2" YValues="400" />
                            <asp:DataPoint AxisLabel="mark3" YValues="100" />
                            <asp:DataPoint AxisLabel="mark4" YValues="0" />
                        </Points>
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
            <asp:Chart ID="Chart3" runat="server" Width="400px">
                <Series>
                    <asp:Series Name="Series1" ChartType="Bar">
                        <Points>
                            <asp:DataPoint AxisLabel="mark" YValues="800" />
                            <asp:DataPoint AxisLabel="mark1" YValues="1000" />
                            <asp:DataPoint AxisLabel="mark2" YValues="400" />
                            <asp:DataPoint AxisLabel="mark3" YValues="100" />
                            <asp:DataPoint AxisLabel="mark4" YValues="0" />
                        </Points>
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
            <asp:Chart ID="Chart4" runat="server" Width="400px">
                <Series>
                    <asp:Series Name="Series1" ChartType="Pie" Legend="Legend1">
                        <Points>
                            <asp:DataPoint AxisLabel="mark" YValues="800" />
                            <asp:DataPoint AxisLabel="mark1" YValues="1000" />
                            <asp:DataPoint AxisLabel="mark2" YValues="400" />
                            <asp:DataPoint AxisLabel="mark3" YValues="100" />
                            <asp:DataPoint AxisLabel="mark4" YValues="0" />
                        </Points>
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
            <asp:Chart ID="Chart5" runat="server">
                <Series>
                    <asp:Series Name="Series1" ChartType="Doughnut" Legend="Legend1">
                        <Points>
                            <asp:DataPoint AxisLabel="mark" YValues="800" />
                            <asp:DataPoint AxisLabel="mark1" YValues="1000" />
                            <asp:DataPoint AxisLabel="mark2" YValues="400" />
                            <asp:DataPoint AxisLabel="mark3" YValues="100" />
                            <asp:DataPoint AxisLabel="mark4" YValues="0" />
                        </Points>
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
            <asp:Chart ID="Chart6" runat="server">
                <Series>
                    <asp:Series Name="Series1" ChartType="Radar">
                        <Points>
                            <asp:DataPoint AxisLabel="mark" YValues="800" />
                            <asp:DataPoint AxisLabel="mark1" YValues="1000" />
                            <asp:DataPoint AxisLabel="mark2" YValues="400" />
                            <asp:DataPoint AxisLabel="mark3" YValues="100" />
                            <asp:DataPoint AxisLabel="mark4" YValues="0" />
                        </Points>
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
    </form>
</body>
</html>
