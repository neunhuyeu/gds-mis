<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LogIn.aspx.cs" Inherits="LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="Scripts/jquery-1.11.1.min.js"></script>
    <div class="logInPage">
        <h3>Please Log in!</h3>
    <asp:Login 
                ID="LoginControl1" 
                runat="server" 
                DestinationPageUrl="~/Home.aspx"
                 FailureText="Username or password is not correct!"
                OnAuthenticate="MyLogin_Authenticate">
    </asp:Login>
    </div>
</asp:Content>

