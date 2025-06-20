<%@ Page Title="Cookie Preferences | SalesSahayak" Language="C#" MasterPageFile="~/Footer.master" AutoEventWireup="true" CodeBehind="CookiePreferences.aspx.cs" Inherits="SalesSahayak.Components.CookiePreferences" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div class="CookiePrefContainer">
        <div class="CookiePrefHeader">
            <h1>Cookie Preferences</h1>
        </div>
        <main>
            <section class="intro">
                <p>We use cookies to enhance your experience on our website. You can choose which cookies to allow or reject. For more details, please refer to our <a href="privacypolicy">Privacy Policy</a>.</p>
            </section>
            <section class="preferences">
                <form id="cookie-form">
                    <fieldset>
                        <legend>Manage Your Cookies</legend>
                        <div class="preference-option">
                            <input type="checkbox" id="essential-cookies" name="cookieType" >
                            <label for="essential-cookies">Essential Cookies (required)</label>
                        </div>
                        <div class="preference-option">
                            <input type="checkbox" id="functional-cookies" name="cookieType">
                            <label for="functional-cookies">Functional Cookies</label>
                        </div>
                        <div class="preference-option">
                            <input type="checkbox" id="analytics-cookies" name="cookieType">
                            <label for="analytics-cookies">Analytics Cookies</label>
                        </div>
                        <button type="submit">Save Preferences</button>
                    </fieldset>
                </form>
            </section>
        </main>
        
    </div>
</asp:Content>
