<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebNewmagyarszotar.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sajt</title>
        <link rel="stylesheet" href="StyleSheet1.css">
</head>
<body style="background-image: url('https://i.imgur.com/ycKxlLt.png')">
    <table id="Page">
        <img src="https://i.imgur.com/WUMps0s.png" id="title" alt="title">
        <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" Text="Nyomd meg, ha vagány vagy" OnClick="Button1_Click" />
        <br>
        <asp:Label ID="Label1" runat="server" BackColor="White" Text="Még semmi"></asp:Label>
    </form>
    </table>
    
 </body>
</html>
