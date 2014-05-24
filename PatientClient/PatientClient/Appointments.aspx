<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Appointments.aspx.cs" Inherits="WebApplication1.Appointments" %>
<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" type="text/css" href="StyleSheets/Home.css" />
    <link rel="stylesheet" type="text/css" href='StyleSheets/main.css'/>
    <title>Fontys Medical Center: About Us</title>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js">
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#login-trigger').click(function () {
                $(this).next('#login-content').slideToggle();
                $(this).toggleClass('active');

                if ($(this).hasClass('active')) $(this).find('span').html('&#x25B2;')
                else $(this).find('span').html('&#x25BC;')
            })
        });
    </script>
</head>
<body>
    <div id="wrap">  
    <div id="container">
		<div id="header-container">
            <table id="header">
                <tr>
                    <td><img  id="logo" src="Images/FontysMedicalCenterLogo.png" /></td>
                    <td><asp:Label ID="patientName" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
              <nav>
              <ul class="nav">
                <li><a href="Home.aspx">HOME</a></li>
                <li><a href="#">LATEST NEWS</a></li>
                <li><a href="#">ABOUT US</a></li>
                <li><a href="Appointments.aspx">APPOINTMENTS</a></li>
                <li><a href="OpeningHours.aspx">OPENING HOURS</a></li>
                <li><a href="ContactUs.aspx">CONTACT US</a></li>
              </ul>
            </nav>
     </div>
        <div id="main">
            <form id="form1" runat="server">
                <DayPilot:DayPilotCalendar ID="DayPilotCalendar1" runat="server" />
            <div id="appointmentsToday">
                <h3 id="history">Appointments History</h3>
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
            </div>
           </form>
        </div>
   </div>
  </div>
    <hr />
 <div id="footer-wrap">

</div>
</body>
</html>

