<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginAdmin.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Log in as Admin</div>
        <p>
            Username:</p>
        <p>
            <asp:TextBox ID="username" runat="server"></asp:TextBox>
        </p>
        <p>
            Password:</p>
        <p>
            <asp:TextBox ID="password" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="login" Text="Log in" />
        </p>
    </form>
</body>
</html>
