<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sendchrequest.aspx.cs" Inherits="Student1.sendchrequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            credit hours<br />
            <asp:TextBox ID="ch" runat="server"></asp:TextBox>
            <br />
            Type</div>
        <asp:TextBox ID="type" runat="server"></asp:TextBox>
        <br />
        Comment<br />
        <asp:TextBox ID="comment" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="Send" runat="server" Text="Button" OnClick="Send_Click" />
        </p>
    </form>
</body>
</html>
