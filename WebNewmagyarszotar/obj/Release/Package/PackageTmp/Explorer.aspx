<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Explorer.aspx.cs" Inherits="WebNewmagyarszotar.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Felfedező mód</title>
    <link rel="stylesheet" href="Style_Explorer.css" />

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

        #Page_title {
            border: 1px solid #898E01;
            margin-top: 1%;
            margin-left: 20%;
            margin-right: 20%;
            padding-left: 2%;
            text-align: left;
            width: 60%;
            height: 20%;
        }

        #fo_tablazat {
            border: 1px solid #898E01;
            margin-top: 1%;
            margin-left: 20%;
            margin-right: 20%;
            text-align: center;
            width: 60%;
            height: 80%;
        }

        #elso_szo
        {
            border: none;
            text-align: left;
            padding-left: 2%;
            width: 100%;
        }

        #masodik_szo
        {
            border: none;
            text-align: right;
            padding-right: 2%;
            width: 100%;
        }

        #vonal{
            border: none;
            width: 100%;
        }

        h1 {
            font-size: 170%;
            font-weight: bold;
            font-family: Calibri;
            color: #898E01;
        }

        #vissza {
            margin-top: 3%;
            font-size: 100%;
            font-family: Calibri;
            color: #898E01;
        }

        #friss {
            text-align: right;
            padding-right: 2%;
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
    <form id="form111" runat="server">
    <table id="Menu_title">
        <tr>
            <td>
                <img src="https://i.imgur.com/HwosnuG.png" width="35%" id="title" alt="title" />
            </td>
        </tr>
    </table>


    <table id="Page_title">
        <tr>
            <td>
                <h1>
                    <asp:Label ID="angol_szo_label" runat="server"></asp:Label>
                </h1>
            </td> 
            
            <td id="friss">            
                <a href="Explorer.aspx">
                    <img src="https://i.imgur.com/r665QFH.png" height="40px" id="reload" alt="reload" />
                </a>
            </td>
        </tr>
    </table>

    <table id="fo_tablazat">
        <tr>
            <td>

                <table id="elso_szo">
                    <tr>
                        <td>
                            <h1>
                                <asp:Label ID="first_forditas" runat="server"></asp:Label>
                            </h1>
                        </td>
                    </tr>
                </table>

                <table id="vonal">
                    <tr>
                        <td>
                            <h1>
                                <img src="https://i.imgur.com/VEp6mpu.png" width="100%" id="vonal_1" alt="vonal" />
                            </h1>
                        </td>
                        <td>
                            <h1>
                                <asp:ImageButton id="up" runat="server" ImageUrl="https://i.imgur.com/4Qv1V8L.png" width="40%" alt="vonal"  OnClick="upClick"/>
                                <!--<img src="https://i.imgur.com/4Qv1V8L.png" width="40%" id="up_down" alt="vonal" />-->
                            </h1>
                        </td>
                        <td>
                            <h1>
                                <asp:ImageButton id="down" runat="server" ImageUrl="https://i.imgur.com/kkF7JDM.png"  width="40%" alt="vonal" OnClick="downClick"/>
                                <!--<img src="https://i.imgur.com/kkF7JDM.png" width="40%" id="up_down" alt="vonal" /> -->
                            </h1>
                        </td>
                        <td>
                            <h1>
                                <img src="https://i.imgur.com/Vqd8ni8.png" width="100%" id="vonal_2" alt="vonal" />
                            </h1>
                        </td>
                    </tr>
                </table>

                <table id="masodik_szo">
                    <tr>
                        <td>
                            <h1>
                                <asp:Label ID="second_forditas" runat="server"></asp:Label>
                            </h1>
                        </td>
                    </tr>
                </table>

            </td>
        </tr>
    </table>

    <a id="vissza" href="index.aspx">Vissza a kezdőoldalra</a>

    </form>

</body>
</html>
