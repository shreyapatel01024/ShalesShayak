<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="product.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="tables">
        <div class="last-appointment">
            <div class="heading">
                <h2>ADD  PRODUCTS</h2>
            </div>
                    <table class="appointments">
                        <thead>
                            <tr class="thread-td">
                                <td>Sr no.</td>
                                <td>Produt name</td>
                                <td>Product Quantity</td>
                                <td>Add</td>
                            </tr>
                        </thead>

                        <tbody>
                            <tr class="thread-tr">
                                <td><asp:Label ID="Label1" runat="server" Text="1"></asp:Label></td>
                                <td><asp:Label ID="Label2" runat="server" Text="product1"></asp:Label></td>
                                <td>
                                    <asp:Button ID="Button3" runat="server" Text="-" Class="btn" /><asp:TextBox ID="TextBox1" runat="server" Class="qty"></asp:TextBox><asp:Button ID="Button4" runat="server" Text="+" class="btn1"/></td>
                                <td><asp:Button ID="Button1" runat="server" Text="ADD" /></td>
                            </tr>
                            <tr class="thread-tr">
                               <td><asp:Label ID="Label5" runat="server" Text="2"></asp:Label></td>
                                <td><asp:Label ID="Label6" runat="server" Text="product2"></asp:Label></td>
                                <td>
                                    <asp:Button ID="Button5" runat="server" Text="-" Class="btn" /><asp:TextBox ID="TextBox2" runat="server" Class="qty"></asp:TextBox><asp:Button ID="Button6" runat="server" Text="+" class="btn1"/></td>
                                <td><asp:Button ID="Button7" runat="server" Text="ADD" /></td>
                            </tr>
                            <tr class="thread-tr">
                                <td><asp:Label ID="Label7" runat="server" Text="3"></asp:Label></td>
                                <td><asp:Label ID="Label8" runat="server" Text="product3"></asp:Label></td>
                                <td>
                                    <asp:Button ID="Button8" runat="server" Text="-" Class="btn" /><asp:TextBox ID="TextBox3" runat="server" Class="qty"></asp:TextBox><asp:Button ID="Button9" runat="server" Text="+" class="btn1"/></td>
                                <td><asp:Button ID="Button10" runat="server" Text="ADD" /></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
        <div class="docter-visiting">
            <div class="heading1">
                
                    <h2>REMOVE PRODUCTS</h2>
            </div>
            <table class="appointments">
                <thread>
                    <tr class="thread-td1">
                       <td>Sr no.</td>
                       <td>Produt name</td>
                       <td>Product Quantity</td>
                       <td>Add</td>
                    </tr>
                </thread>
                <tbody>
                    <tr class="thread-tr">
                        <td><asp:Label ID="Label3" runat="server" Text="1"></asp:Label></td>
                        <td><asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></td>
                        <td><asp:Button ID="Button11" runat="server" Text="-" Class="btn" /><asp:TextBox ID="TextBox4" runat="server" Class="qty"></asp:TextBox><asp:Button ID="Button12" runat="server" Text="+" class="btn1"/></td>
                        <td><asp:Button ID="Button2" runat="server" Text="REMOVE" /></td>
                    </tr>
                </tbody>
            </table>
        </div>
      </div>
    </form>
</body>
</html>
