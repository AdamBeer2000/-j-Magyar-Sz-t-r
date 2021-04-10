<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebNewmagyarszotar.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>New Magyar Szótár</title>

    <style>
    body {
        background-image: url('https://i.imgur.com/DkxArzl.png');
        background-size: 100%;
        background-repeat: no-repeat;
        text-align: center;
        -webkit-user-select: none;
        -moz-user-select: none;
        -ms-user-select: none;
        user-select: none;
    }

    #Menu_title {
        border: none;
        margin-top: 1%;
        padding: 1%;
        text-align: center;
        width: 100%;
        height: 20%;
    }

    #title {
       width: 80%;
    }

    #ranks {
       width: 60%;
    }

    #register {
       width: 85%;
    }

    #browse {
       width: 68%;
    }

    #explorer {
       width: 40%;
    }

    #login {
       width: 60%;
    }

    #Menu_bar {
        border: none;
        text-align: center;
        width: 100%;
        height: 20%;
    }

    #Page {
        border: none;
        margin-top: 1%;
        text-align: center;
        width: 100%;
        height: 20%;
    }

    #Button1 {
        background-color: #6ae134;
        border: none;
        font-family: Calibri;
        font-weight: bold;
        font-size: 240%;
        color: #202020;
        margin-top: 5%;
        padding: 5px 15px;
        text-align: center;
        outline: none;
    }

    #Button1:hover {
        cursor: pointer;
        box-shadow: 0 0 10px #6ae134;
    }

    Label1 {
        padding-top: 5%;
        margin-top: 5%;
    }


    @media only screen and (min-width: 1024px) {
        body {
            background-image: url('https://i.imgur.com/FKNQ2rM.png');
            background-size: 100%;
            background-repeat: no-repeat;
        }

        #title {
            width: 70%;
        }

        #ranks {
           width: 30%;
        }

        #register {
           width: 55%;
        }

        #browse {
           width: 38%;
        }

        #explorer {
           width: 20%;
        }

        #login {
            width: 30%;
        }

        #Button1 {
            background-color: #6ae134;
            border: none;
            font-family: Calibri;
            font-weight: bold;
            font-size: 20px;
            color: #202020;
            margin-top: 5%;
            padding: 5px 15px;
            text-align: center;
            outline: none;
        }
    }
    </style>

</head>
<body>
    <table id="Menu_title">
        <tr>
            <td>
                <img src="https://i.imgur.com/bUmy7ss.png" id="title" alt="title" />
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>

    <table id="Menu_bar">
        <tr>
            <td>
                <a href="Ranks.aspx">
                    <img src="https://i.imgur.com/SBwBvcT.png" id="ranks" alt="ranks" />
                </a>
            </td>

            <td>
                <a href="Register.aspx">
                    <img src="https://i.imgur.com/uOKgULx.png" id="register" alt="register" />
                </a>
            </td>

            <td>
                <a href="Browse.aspx">
                    <img src="https://i.imgur.com/7bBZof5.png" id="browse" alt="browse" />
                </a>
            </td>
        </tr>

        <tr>
            <td>

            </td>

            <td>
                <br />
                <a href="Login.aspx">
                    <img src="https://i.imgur.com/lwnbx8R.png" id="login" alt="login" />
                </a>
            </td>

            <td>

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
                    <img src="https://i.imgur.com/bjf1uwn.png" id="explorer" alt="explorer mode" />
                </a>
            </td>
        </tr>
        
    </table>
    <!--
        <img src="https://i.imgur.com/1eNto3n.png" id="menu" alt="menu">
        -->
    
    
</body>
</html>
