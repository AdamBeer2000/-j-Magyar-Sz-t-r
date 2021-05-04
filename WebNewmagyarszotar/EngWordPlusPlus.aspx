amú<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EngWordPlusPlus.aspx.cs" Inherits="WebNewmagyarszotar.EngWordPlusPlus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Angol szó hozzáadása</title>

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

        #textbox_addid {
            border: 1px solid #898E01;
            margin-top: 1%;
            text-align: center;
            width: 60%;
            margin-left: 20%;
            background-color: #080808;
            opacity: 0.8;
            margin-bottom: 2%;
        }

        h1 {
            color: #898E01;
            font-family: Calibri;
            font-size: 200%;
        }

         #eng_word_textbox {
            outline: none;
            border: 1px solid #898E01;
            min-width: 60%;
            font-size: 200%;
            font-family: Calibri;
            color: #898E01;
            background-color: #080808;
            opacity: 0.9;
         }

         #eng_description_textbox {
            outline: none;
            border: 1px solid #898E01;
            min-width: 60%;
            font-size: 200%;
            font-family: Calibri;
            color: #898E01;
            background-color: #080808;
            opacity: 0.9;
            margin-bottom: 2%;
         }

         #error_label {
            font-size: 200%;
            font-family: Calibri;
            color: #898E01;
         }

         #error_desc {
            font-size: 200%;
            font-family: Calibri;
            color: #898E01;
         }

         #debugl {
            font-size: 200%;
            font-family: Calibri;
            color: #898E01;
         }

         #add_eng_button {
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
            padding: 1%;
         }

         #add_eng_button:hover{
            box-shadow: 0 0 10px #898E01;
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

            h1 {
                color: #898E01;
                font-family: Calibri;
                font-size: 100%;
            }

            #textbox_addid {
                border: 1px solid #898E01;
                margin-top: 1%;
                text-align: center;
                width: 30%;
                margin-left: 35%;
                background-color: #080808;
                opacity: 0.8;
            }

            #eng_word_textbox {
                outline: none;
                border: 1px solid #898E01;
                min-width: 40%;
                font-size: 100%;
                font-family: Calibri;
                color: #898E01;
                background-color: #080808;
                opacity: 0.9;
            }

            #eng_description_textbox {
                outline: none;
                border: 1px solid #898E01;
                min-width: 40%;
                font-size: 100%;
                font-family: Calibri;
                color: #898E01;
                background-color: #080808;
                opacity: 0.9;
                margin-bottom: 2%;
            }

            #error_label {
                font-size: 100%;
                font-family: Calibri;
                color: #898E01;
             }

            #error_desc {
                font-size: 100%;
                font-family: Calibri;
                color: #898E01;
             }

             #debugl {
                font-size: 100%;
                font-family: Calibri;
                color: #898E01;
             }

             #add_eng_button {
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
    <form id="eng_form" runat="server">

        <table id="Menu_title">
        <tr>
            <td>
                <img src="https://i.imgur.com/gFTaptm.png" id="title" alt="title" />
            </td>
        </tr>
    </table>

    <table id="textbox_addid">
        <tr>
            <td>

                <h1>
                    Angol szó:
                </h1>

                <asp:Label ID="error_label" runat="server" Text=""></asp:Label>
                <br />

                <asp:TextBox ID="eng_word_textbox" runat="server" OnTextChanged="eng_word_textbox_TextChanged"></asp:TextBox>
                <br />

                <h1>
                    Leírás:
                </h1>

                <asp:Label ID="error_desc" runat="server" Text=""></asp:Label>
                <br />

                <asp:TextBox ID="eng_description_textbox" runat="server" OnTextChanged="eng_description_textbox_TextChanged"></asp:TextBox>
                <br />
                <h1>
                    Magyar szó (Opcionális):
                </h1>

                <asp:Label ID="hl" runat="server" Text=""></asp:Label>
                <br />

                <asp:TextBox ID="ht" runat="server"></asp:TextBox>
                <br />

                <asp:Button ID="add_eng_button" runat="server" OnClick="add_eng_button_Click" Text="Hozzáad" />
            </td>
        </tr>
    </table>
            
        <p>
        <asp:Label ID="debugl" runat="server" Text="D-Dont look my d-debug.. b-baka!!!"></asp:Label>
        </p>
    </form>
</body>
</html>
