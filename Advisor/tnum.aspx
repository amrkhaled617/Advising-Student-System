<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tnum.aspx.cs" Inherits="WebApplication11.tnum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Telephone number</div>
        <p>
            <asp:TextBox ID="tnumber" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="addnum" runat="server" Text="add" OnClick="addnum_Click" />
        </p>
    </form>
</body>
</html>
