<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EngWordPlusPlus.aspx.cs" Inherits="WebNewmagyarszotar.EngWordPlusPlus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Angol szó hozzáadása</title>
     <!--<style type="text/css">
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

        #textbox_addid {

        }

    </style>-->
</head>
<body>
    <form id="eng_form" runat="server">
        <div>
        </div>
        <table id="textbox_addid">
            <tr>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="eng_word_textbox_TextChanged"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <asp:TextBox ID="eng_word_textbox" runat="server" OnTextChanged="eng_word_textbox_TextChanged"></asp:TextBox>
        <asp:Label ID="error_label" runat="server" Text=""></asp:Label>
        <p>
            <asp:TextBox ID="eng_description_textbox" runat="server" OnTextChanged="eng_description_textbox_TextChanged"></asp:TextBox>
        </p>
            <asp:ImageButton ID="add_eng_button" runat="server" Height="42px" OnClick="add_eng_button_Click" Width="48px" />
        <p>
        <asp:Label ID="debugl" runat="server" Text="D-Dont look my d-debug.. b-baka!!!"></asp:Label>
        </p>
    </form>
</body>
</html>
