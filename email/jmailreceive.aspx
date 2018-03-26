<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jmailreceive.aspx.cs" Inherits="email.jmailreceive" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .style1 {
           cursor:pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
                   使用jmail接收邮件<asp:LinkButton ID="LinkButton1" runat="server">接收邮件</asp:LinkButton>            
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"  DataKeyNames="id" DataSourceID="SqlDataSource1"  PageSize="18" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" class="style">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                            <asp:BoundField DataField="sendmail" HeaderText="sendmail" SortExpression="sendmail" />
                            <asp:BoundField DataField="mailtitle" HeaderText="mailtitle" SortExpression="mailtitle" />
                            <asp:BoundField DataField="mailcontents" HeaderText="mailcontents" SortExpression="mailcontents" />
                            <asp:BoundField DataField="mailtime" HeaderText="mailtime" SortExpression="mailtime" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:jmailConnectionString %>" SelectCommand="SELECT * FROM [tb_JMail] ORDER BY [id] DESC"></asp:SqlDataSource>           
    </div>
    </form>
</body>
</html>
