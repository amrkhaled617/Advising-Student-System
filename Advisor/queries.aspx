<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="queries.aspx.cs" Inherits="WebApplication1.queries" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:Button ID="Button1" runat="server" onclick="listAdvisors" Text="List all advisors in the system" CssClass="mybutton" />
        </p>
        <p>
            <asp:Button ID="Button2" runat="server" onclick="listStudentsWithAdvisors" Text="List all students with their corresponding advisors" CssClass="mybutton" />
        </p>
        <p>
            <asp:Button ID="Button3" runat="server" onclick="listPendingRequests" Text="List all pending requests" CssClass="mybutton"/>
        </p>
        <p>
            <asp:Button ID="Button4" runat="server" onclick="addNewSemester" Text="Add a new semester" CssClass="mybutton2" />
        </p>
        <p>
            <asp:Button ID="Button5" runat="server" onclick="addNewCourse" Text="Add a new course" CssClass="mybutton2" />
        </p>
        <p>
            <asp:Button ID="Button6" runat="server" onclick="linkInstructorToCourse" Text="Link instructor to a course in a specific slot" CssClass="mybutton2"/>
        </p>

        <p>
            <asp:Button ID="Button7" runat="server" onclick="linkStudentToAdvisor" Text="Link a student to an advisor" CssClass="mybutton2"/>
        </p>

        <p>
            <asp:Button ID="Button8" runat="server" onclick="linkStudentToCourseWithInstructor" Text="Link a student to a course with a specific instructor" CssClass="mybutton2"/>
        </p>
        <p>
            <asp:Button ID="Button9" runat="server" onclick="viewInstructorsWithCourses" Text="View all details of instructors along with their assigned courses" CssClass="mybutton"/>
        </p>
        <p>
            <asp:Button ID="Button10" runat="server" onclick="fetchAllSemestersWithCourses" Text="Fetch all semesters along with their offered courses" CssClass="mybutton"/>
        </p>
         <p>
            <asp:Button ID="Button11" runat="server" onclick="NextPage" Text="Next Page" CssClass="mybutton3"/>
        </p>
    </form>
</body>
        <style>
            .mybutton3{
            padding: 10px;
            padding-left:20px;
            padding-right:20px;
            font-size: 16px;
            background-color:black;
            border-radius:25px;
            font-size:14px;
            font-weight:bold;
            border:none;
            color:white;
            cursor: pointer;
            }
        body {
            font-family: 'Arial';
            background-color: ghostwhite;
            display: flex;
            flex-direction: column;
            align-items: center;
            padding: 20px;
        }

        .mybutton {
            padding: 10px;
            padding-left:20px;
            padding-right:20px;
            font-size: 16px;
            background-color:lightgreen;
            border-radius:25px;
            font-size:14px;
            font-weight:bold;
            border:none;
            cursor: pointer;
        }
        .mybutton:hover{
            filter:brightness(1.1);
        }
        .mybutton2{
            background-color:#1da1f2;
            color:white;
            padding:10px 20px;
            border:none;
            border-radius:9999px;
            font-size:14px;
            font-weight:bold;
            cursor:pointer;
            transition: background-color 0.3s ease-in-out;
        }
        .mybutton2:hover{
            background-color:#0d8ecf;
        }
    </style>
</html>
