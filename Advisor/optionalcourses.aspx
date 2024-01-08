<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="optionalcourses.aspx.cs" Inherits="WebApplication11.optionalcourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            Enter current semester code</p>
        <p>
            <asp:TextBox ID="cscc" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="doneoc" runat="server" Text="Done" OnClick="doneoc_Click" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true">
</asp:GridView>
    </form>
</body>
</html>
