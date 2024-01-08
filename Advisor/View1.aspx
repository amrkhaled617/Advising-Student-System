<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View1.aspx.cs" Inherits="Milestone3.View1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <strong>All payments along with their corresponding students:</strong></div>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:Button ID="Button1" runat="server" Text="Back to Previous Page" OnClick="Button1_Click" />
    </form>
</body>
</html>
