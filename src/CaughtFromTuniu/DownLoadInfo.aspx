<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DownLoadInfo.aspx.cs" Inherits="CaughtFromTuniu.DownLoadInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>抓包</title>
</head>
<body>
    <center>
    <form id="form1" runat="server" >
    <div style="text-align:center;" >
       
    <table>
        <tr>
            <td>出发城市名称：</td>
            <td>
                <asp:TextBox ID="txtSetOutCityId" runat="server"></asp:TextBox></td>

        </tr>
        <tr>
            <td>到达城市名称：</td>
            <td>
                <asp:TextBox ID="txtArriveAtCityId" runat="server"></asp:TextBox></td>

        </tr>
        <tr>

            <td colspan="2" align="center">
                <asp:Button ID="btnDownLoad" runat="server" Text="抓取数据" OnClick="btnDownLoad_Click" /></td>
        </tr>
    </table>
         
    </div>
    </form>
        </center>
</body>
</html>
