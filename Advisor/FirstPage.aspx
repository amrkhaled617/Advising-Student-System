<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FirstPage.aspx.cs" Inherits="WebApplication1.FirstPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
         <p>
            <asp:Button ID="Button1" runat="server" onclick="Student" Text="Student" CssClass="mybutton"/>
        </p>
        <p>
            <asp:Button ID="Button2" runat="server" onclick="Advisor" Text="Advisor" CssClass="mybutton"/>
        </p>
         <p>
            <asp:Button ID="Button3" runat="server" onclick="Admin" Text="Admin" CssClass="mybutton3"/>
        </p>
        </div>
    </form>
</body>
</html>
