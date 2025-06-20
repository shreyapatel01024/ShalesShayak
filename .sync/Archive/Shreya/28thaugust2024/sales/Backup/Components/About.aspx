<%@ Page Title="About | SalesSahayak" Language="C#" MasterPageFile="~/Footer.master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="SalesSahayak.Components.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="AboutContainer">
        <div class="AboutHeader">
            <h1>About Us</h1>
            <p>Welcome to Our Sales Sahayak Platform</p>
        </div>
        <section class="AboutContent">
            <div class="intro">
                <h2>Who We Are</h2>
                <p>We are a leading provider of sales management solutions, dedicated to helping businesses streamline their sales processes and achieve their goals.</p>
            </div>
            <div class="team">
                <h2>Our Team</h2>
                <p>Our team of experienced professionals is committed to providing top-notch service and support to ensure your success.</p>
                <div class="team-members">
                    <div class="member">
                        <img src="../Images/SatyamImage.png" alt="Team Member 1">
                        <h3>Satyam Jha</h3>
                        <p></p>
                    </div>
                    <div class="member">
                        <img src="../Images/ShreyaImage.jpg" alt="Team Member 2">
                        <h3>Shreya Patel</h3>
                        <p></p>
                    </div>
                    <div class="member">
                        <img src="../Images/DevImage.jpeg" alt="Team Member 3">
                        <h3>Dev Jani</h3>
                        <p></p>
                    </div>
                    <!-- Add more team members as needed -->
                </div>
            </div>
            <div class="mission">
                <h2>Our Mission</h2>
                <p>Our mission is to empower businesses with the tools and insights they need to drive sales and grow their operations.</p>
            </div>
        </section>
    </div>
</asp:Content>
