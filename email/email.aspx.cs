using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;

namespace email
{
    public partial class email : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String id = Request.Params["id"];
            String str = ConfigurationManager.ConnectionStrings["jmailConnectionString"].ConnectionString.ToString();
            SqlConnection connection=new SqlConnection(str);
            connection.Open();
            SqlCommand com = new SqlCommand("select mailtitle,sendmail,mailtime,mailcontents,att from tb_JMail where id="+Request.Params["id"], connection);
            SqlDataReader read = com.ExecuteReader();
            while (read.Read()==true)
            {
                Label1.Text = read["mailtitle"].ToString();
                Label2.Text = read["sendmail"].ToString();
                Label3.Text = read["mailtime"].ToString().Substring(0,9); 
                if (!read["mailcontents"].ToString().Equals(String.Empty))
                {
                    Label4.Text = read["mailcontents"].ToString();
                    Label4.Visible = true;
                }
                if (!read["att"].ToString().Equals(String.Empty))
                {
                    Label6.Text= read["att"].ToString();       
                    Label5.Visible = true;
                }
            }
            read.Close();
            connection.Close();
        }
    }
}