<%@ Page Title="" Language="C#" MasterPageFile="~/Footer.master" AutoEventWireup="true" CodeBehind="ShowProductsDetail.aspx.cs" Inherits="SalesSahayak.Components.ShowProductsDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div class="ProductsDetailsContent">  
    <h2 class="">Product Details</h2>
           <div class="ProductsDetailsContainer">
               <div class="ProductsIdContainer">
               <asp:Label ID="Label10" runat="server" Text="Product Id: " CssClass="ProductIdLabel"></asp:Label>  <asp:Label ID="Product_Id" runat="server" Text="" CssClass="ProductIdText"></asp:Label>
             
                   </div><br />
<asp:Label ID="Label2" runat="server" Text="Product Name: "></asp:Label><asp:Label ID="Product_Name" runat="server" Text=""></asp:Label>
             <br />
 <asp:Label ID="Label3" runat="server" Text="Product Price: "></asp:Label><asp:Label ID="Product_Price" runat="server" Text=""></asp:Label>
               <br />
        
                                   <div class="ButtonsContainer">
 
                 <div id="Product_Buttons" runat="server">
<asp:Button ID="Edit" runat="server" Text="Edit" type="submit" CssClass="Edit_Btn" OnClick="Edit_Btn"/>
                   
 
<asp:Button ID="Remove" runat="server" Text="Remove" type="submit" OnClick="Remove_Click"  CssClass="Remove_Btn"/>

</div>

<asp:Button ID="Back" runat="server" Text="Back" type="submit" OnClick="Back_Click"  CssClass="Back_Btn" />
<br />
                   </div>
                   </div>
               </div>
                    
</asp:Content>
