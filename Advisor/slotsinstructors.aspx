<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="slotsinstructors.aspx.cs" Inherits="WebApplication2.slotsinstructors" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Course ID"></asp:Label>
<asp:TextBox ID="txtCourseID3" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Instructor ID"></asp:Label>
            <asp:TextBox ID="txtInstructorID" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnRegister" runat="server" Text="View" OnClick="btnRegister_Click3" />
        </div>
        <div>
            <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
        </div>
    </form>
</body>
</html>
