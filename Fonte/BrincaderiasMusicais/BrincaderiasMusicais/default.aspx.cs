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
        private OleDbDataReader rsBlog, rsVideo, rsVFoto, rsCargo, rsToken, rsEmail;

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                objUtils = new utils();
                objBD = new bd();
                string acao = Request["acao"];

                switch (acao)
                {
                    case "validaemail":
                        rsEmail = objBD.ExecutaSQL("SELECT USU_USUARIO from Usuario where USU_EMAIL = '" + Request["USU_EMAIL"] + "'");
                        if (rsEmail.HasRows)
                        {
                            rsEmail.Read();
                            Response.Write("<p>Esse email já está cadastrado!</p>");
                            Response.End();
                        }
                        else
                        {
                            Response.Write("OK");
                            Response.End();
                        }
                        break;
                    default:
                        PopularBlog(Convert.ToInt16(Session["redeID"]));
                        PopularVideos(Convert.ToInt16(Session["redeID"]));
                        PopularFotos(Convert.ToInt16(Session["redeID"]));
                        PopularCargos();
                        break;
                }

                //Verificar acesso via Toke
                if (Request["accesstoken"] != null && Request["accesstoken"].ToString().Length > 1)
                {
                    rsToken = objBD.ExecutaSQL("select TOK_ID from TokenUsuario where TOK_TOKEN = " + Request["accesstoken"].ToString() + " and tok_ativo = 1 ");

                    if (rsToken == null)
                    {
                        throw new Exception();
                    }
                    if (rsToken.HasRows)
                    {
                        rsToken.Read();

                        Session.Abandon();
                        TOK_TOKEN.Value = Request["accesstoken"];
                        mask.Attributes.Add("style", "display:block");
                        modal.Attributes.Add("style", "display:block");

                    }
                    else
                    {
                        Response.Redirect("/");
                    }

                    rsToken.Close();
                    rsToken.Dispose();

                }
                if (Session["nomeUsuario"] != null && Session["nomeUsuario"].ToString().Length > 1)
                {
                    //LOGADO
                    pBlog.InnerHtml = "<img src='/images/titu_blog_home.png' >Blog Regional - " + Session["nomeInstituicao"] + "";
                    spanGaleria.InnerHtml = "GALERIA COLABORATIVA BRINCADEIRAS MUSICAIS:";
                }
                else
                {
                    //DESLOGADO
                    pBlog.InnerHtml = "<img src='/images/titu_blog_home.png' >Blog brincadeiras musicais: <em>(posts Recentes)</em>";
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
                    ulPost.InnerHtml += " <li><a href=\"/post/" + objUtils.GerarURLAmigavel(rsBlog["POS_TITULO"].ToString()) + "\" title=\"Titulo da postagem\"><img src='/upload/imagens/blog/thumb-" + rsBlog["POS_IMAGEM"].ToString() + "'></a>";
                    ulPost.InnerHtml += "   <p class=\"titu_post_home\"><a href=\"post/" + objUtils.GerarURLAmigavel(rsBlog["POS_TITULO"].ToString()) + "\">" + objUtils.CortarString(true, 36, rsBlog["POS_TITULO"].ToString()) + "</a></p>";
                    ulPost.InnerHtml += "   <p class=\"desc_post_home\"><a href=\"post/" + objUtils.GerarURLAmigavel(rsBlog["POS_TITULO"].ToString()) + "\">" + objUtils.RemoveHTML(objUtils.CortarString(true, 110, rsBlog["POS_TEXTO"].ToString())) + "</a></p>";
                    ulPost.InnerHtml += "   <p class=\"desc_post_home\">&nbsp;</p>";
                    ulPost.InnerHtml += "   <a href=\"/post/" + objUtils.GerarURLAmigavel(rsBlog["POS_TITULO"].ToString()) + "\" class=\"btn\">LEIA MAIS</a>";
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
                    ulVideos.InnerHtml += " </li>";
                }
            }

            rsVideo.Dispose();
            rsVideo.Close();
        }

        public void PopularFotos(int RED_ID)
        {
            rsVFoto = objBD.ExecutaSQL("EXEC site_psFoto  " + RED_ID + " ");

            if (rsVFoto == null)
            {
                throw new Exception();
            }
            if (rsVFoto.HasRows)
            {
                while (rsVFoto.Read())
                {
                    ulFotos.InnerHtml += " <li>";
                    ulFotos.InnerHtml += "     <a href=\"/upload/imagens/galeria/" + rsVFoto["GFO_IMAGEM"].ToString() + "\">";
                    ulFotos.InnerHtml += "         <img src=\"/upload/imagens/galeria/thumb-" + rsVFoto["GFO_IMAGEM"].ToString() + "\" alt=\" " + rsVFoto["GFO_LEGENDA"].ToString() + "\" /></a>";
                    ulFotos.InnerHtml += "     </a>";
                    ulFotos.InnerHtml += "     <p>:: " + rsVFoto["GFO_LEGENDA"].ToString() + " ::</p>";
                    ulFotos.InnerHtml += " </li>";
                }
            }

            rsVFoto.Dispose();
            rsVFoto.Close();
        }

        public void PopularCargos()
        {
            rsCargo = objBD.ExecutaSQL("select CAR_ID, CAR_TITULO from cargo where CAT_ATIVO = 1");
            if (rsCargo == null)
            {
                throw new Exception();
            }
            if (rsCargo.HasRows)
            {
                while (rsCargo.Read())
                {
                    System.Web.UI.WebControls.ListItem R = new System.Web.UI.WebControls.ListItem();
                    R.Value = rsCargo["CAR_ID"].ToString();
                    R.Text = rsCargo["CAR_TITULO"].ToString();
                    CAR_ID.Items.Add(R);
                }
            }
            rsCargo.Close();
            rsCargo.Dispose();
        }
    }
}



