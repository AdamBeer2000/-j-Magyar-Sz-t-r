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
            padding-left: 5%;
            border: none;
            margin-top: 1%;
            text-align: left;
            width: 100%;
            height: 20%;
        }

        #SzotarTable {
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
            color: #898E01;
        }
        #kereses:-moz-placeholder {
            color: #898E01;
        }
        #kereses::-moz-placeholder {
            color: #898E01;
        }

        #searchBox {
            outline: none;
            border: 1px solid #898E01;
            min-width: 40%;
            font-size: 100%;
            font-family: Calibri;
            color: #898E01;
            background-color: #080808;
            opacity: 0.9;
        }

        .cimsor td{
            border: 1px dashed rgba(137, 142, 1, 0.2);
            border-bottom: 1px solid rgba(137, 142, 1, 0.5);
            color: #898E01;
            font-size: 150%;
            font-family: Calibri;
            font-weight: bold;
        }

        tr.egysor td{
            border: 1px solid #898E01;
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

        .rowStyle td
        {
            border: 1px dashed rgba(137, 142, 1, 0.2);
            border-bottom: 1px solid rgba(137, 142, 1, 0.5);
            color: #898E01;
            font-size: 120%;
            font-family: Calibri;
            max-height: 30%;
        }

        .likebutton
        {
            height: 30px;
        }

        .lenyitbutton
        {
            height: 10px;
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
                <img src="https://i.imgur.com/CW4NGnF.png" width="35%" id="title" alt="title" />
            </td>
        </tr>
    </table>

    <form id="form1" runat="server">

    <table id="search">
        <tr>
            <td>
                <asp:TextBox ID="searchBox" runat="server" OnTextChanged="searchBox_TextChanged" AutoPostBack="True"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" Text="Label" BackColor="White"></asp:Label>
            </td>
        </tr>
    </table>

    <table id="SzotarTable" runat="server">
        <tr class="egysor">
            <td>
                <h1 style="color:#898E01;font-family: Calibri;">
                </h1>
            </td>
            <td>
                <h1  style="color:#898E01;font-family: Calibri;">
                </h1>
            </td>
        </tr>
    </table>

    <table id="for_back">
        <tr>
            <td>
                <a href="Browse.aspx">
                    <asp:ImageButton ID="back_button" runat="server" src="https://i.imgur.com/D5tvrqL.png" outline="none" width="10%" alt="browse" OnClick="back_button_Click"/>
                </a>
            </td>
            <td>
                <a href="Browse.aspx">
                    <asp:ImageButton ID="forward_button" runat="server" src="https://i.imgur.com/by9oUf1.png" outline="none" width="10%" alt="browse" OnClick="forward_button_Click"/>
                </a>
            </td>
        </tr>
    </table>
        <div>
        </div>
    </form>
</body>
</html>
