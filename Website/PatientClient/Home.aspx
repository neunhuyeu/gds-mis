<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
    <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    <script src="Scripts/jquery.slides.min.js"></script>
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
</asp:Content>

