<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebNewmagyarszotar.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sajt</title>
    <link rel="stylesheet" href="StyleSheet1.css" />
</head>
<body>
    <table id="Menu_title">
        <tr>
            <td>
                <img src="https://i.imgur.com/WUMps0s.png" id="title" alt="title" />
            </td>
        </tr>
    </table>

    <table id="Menu_bar">
        <tr>
            <td>
                <a href="https://www.youtube.com/watch?v=yV3U2jAlbVg">
                    <img src="https://i.imgur.com/1eNto3n.png" width="15%" id="menu_b" alt="menu">
                </a>
            </td>

            <td>
                <a href="">
                    <img src="https://i.imgur.com/jT5qLd4.png" width="15%" id="menu_b" alt="menu">
                </a>
            </td>

            <td>
                <a href="">
                    <img src="https://i.imgur.com/jT5qLd4.png" width="15%" id="menu_b" alt="menu">
                </a>
            </td>
        </tr>
    </table>

    <table id="Page">
        <tr>
            <td>

                <form id="form1" runat="server">
                    <asp:Button ID="Button1" runat="server" Text="Nyomd meg, ha vagány vagy" OnClick="Button1_Click" />
                    <br />
                    <asp:Label ID="Label1" runat="server" BackColor="White" Text="Még semmi"></asp:Label>
                </form>
            </td>
        </tr>
        
    </table>
    <!--
        <img src="https://i.imgur.com/1eNto3n.png" id="menu" alt="menu">
        -->
    
    
</body>
</html>
