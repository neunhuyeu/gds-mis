<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="StyleSheets/Home.css" />
    <link rel="stylesheet" type="text/css" href="StyleSheets/LogIn.css" />
    <title>Fontys Medical Center</title>
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
                    <td>
                    <td><asp:Label ID="patientName" runat="server" Text=""></asp:Label>
                    </td>
                 <form id="FormLogin" runat="server">
                    <div id="logform">
                    <nav>
                    <ul id="log">
                      <li id="login"><a id="login-trigger" href="#">Log in</a>
                        <div id="login-content">
                        <fieldset id="inputs">                                                                                 
                        <asp:TextBox ID="txtUserName" runat="server" placeholder="Your email address" type="email"></asp:TextBox>                                                                                        
                        <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                        <fieldset id="actions">                                                                                
                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="submit" OnClick="btnLogin_Click"></asp:Button>                                                                            
                        <%--<asp:CheckBox ID="chkRemember" runat="server" Checked="true"></asp:CheckBox>Remember me
                                  </fieldset>
                                <a href="#" style="float:right;">Forgot password?</a>--%>
                        </div>
                        </li>
                    </ul>
                    </nav>
                    </div>
                 </form>
        </td>
        </tr>
            </table>
              <nav>
              <ul class="nav">
                <li><a href="#">HOME</a></li>
                <li><a href="#">LATEST NEWS</a></li>
                <li><a href="AboutUs.aspx">ABOUT US</a></li>
                <li><a href="Appointments.aspx">APPOINTMENTS</a></li>
                <li><a href="OpeningHours.aspx">OPENING HOURS</a></li>
                <li><a href="ContactUs.aspx">CONTACT US</a></li>
              </ul>
            </nav>
     </div>
        <div id="slides">
          <img src="Images/slider-1.jpg" />
          <img src="Images/slider-2.jpg" />
          <img src="Images/slider-3.jpg" />
          <img src="Images/slider-4.jpg" />
        </div>
        <hr />
        <div id="main">
            <p id="welcome-message"><span id="w">W</span>elcome to The Fontys Medical Center, a private medical practice based in Eindhoven that aims to provide a high quality healthcare service to the students of The Fontys University of Applied Science.  We also welcome patient students from all over the world living-in or visiting our city. Our doctors provide a comprehensive range of traditional family medicine services with a personal approach.  To ensure convenience to our patients, same-day appointments and online appointments are available.  Medications are dispensed on-site and some investigations can also be carried out within the clinic. We also have direct billing arrangements with some health insurance companies. The staff pride themselves in maintaining the highest standards of care, tailoring medical requirements to individual needs and offering excellence in clinical management.
            </p>
        </div>
    </div>
   </div>
    <hr />
 <div id="footer-wrap">

</div>

  <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
  <script src="js/jquery.slides.min.js"></script>
   <!-- Begin SlidesJS -->
  <script>
      $(function () {
          $('#slides').slidesjs({
              width: 940,
              height: 528,
              play: {
                  active: true,
                  auto: true,
                  interval: 4000,
                  swap: true
              }
          });
      });
  </script>
  <!-- End SlidesJS  -->
</body>
</html>
