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
 
namespace BrincaderiasMusicais
{
    public partial class _default : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsBlog, rsVideo;

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                objUtils = new utils();
                objBD = new bd();
                string acao = Request["acao"];

                switch (acao)
                {
                    default:
                        PopularBlog(Convert.ToInt16(Session["redeID"]));
                        PopularVideos(Convert.ToInt16(Session["redeID"]));
                        break;
                }


                if (Session["nomeUsuario"] != null && Session["nomeUsuario"].ToString().Length > 1)
                {
                    //LOGADO
                    pBlog.InnerHtml = "Blog Regional- << " + Session["nomeInstituicao"] + " >>";
                }
                else
                {
                    //DESLOGADO
                    pBlog.InnerHtml = "Blog brincadeiras musicais:<em>(posts Recentes)</em>";
                }

            }
            catch (Exception ex)
            {
                objUtils.Feedbacker(ex);
                throw;
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
                    ulPost.InnerHtml += " <li><a href=\"post/"+objUtils.GerarURLAmigavel(rsBlog["POS_TITULO"].ToString())+"\" title=\"Titulo da postagem\"><img src='/upload/imagens/blog/cropadas/" + rsBlog["POS_IMAGEM"].ToString() + "'></a>";
                    ulPost.InnerHtml += "   <p class=\"titu_post_home\"><a href=\"post/" + objUtils.GerarURLAmigavel(rsBlog["POS_TITULO"].ToString()) + "\">" + rsBlog["POS_TITULO"].ToString() + "</a></p>";
                    ulPost.InnerHtml += "   <p class=\"desc_post_home\"><a href=\"post/" + objUtils.GerarURLAmigavel(rsBlog["POS_TITULO"].ToString()) + "\">" + objUtils.RemoveHTML(objUtils.CortarString(true, 110, rsBlog["POS_TEXTO"].ToString())) + "</a></p>";
                    ulPost.InnerHtml += "   <a href=\"post/" + objUtils.GerarURLAmigavel(rsBlog["POS_TITULO"].ToString()) + "\" class=\"btn\">LEIA MAIS</a>";
                    ulPost.InnerHtml += " </li>";
                  }
              }

              rsBlog.Dispose();
              rsBlog.Close();
          }

        public void PopularVideos(int RED_ID)
          {
              rsVideo = objBD.ExecutaSQL("EXEC site_psVideo  " + RED_ID + " ");

              if (rsVideo == null)
              {
                  throw new Exception();
              }
              if (rsVideo.HasRows)
              {
                  while (rsVideo.Read())
                  {
                    ulVideos.InnerHtml += " <li>";
                    ulVideos.InnerHtml += "     <a href=\"" + rsVideo["GVI_LINK"].ToString() + "\">";
                    ulVideos.InnerHtml += "         <img src=\"" + rsVideo["GVI_IMAGEM"].ToString() + "\" alt=\"" + rsVideo["GVI_TITULO"].ToString() + "\" />";
                    ulVideos.InnerHtml += "     </a>";
                    ulVideos.InnerHtml += "     <p>:: " + rsVideo["GVI_TITULO"].ToString() + " ::</p>";
                    ulVideos.InnerHtml +=  " </li>";
                  }
              }

              rsVideo.Dispose();
              rsVideo.Close();
          }
    }
}