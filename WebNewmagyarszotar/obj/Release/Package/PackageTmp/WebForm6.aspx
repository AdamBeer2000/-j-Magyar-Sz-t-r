<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm6.aspx.cs" Inherits="WebNewmagyarszotar.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #TextArea1 {
            height: 115px;
            width: 185px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input id="Text1" type="text" runat="server"/></div>
        <p>
            <input id="Text2" type="text" runat="server"/></p>
    <p>
        <input id="Password1" type="password" runat="server"/></p>
    <p>
        
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
            
</body>
</html>
