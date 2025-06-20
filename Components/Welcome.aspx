<%@ Page Title="Home | SalesSahayak" Language="C#" MasterPageFile="~/HeaderFLogin.Master" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="SalesSahayak.Components.Welcome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <h1>Empower Your Sales with Sales Sahayak</h1>
        <p>
            At Sales Sahayak, we equip you with the cutting-edge tools and insights needed to elevate your sales game.
            Whether you are managing a small business or part of a large organization, Sales Sahayak helps streamline
            your sales process, making it more efficient and effective.
        </p>

        <!-- Detailed Introduction Section -->
        <div class="intro">
            <h3>About Sales Sahayak</h3>
            <p>
                Sales Sahayak is a comprehensive sales management platform designed to meet the diverse needs of modern businesses.
                Our platform integrates advanced analytics, customer relationship management (CRM), and marketing automation tools
                to provide a holistic solution for boosting your sales performance. 
            </p>
            <p>
                With Sales Sahayak, you can track real-time sales data, gain valuable insights through detailed reports, and optimize
                your strategies for better results. Whether you're a startup looking to scale or an established enterprise aiming
                to refine your sales processes, Sales Sahayak is the partner you need to achieve your goals.
            </p>

            <!-- Moving Images and Videos -->
            <img src="image/chad-yuu-chad-perry.gif" alt="Dynamic Sales Process">
            <img src="image/simpsons-tv.gif" alt="Sales Growth">
            <img src="image/we're-a-team-lois-lane.gif" alt="Customer Engagement">
            <img src="image/team-teamwork.gif" alt="Team Collaboration">
            <p>
                Our user-friendly interface and customizable features ensure that Sales Sahayak adapts to your unique business requirements.
                From lead generation to customer retention, every aspect of your sales funnel is covered. Join the growing number of businesses
                that trust Sales Sahayak to drive their sales success.
            </p>
            <!-- <video controls> -->
                <!-- <source src="../Images/Intro1.mp4" type="video/mp4"> -->
                <!-- Your browser does not support the video tag. -->
            <!-- </video> -->
        </div>

        <a href="LoginPage.aspx" class="cta-button">Get Started Now</a>

        <div class="features">
            <div class="feature-box">
                <i class="fas fa-chart-line"></i>
                <h3>Sales Analytics</h3>
                <p>Get deep insights into your sales performance and make data-driven decisions.</p>
            </div>
            <div class="feature-box">
                <i class="fas fa-users"></i>
                <h3>Customer Management</h3>
                <p>Manage your customers efficiently with our easy-to-use tools.</p>
            </div>
            <div class="feature-box">
                <i class="fas fa-bullhorn"></i>
                <h3>Marketing Automation</h3>
                <p>Automate your marketing efforts and reach the right audience at the right time.</p>
            </div>
        </div>

        <div class="dashboard">
            <div class="chart-container">
                <canvas id="lineChart"></canvas>
            </div>
            <div class="chart-container">
                <canvas id="pieChart"></canvas>
            </div>
            <div class="chart-container">
                <canvas id="donutChart"></canvas>
            </div>
            <div class="chart-container">
                <canvas id="barChart"></canvas>
            </div>
        </div>

        <!-- Team Section -->
        <div class="team">
            <h3>Meet Our Team</h3>
            <div class="team-member">
                <img src="../Images/SatyamImage.png" alt="Founder Photo">
                <h4>Satyam Jha</h4>
                <p>Founder & CEO</p>
            </div>
            <div class="team-member">
                <img src="../Images/ShreyaImage.jpg" alt="Designer Photo">
                <h4>Shreya Patel</h4>
                <p>Lead Designer</p>
            </div>
            <div class="team-member">
                <img src="../Images/DevImage.jpeg" alt="Developer Photo">
                <h4>Dev Jani</h4>
                <p>Lead Developer</p>
               
            </div>
        </div>
    </div>

    <footer>
        <p>&copy; 2024 Sales Sahayak. All Rights Reserved.</p>
    </footer>

    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script>
        // Line Chart
        const ctxLine = document.getElementById('lineChart').getContext('2d');
        const lineChart = new Chart(ctxLine, {
            type: 'line',
            data: {
                labels: ['January', 'February', 'March', 'April', 'May', 'June'],
                datasets: [{
                    label: 'Sales Over Time',
                    data: [15000, 20000, 30000, 25000, 40000, 45000],
                    backgroundColor: 'rgba(156, 39, 176, 0.4)',
                    borderColor: 'rgba(123, 31, 162, 1)',
                    borderWidth: 2,
                    fill: true
                }]
            },
            options: {
                responsive: true,
                plugins: {
                    legend: {
                        display: true,
                        position: 'top'
                    }
                }
            }
        });

        // Pie Chart
        const ctxPie = document.getElementById('pieChart').getContext('2d');
        const pieChart = new Chart(ctxPie, {
            type: 'pie',
            data: {
                labels: ['Product A', 'Product B', 'Product C'],
                datasets: [{
                    label: 'Product Share',
                    data: [30, 40, 30],
                    backgroundColor: [
                        'rgba(186, 104, 200, 0.6)',
                        'rgba(149, 117, 205, 0.6)',
                        'rgba(103, 58, 183, 0.6)'
                    ]
                }]
            },
            options: {
                responsive: true,
                plugins: {
                    legend: {
                        display: true,
                        position: 'top'
                    }
                }
            }
        });

        // Donut Chart
        const ctxDonut = document.getElementById('donutChart').getContext('2d');
        const donutChart = new Chart(ctxDonut, {
            type: 'doughnut',
            data: {
                labels: ['North', 'South', 'East', 'West'],
                datasets: [{
                    label: 'Sales Distribution',
                    data: [25, 25, 25, 25],
                    backgroundColor: [
                        'rgba(126, 87, 194, 0.6)',
                        'rgba(94, 53, 177, 0.6)',
                        'rgba(81, 45, 168, 0.6)',
                        'rgba(69, 39, 160, 0.6)'
                    ]
                }]
            },
            options: {
                responsive: true,
                plugins: {
                    legend: {
                        display: true,
                        position: 'top'
                    }
                }
            }
        });

        // Bar Chart
        const ctxBar = document.getElementById('barChart').getContext('2d');
        const barChart = new Chart(ctxBar, {
            type: 'bar',
            data: {
                labels: ['Q1', 'Q2', 'Q3', 'Q4'],
                datasets: [{
                    label: 'Quarterly Sales',
                    data: [50000, 60000, 55000, 70000],
                    backgroundColor: [
                        'rgba(186, 104, 200, 0.6)',
                        'rgba(149, 117, 205, 0.6)',
                        'rgba(103, 58, 183, 0.6)',
                        'rgba(126, 87, 194, 0.6)'
                    ]
                }]
            },
            options: {
                responsive: true,
                plugins: {
                    legend: {
                        display: true,
                        position: 'top'
                    }
                }
            }
        });
    </script>
</asp:Content>
