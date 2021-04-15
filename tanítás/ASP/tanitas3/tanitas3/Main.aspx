<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="tanitas3.WebForm1" %>
<%@ Register assembly="System.Web.DataVisualization, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sample text</title>
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

        h1 {
            font-family: Calibri;
            color: #f00f51;
        }

        h2 {
            text-align: left;
            margin-left: 10%;
            font-family: Calibri;
            color: #00b0e6;
        }

        #harmadik  {
            text-align: left;
            font-weight: bold;
            margin-left: 10%;
            font-family: Calibri;
            color: #e6e200;
        }

        #lista1 {
            margin-left: 15%;
            font-family: Calibri;
            text-align: left;
            color: #00e626;
        }

        #inputmezo {
            font-family: Calibri;
            text-align: left;
            font-size: 20px;
            margin-top: 1%;
            border: 2px solid #00b0e6;
            width: 300px;
            background-color: #161616;
            color: #00b0e6;
            outline: none;
        }

        ::placeholder {
            color: #00b0e6;
        }

        #Button1 {
            background-color: #00b0e6;
            border: none;
            font-family: Calibri;
            font-weight: bold;
            font-size: 20px;
            color: #202020;
            padding: 5px 15px;
            text-align: center;
            outline: none;
            margin-top: 1%;
        }

        #Button2 {
            background-color: #00b0e6;
            border: none;
            font-family: Calibri;
            font-weight: bold;
            font-size: 20px;
            color: #202020;
            padding: 5px 15px;
            text-align: center;
            outline: none;
            margin-top: 1%;
        }

        #Button1:hover {
            cursor: pointer;
            box-shadow: 0 0 10px #00b0e6;
        }

        #Button5 {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            background-color: #00b0e6;
            font-family: Calibri;
            font-weight: bold;
            font-size: 20px;
            color: #202020;
            padding: 5px 15px;
            text-align: center;
            outline: none;
            }

        #Select1 {
            width: 100px;
        }

        </style>
</head>
<body runat="server" id="mainPage">
    <form id="form1" runat="server">
        <div>

            <asp:Menu ID="Menu1" runat="server">
                <Items>
                    <asp:MenuItem NavigateUrl="~/Main.aspx" Text="SzöbegSzerk" Value="SzöbegSzerk"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/WebForm2.aspx" Text="TableGen" Value="TableGen"></asp:MenuItem>
                    <asp:MenuItem Text="Chart" Value="Chart" NavigateUrl="~/WebForm3.aspx"></asp:MenuItem>
                </Items>
            </asp:Menu>
            <h1>Ez itt egy szöveg.
                <asp:Button ID="Button3" runat="server" OnClick="light_button_Click" Text="Light" />
                <asp:Button ID="Button4" runat="server" Text="Dark" OnClick="dark_button_Click" />
            </h1>

            <div id="input_mezo">
                <asp:TextBox ID="inputmezo" runat="server" placeholder="Ide lehet valamit írni..."></asp:TextBox>
            </div>

            <asp:Button ID="Button1" runat="server" onclick="doit" Text="Do it" />
            
            <h2>
                Ez egy másik szöveg.
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </h2>

                <div id="harmadik" runat="server">
                    Ezt akarjuk megváltoztatni.
                </div>

            <ul runat="server" id="lista1">
            </ul>

        </div>
            
    </form>
</body>
</html>
