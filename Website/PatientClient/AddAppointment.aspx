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
                    <asp:DropDownList ID="DoctorsList" runat="server"></asp:DropDownList>
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
                    <asp:DropDownList ID="TimeList" runat="server"></asp:DropDownList>
                </td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td class="auto-style2"><asp:Button ID="Confirm" OnClick="Confirm_Click" Text="Confirm" runat="server" /></td>
                <td><asp:Button ID="Cancel" OnClick="Cancel_Click" Text="Cancel" runat="server" /></td>
            </tr>
        </table>

    </div>
</asp:Content>

