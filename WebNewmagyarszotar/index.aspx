<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebNewmagyarszotar.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>New Magyar Szótár</title>
    <link rel="stylesheet" href="Style_index.css" />
</head>
<body>
    <table id="Menu_title">
        <tr>
            <td>
                <img src="https://i.imgur.com/bUmy7ss.png" width="70%" id="title" alt="title" />
            </td>
        </tr>
    </table>

    <table id="Menu_bar">
        <tr>
            <td>
                <a href="Ranks.aspx">
                    <img src="https://i.imgur.com/SBwBvcT.png" width="30%" id="ranks" alt="ranks" />
                </a>
            </td>

            <td>
                <a href="Register.aspx">
                    <img src="https://i.imgur.com/uOKgULx.png" width="55%" id="register" alt="register" />
                </a>
            </td>

            <td>
                <a href="Browse.aspx">
                    <img src="https://i.imgur.com/7bBZof5.png" width="38%" id="browse" alt="browse" />
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
                
                <a href="Explorer.aspx">
                    <img src="https://i.imgur.com/YuSDoUE.jpeg" width="40%" id="explorer" alt="explorer mode" />
                </a>
            </td>
        </tr>
        
    </table>
    <!--
        <img src="https://i.imgur.com/1eNto3n.png" id="menu" alt="menu">
        -->
    
    
</body>
</html>
