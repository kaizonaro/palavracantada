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
          /*  try
            {
                objUtils = new utils();
                objBD = new bd();
                string acao = Request["acao"];

                switch (acao)
                {
                    case "FazerLogin":
                        FazerLogin();
                        break;
                    
                    default:
                        PopularBlog();
                        PopularVideos();
                        break;
                }
            }
            catch (Exception ex)
            {
                objUtils.Feedbacker(ex);
                throw;
            }*/    
        }

        /*  public void FazerLogin()
          {
           
              rsLogin = objBD.ExecutaSQL("EXEC site_psUsuarioPorEmaileSenha '" + objUtils.TrataSQLInjection(Request["email"]) + "','" + objUtils.TrataSQLInjection(objUtils.getMD5Hash(Request["senha"])) + "'");

              if (rsLogin == null)
              {
                  throw new Exception();
              }
              if (rsLogin.HasRows)
              {
                  rsLogin.Read();
                  //Salvar as Session do usuário
                  Session["nomeUsuario"] = rsLogin["USU_NOME"].ToString();
                  Session["nomeInstituicao"] = rsLogin["RED_TITULO"].ToString();
                  Session["redeID"] = rsLogin["RED_ID"].ToString();

                  //Salva no log
                  objBD.ExecutaSQL("EXEC psLog '" + rsLogin["USU_ID"] + "',null,'Login efetuado no sistema'");

                  //Redereciona para a "home" logada
                  Response.Redirect("/rede/" + objUtils.GerarURLAmigavel(rsLogin["RED_TITULO"].ToString()));
                  Response.End();
              }
              else
              {
                  Response.Redirect("/");
              }

              rsLogin.Dispose();
              rsLogin.Close();
           
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
                      divBlog.InnerHtml += "<img src='upload/imagens/blog/cropadas/" + rsBlog["POS_IMAGEM"].ToString() + "'>";
                      divBlog.InnerHtml += "<strong>"+rsBlog["POS_TITULO"].ToString()+"</strong>";
                      divBlog.InnerHtml += "<p>" + objUtils.CortarString(true,110,rsBlog["POS_TEXTO"].ToString()) + "</p>";
                      divBlog.InnerHtml += "<p><a href='javascript:void(0);'>LEIA MAIS</a></p>";
                  }
              }

              rsBlog.Dispose();
              rsBlog.Close();
          }

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