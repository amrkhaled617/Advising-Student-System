<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chooseinstructor.aspx.cs"Inherits="WebApplication2.chooseinstructor"
 %>

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
            <asp:TextBox ID="txtInstructorID2" runat="server"></asp:TextBox>
        </div>
         <div>
     <asp:Label ID="Label3" runat="server" Text="Semester Code"></asp:Label>
     <asp:TextBox ID="txtSemester" runat="server"></asp:TextBox>
 </div>
        <div>
            <asp:Button ID="btnRegister" runat="server" Text="Confirm" OnClick="btnRegister_Click4" />
        </div>
        <div>
            <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
        </div>
    </form>
</body>
</html>
