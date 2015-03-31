using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Etnia.classe;
using System.Data.OleDb;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace BrincaderiasMusicais.inc
{
    public partial class blogPessoal : System.Web.UI.UserControl
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsBlog;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            PopularBlog();
        }

        public void PopularBlog()
        {
            rsBlog = objBD.ExecutaSQL("EXEC site_psPostBlogPorUsuID " + Session["usuID"] + " ");

            if (rsBlog == null)
            {
                throw new Exception();
            }
            if (rsBlog.HasRows)
            {
                while (rsBlog.Read())
                {
                    ulPost.InnerHtml += " <li>";
                    ulPost.InnerHtml += "   <p class=\"titu_post_home\"><a href=\"meu-post/" + objUtils.GerarURLAmigavel(rsBlog["POS_TITULO"].ToString()) + "\">" + objUtils.CortarString(true, 36, rsBlog["POS_TITULO"].ToString().ToUpper()) + "</a></p>";
                    ulPost.InnerHtml += "   <p class=\"desc_post_home\"><a href=\"meu-post/" + objUtils.GerarURLAmigavel(rsBlog["POS_TITULO"].ToString()) + "\">" + objUtils.RemoveHTML(objUtils.CortarString(true, 110, rsBlog["POS_TEXTO"].ToString())) + "</a></p>";
                    ulPost.InnerHtml += "   <a href=\"/meu-post/" + objUtils.GerarURLAmigavel(rsBlog["POS_TITULO"].ToString()) + "\" class=\"btn\">LEIA MAIS</a>";
                    ulPost.InnerHtml += " </li>";
                }
            }

            rsBlog.Dispose();
            rsBlog.Close();
        }
    }
}