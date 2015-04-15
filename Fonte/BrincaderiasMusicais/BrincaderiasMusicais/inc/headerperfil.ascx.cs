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
            rsPerfil = objBD.ExecutaSQL("EXEC PerfilUsuarioPorUsername " + Request["usuario"]);
            if (rsPerfil == null) { Response.Redirect("./default.aspx"); }
            if (rsPerfil.HasRows)
            {
                rsPerfil.Read();
                nomeusuario.InnerText = rsPerfil["USU_NOME"].ToString();
                regiao.InnerText = rsPerfil["USU_REGIAO"].ToString();
                biografia.InnerText = rsPerfil["USU_BIOGRAFIA"].ToString();
                foto.Attributes.Add("src", "upload/imagens/usuarios/" + rsPerfil["USU_FOTO"].ToString());

                if (Session["usuID"].ToString() != rsPerfil["USU_ID"].ToString())
                {
                    linkfotos.Attributes.Add("href", "/perfil/fotos/" + rsPerfil["USU_USUARIO"]);
                    linkvideos.Attributes.Add("href", "/perfil/videos/" + rsPerfil["USU_USUARIO"]);
                    linkblog.Attributes.Add("href", "/perfil/blog/" + rsPerfil["USU_USUARIO"]);




                }
                else
                {
                    linkfotos.Attributes.Add("href", "/minhas-fotos/");
                    linkvideos.Attributes.Add("href", "/meus-videos/");
                    linkblog.Attributes.Add("href", "/meu-blog/");
                }

                if (Session["redeID"].ToString() != rsPerfil["RED_ID"].ToString()) { Response.Redirect("../default.aspx"); Response.End(); }


            }
        }
    }
}