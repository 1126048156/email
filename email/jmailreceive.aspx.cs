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

namespace email
{
    public partial class jmailreceive : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String con = WebConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString.ToString();

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("email.aspx?id=" + this.GridView1.SelectedDataKey["id"].ToString());
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
                    //当鼠标停留时更改背景色
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
    }
}