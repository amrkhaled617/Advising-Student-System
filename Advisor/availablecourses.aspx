<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="availablecourses.aspx.cs" Inherits="WebApplication11.availablecourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
                <p>
            Enter current semester code</p>
        <p>
            <asp:TextBox ID="availablecoursesid" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="done2" runat="server" Text="Done" OnClick="doneoc_Click" />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="true">
</asp:GridView>
    </form>
</body>
</html>
