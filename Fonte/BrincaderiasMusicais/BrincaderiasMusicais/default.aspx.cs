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
        private OleDbDataReader rsLogin, rsBlog, rsVideo;

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
                        PopularBlog();
                        //PopularVideos();
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

        
          public void PopularBlog()
          {
              rsBlog = objBD.ExecutaSQL("EXEC site_psPostBlog");

              if (rsBlog == null)
              {
                  throw new Exception();
              }
              if (rsBlog.HasRows)
              {
                  while (rsBlog.Read())
                  {
                    ulPost.InnerHtml += " <li><a href=\"javascript:void(0)\" title=\"Titulo da postagem\"><img src='/upload/imagens/blog/cropadas/" + rsBlog["POS_IMAGEM"].ToString() + "'></a>";
                    ulPost.InnerHtml += "   <p class=\"titu_post_home\"><a href=\"javascript:void(0)\">" + rsBlog["POS_TITULO"].ToString() + "</a></p>";
                    ulPost.InnerHtml += "   <p class=\"desc_post_home\"><a href=\"javascript:void(0)\">" + objUtils.CortarString(true, 110, rsBlog["POS_TEXTO"].ToString()) + "</a></p>";
                    ulPost.InnerHtml += "   <a href=\"javascript:void(0)\" class=\"btn\">LEIA MAIS</a>";
                    ulPost.InnerHtml += " </li>";
                  }
              }

              rsBlog.Dispose();
              rsBlog.Close();
          }
 /* 
          public void PopularVideos()
          {
              rsVideo = objBD.ExecutaSQL("EXEC site_psVideoHome");

              if (rsVideo == null)
              {
                  throw new Exception();
              }
              if (rsVideo.HasRows)
              {
                  while (rsVideo.Read())
                  {
                      divVideos.InnerHtml += "<img src='" + rsVideo["GVI_IMAGEM"].ToString() + "' aria-hidden=\"true\" width=\"196\"> &nbsp;";
                  }
              }

              rsVideo.Dispose();
              rsVideo.Close();
          }*/
    }
}