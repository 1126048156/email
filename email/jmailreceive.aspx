<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jmailreceive.aspx.cs" Inherits="email.jmailreceive" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
                   使用jmail接收邮件<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">接收邮件</asp:LinkButton>            
                   
    </div>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"  DataKeyNames="id"  PageSize="18" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"  />
                            <asp:BoundField DataField="sendmail" HeaderText="sendmail" />
                            <asp:BoundField DataField="mailtitle" HeaderText="mailtitle"/>
                            <asp:TemplateField HeaderText="mailcontents">
                               
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# MyContent((string)Eval("mailcontents"))%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="mailtime" HeaderText="mailtime" DataFormatString="{0:d}" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
    </form>
</body>
</html>
