<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jmail.aspx.cs" Inherits="email.jmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            收件人地址：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            邮件主题：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p>
            邮件内容：<asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine"></asp:TextBox>
        </p>
        抄送：<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        <br />
        附件：<asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="发送邮件" style="height: 21px" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="重新填写" />
    </form>
</body>
</html>
