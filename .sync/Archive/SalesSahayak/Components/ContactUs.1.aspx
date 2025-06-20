<%@ Page Title="Contact Us | SalesSahayak" Language="C#" MasterPageFile="~/Footer.master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="SalesSahayak.Components.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link rel="stylesheet" href="contact1.css"/>
    <div class="main">
        <div class="contactuscontainer">
        <h1>How would you like to contact Sales Shayak?</h1><br />
        <h3>Request a call.</h3><br />
        <p>Give us some info so the right person can get back to you.</p>
            <!---input type text--->
                 <input type="text" value="First Name" name="fname" required="True" ><br />
                 <input type="text" value="Last Name" name="lname" required="True"><br>
            <!---Drop down list-->
                 <select name="jobtitle" id="job_title" required="True">
                    <option value="">--Job Title--</option>
                    <option value="Sales Manager">Sales Manager</option>
                    <option value="Marketing/PR Manager">Marketing/PR Manager</option>
                    <option value="Customer Service Manager">Customer Service Manager</option>
                    <option value="CXO/VP/General Manager">CXO/VP/General Manager</option>
                    <option value="IT Manager">IT Manager</option>
                    <option value="Operation Manager">Operation Manager</option>
                    <option value="Developer /Software Engineer">Developer/Software Engineer</option>
                    <option value="Student/Job Seeker/Personal Interest">Student/Job Seeker/Personal Interest</option>
                    <option value="Other">Other</option>
                 </select><br>
            <!---input type ---> 
                 <input type="email" value="Work Email" name="work_email" required="True"><br />
                 <input type="text" value="Company" name="Company" required="True"><br />
                 <input type="text" value="Employee" name="Employee" required="True"><br />
                 <input type="text" value="Phone" name="Phone" required="True"><br />
             <!---Drop down list-->
                   
  <p style="background-color:azure">Country/Region</p> <select name="Country/Region" id="Country" required="True">
                    <option value="">India</option>
                    <option value="Canada">Canada</option>
                </select><br>

               <input type="text" value="Questions/Comments" name="Questions/Comments" required="True"><br>
    <h6>
        By registering you confirm that you agree to the storing and processing of
        your personal data by Sale Sahayk as described in the
            <a href="#">Privacy</a>
    </h6>
             <!---submit-->
                    <type ="submit" value="CONTACT ME">
        </div>
        <hr />

       
     </div>
</asp:Content>
