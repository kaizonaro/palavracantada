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
                
                //breadcrumb
                breadcrumb.InnerHtml = "<a href='/' title='Home'>Home</a> >> <strong>Blog</strong> >> " + rsBlog["POS_TITULO"] + " ";

                //imagem
                imgPost.Src = "/upload/imagens/blog/thumb-" + rsBlog["POS_IMAGEM"].ToString() + "";

                //Texto
                txtPost.InnerHtml += "<span>Publicado por <strong><i>" + rsBlog["USU_NOME"] + rsBlog["ADM_NOME"] + "</i></strong> na categoria <<categoria>> em <strong><i>" + rsBlog["POS_DH_PUBLICACAO"].ToString() + "</i></strong></span><br/><br/>";
                txtPost.InnerHtml += "" + rsBlog["POS_TEXTO"].ToString() + "";
            }
        }
    }
}