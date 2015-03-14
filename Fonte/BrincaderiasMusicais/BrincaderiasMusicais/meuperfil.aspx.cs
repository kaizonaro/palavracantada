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
    public partial class meuperfil : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsUser, rsBlog;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            //Verificar se ainda está logado
            if (Session["nomeUsuario"] != null && Session["nomeUsuario"].ToString().Length > 1)
            {
                //LOGADO -- Session["usuID"]
                rsUser = objBD.ExecutaSQL("select USU_BIOGRAFIA, USU_FOTO from Usuario where USU_ID = " + Session["usuID"] + " ");
                if (rsUser == null)
                {
                    throw new Exception();
                }
                if (rsUser.HasRows)
                {
                    rsUser.Read();

                    nome_perfil.InnerHtml = Session["nomeUsuario"].ToString();
                    regiao_perfil.InnerHtml = Session["nomeInstituicao"].ToString();
                    txt_perfil.InnerHtml = rsUser["USU_BIOGRAFIA"].ToString();
                    img_perfil.InnerHtml = "<img src=\"/upload/imagens/usuarios/" + rsUser["USU_FOTO"] + "\" />";
                    
                }
                rsUser.Dispose();
                rsUser.Close();

                PopularBlog();
            }
            else
            {
                //DESLOGADO
                Response.Redirect("/");
            }
            
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
                    ulPost.InnerHtml += " <li><a href=\"/meu-post/" + objUtils.GerarURLAmigavel(rsBlog["POS_TITULO"].ToString()) + "\" title=\"Titulo da postagem\"><img src='/upload/imagens/blog/thumb-" + rsBlog["POS_IMAGEM"].ToString() + "'></a>";
                    ulPost.InnerHtml += "   <p class=\"titu_post_home\"><a href=\"meu-post/" + objUtils.GerarURLAmigavel(rsBlog["POS_TITULO"].ToString()) + "\">" + objUtils.CortarString(true, 36, rsBlog["POS_TITULO"].ToString()) + "</a></p>";
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