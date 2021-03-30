<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebNewmagyarszotar.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Regisztáció</title>
    <link rel="stylesheet" href="Style_Register.css" />

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

        #register{
            border: 1px solid #898E01;
            margin-top: 1%;
            text-align: center;
        }

        h1 {
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
                <img src="https://i.imgur.com/McfDfCf.png"width="35%" id="title" alt="title" />
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
                        <p id="hiba_username">
                        </p>
                        <asp:TextBox ID="usernameBox" runat="server" OnTextChanged="usernameBox_TextChanged" AutoPostBack="True"></asp:TextBox>
                        <br />

                        <h1>
                            Jelszó:
                        </h1>
                        <p id="hiba_password1">
                        </p>
                        <asp:TextBox  ID="passwordBox1" TextMode="Password" runat="server" OnTextChanged="passwordBox1_TextChanged" AutoPostBack="True"></asp:TextBox>
                        <br />

                        <h1>
                            Jelszó mégegyszer:
                        </h1>
                        <p id="hiba_password2">
                        </p>
                        <asp:TextBox  ID="passwordBox2" TextMode="Password" runat="server" OnTextChanged="passwordBox2_TextChanged" AutoPostBack="True"></asp:TextBox>
                        <br />

                        <h1>
                            E-mail:
                        </h1>
                        <p id="hiba_email">
                        </p>
                        <asp:TextBox ID="emailBox" TextMode="Email" runat="server" OnTextChanged="emailBox_TextChanged" AutoPostBack="True"></asp:TextBox>
                    </td>
                </tr>
                
            </table>
        </div>
    </form>
</body>
</html>
