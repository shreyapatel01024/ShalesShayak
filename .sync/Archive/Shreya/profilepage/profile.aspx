<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="profilepage.profile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="profile.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
     <div class="whole">
      <div class="profile-box">
        <div class="profile-input-box">
            <div class="box-img">
                <img src="https://cdn-icons-png.flaticon.com/512/3781/3781986.png" alt="ProfileImg" class="ProfileImg-pro" />
                <div class="box-input">
                   <span>EMPLOYEE ID:</span>
                    <asp:Label ID="Label4" runat="server" Text="Label" CssClass="lbpro"></asp:Label>
                </div>
                <div class="box-input">
                   <span> EMPLOYEE NAME:</span>
                   <asp:Label ID="Label1" runat="server" Text="Label" CssClass="lbpro"></asp:Label>
               </div>
               <div class="box-input">
                   <span> EMPLOYEE GENDER:</span>
                   <asp:Label ID="Label11" runat="server" Text="Label" CssClass="lbpro"></asp:Label>
                </div>
                <div class="box-input">
                   <span>EMPLOYEE AGE:</span>
                   <asp:Label ID="Label3" runat="server" Text="Label" CssClass="lbpro"></asp:Label>
                </div>
            </div>
            <div class="box-img">
               
               <div class="box-input">
                   <span>EMPLOYEE DESIGNATION:</span>
                   <asp:Label ID="Label2" runat="server" Text="Label" CssClass="lbpro"></asp:Label>
               </div>
                <div class="box-input">
                   <span>EMPLOYEE ADDRESS:</span>
                    <asp:Label ID="Label5" runat="server" Text="Label" CssClass="lbpro"></asp:Label>
                </div>
                <div class="box-input">
                   <span>EMPLOYEE EMAIL:</span>
                    <asp:Label ID="Label6" runat="server" Text="Label" CssClass="lbpro"></asp:Label>
                </div>
                <div class="box-input">
                   <span>EMPLOYEE COMPANY EMAIL:</span>
                    <asp:Label ID="Label7" runat="server" Text="Label" CssClass="lbpro"></asp:Label>
                </div>
                <div class="box-input">
                   <span>EMPLOYEE IDENTITY TYPE:</span>
                    <asp:Label ID="Label8" runat="server" Text="Label" CssClass="lbpro"></asp:Label>
                    </div>
                <div class="box-input">
                   <span>EMPLOYEE IDENTITY NUMBER:</span>
                    <asp:Label ID="Label9" runat="server" Text="Label" CssClass="lbpro"></asp:Label>
                </div>
                <div class="box-input">
                   <span>EMPLOYEE MOBILE NUMBER:</span>
                    <asp:Label ID="Label10" runat="server" Text="Label" CssClass="lbpro"></asp:Label>
                </div>
               <div class="box-input">
                   <span>EMPLOYEE QUALIFICATION:</span>
                   <asp:Label ID="Label12" runat="server" Text="Label" CssClass="lbpro"></asp:Label>
               </div>
            </div>
        </div>
      </div>
    </div>
    </form>
</body>
</html>
