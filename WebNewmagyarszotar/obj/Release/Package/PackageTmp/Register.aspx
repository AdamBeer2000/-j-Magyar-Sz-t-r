<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebNewmagyarszotar.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Regisztáció</title>

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

        #register{
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
            font-size: 250%;
        }

        #usernameBox {
            outline: none;
            border: 1px solid #898E01;
            min-width: 80%;
            font-size: 200%;
            font-family: Calibri;
            color: #898E01;
            background-color: #080808;
            opacity: 0.9;
        }

        #passwordBox1 {
            outline: none;
            border: 1px solid #898E01;
            min-width: 80%;
            font-size: 200%;
            font-family: Calibri;
            color: #898E01;
            background-color: #080808;
            opacity: 0.9;
        }

        #passwordBox2 {
            outline: none;
            border: 1px solid #898E01;
            min-width: 80%;
            font-size: 200%;
            font-family: Calibri;
            color: #898E01;
            background-color: #080808;
            opacity: 0.9;
        }

        #emailBox {
            outline: none;
            border: 1px solid #898E01;
            min-width: 80%;
            font-size: 200%;
            font-family: Calibri;
            color: #898E01;
            background-color: #080808;
            opacity: 0.9;
        }

        #tovabb {
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

        #tovabb:hover{
            box-shadow: 0 0 10px #898E01;
        }

        #hiba_username {
            color: #FF3D3D;
            font-size: 200%;
        }

        #hiba_password1 {
            color: #FF3D3D;
            font-size: 200%;
        }

        #hiba_password2 {
            color: #FF3D3D;
            font-size: 200%;
        }

        #hiba_email {
            color: #FF3D3D;
            font-size: 200%;
        }

        #back_image {
            width: 20%;
        }

        #Label1 {
            font-family: Calibri;
            font-size: 100%;
            color: #898E01;
            background-color: #080808;
            opacity: 0.9;
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

            #register{
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

            #usernameBox {
                outline: none;
                border: 1px solid #898E01;
                min-width: 40%;
                font-size: 100%;
                font-family: Calibri;
                color: #898E01;
                background-color: #080808;
                opacity: 0.9;
            }

            #passwordBox1 {
                outline: none;
                border: 1px solid #898E01;
                min-width: 40%;
                font-size: 100%;
                font-family: Calibri;
                color: #898E01;
                background-color: #080808;
                opacity: 0.9;
            }

            #passwordBox2 {
                outline: none;
                border: 1px solid #898E01;
                min-width: 40%;
                font-size: 100%;
                font-family: Calibri;
                color: #898E01;
                background-color: #080808;
                opacity: 0.9;
            }

            #emailBox {
                outline: none;
                border: 1px solid #898E01;
                min-width: 40%;
                font-size: 100%;
                font-family: Calibri;
                color: #898E01;
                background-color: #080808;
                opacity: 0.9;
            }

            #tovabb {
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

            #hiba_username {
                color: #FF3D3D;
                font-size: 100%;
            }

            #hiba_password1 {
                color: #FF3D3D;
                font-size: 100%;
            }

            #hiba_password2 {
                color: #FF3D3D;
                font-size: 100%;
            }

            #hiba_email {
                color: #FF3D3D;
                font-size: 100%;
            }

            #back_image {
                width: 15%;
            }

            #Label1 {
                font-family: Calibri;
                font-size: 100%;
                color: #898E01;
                background-color: #080808;
                opacity: 0.9;
            }
        }

    </style>
</head>
<body>
    <table id="Menu_title">
        <tr>
            <td>
                <img src="https://i.imgur.com/McfDfCf.png" width="35%" id="title" alt="title" />
            </td>
        </tr>
    </table>

    <form id="form1" runat="server">
        <div>
            <table id="register">
                <tr>

                    <td>
                        <h1>
                            Felhasználónév:
                        </h1>
                        <p id="hiba_username" runat="server">
                        </p>
                        <asp:TextBox ID="usernameBox" runat="server"></asp:TextBox>
                        <br />

                        <h1>
                            Jelszó:
                        </h1>
                        <p id="hiba_password1" runat="server"> 
                        </p>
                        <asp:TextBox  ID="passwordBox1" TextMode="Password" runat="server"></asp:TextBox>
                        <br />

                        <h1>
                            Jelszó mégegyszer:
                        </h1>
                        <p id="hiba_password2" runat="server">
                        </p>
                        <asp:TextBox  ID="passwordBox2" TextMode="Password" runat="server"></asp:TextBox>
                        <br />

                        <br />

                        <asp:Button ID="tovabb" runat="server" Text="Tovább" OnClick="tovabb_Click"/>
                    </td>

                </tr>
            </table>
        </div>
        <p>
            <asp:Label ID="Label1" runat="server" BackColor="#080808" Text="Label"></asp:Label>
        </p>
        <a id="vissza" href="index.aspx">
            <img src="https://i.imgur.com/Gq9hR5m.png" id="back_image" alt="back_image" />
        </a>
    </form>
</body>
</html>
