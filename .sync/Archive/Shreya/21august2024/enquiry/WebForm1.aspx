<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="enquiry.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
      <div class="container">
            <div class="text">ENQUIRY PAGE</div>
            <form id="form2" runat="server" action="#">
                <div class="form-row">
                    <div class="input-data">
                        <asp:TextBox ID="TextBox1" runat="server" Class="txtcosid" placeholder="ENTER COSTUMER ID HERE"></asp:TextBox>
                        <div class="underline"></div>
                        
                    </div>
                    <div class="input-data">
                         <asp:TextBox ID="TextBox2" runat="server" Class="txtcosid" placeholder="ENTER COSTUMER ID HERE"></asp:TextBox>
                        <div class="underline"></div>
                        
                    </div>
                </div>
                 <div class="form-row">
                    <div class="input-data">
                         <asp:TextBox ID="TextBox3" runat="server" Class="txtcosid" placeholder="ENTER COSTUMER ID HERE"></asp:TextBox>
                        <div class="underline"></div>
                        
                       
                    </div>
                    <div class="input-data">
                         <asp:TextBox ID="TextBox4" runat="server" Class="txtcosid" placeholder="ENTER COSTUMER ID HERE"></asp:TextBox>
                        <div class="underline"></div>
                        
                       
                    </div>
                </div>
                 <div class="form-row">
                    <div class="input-data">
                        <asp:TextBox ID="TextBox5" runat="server" Class="txtcosid" placeholder="ENTER COSTUMER ID HERE"></asp:TextBox>
                        <div class="underline"></div>
                      
                    </div>
                    <div class="input-data">
                         <asp:TextBox ID="TextBox6" runat="server" Class="txtcosid" placeholder="ENTER COSTUMER ID HERE"></asp:TextBox>
                        <div class="underline"></div>
                    </div>
                </div>
                <div class="input-data"><asp:Button ID="Button1" runat="server" Text="SUBMIT" class="btn"/></div>
            </form>
        </div>
</body>
</html>
