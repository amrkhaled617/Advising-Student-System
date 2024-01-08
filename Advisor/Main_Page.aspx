<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main_Page.aspx.cs" Inherits="Milestone3.Main_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            font-size: x-large;
            text-align: center;
        }
        .auto-style3 {
            text-align: center;
        }
        .auto-style4 {
            font-size: small;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style3">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong><span class="auto-style2"> Admin Page Controls: </span></strong>
        </div>
        <p>
            To
            Delete Course with its related slots:</p>
        <p class="auto-style4">
            <em>Enter Course ID:</em></p>
        <p>
            <asp:TextBox ID="CourseIDtoDelete" runat="server"></asp:TextBox>
        </p>
        <p>
        <asp:Button ID="Delete_Course" runat="server" Text="Delete Course" OnClick="Delete_Course_Click" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            Delete a slot of a certain course if the course isn’t offered in the current semester:</p>
        <p>
            <em>Current Semster:</em></p>
        <p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="DeleteSlots" runat="server" Text="Delete Slot" OnClick="DeleteSlots_Click" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            Add makeup exam for a certain course:</p>
        <p class="auto-style4">
            <em>Enter Course ID:</em></p>
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        <br />
        <em><span class="auto-style4">Enter Date (</span></em><span class="auto-style4" style="color: rgb(32, 33, 36); font-family: &quot;Google Sans&quot;, arial, sans-serif; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;"><em>YYYY-MM-DD HH:MI:SS</em></span><em><span class="auto-style4">):</span></em><br />
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <em><span class="auto-style4">Enter Type (First_makeup or Second_makeup):</span></em><br />
        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Add Exam" OnClick="Button1_Click" />
        <br />
        <br />
        View details for all payments along with their corresponding students:<br />
        <asp:Button ID="Button2" runat="server" Text="View" OnClick="Button2_Click" />
        <br />
        <br />
        Issue installments as per the number of installments for a certain payment:<br />
        <em>Payment ID:</em><br />
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button5" runat="server" Text="Issue" OnClick="Button5_Click" />
        <br />
        <br />
        Update a student status based on his/her financial status:<br />
        <em>Student ID:</em><br />
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button4" runat="server" Text="Update" OnClick="Button4_Click" />
        <br />
        <br />
        Fetch all details of active students:<br />
        <asp:Button ID="Button3" runat="server" Text="View" OnClick="Button3_Click" />
        <br />
        <br />
        View all graduation plans along with their initiated advisors:<br />
        <asp:Button ID="Button7" runat="server" Text="View" OnClick="Button7_Click" />
        <br />
        <br />
        View all students transcript details:<br />
        <asp:Button ID="Button8" runat="server" Text="View" OnClick="Button8_Click" />
        <br />
        <br />
        Fetch all semesters along with their offered courses:<br />
        <asp:Button ID="Button9" runat="server" Text="View" OnClick="Button9_Click" />
        <br />
    </form>
</body>
</html>
