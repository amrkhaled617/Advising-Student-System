<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="firstm.aspx.cs" Inherits="WebApplication2.firstm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Course ID"></asp:Label>
<asp:TextBox ID="txtCourseID" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Current Semester"></asp:Label>
            <asp:TextBox ID="txtCurrentSemester" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
        </div>
        <div>
            <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
        </div>
    </form>
</body>
</html>
