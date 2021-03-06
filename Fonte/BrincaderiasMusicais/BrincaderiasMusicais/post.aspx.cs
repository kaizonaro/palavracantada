﻿using System;
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
    public partial class post : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsBlog;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            if (Request["titulo"] != null)
            {
                PopulaBlog();
            }
            else
            {
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

                //facebook
                // metaTitle.Content = "Projeto Brincadeiras Musicais da Palavra Cantada - Blog";
                metaTitle.Content = "" + rsBlog["POS_TITULO"].ToString() + "";
                metaImage.Content = "http://projetopalavracantada.net/images/logo-fb.png";
                //metaDescription.Content = "" + rsBlog["POS_TITULO"].ToString() + "";
                metaDescription.Content = "" + rsBlog["POS_TEXTO"].ToString() + "";
                metaURL.Content = "http://projetopalavracantada.net/post/" + Request["titulo"] + "";
                var USU_ID_BLOG = rsBlog["USU_ID"].ToString();
                if (!string.IsNullOrWhiteSpace(USU_ID_BLOG))
                {
                    var USU_ID_SESSAO = Session["usuId"].ToString();
                    if (USU_ID_BLOG == USU_ID_SESSAO)
                    {
                        Response.Redirect("../meu-post/" + Request["titulo"]);
                    }
                }
                // liFace.InnerHtml = "<iframe src=\"//www.facebook.com/plugins/like.php?href=http%3A%2F%2Fprojetopalavracantada.net%2Fpost%2F" + objUtils.GerarURLAmigavel(rsBlog["POS_TITULO"].ToString()) + "&amp;width&amp;layout=button_count&amp;action=like&amp;show_faces=true&amp;share=true&amp;height=21&amp;appId=404437276390840\" scrolling=\"no\" frameborder=\"0\" style=\"border:none; overflow:hidden; height:21px;\" allowTransparency=\"true\"></iframe>";


                if (!string.IsNullOrWhiteSpace(rsBlog["RED_ID"].ToString()))
                {
                    //breadcrumb
                    breadcrumb.InnerHtml = "<a href='/' title='Home'>Home</a> >> <strong><a href=\"/blog-regional\">Blog-Regional</a></strong> >> " + rsBlog["POS_TITULO"] + " ";
                }
                else
                {
                    //breadcrumb
                    breadcrumb.InnerHtml = "<a href='/' title='Home'>Home</a> >> <strong>Blog</strong> >> " + rsBlog["POS_TITULO"] + " ";
                }

                if (string.IsNullOrWhiteSpace(rsBlog["POS_IMAGEM"].ToString()) == true)
                {
                    imgPost.Attributes.Add("style", "display:none;");
                }
                //imagem
                imgPost.Src = "/upload/imagens/blog/big-" + rsBlog["POS_IMAGEM"].ToString() + "";
                logPost.InnerHtml += "Publicado por <strong><i>" + rsBlog["USU_NOME"] + rsBlog["ADM_NOME"] + "</i></strong> em <strong><i>" + rsBlog["POS_DH_PUBLICACAO"].ToString() + "</i></strong> na categoria: <strong><i>" + rsBlog["PCA_TITULO"].ToString() + "</i></strong><br/><br/>";
                //Texto

                txtPost.InnerHtml += "<p class='tit_post'>" + rsBlog["POS_TITULO"] + "</p>";
                txtPost.InnerHtml += "" + rsBlog["POS_TEXTO"].ToString() + "";

                //liGPlus.InnerHtml = "<div class='g-plus' data-action='share' data-annotation='bubble' data-href='href=\"/post/" + objUtils.GerarURLAmigavel(rsBlog["POS_TITULO"].ToString()) + "\"'></div>";
            }
            rsBlog.Close();
            rsBlog.Dispose();
        }
    }
}