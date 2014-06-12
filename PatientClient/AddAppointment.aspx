<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddAppointment.aspx.cs" Inherits="AddAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 166px;
        }

        .auto-style2 {
            width: 73px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function popupCalendar() {
            var dateField = document.getElementById('dateField');
            // toggle the div
            if (dateField.style.display == 'none')
                dateField.style.display = 'block';
            else
                dateField.style.display = 'none';
        }
    </script>


    <div id="AddAppointmentPage">
        <h3 id="appointmentForm">Appointment Form</h3>
        <div id="dateField" style="display: none;">
            <asp:Calendar ID="calDate" OnSelectionChanged="calDate_SelectionChanged" runat="server" />
        </div>
        <table>
            <tr>
                <td class="auto-style1">Select a doctor:</td>
                <td>
                    <asp:DropDownList ID="DoctorsList"  runat="server">
                        <asp:ListItem Selected="True" Value="last_one"> last_one </asp:ListItem>
                        <asp:ListItem Value="last_two"> last_two </asp:ListItem>
                        <asp:ListItem Value="last_three"> last_three </asp:ListItem>
                        <asp:ListItem Value="last_four"> last_four </asp:ListItem>
                        <asp:ListItem Value="last_five"> last_five </asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                        ControlToValidate="DoctorsList"
                        ErrorMessage="Cannot be empty."
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Pick appointment date:</td>
                <td>
                    <asp:TextBox ID="txtDate" runat="server" />
                    <img src="Images/cal.png" onclick="popupCalendar()" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                        ControlToValidate="txtDate"
                        ErrorMessage="Cannot be empty or in the past."
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Pick time:</td>
                <td>
                    <asp:DropDownList ID="TimeList" runat="server">
                        <asp:ListItem Selected="True" Value="09:00"> 09:00 </asp:ListItem>
                        <asp:ListItem Value="09:30"> 09:30 </asp:ListItem>
                        <asp:ListItem Value="10:00"> 10:00 </asp:ListItem>
                        <asp:ListItem Value="10:30"> 10:30 </asp:ListItem>
                        <asp:ListItem Value="11:00"> 11:00 </asp:ListItem>
                        <asp:ListItem Value="11:30"> 11:30 </asp:ListItem>
                        <asp:ListItem Value="12:00"> 12:00 </asp:ListItem>
                        <asp:ListItem Value="12:30"> 12:30 </asp:ListItem>
                        <asp:ListItem Value="13:00"> 13:00 </asp:ListItem>
                        <asp:ListItem Value="13:30"> 13:30 </asp:ListItem>
                        <asp:ListItem Value="14:00"> 14:00 </asp:ListItem>
                        <asp:ListItem Value="14:30"> 14:30 </asp:ListItem>
                        <asp:ListItem Value="15:00"> 15:00 </asp:ListItem>
                        <asp:ListItem Value="15:30"> 15:30 </asp:ListItem>
                        <asp:ListItem Value="16:00"> 16:00 </asp:ListItem>
                        <asp:ListItem Value="16:30"> 16:30 </asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="Confirm" OnClick="Confirm_Click" Text="Confirm" runat="server" /></td>
                <td>
                    <asp:Button ID="Cancel" OnClick="Cancel_Click" Text="Cancel" runat="server" /></td>
            </tr>
            <tr><asp:Label ID="ReservationMessage" runat="server"></asp:Label></tr>
        </table>

    </div>
</asp:Content>

