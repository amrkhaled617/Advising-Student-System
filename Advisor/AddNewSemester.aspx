<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewSemester.aspx.cs" Inherits="WebApplication1.AddNewSemester" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Start date</p>
        <p>
            <asp:TextBox ID="StartDate" runat="server"></asp:TextBox>
        </p>
        <p>
            End date</p>
        <p>
            &nbsp;<asp:TextBox ID="EndDate" runat="server"></asp:TextBox>
        </p>
        <p>
            Semester code</p>
        <p>
            <asp:TextBox ID="SemesterCode" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button4" runat="server" onclick="addNewSemester" Text="Add a new semester" />
        </p>
    </form>
</body>
</html>
