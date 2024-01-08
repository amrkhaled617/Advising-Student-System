<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="buttons.aspx.cs" Inherits="WebApplication11.buttons" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Button ID="Button1" runat="server" Text=" Graduation Plan" Onclick="gradplan" Width="285px"/>
        <p>
            <asp:Button ID="Button2" runat="server" Text="Upcoming Installment" Onclick="inst" Width="285px" />
        </p>
        <asp:Button ID="Button3" runat="server" Text="Courses' Exams" OnClick="exams" Width="285px" />
        <p>
            <asp:Button ID="Button4" runat="server" Text="1st Makeup Registration" OnClick="firstm" Width="285px" />
        </p>
        <p>
            <asp:Button ID="Button5" runat="server" Text="2nd Makeup Registration" OnClick="secondm" Width="285px" />
        </p>
        <p>
            <asp:Button ID="Button6" runat="server" Text="All My Courses Details" OnClick="allcoursesslots" Width="285px" />
        </p>
        <p>
            <asp:Button ID="Button7" runat="server" Text="Course Slots and Instructors" OnClick="slotsinstructors" Width="285px" />
        </p>
        <p>
            <asp:Button ID="Button8" runat="server" Text="Choose Course Instructor" OnClick="chooseinstructor" Width="285px" />
        </p>
        <p>
            <asp:Button ID="Button9" runat="server" Text="Course Prerequisites" OnClick="prereq" Width="285px" />
        </p>
    </form>
</body>
</html>
