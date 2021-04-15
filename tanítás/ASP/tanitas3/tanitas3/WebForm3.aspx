<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="tanitas3.WebForm3" %>

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
    </style>
</head>
<body id="ChartPage" runat="server" >
    <form id="form1" runat="server">
        <div>

            <div>
            <table style="margin-left: auto;margin-right: auto;">
                <tr>
                <th rowspan="7">
                    <asp:Chart ID="Chart1" runat="server" OnLoad="Chart1_Load" Height="364px" Width="413px">
                    <series>
                    </series>
                    <chartareas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                        </chartareas>
                    </asp:Chart>
                </th>
                <th></th></tr>
                <tr><th>A-csapat</th></tr>
                <tr><th><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></th></tr>
                <tr><th>B-csapat</th></tr>
                <tr><th><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></th></tr>
                <tr><th><asp:Button ID="Csapat1_Gomb" runat="server" OnClick="Send_Click" Text="Draw" /></th></tr>
                <tr><th>
                    <asp:DropDownList ID="DropDownList1" runat="server" onselectedindexchanged="Send_Click" AutoPostBack="True">
                         <asp:ListItem Selected="True" Value="Pie"> Pie </asp:ListItem>
                          <asp:ListItem Value="Bar"> Bar </asp:ListItem>
                          <asp:ListItem Value="Doughnut"> Doughnut </asp:ListItem>
                    </asp:DropDownList>
                </th></tr>
            </table>
            </div>
        </div>
        <asp:Chart ID="Chart2" runat="server">
            <Series>
                <asp:Series Name="Series1">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </form>
</body>
</html>
