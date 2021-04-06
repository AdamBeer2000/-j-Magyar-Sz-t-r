<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebNewmagyarszotar.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bejelentkezés</title>
    
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

        #title {
            width: 80%;
        }

        #login{
            border: 1px solid #898E01;
            margin-top: 1%;
            text-align: center;
            width: 80%;
            margin-left: 10%;
            background-color: #080808;
            opacity: 0.8;
        }

        h1 {
            color: #898E01;
            font-family: Calibri;
            font-size: 300%;
        }


        #username_ {
            outline: none;
            border: 1px solid #898E01;
            min-width: 80%;
            font-size: 200%;
            font-family: Calibri;
            color: #898E01;
            background-color: #080808;
            opacity: 0.9;
        }

        #Password1 {
            outline: none;
            border: 1px solid #898E01;
            min-width: 80%;
            font-size: 200%;
            font-family: Calibri;
            color: #898E01;
            background-color: #080808;
            opacity: 0.9;
        }

        #Button1 {
            cursor: pointer;
            border: none;
            margin-top: 3%;
            margin-bottom: 2%;
            outline: none;
            background-color: #898E01;
            color: #080808;
            font-size: 200%;
            font-weight: bolder;
            font-family: Calibri;
            padding: 2%;
        }

        #Button1:hover{
            box-shadow: 0 0 10px #898E01;
        }

        #Label1 {
            color: #898E01;
            font-family: Calibri;
            font-size: 140%;
        }

        @media only screen and (min-width: 1024px) {
            body {
                background-image: url('https://i.imgur.com/FKNQ2rM.png');
                background-size: 100%;
                background-repeat: no-repeat;
            }

            #title {
                width: 60%;
            }

            #login{
                border: 1px solid #898E01;
                margin-top: 1%;
                text-align: center;
                width: 40%;
                margin-left: 30%;
                background-color: #080808;
                opacity: 0.8;
            }

            h1 {
                color: #898E01;
                font-family: Calibri;
                font-size: 140%;
            }

            #username_ {
                outline: none;
                border: 1px solid #898E01;
                min-width: 40%;
                font-size: 100%;
                font-family: Calibri;
                color: #898E01;
                background-color: #080808;
                opacity: 0.9;
            }

            #Password1 {
                outline: none;
                border: 1px solid #898E01;
                min-width: 40%;
                font-size: 100%;
                font-family: Calibri;
                color: #898E01;
                background-color: #080808;
                opacity: 0.9;
            }

            #Button1 {
                cursor: pointer;
                border: none;
                margin-top: 3%;
                margin-bottom: 2%;
                outline: none;
                background-color: #898E01;
                color: #080808;
                font-size: 100%;
                font-weight: bolder;
                font-family: Calibri;
                padding: 1%;
            }
        }

    </style>
</head>
<body>

     <table id="Menu_title">
        <tr>
            <td>
                <img src="https://i.imgur.com/bdQfMea.png"width="35%" id="title" alt="title" />
            </td>
        </tr>
    </table>

    <form id="form1" runat="server">
        <div>
            <table id="login">
                <tr>

                    <td>

                        <h1>
                            Felhasználónév:
                        </h1>

                        <p><input id="username_" type="text" runat="server"/></p>

                        <h1>
                            Jelszó:
                        </h1>
                        <p><input id="Password1" type="password" runat="server"/></p>

                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sajt" />
                    </td>

                </tr>
            </table>
        </div>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </p>
    </form>
            
</body>
</html>
