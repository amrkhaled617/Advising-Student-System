<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="services.aspx.cs" Inherits="Advisor.services" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
            <asp:Button ID="telephonenum" runat="server" Text="add telephone number
                " Height="39px" OnClick="Button2_Click" Width="208px" />
        <p>
        <asp:Button ID="vopc" runat="server" Text="view optional courses" OnClick="Button1_Click" Height="39px" Width="208px" />
        </p>
        <p>
            <asp:Button ID="vavc" runat="server" Text="view available courses" Height="39px" Width="208px" OnClick="vavc_Click" />
        </p>
        <p>
        <asp:Button ID="vrc" runat="server" style="margin-left: 0px; margin-right: 0px; margin-top: 0px; margin-bottom: 0px;" Text="view required courses" Width="208px" Height="39px" OnClick="register_Click" />
        </p>
        <asp:Button ID="vmc" runat="server" Text="view missing courses" Width="208px" Height="39px" OnClick="vmc_Click" />
        <p>
            <asp:Button ID="scr" runat="server" Height="39px" Text="Send a course request" Width="208px" OnClick="scr_Click" />
        </p>
        <p>
            <asp:Button ID="schr" runat="server" Text="Send a credithour request" Height="36px" Width="249px" OnClick="schr_Click" />
        </p>
        <p>
            <asp:Button ID="np" runat="server" style="margin-left: 399px" Text="Next page" Width="120px" Height="41px" OnClick="np_Click" />
        </p>
    </form>
</body>
</html>
