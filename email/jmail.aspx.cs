using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using jmail;
namespace email
{
    public partial class jmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

           MessageClass mymessage = new MessageClass();
           mymessage.Charset = "gb2312";  //设置邮件的编码格式为中文
           mymessage.From = "xxxx@163.com";//邮件的发送者的地址
           mymessage.FromName = "徐青青";//发送邮件的用户名
           mymessage.Subject = TextBox2.Text;//邮件的主题
           mymessage.Body = TextBox3.Text;//邮件的内容

           //// 设置登陆邮箱的用户名和密码
           mymessage.MailServerUserName = "xxxx@163.com";//登录邮件服务器所需的用户名   
           mymessage.MailServerPassWord = "xxxx";//登录邮件服务器所需的密码

            //接受邮件的地址
           mymessage.AddRecipient(TextBox1.Text);
           mymessage.Send("smtp.163.com");//服务器                
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
        }
    }
}