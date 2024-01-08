<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication11.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            please login or
        <asp:Button ID="register" runat="server" style="margin-left: 7px; margin-right: 0px; margin-top: 0px; margin-bottom: 0px;" Text="register" Width="101px" Height="28px" OnClick="register_Click" />
        </div>
        <p>
            Username:</p>
        <p>
            <asp:TextBox ID="Username" runat="server" style="margin-bottom: 0px"></asp:TextBox>
        </p>
        <p>
            Password:</p>
        <p>
            <asp:TextBox ID="Password" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        </p>
        <asp:Button ID="signin" runat="server" onClick="Login" Text="login" Width="120px" />
    </form>
</body>
</html>
