<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="tanitas3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sample text</title>
    <style>
        body {
            margin: 2%;
            background-color:  	#161616;
            text-align: center;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
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

        #macska{
            border: 1px solid #6f00ff;
            text-align: center;
            color: #6f00ff;
            font-family: Calibri;
            font-size: 100%;
            font-style: italic;
            padding: 2%;
            margin-left: 30%;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h1>
                Ez itt egy szöveg.
            </h1>

            <div id="input_mezo">
                <asp:TextBox ID="inputmezo" runat="server" placeholder="Ide lehet valamit írni..."></asp:TextBox>
                <asp:TextBox ID="inputmezo2" runat="server" placeholder="Ide lehet valamit írni..."></asp:TextBox>
            </div>

            <asp:Button ID="Button1" runat="server" onclick="doit" Text="Do it" />

            <asp:Button ID="Button3" runat="server" onclick="feladat2b" Text="Do it 2" />

            <h2>
                Ez egy másik szöveg.
            </h2>

                <div id="harmadik" runat="server">
                    Ezt akarjuk megváltoztatni.
                </div>

            <table id="macska">
                <tr>
                    <td>
                        Ez
                    </td>
                    <td>
                        egy
                    </td>
                </tr>
                <tr>
                    <td>
                        2x2
                    </td>
                    <td>
                        táblázat
                    </td>
                </tr>
            </table>

            <asp:Button ID="Button2" runat="server" onclick="Hozzaad" Text="Hozzaad" />

            <ul runat="server" id="lista1">
            </ul>

        </div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="#006600"></asp:Label>
            <asp:Chart ID="Chart1" runat="server">
                <series>
                    <asp:Series ChartType="Pie" Name="Series1">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </chartareas>
            </asp:Chart>
        </div>
        <div id="input_mezo">
                <asp:TextBox ID="TextBox3b1" runat="server" placeholder="gyarto [Opel, Ford, stb]"></asp:TextBox>
                <asp:TextBox ID="TextBox3b2" runat="server" placeholder="Uzemanyag [benzin, dizel]"></asp:TextBox>
                <asp:Button ID="go3b" runat="server" onclick="dewit" Text="Dewit" /> <p></p>
                <asp:Label ID="label3b" runat="server" Text="" ForeColor="#FF0000"></asp:Label>
        </div>
    </form>
</body>
</html>
