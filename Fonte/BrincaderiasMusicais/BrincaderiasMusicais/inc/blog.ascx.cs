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
    public partial class blog : System.Web.UI.UserControl
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsBlog;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    objUtils = new utils();
                    objBD = new bd();

                    if (Session["nomeUsuario"] != null && Session["nomeUsuario"].ToString().Length > 1)
                    {
                        //LOGADO
                        pBlog.InnerHtml = "BLOG BRINCADEIRAS MUSICAIS<br />Blog Regional - " + Session["nomeInstituicao"] + "";
                    }
                    else
                    {
                        //DESLOGADO
                        pBlog.InnerHtml = "BLOG BRINCADEIRAS MUSICAIS<br />(PUBLICAÇÕES RECENTES)";
                    }


                    PopularBlog(Convert.ToInt16(Session["redeID"]));
                }
                catch (Exception)
                {

                    throw;
                }
            }

            
        }

        public void PopularBlog(int RED_ID)
        {
            rsBlog = objBD.ExecutaSQL("EXEC site_psPostBlog " + RED_ID + " ");

            if (rsBlog == null)
            {
                throw new Exception();
            }
            if (rsBlog.HasRows)
            {
                while (rsBlog.Read())
                {
                    ulPost.InnerHtml += " <li><a href=\"/post/" + objUtils.GerarURLAmigavel(rsBlog["POS_TITULO"].ToString()) + "\" title=\"Titulo da postagem\"><img src='/upload/imagens/blog/thumb-" + rsBlog["POS_IMAGEM"].ToString() + "'></a>";
                    ulPost.InnerHtml += "   <p class=\"titu_post_interna\"><a href=\"post/" + objUtils.GerarURLAmigavel(rsBlog["POS_TITULO"].ToString()) + "\">" + objUtils.CortarString(true, 45, rsBlog["POS_TITULO"].ToString()) + "</a></p>";
                    ulPost.InnerHtml += "   <p class=\"desc_post_interna\"><a href=\"post/" + objUtils.GerarURLAmigavel(rsBlog["POS_TITULO"].ToString()) + "\">" + objUtils.RemoveHTML(objUtils.CortarString(true, 60, rsBlog["POS_TEXTO"].ToString())) + "</a></p>";
                    ulPost.InnerHtml += "   <a href=\"/post/" + objUtils.GerarURLAmigavel(rsBlog["POS_TITULO"].ToString()) + "\" class=\"btn\">LEIA MAIS</a>";
                    ulPost.InnerHtml += " </li>";
                }
            }

            rsBlog.Dispose();
            rsBlog.Close();
        }
    }

}