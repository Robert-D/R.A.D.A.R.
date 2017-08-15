<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Montserrat Alternates">
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel ID="LoginPAN" runat="server">
        <table align="center" cellpadding="5" width="500px">
            <tr>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    A password is required to view this page:<br />
                    <br />
                    <asp:TextBox ID="AuthPassTXT" runat="server" TextMode="Password"></asp:TextBox>
                    &nbsp;<asp:Button ID="LoginBTN" runat="server" Text="Login" />
                    <br />
                    <asp:Label ID="StatusLAB" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>

    </asp:Panel>
    <asp:Panel ID="DisplayPAN" runat="server">
        <table align="center" cellpadding="5" class="bodyTable" width="100%">
            <tr>
                <td>
                    <h1>
                        <asp:Label ID="HeaderTextLAB" runat="server" Text="The Community's Screenshots"></asp:Label></h1>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%">
                        <tr>
                            <td>
                                <h3>
                                    Quick Search</h3>
                                Hero Name:
                                <asp:TextBox ID="HeroNameTXT" runat="server"></asp:TextBox>
                                &nbsp;&nbsp; Server:
                                <asp:DropDownList ID="ServersDDL" runat="server" AppendDataBoundItems="True">
                                    <asp:ListItem Value="0">All Servers</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="SearchBTN" runat="server" Text="Search" />
                                &nbsp;<asp:Button ID="ResetBTN" runat="server" Text="Reset" />
                                <br />
                                <asp:CheckBox ID="SuspiciousCB" runat="server" Text="Suspicious" />
                                &nbsp;
                                <asp:CheckBox ID="CroppedCB" runat="server" Text="Cropped" />
                                &nbsp;
                                <asp:CheckBox ID="FailedCB" runat="server" Text="Failed" />
                                &nbsp;
                                <asp:CheckBox ID="PinkCB" runat="server" Text="Pink" />
                                &nbsp;
                                <asp:CheckBox ID="BlackCB" runat="server" Text="Black" />
                                &nbsp;
                                <asp:CheckBox ID="NormalCB" runat="server" Text="Normal" />
                                &nbsp;
                                <asp:CheckBox ID="CheatersCB" runat="server" Text="Cheaters" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Literal ID="ResultsLIT" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </asp:Panel>
    </form>
</body>
</html>
