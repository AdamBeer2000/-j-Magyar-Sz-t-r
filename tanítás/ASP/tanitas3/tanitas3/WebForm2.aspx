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
            background-color:#161616
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
                    <asp:MenuItem NavigateUrl="~/Main.aspx" Text="SzöbegSzerk" Value="SzöbegSzerk"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/WebForm2.aspx" Text="TableGen" Value="TableGen"></asp:MenuItem>
                    <asp:MenuItem Text="Chart" Value="Chart" NavigateUrl="~/WebForm3.aspx"></asp:MenuItem>
                </Items>
            </asp:Menu>

            <asp:Button ID="Button5" runat="server" onclick="Hozzaad2" Text="Sor hozza adasa" />
            <asp:Button ID="Button1" runat="server" onclick="elvesz" Text="Sor elvétele" />

            <asp:Table ID="Tablazat1" runat="server" CssClass="macska"></asp:Table>
        </div>
    </form>

    
</body>
</html>
