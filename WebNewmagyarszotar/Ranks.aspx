<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ranks.aspx.cs" Inherits="WebNewmagyarszotar.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
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
                <img src="https://i.imgur.com/fBxBH6q.png" width="35%" id="title" alt="title" />
            </td>
        </tr>
    </table>
    <form id="form1" runat="server">
        <div>
        </div>
        <a id="vissza" href="index.aspx">Vissza a kezdőoldalra</a>
    </form>
</body>
</html>
