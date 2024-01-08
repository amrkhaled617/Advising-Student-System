<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="secondm.aspx.cs" Inherits="WebApplication2.secondm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Course ID"></asp:Label>
            <asp:TextBox ID="txtCourseID2" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Current Semester"></asp:Label>
            <asp:TextBox ID="txtCurrentSemester2" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click2" />
        </div>
        <div>
            <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
        </div>
    </form>
</body>
</html>
