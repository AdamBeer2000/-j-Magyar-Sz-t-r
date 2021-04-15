<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="tanitas3.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            margin: 2%;
            text-align: center;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
        }

        .light 
        {
            background-color:#8ec2ff;
        }

        .black 
        {
            background-color:#161616;
        }

        #Button5
        {
            background-color: #50ff1c;
            color: #202020;
            padding-left: 2%;
            padding-right: 2%;
            padding-top: 1%;
            padding-bottom: 1%;
            margin-left: 2%;
            font-family: Calibri;
            font-weight: bold;
            outline: none;
            border: none;
            cursor: pointer;
        }

        #Button1
        {
            background-color: #ee0a1d;
            color: #202020;
            padding-left: 2%;
            padding-right: 2%;
            padding-top: 1%;
            padding-bottom: 1%;
            margin-left: 2%;
            font-family: Calibri;
            font-weight: bold;
            outline: none;
            border: none;
            cursor: pointer;
        }

        .macska{
            border: 1px solid #6f00ff;
            text-align: left;
            color: #6f00ff;
            font-family: Calibri;
            font-size: 100%;
            font-style: italic;
            padding: 2%;
            margin-left: 30%;
        }


    </style>
</head>
<body id="mainPage" runat="server">
    <form id="form1" runat="server">
        <div id="thing" runat="server">

            <asp:Menu ID="Menu1" runat="server">
                <Items>
                    <asp:MenuItem NavigateUrl="~/Main.aspx" Text="SzövegSzerk" Value="SzöbegSzerk"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/WebForm2.aspx" Text="TableGen" Value="TableGen"></asp:MenuItem>
                    <asp:MenuItem Text="Chart" Value="Chart" NavigateUrl="~/WebForm3.aspx"></asp:MenuItem>
                </Items>
            </asp:Menu>

            <asp:Button ID="Button5" runat="server" onclick="Hozzaad2" Text="Sor hozzáadasa" />
            <asp:Button ID="Button1" runat="server" onclick="elvesz" Text="Sor elvétele" />

            <asp:Table ID="Tablazat1" runat="server" CssClass="macska"></asp:Table>
        </div>
    </form>

    
</body>
</html>
