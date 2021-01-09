<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication_F1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!--
            Username <asp:TextBox ID="txtUserName" runat="server"/><br /><br />
            Password <input type="text" ID="txtPassword"/><br /><br />
            -->
            <asp:Label ID="lblMessaggio" runat="server" Text=" "/>
            <br />
            <asp:ListBox ID="lstTable" runat="server" Width="167px" Height="57px" style="margin-bottom: 0px" OnSelectedIndexChanged="loadData" AutoPostBack="true"></asp:ListBox>
            <br />
            <br />
            <asp:GridView ID="dataTable" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>