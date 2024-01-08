<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkStudentToAdvisor.aspx.cs" Inherits="WebApplication1.LinkStudentToAdvisor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Student id</p>
        <p>
            <asp:TextBox ID="StudentID" runat="server"></asp:TextBox>
        </p>
        <p>
            Advisor id</p>
        <p>
            &nbsp;<asp:TextBox ID="AdvisorID" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button7" runat="server" onclick="linkStudentToAdvisor" Text="Link a student to an advisor" />
        </p>
    </form>
</body>
</html>
