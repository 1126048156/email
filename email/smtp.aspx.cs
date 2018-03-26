using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.IO;
namespace email
{
    public partial class smtp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {         
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            MailMessage mymail=new MailMessage();//声明一个mail对象
            mymail.From=new MailAddress("xxxx@163.com","your name");//发件人地址,姓名
            mymail.To.Add(new MailAddress(TextBox1.Text));//收件人地址
            mymail.Subject=TextBox2.Text;//邮件主题
            mymail.Body=TextBox3.Text;//发送邮件的内容
          //  string filename = Path.GetFileName(FileUpload1.FileName);//获得文件名和后缀
        
            //FileUpload1.SaveAs(Server.MapPath("~/") + filename)//保存文件到本程序的文件夹下
            Attachment myfiles = new Attachment(FileUpload1.PostedFile.InputStream, FileUpload1.PostedFile.FileName);//把上传的文件指向的文件流给附件对象
            mymail.Attachments.Add(myfiles);//发送邮件附件使用Attachments
            mymail.CC.Add(new MailAddress(TextBox4.Text));//抄送邮件用CC

            SmtpClient myclient=new SmtpClient();//创建一个邮件服务器
            myclient.Host="smtp.163.com";//使用的163的SMTP服务器
            myclient.Port=25;//smtp服务器端口
            myclient.Credentials=new NetworkCredential("xxxxx@163.com", "xxxxx");//网易的邮箱及密码
            myclient.Send(mymail);
            Response.Write("成功！");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
        }
      }
    }