<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLinkStudent.aspx.cs" Inherits="WebApplication1.AdminLinkStudent" %>

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
            Student id</p>
        <p>
            <asp:TextBox ID="StudentID" runat="server"></asp:TextBox>
        </p>
        <p>
            Semester code</p>
        <p>
            <asp:TextBox ID="SemesterCode" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button8" runat="server" onclick="linkStudentToCourseWithInstructor" Text="Link a student to a course with a specific instructor" />
        </p>
    </form>
</body>
</html>
