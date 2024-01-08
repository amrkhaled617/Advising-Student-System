<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sendcourserequest.aspx.cs" Inherits="Student1.sendcourserequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Course id</div>
        <asp:TextBox ID="cid" runat="server"></asp:TextBox>
        <br />
        Type<br />
        <asp:TextBox ID="type" runat="server"></asp:TextBox>
        <br />
        Comment<br />
        <asp:TextBox ID="comment" runat="server"></asp:TextBox>
        <br />
        <p>
            <asp:Button ID="send" runat="server" Text="Send" OnClick="send_Click" />
        </p>
    </form>
</body>
</html>
