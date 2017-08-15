<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>R.A.D.A.R Screen Shot Viewier</title>
    <link href="Style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Montserrat Alternates">
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script src="http://www.appelsiini.net/projects/lazyload/jquery.lazyload.js?v=3"
        type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("img.lazy").lazyload(
        {
            placeholder: "http://www.pb-radar.net/images/loading.gif",
            effect: "fadeIn"
        });
        });
    </script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery('#backtotop a').click(function () {
                jQuery('html, body').animate({ scrollTop: 0 }, 'slow');
                return false;
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel ID="LoginPAN" runat="server">
        <table align="center" cellpadding="5" width="500px">
            <tr>
                <td colspan="2">
                    &nbsp;
                </td>
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
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
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
                            </td>
                            <td align="right">
                                <h3>
                                    <asp:LinkButton ID="LogoutBTN" runat="server">Logout</asp:LinkButton></h3>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
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
                        </tr>
                    </table>
                    <asp:Literal ID="ResultsLIT" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
        <div id="backtotop">
            <a href="#">
                <img src="top.png" border="0" alt="Back to TOP" />
            </a>
        </div>
    </asp:Panel>
    </form>
</body>
</html>
