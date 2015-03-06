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
    public partial class quem_somos : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsTexto;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            Popula();
        }

        public void Popula()
        {
            rsTexto = objBD.ExecutaSQL("select SOB_TITULO, SOB_TEXTO_INICIAL, SOB_TEXTO_FINAL from SobreProjeto where SOB_ID = 2");
            if (rsTexto == null)
            {
                throw new Exception();
            }
            if (rsTexto.HasRows)
            {
                rsTexto.Read();

                //TÍTULO
                titu.InnerHtml += rsTexto["SOB_TITULO"].ToString();

                //breadcrumb
                breadcrumb.InnerHtml = "<a href='/' title='Home'>Home</a> >> <strong>Conheça - " + rsTexto["SOB_TITULO"].ToString() + "</strong>";
                central.InnerHtml += "<div class='txt'>" + rsTexto["SOB_TEXTO_INICIAL"].ToString() + "</div>";
                central.InnerHtml += "<img src='/images/quem-somos-2.jpg' class='img_destaque' />";
                central.InnerHtml += "<div class='txt'>" + rsTexto["SOB_TEXTO_FINAL"].ToString() + "</div>";
            }
        }

    }
}