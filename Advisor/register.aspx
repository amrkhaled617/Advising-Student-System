<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="WebApplication11.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            first name<br />
            <asp:TextBox ID="firstname" runat="server"></asp:TextBox>
            <br />
            lastname<br />
            <asp:TextBox ID="lastname" runat="server"></asp:TextBox>
            <br />
            password<br />
            <asp:TextBox ID="rpassword" runat="server"></asp:TextBox>
            <br />
            faculty<br />
            <asp:TextBox ID="faculty" runat="server"></asp:TextBox>
            <br />
            email<br />
            <asp:TextBox ID="email" runat="server"></asp:TextBox>
            <br />
            major<br />
            <asp:TextBox ID="major" runat="server"></asp:TextBox>
            <br />
            semester<br />
            <asp:TextBox ID="semster" runat="server"></asp:TextBox>
            <br />
        </div>
        <asp:Button ID="register1" runat="server" Text="register" OnClick="register1_Click" />
    </form>
</body>
</html>
