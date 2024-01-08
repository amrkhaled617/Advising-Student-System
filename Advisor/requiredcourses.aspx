<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="requiredcourses.aspx.cs" Inherits="Student1.requiredcourses" %>

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
            <asp:TextBox ID="requiredcoursesid" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="done3" runat="server" Text="Done" OnClick="doneoc_Click" />
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="true">
</asp:GridView>
        <div>
        </div>
    </form>
</body>
</html>
