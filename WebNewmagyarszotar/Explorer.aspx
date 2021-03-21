<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Explorer.aspx.cs" Inherits="WebNewmagyarszotar.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Felfedező mód</title>
    <link rel="stylesheet" href="Style_Explorer.css" />

    <style type="text/css">
        body {
            background-image: url('https://i.imgur.com/RflwZ1R.png');
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

        #Page_title {
            border: 1px solid #898E01;
            margin-top: 1%;
            padding-top: 1%;
            margin-left: 20%;
            margin-right: 20%;
            text-align: center;
            width: 60%;
            height: 20%;
        }

        #Page {
            border: 1px solid #898E01;
            margin-top: 1%;
            margin-left: 20%;
            margin-right: 20%;
            text-align: center;
            width: 60%;
            height: 20%;
        }

        h1 {
            font-size: 120%;
            font-family: Calibri;
            color: #898E01;
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
                <img src="https://i.imgur.com/RflwZ1R.png" width="35%" id="title" alt="title" />
            </td>
        </tr>
    </table>


    <table id="Page_title">
        <tr>
            <td>
                <h1>
                    angol szó
                </h1>
            </td>
        </tr>
    </table>


</body>
</html>
