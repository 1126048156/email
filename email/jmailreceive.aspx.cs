using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using jmail;
using System.Web.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Data;

namespace email
{
    public partial class jmailreceive : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            showmail();

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("email.aspx?id=" + this.GridView1.SelectedDataKey["id"].ToString());
            }
           catch(Exception ex){
               Response.Write(ex.Message);
           };
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int i;
            //执行循环，保证每条数据都可以更新
            for (i = 0; i < GridView1.Rows.Count + 1; i++)
            {
                //首先判断是否是数据行
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //当鼠标停留时更改背景色和鼠标形状
                    e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#5FB878';this.style.cursor='pointer'");
                    //当鼠标移开时还原背景色
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
                }
            }
            PostBackOptions myPostBackOptions = new PostBackOptions(this);
            myPostBackOptions.AutoPostBack = false;
            myPostBackOptions.RequiresJavaScriptProtocol = true;
            myPostBackOptions.PerformValidation = false;
            String evt = Page.ClientScript.GetPostBackClientHyperlink(sender as GridView, "Select$" + e.Row.RowIndex.ToString());
            e.Row.Attributes.Add("onclick", evt);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            POP3Class popmails=new POP3Class();//建立接收邮箱的对象
            Message mailMessage;//邮箱信息接口
            try{
            string str = ConfigurationManager.ConnectionStrings["jmailConnectionString"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(str);
            con.Open();
            popmails.Connect("xxxx@163.com", "xxxx", "pop.163.com",110);//链接邮箱服务  参数用户名,密码,服务器地址,端口
            if(popmails.Count>0)
                {
                  for(int i=1;i<popmails.Count;i++)
                   {
                    string theUid = popmails.GetMessageUID(i);
                    mailMessage = popmails.Messages[i];//获得一条邮件信息
                   
                    if(!getLocalUID(theUid))
                      {
                   String s =null;
                   Attachments attachments = mailMessage.Attachments;      //建立附件集接口
         
                    for (int j = 0; j < attachments.Count; j++)         
                      {              //根据索引取附件
                          Attachment attachment = attachments[j];             //附件名
                          string fileName = attachment.Name;              //附件保存在指定路径，不要有同名文件，否则出异常
                          string road = Server.MapPath("/recieveatt/") + fileName;
                          attachment.SaveToFile(road);
                          s = road + "  ";
                        }               
                        string insert = "insert into tb_JMail(sendmail,mailtitle,mailcontents,mailtime,idu,att) values('"+ DecodeStr(mailMessage.From) + " " + "','" + DecodeStr(mailMessage.Headers.GetHeader("Subject")) + "','" + mailMessage.Body + "','" + mailMessage.Date.ToString("yyyy-MM-dd") + "','" + theUid +"','"+s+"')";                       
                        SqlCommand com = new SqlCommand(insert, con);
                        com.ExecuteNonQuery();
                      }                     
                    }
                }
            showmail();
            con.Close();

            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        public Boolean getLocalUID(string n)//通过uid判断数据库有没有该邮件
        {
            string str = ConfigurationManager.ConnectionStrings["jmailConnectionString"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand com = new SqlCommand("select * from tb_JMail where idu='"+n+"'", con);
            SqlDataReader rd = com.ExecuteReader();
            while (rd.Read() == true)
            {
                return true;
            }
            return false;
        }
        protected string MyContent(string input)//在gridview中显示20个字符
        {
            if (input.Length > 20)
            {
                return input.Substring(0, 20) + "......";
            }
            else
            {
                return input.Substring(0, input.Length);
            }
        }
        public string DecodeStr(string str)
        {
            Boolean flag=false;
            String[] code = { "UTF-8", "GB2312", "ISO-2022-JP","GB18030"};//添加编码
            string result = "";
            if (!str.Equals(String.Empty))
            {
                for (int i = 0; i < code.Length; i++)
                {
                    if (str.ToUpper().Contains(code[i]))
                    {
                        String[] array = str.Split('?');
                        if (array.Length > 2)
                        {
                            string title = array[3];
                            byte[] bytes = Convert.FromBase64CharArray(title.ToCharArray(), 0, title.ToCharArray().Length);
                            Encoding en = Encoding.GetEncoding(code[i].ToLower());
                            result = en.GetString(bytes);
                            return result;
                        }
                        flag = false;
                    }                                       
                }
                 if(!flag)
                     return str;
            }
            return "";
        }
        private void showmail()
        {
            string con=ConfigurationManager.ConnectionStrings["jmailConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            String str = "select *from tb_JMail order by id desc";         
            SqlDataAdapter ad = new SqlDataAdapter(str, connection);
             DataSet adds = new DataSet();
             ad.Fill(adds);
             if (adds.Tables[0].Rows.Count > 0)
             {
                 GridView1.DataSource = adds;
                 GridView1.DataKeyNames = new string[] { "id" };
                 GridView1.DataBind();
             }
             connection.Close();   
        }
    }
}