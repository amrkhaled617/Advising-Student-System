<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewCourse.aspx.cs" Inherits="WebApplication1.AddNewCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
 <p>
     Major</p>
 <p>
     <asp:TextBox ID="Major" runat="server"></asp:TextBox>
 </p>
 <p>
     Semester</p>
 <p>
     &nbsp;<asp:TextBox ID="Semester" runat="server"></asp:TextBox>
 </p>
 <p>
     Credit hours</p>
 <p>
     <asp:TextBox ID="CreditHours" runat="server"></asp:TextBox>
 </p>
 <p>
     Name</p>
 <p>
     <asp:TextBox ID="Name" runat="server"></asp:TextBox>
 </p>
 <p>
     Is offered</p>
 <p>
     &nbsp;<asp:TextBox ID="IsOffered" runat="server"></asp:TextBox>
 </p>
 <p>
     <asp:Button ID="Button5" runat="server" onclick="addNewCourse" Text="Add a new course" />
 </p>
    </form>
</body>
</html>
