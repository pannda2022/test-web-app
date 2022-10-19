<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Application Insightsログ出力試験" OnClick="Button1_Click" />
        </div>
    </form>
    <input type="button" value="DB読み取り" onclick="location.href='GetDB.aspx'" />
    <input type="button" value="Blobにファイル出力" onclick="location.href='SaveFile.aspx'" />
    <input type="button" value="ADのトークン取得" onclick="location.href='GetToken.aspx'" />
</body>
</html>
