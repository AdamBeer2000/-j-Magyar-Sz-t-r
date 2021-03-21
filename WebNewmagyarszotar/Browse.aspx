<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Browse.aspx.cs" Inherits="WebNewmagyarszotar.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Böngészés</title>
    <link rel="stylesheet" href="Style_Browse.css" />

    <style type="text/css">
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

        #search {
            padding-right: 5%;
            border: none;
            margin-top: 1%;
            text-align: right;
            width: 100%;
            height: 20%;
        }



        #Page {
            border: 1px solid #898E01;
            margin-top: 1%;
            padding-top: 1%;
            margin-left: 5%;
            margin-right: 5%;
            text-align: center;
            width: 90%;
            height: 20%;
            background-color: #080808;
            opacity: 0.8;
        }

        h1 {
            font-size: 120%;
            font-family: Calibri;
            color: #898E01;
        }

        #kereses {
            outline: none;
            border: 1px solid #898E01;
            font-size: 100%;
            font-family: Calibri;
            color: #898E01;
            background-color: #080808;
            opacity: 0.8;
        }
        #kereses::-webkit-input-placeholder {
            color:    #898E01;
        }
        #kereses:-moz-placeholder {
            color:    #898E01;
        }
        #kereses::-moz-placeholder {
            color:    #898E01;
        }

        #for_back {
            border: none;
            margin-top: 1%;
            padding-top: 1%;
            margin-left: 30%;
            margin-right: 30%;
            text-align: center;
            width: 40%;
            height: 20%;
        }

        @media only screen and (min-width: 1024px) {
            body {
                background-image: url('https://i.imgur.com/FKNQ2rM.png');
                background-size: 100%;
                background-repeat: no-repeat;
            }
        }

    </style>
</head>
<body>
    <table id="Menu_title">
        <tr>
            <td>
                <img src="https://i.imgur.com/TorIkJf.png" width="35%" id="title" alt="title" />
            </td>
        </tr>
    </table>

    <table id="search">
        <tr>
            <td>
                <input id="kereses" type="text" name="kereses" placeholder="keress bazmeg" runat="server"/>
            </td>
        </tr>
    </table>

    <table id="Page">
        <tr>
            <td>
                <h1  style="color:#898E01;font-family: Calibri;">
                    angol szó
                </h1>
            </td>
            <td>
                <h1  style="color:#898E01;font-family: Calibri;">
                    eredeti magyar jelentése
                </h1>
            </td>
            <td>
                <h1  style="color:#898E01;font-family: Calibri;">
                    vicces magyar jelentése
                </h1>

            </td>
        </tr>
    </table>
    <table id="for_back">
        <tr>
            <td>
                <a href="Browse.aspx">
                    <img src="https://i.imgur.com/D5tvrqL.png" width="10%" alt="browse" />
                </a>
            </td>
            <td>
                <a href="Browse.aspx">
                    <img src="https://i.imgur.com/by9oUf1.png" width="10%" alt="browse" />
                </a>
            </td>
        </tr>
    </table>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Anyááááááááááááááááááád"></asp:Label>
        </div>
    </form>


</body>
</html>
