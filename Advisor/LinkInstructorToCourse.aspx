<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkInstructorToCourse.aspx.cs" Inherits="WebApplication1.LinkInstructorToCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Course id</p>
        <p>
            <asp:TextBox ID="CourseID" runat="server"></asp:TextBox>
        </p>
        <p>
            Instructor id</p>
        <p>
            &nbsp;<asp:TextBox ID="InstructorID" runat="server"></asp:TextBox>
        </p>
        <p>
            Slot id</p>
        <p>
            <asp:TextBox ID="SlotID" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button6" runat="server" onclick="linkInstructorToCourse" Text="Link instructor to a course in a specific slot" />
        </p>
    </form>
</body>
</html>
