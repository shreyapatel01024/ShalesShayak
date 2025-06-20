<%@ Page Title="Profile | SalesSahayak" Language="C#" MasterPageFile="~/Footer.master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="SalesSahayak.Components.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
      <div class="whole">
          
      <div class="profile-box">
          <h2>Profile </h2>
        <div class="profile-input-box">
            <div class="box-img">
                <img src="https://cdn-icons-png.flaticon.com/512/3781/3781986.png" alt="ProfileImg" class="ProfileImg-pro" />
                <div class="box-input">
                   <asp:Label ID="idlabel" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="Id" runat="server" Text="Label" CssClass="lbpro"></asp:Label>
                </div>
                <div class="box-input">
                   <span>Name:</span>
                   <asp:Label ID="Emp_Name" runat="server" Text="Label" CssClass="lbpro"></asp:Label>
               </div>
               <div class="box-input">
                   <span>Gender:</span>
                   <asp:Label ID="gender" runat="server" Text="Label" CssClass="lbpro"></asp:Label>
                </div>
                <div class="box-input">
                   <span>Age:</span>
                   <asp:Label ID="Emp_Age" runat="server" Text="Label" CssClass="lbpro"></asp:Label>
                </div>
            </div>
            <div class="box-img">
               
               <div class="box-input">
                   <span>Designation:</span>
                   <asp:Label ID="Designation" runat="server" Text="Label" CssClass="lbpro"></asp:Label>
               </div>
                <div class="box-input">
                   <span>Address:</span>
                    <asp:Label ID="Address_Emp" runat="server" Text="Label" CssClass="lbpro"></asp:Label>
                </div>
                <div class="box-input">
                   <span>Email:</span>
                    <asp:Label ID="Email" runat="server" Text="Label" CssClass="lbpro"></asp:Label>
                </div>
                <div class="box-input">
                    <span>Moile Number:</span>
                    <asp:Label ID="Mobile_Number" runat="server" Text="Label" CssClass="lbpro"></asp:Label>
                </div>
                <div class="box-input">
                    <span>Qualification:</span>
                    <asp:Label ID="Qualification" runat="server" Text="Label" CssClass="lbpro"></asp:Label>
                </div>
                <!--<div class="box-input">
                   <span>COMPANY ID:</span>
                    <asp:Label ID="Company_Id" runat="server" Text="Label" CssClass="lbpro"></asp:Label>
                </div>-->
                <div class="box-input">
                   <span>Company Name:</span>
                    <asp:Label ID="Company_Name" runat="server" Text="Label" CssClass="lbpro"></asp:Label>
                    </div>
                <div class="box-input">
                   <span>Company Address:</span>
                    <asp:Label ID="Address" runat="server" Text="Label" CssClass="lbpro"></asp:Label>
                </div>
               
            </div>
        </div>
      </div>
    </div>
</asp:Content>
