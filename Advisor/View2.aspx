<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View2.aspx.cs" Inherits="Milestone3.View2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1><em><strong>Details of active students:</strong></em></h1>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <p>
                <asp:Button ID="Button1" runat="server" Text="Back to Previous Page" OnClick="Button1_Click" />
            </p>
        </div>
    </form>
</body>
</html>
