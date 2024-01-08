<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View4.aspx.cs" Inherits="Milestone3.View4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>S<em>tudents&#39; transcript details:</em></h1>
        </div>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:Button ID="Button1" runat="server" Text="Back to Previous Page" OnClick="Button1_Click" />
    </form>
</body>
</html>
