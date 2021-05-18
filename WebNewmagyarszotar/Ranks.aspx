<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ranks.aspx.cs" Inherits="WebNewmagyarszotar.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <style>
        body {
            background-image: url('https://i.imgur.com/DkxArzl.png');
            background-size: 100%;
            background-repeat: repeat;
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

        .rangtabla {
            border: 1px solid #5B5E00;
            padding: 1%;
            text-align: center;
            width: 100%;
            height: 20%;
            background-color: #000000;
            opacity: 0.8;
        }

        .rangtabla tr td {
            border: 1px solid #5B5E00;
        }

        #back_image {
            width: 20%;
        }

        #only_text_label0 {
            font-family: Calibri;
            font-size: 100%;
            color: #898E01;
            background-color: none;
            opacity: 0.9;
        }

        #rank_label {
            font-family: Calibri;
            font-size: 300%;
            color: #898E01;
            background-color: none;
            opacity: 0.9;
        }

        #only_text_label1 {
            font-family: Calibri;
            font-size: 150%;
            color: #898E01;
            background-color: none;
            opacity: 0.9;
        }

        #need_to_next_rank_label {
            font-family: Calibri;
            font-size: 150%;
            color: #898E01;
            background-color: none;
            opacity: 0.9;
        }

        #only_text_label2 {
            font-family: Calibri;
            font-size: 100%;
            color: #898E01;
            background-color: none;
            opacity: 0.9;
        }

        .cimsor {
           font-family: Calibri;
            font-size: 200%;
            color: #898E01;
            background-color: none;
            opacity: 0.9;
        }

        .simasor {
           font-family: Calibri;
            font-size: 160%;
            color: #898E01;
            background-color: none;
            opacity: 0.9;
        }

        @media only screen and (min-width: 1024px) {
            body {
                background-image: url('https://i.imgur.com/FKNQ2rM.png');
                background-size: 100%;
                background-repeat: repeat;
            }

            .rangtabla {
                padding: 1%;
                text-align: center;
                width: 100%;
                height: 20%;
            }

            #back_image {
                width: 15%;
            }

            .cimsor {
                font-size: 120%;
            }

            .simasor {
                font-size: 100%;
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
            
            <asp:Label ID="only_text_label0" runat="server" Text=""></asp:Label><br>
            <asp:Label ID="rank_label" runat="server"></asp:Label><br><br><br>
            <asp:Label ID="only_text_label1" runat="server" Text="A legkedveltebb szavadról hiányzó like-ok következő rangig"></asp:Label><br>
            <asp:Label ID="need_to_next_rank_label" runat="server"></asp:Label><br><br><br>
            
            <asp:Label ID="only_text_label2" runat="server" Text="Többi felhasználó rangja  [ Csak akkor lehetsz rajta a ranglistán, ha már kaptál lájkot! ]"></asp:Label><br>
            <br>

            <table id="rank_table" runat="server">
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
            
        </div>
        <a id="vissza" href="index.aspx">
            <img src="https://i.imgur.com/Gq9hR5m.png" id="back_image" alt="back_image" />
        </a>
    </form>
</body>
</html>
