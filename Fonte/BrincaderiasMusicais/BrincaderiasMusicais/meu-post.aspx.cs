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
    public partial class meu_post : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsUser, rsBlog;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            if (Session["nomeUsuario"] != null && Session["nomeUsuario"].ToString().Length > 1 && string.IsNullOrWhiteSpace(Request["POS_ID"]) == false)
            {
                objBD.ExecutaSQL("update PostBlog set POS_ATIVO = 0 where POS_ID = " + Request["POS_ID"]);
                Response.Redirect("meu-perfil");
            }


            //Verificar se ainda está logado
            if (Session["nomeUsuario"] != null && Session["nomeUsuario"].ToString().Length > 1 && Request["titulo"] != null)
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
                    img_perfil.InnerHtml = "<img class=\"mini_perfil\" src=\"/upload/imagens/usuarios/" + rsUser["USU_FOTO"] + "\" alt=\"Foto do Perfil do " + Session["nomeUsuario"].ToString() + "\" />";
                }
                rsUser.Dispose();
                rsUser.Close();

                PopulaBlog();

                
                
            }
            else
            {
                //DESLOGADO
                Response.Redirect("/");
            }

        }

        public void PopulaBlog()
        {
            rsBlog = objBD.ExecutaSQL("EXEC site_PostBlogPorTitulo '" + Request["titulo"] + "' ");
            if (rsBlog == null)
            {
                throw new Exception();
            }
            if (rsBlog.HasRows)
            {
                rsBlog.Read();

                //imagem
                img1.Src = "/upload/imagens/blog/big-" + rsBlog["POS_IMAGEM"].ToString() + "";
                logPost.InnerHtml += "Publicado por <strong><i>" + rsBlog["USU_NOME"] + rsBlog["ADM_NOME"] + "</i></strong> em <strong><i>" + rsBlog["POS_DH_PUBLICACAO"].ToString() + "</i></strong> na categoria: <strong><i>" + rsBlog["PCA_TITULO"].ToString() + "</i></strong><br/><br/>";

                //Texto
                txtPost.InnerHtml += "<p class='tit_post'>" + rsBlog["POS_TITULO"] + "</p>";
                txtPost.InnerHtml += "" + rsBlog["POS_TEXTO"].ToString() + "";
                editar_bt.Attributes.Add("href","/enviar-post?POS_ID=" + rsBlog["POS_ID"].ToString());
                excluir_bt.Attributes.Add("href", "/meu-post.aspx?POS_ID=" + rsBlog["POS_ID"].ToString());

            }

            rsBlog.Close();
            rsBlog.Dispose();
        }
    }
}