﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Browse.aspx.cs" Inherits="WebNewmagyarszotar.WebForm4"  MaintainScrollPositionOnPostback="true"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Böngészés</title>

    <style type="text/css">
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

        #title {
            width: 80%;
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
            font-size: 150%;
            font-family: Calibri;
            color: #898E01;
        }

        .lapozo {
            font-size: 120%;
            font-weight: bold;
            text-decoration: none;
            font-family: Calibri;
            color: #898E01;
        }
        .lapozofocus {
            font-size: 120%;
            font-weight: bold;
            text-decoration: underline;
            font-family: Calibri;
            color: #898E01;
        }

        #Label3 {
            color: #898E01;
            padding-top: 2%;
            padding-bottom: 5%;
            font-size: 150%;
            font-family: Calibri;
        }

        #World {
            font-size: 180%;
            text-decoration: none;
            font-family: Calibri;
            color: #898E01;
        }

        #Creator {
            font-size: 140%;
            text-decoration: none;
            font-family: Calibri;
            color: #898E01;
        }

        #Definicon {
            font-size: 140%;
            text-decoration: none;
            font-family: Calibri;
            color: #898E01;
        }

        #searchbutton {
            margin-top: 100px;
            height: 30px;
            height: 30px;
            outline: none;
        }

        #searchBox {
            outline: none;
            border: 1px solid #898E01;
            min-width: 40%;
            font-size: 400%;
            font-family: Calibri;
            color: #898E01;
            background-color: #080808;
            opacity: 0.9;
        }

        #searchBox::-webkit-input-placeholder {
            color: #898E01;
        }
        #searchBox:-moz-placeholder {
            color: #898E01;
        }
        #searchBox::-moz-placeholder {
            color: #898E01;
        }

        .cimsor td{
            border: 1px dashed rgba(137, 142, 1, 0.2);
            border-bottom: 1px solid rgba(137, 142, 1, 0.5);
            color: #898E01;
            font-size: 300%;
            font-family: Calibri;
            font-weight: bold;
        }

        tr.egysor td{
            border: 1px solid #898E01;
        }

        #for_back {
            border: none;
            margin-top: 2%;
            padding-top: 2%;
            margin-left: 10%;
            margin-right: 10%;
            text-align: center;
            width: 80%;
            height: 40%;
        }

        .rowStyle td
        {
            padding-top: 2%;
            padding-bottom: 2%;
            border: 1px dashed rgba(137, 142, 1, 0.2);
            border-bottom: 1px solid rgba(137, 142, 1, 0.5);
            color: #898E01;
            font-size: 200%;
            font-family: Calibri;
            max-height: 30%;
        }
        .textStyle 
        {
            color: #898E01;
            text-decoration: none;
            font-family: Calibri;
            max-height: 30%;
        }

        .textStyle2
        {
            color: #898E01;
            text-decoration: none;
            font-family: Calibri;
            max-height: 30%;
        }

        .addbutton
        {
            height: 20px;
            outline: none;
        }

        .reportbutton
        {
            margin-left: 2%;
            height: 23px;
            outline: none;

        }

        .likebutton
        {
            height: 60px;
            outline: none;
        }

        .lenyitbutton
        {
            height: 20px;
            outline: none;
        }

        #back_image {
            width: 20%;
            outline: none;
        }

        .modalBackground
        {
            background-color: #000000;
            filter: alpha(opacity=90);
            opacity: 0.7;
        }

        .modalPopup
        {
            background-color: #080808;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 400px;
            height: 210px;
        }

        #Label2 {
            color: #898E01;
            padding-top: 2%;
            padding-bottom: 5%;
            font-size: 200%;
            font-family: Calibri;
        }

        #reportCommentInput {
            outline: none;
            border: 1px solid #898E01;
            min-width: 50%;
            font-size: 150%;
            font-family: Calibri;
            color: #898E01;
            background-color: #080808;
        }

        #WordAddInputBox {
            outline: none;
            border: 1px solid #898E01;
            min-width: 60%;
            font-size: 200%;
            font-family: Calibri;
            color: #898E01;
            background-color: #080808;
        }

        .WordAddInputConfirm {
            cursor: pointer;
            border: none;
            margin-top: 3%;
            margin-bottom: 1%;
            outline: none;
            background-color: #898E01;
            color: #080808;
            font-size: 160%;
            font-weight: bolder;
            font-family: Calibri;
            padding: 2%;
        }

        .WordAddInputConfirm:hover{
            box-shadow: 0 0 10px #898E01;
        }

        @media only screen and (min-width: 1024px) {
            body {
                background-image: url('https://i.imgur.com/FKNQ2rM.png');
                background-size: 100%;
                background-repeat: repeat;
            }

            #title {
                width: 60%;
            }

            h1 {
                font-size: 120%;
                font-family: Calibri;
                color: #898E01;
            }

            .lapozo {
                font-size: 120%;
                font-weight: bold;
                text-decoration: none;
                font-family: Calibri;
                color: #898E01;
            }

            #Label3 {
                color: #898E01;
                padding-top: 2%;
                padding-bottom: 5%;
                font-size: 150%;
                font-family: Calibri;
            }

            #World {
                font-size: 160%;
                text-decoration: none;
                font-family: Calibri;
                color: #898E01;
            }

            #Creator {
                font-size: 120%;
                text-decoration: none;
                font-family: Calibri;
                color: #898E01;
            }

            #Definicon {
                font-size: 120%;
                text-decoration: none;
                font-family: Calibri;
                color: #898E01;
            }

            #searchbutton {
                height: 25px;
                height: 25px;
                outline: none;
            }

            #searchBox {
                outline: none;
                border: 1px solid #898E01;
                min-width: 40%;
                font-size: 200%;
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

            .rowStyle td
            {
                padding-top: 0%;
                padding-bottom: 0%;
                border: 1px dashed rgba(137, 142, 1, 0.2);
                border-bottom: 1px solid rgba(137, 142, 1, 0.5);
                color: #898E01;
                font-size: 120%;
                font-family: Calibri;
                max-height: 30%;
            }

            .addbutton
            {
                height: 12px;
                outline: none;
            }

            .reportbutton
            {
                margin-left: 2%;
                height: 13px;
                outline: none;
            }

            .likebutton
            {
                height: 30px;
                outline: none;
            }

            .lenyitbutton
            {
                height: 10px;
                outline: none;
            }

            .modalPopup
            {
                background-color: #080808;
                border-width: 3px;
                border-style: solid;
                border-color: black;
                padding-top: 10px;
                padding-left: 10px;
                width: 300px;
                height: 140px;
            }

            #Label2 {
                color: #898E01;
                padding-top: 2%;
                padding-bottom: 5%;
                font-size: 150%;
                font-family: Calibri;
            }

            .LableBad {
                color: red;
                padding-top: 2%;
                padding-bottom: 5%;
                font-size: 100%;
                font-family: Calibri;
            }
            .LableGood {
                color: green;
                padding-top: 2%;
                padding-bottom: 5%;
                font-size: 100%;
                font-family: Calibri;
            }

            #WordAddInputBox {
                outline: none;
                border: 1px solid #898E01;
                min-width: 40%;
                font-size: 150%;
                font-family: Calibri;
                color: #898E01;
                background-color: #080808;
            }

            #reportCommentInput {
                outline: none;
                border: 1px solid #898E01;
                min-width: 50%;
                font-size: 150%;
                font-family: Calibri;
                color: #898E01;
                background-color: #080808;
            }

            .WordAddInputConfirm {
                cursor: pointer;
                border: none;
                margin-top: 3%;
                margin-bottom: 1%;
                outline: none;
                background-color: #898E01;
                color: #080808;
                font-size: 100%;
                font-weight: bolder;
                font-family: Calibri;
                padding: 2%;
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
                outline: none;
            }

            #back_image {
                width: 15%;
                outline: none;
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
        <asp:ScriptManager ID="Sm1" runat="server"></asp:ScriptManager>

        <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup">
            <asp:Label ID="Label2" runat="server" Text="Szó Hozzáadása"></asp:Label><br>
            <asp:Label ID="AddWordResponseLable" runat="server" Text=""></asp:Label><br>
            <asp:TextBox ID="WordAddInputBox" runat="server"></asp:TextBox><br>
            <asp:Button ID="Confirm" runat="server" Text="Hozzáad" OnClick="WordAddInputConfirm_Click" CssClass="WordAddInputConfirm"/>
            <asp:Button ID="Cancle" runat="server" Text="Mégse" OnClick="WordAddCancle_Click" CssClass="WordAddInputConfirm"/>
        </asp:Panel>

        <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="Button2" BackgroundCssClass="modalBackground"> </cc1:ModalPopupExtender>

        <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup">

            <asp:Label ID="Label3" runat="server" Text="Szó bejelentése"></asp:Label><br>
            <asp:Label ID="ReportWordResponseLable" runat="server" Text=""></asp:Label><br>
            <asp:TextBox ID="reportCommentInput" runat="server"></asp:TextBox><br>

            <asp:Button ID="Button1" runat="server" Text="Bejelent" OnClick="WordAddReportConfirm_Click" CssClass="WordAddInputConfirm"/>
            <asp:Button ID="Button3" runat="server" Text="Mégse" OnClick="WordReportCancle_Click" CssClass="WordAddInputConfirm"/>

        </asp:Panel>

        <cc1:ModalPopupExtender ID="mp2" runat="server" PopupControlID="Panel2" TargetControlID="Button2" BackgroundCssClass="modalBackground"> </cc1:ModalPopupExtender>

        <asp:Panel ID="WordInfoPanel" runat="server" CssClass="modalPopup">

            <asp:Label ID="World" runat="server"></asp:Label><br>
            <asp:Label ID="Creator" runat="server"></asp:Label><br>
            <asp:Label ID="Definicon" runat="server"></asp:Label><br>
            <asp:Button ID="Button4" runat="server" Text="Vissza" OnClick="WordReportCancle_Click" CssClass="WordAddInputConfirm"/>

        </asp:Panel>
        <cc1:ModalPopupExtender ID="WorldInfoExtender" runat="server" PopupControlID="WordInfoPanel" TargetControlID="Button2" BackgroundCssClass="modalBackground"> </cc1:ModalPopupExtender>

        <asp:Button ID="Button2" runat="server" Text="Button" style="display: none;"/>

    <table id="search">
        <tr>
            <td>
                <asp:TextBox ID="searchBox" runat="server" OnTextChanged="searchBox_TextChanged1" AutoPostBack="True"></asp:TextBox>
                <asp:ImageButton ID ="searchbutton" runat="server" src="https://i.imgur.com/vXukVi0.png"></asp:ImageButton>
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
            <td id="pagenums" runat="server">
                
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
        <a id="vissza" href="index.aspx">
            <img src="https://i.imgur.com/Gq9hR5m.png" id="back_image" alt="back_image" />
        </a>
    </form>
</body>
<%--</html>--%>
