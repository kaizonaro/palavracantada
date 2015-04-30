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
    public partial class headerperfil : System.Web.UI.UserControl
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsUser, rsPerfil;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["usuUsuario"].ToString();
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Desculpe... Você não pode vizualizar perfis enquanto estiver deslogado. Por favor efetue login e tente novamente.'); window.history.back();</script>");
                Response.End();
            }

            objUtils = new utils();
            objBD = new bd();
            ModificaBotoes();
            //Ajustando as classes dos botões
            string urlCompleta = Request.Url.AbsoluteUri;
            string paginaAtual = Request.CurrentExecutionFilePath;
            paginaAtual = paginaAtual.Remove(0, paginaAtual.LastIndexOf("/") + 1);


            switch (paginaAtual)
            {
                case "minha-galeria.aspx":
                    videos.Attributes["class"] += " disabled ";
                    blog.Attributes["class"] += " disabled ";
                    break;

                case "meus-videos.aspx":
                    fotos.Attributes["class"] += " disabled ";
                    blog.Attributes["class"] += " disabled ";
                    break;
                case "meu-blog.aspx":
                    fotos.Attributes["class"] += " disabled ";
                    videos.Attributes["class"] += " disabled ";
                    break;
                /* case "editar_config.aspx":
                     fotos.Attributes["class"] += " disabled ";
                     videos.Attributes["class"] += " disabled ";
                     break;*/
                default:
                    fotos.Attributes["class"] = " img_links";
                    videos.Attributes["class"] = " img_links ";
                    blog.Attributes["class"] = " img_links ";
                    break;
            }

            rsUser = objBD.ExecutaSQL("select USU_BIOGRAFIA, USU_FOTO from Usuario where USU_ID = " + Session["usuID"] + " ");
            if (rsUser == null)
            {
                throw new Exception();
            }
            if (rsUser.HasRows)
            {
                rsUser.Read();

                ///nome_perfil.InnerHtml = Session["nomeUsuario"].ToString();
                // regiao_perfil.InnerHtml = Session["nomeInstituicao"].ToString();
                // txt_perfil.InnerHtml = rsUser["USU_BIOGRAFIA"].ToString();

                if (rsUser["USU_FOTO"].ToString().Length < 1)
                {
                    img_perfil.InnerHtml = "<img src='/images/img_perfil.jpg'/>";
                }
                else
                {
                    img_perfil.InnerHtml = "<img src=\"/upload/imagens/usuarios/" + rsUser["USU_FOTO"] + "\" />";
                }
            }
            rsUser.Dispose();
            rsUser.Close();
        }

        void ModificaBotoes()
        {
            string usuario = Request["usuario"];
            bool valida = true;

            if (string.IsNullOrWhiteSpace(usuario))
            {
                usuario = Session["usuUsuario"].ToString();
                valida = false;
            }

            if (Request["usuario"] == Session["usuUsuario"].ToString())
            {
                valida = false;
            }

            rsPerfil = objBD.ExecutaSQL("EXEC PerfilUsuarioPorUsername " + usuario);
            if (rsPerfil == null)
            {
                Response.Redirect("./default.aspx");
            }
            if (rsPerfil.HasRows)
            {
                rsPerfil.Read();
                ValidaPrivacidade(valida);


                nomeusuario.InnerText = rsPerfil["USU_NOME"].ToString();
                regiao.InnerText = rsPerfil["USU_REGIAO"].ToString();
                biografia.InnerText = rsPerfil["USU_BIOGRAFIA"].ToString();
                foto.Attributes.Add("src", "upload/imagens/usuarios/" + rsPerfil["USU_FOTO"].ToString());

                if (Session["usuID"].ToString() != rsPerfil["USU_ID"].ToString())
                {
                    linkfotos.Attributes.Add("href", "/perfil/fotos/" + rsPerfil["USU_USUARIO"]);
                    linkvideos.Attributes.Add("href", "/perfil/videos/" + rsPerfil["USU_USUARIO"]);
                    linkblog.Attributes.Add("href", "/perfil/blog/" + rsPerfil["USU_USUARIO"]);

                    linkfotos_img.Attributes.Add("src", "/images/fotos_perfil2.png");
                    linkvideos_img.Attributes.Add("src", "/images/videos_perfil2.png");
                    linkblog_img.Attributes.Add("src", "/images/blog_perfil2.png");
                }
                else
                {
                    linkfotos.Attributes.Add("href", "/minhas-fotos");
                    linkvideos.Attributes.Add("href", "/meus-videos");
                    linkblog.Attributes.Add("href", "/meu-blog");
                }

                if (Session["redeID"].ToString() != rsPerfil["RED_ID"].ToString()) { Response.Write("<script>alert('Desculpe... Este usuario não é da sua Rede.'); window.history.back();</script>"); }


            }
            else
            {
                Response.Write("<script>alert('Desculpe... Este usuario não existe'); window.history.back();</script>");
                Response.End();
            }
        }

        private void ValidaPrivacidade(bool validacao)
        {
            if (validacao == false)
            {
                return;
            }

            if (rsPerfil["PRI_PERFIL"].ToString() == "true")
            {
                Response.Write("<script>alert('Desculpe... Este perfil é privado.'); window.history.back();</script>");
                Response.End();
            }

            switch (new FileInfo(this.Request.Url.LocalPath).Name)
            {
                case "perfil-blog.aspx":
                    if (rsPerfil["PRI_BLOG"].ToString() == "True")
                    {
                        Response.Write("<script>alert('Desculpe... Este blog é privado.'); window.history.back();</script>");
                        Response.End();
                    }
                    break;
                case "minha-galeria.aspx":
                    if (rsPerfil["PRI_FOTOS"].ToString() == "True")
                    {
                        Response.Write("<script>alert('Desculpe... Esta galeria de fotos é privada.'); window.history.back();</script>");
                        Response.End();
                    }
                    break;
                case "meus-videos.aspx":
                    if (rsPerfil["PRI_VIDEOS"].ToString() == "True")
                    {
                        Response.Write("<script>alert('Desculpe... Este galeria de videos é privada.'); window.history.back();</script>");
                        Response.End();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}