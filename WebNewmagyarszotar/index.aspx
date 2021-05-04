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

        #user_label {
            width: 100%;
            padding: 0%;
            margin: 0%;
        }

        #box {
            text-align: right;
            padding-right: 1%;
            width: 100%;
            margin-top: 5%;
        }

        #menu_title {
            padding-left: 5%;
            text-align: left;
        }

        #title {
           width: 100%;
        }

        h1 {
            color: #898E01;
            font-family: Calibri;
            font-size: 100%;
        }

        #ranks {
           width: 60%;
        }

        #register {
           width: 100%;
           padding: 0%;
           margin: 0%;
        }

        #browse {
           width: 68%;
        }

        #explorer {
           width: 68%;
        }

        #login {
           width: 100%;
           padding: 0%;
           margin: 0%;
        }

        #Menu_bar {
            margin-top: 10%;
            border: none;
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

        #HozzaadAngolSzot {
            border: 1px solid #898E01;
            margin-top: 1%;
            margin-left: 5%;
            margin-right: 5%;
            text-align: center;
            width: 90%;
            height: 20%;
            background-color: #080808;
            opacity: 0.8;
        }

        .addEnglishWord {
            cursor: pointer;
            border: none;
            margin-top: 3%;
            margin-bottom: 1%;
            outline: none;
            background-color: #898E01;
            color: #080808;
            font-size: 160%;
            font-weight: bolder;
            font-family: Calibri;
            padding: 2%;
        }

        .addEnglishWord:hover{
            box-shadow: 0 0 10px #898E01;
        }


        @media only screen and (min-width: 1024px) {
            body {
                background-image: url('https://i.imgur.com/FKNQ2rM.png');
                background-size: 100%;
                background-repeat: no-repeat;
            }

            #box {
                text-align: right;
                padding-right: 1%;
                width: 100%;
                margin-top: 0%;
            }

            #title {
                width: 90%;
            }

            #menu_title {
                padding-left: 3%;
                text-align: left;
            }

            #Menu_bar {
                margin-top: 5%;
                border: none;
                text-align: center;
                width: 100%;
                height: 20%;
            }

            h1 {
                color: #898E01;
                font-family: Calibri;
                font-size: 100%;
            }

            #ranks {
               width: 30%;
            }

            #register {
               width: 70%;
               padding: 0%;
               margin: 0%;
            }

            #browse {
               width: 38%;
            }

            #explorer {
               width: 38%;
            }

            #login {
               width: 70%;
               padding: 0%;
               margin: 0%;
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

            .addEnglishWord {
                cursor: pointer;
                border: none;
                margin-top: 3%;
                margin-bottom: 1%;
                outline: none;
                background-color: #898E01;
                color: #080808;
                font-size: 100%;
                font-weight: bolder;
                font-family: Calibri;
                padding: 2%;
            }
        }
    </style>

</head>
<body>

    <table id="box">
        <tr>
            <td id="menu_title">
                <img src="https://i.imgur.com/bUmy7ss.png" id="title" alt="title" />
            </td>

            <td>
                <h1>
                    <asp:Label ID="user_label" runat="server" Text="username"></asp:Label>
                </h1>
            </td>

            <td>
                <a href="Login.aspx">
                    <img src="https://i.imgur.com/lwnbx8R.png" id="login" alt="login" />
                </a>
            </td>

            <td>

                <a href="Register.aspx">
                    <img src="https://i.imgur.com/uOKgULx.png" id="register" alt="register" />
                </a>
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
                <a href="Explorer.aspx">
                    <img src="https://i.imgur.com/bjf1uwn.png" id="explorer" alt="explorer mode" />
                </a>
            </td>

            <td>
                <a href="Browse.aspx">
                    <img src="https://i.imgur.com/7bBZof5.png" id="browse" alt="browse" />
                </a>
            </td>
        </tr>
    </table>

    <form id="form23" runat="server">
        <table id="HozzaadAngolSzot">
            <tr>
                <td>

                    <h1>
                        Új angol szó hozzáadása
                    </h1>
                </td>
            </tr>

            <tr>
                <td>
                
                    <asp:Button ID="addEnglishWord" runat="server" Text="Angol szó hozzáadása" CssClass="addEnglishWord"/>
                
                </td>
            </tr>
        </table>
    </form>
    
</body>
</html>
