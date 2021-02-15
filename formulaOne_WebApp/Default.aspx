<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication_F1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>F1 - Show db Table</title>
    <link rel = "stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css">
</head>
<body>
    <form id="form1" runat="server">
        <!--
        Username <asp:TextBox ID="txtUserName" runat="server"/><br /><br />
        Password <input type="text" ID="txtPassword"/><br /><br />
        -->
        <div style="width:97%;height:auto;margin:1% auto;">
            <asp:Label ID="lblMessaggio" runat="server" Text=""/>
            <br /><br />
            <asp:ListBox ID="lstTable" runat="server" Width="230px" Height="64px" style="margin-bottom: 0px" OnSelectedIndexChanged="loadData" AutoPostBack="true"></asp:ListBox>
            <br /><br />
            <asp:GridView ID="dataTable" runat="server" class="table table-striped table-bordered"></asp:GridView>
            <asp:Label ID="lblNoData" runat="server" Text=""/>
        </div>
    </form>
</body>
</html>