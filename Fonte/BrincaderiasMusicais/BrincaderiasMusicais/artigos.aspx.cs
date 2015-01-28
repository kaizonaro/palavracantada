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
    public partial class artigo : System.Web.UI.Page
    {

        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsArtigos;
        int registro = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                objUtils = new utils();
                objBD = new bd();

                PopularArtigos();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void PopularArtigos()
        {
            rsArtigos = objBD.ExecutaSQL("EXEC site_artigo_lis '3','1','1' ");

            if (rsArtigos == null)
            {
                throw new Exception();
            }

            if (rsArtigos.HasRows)
            {
                while (rsArtigos.Read())
                {
                    divArtigos.InnerHtml += "<div class=\"txt artigo_txt\">";
                    divArtigos.InnerHtml += "   <img src=\"/images/imagem-artigo.jpg\" class=\"thumb_artigo\">";
                    divArtigos.InnerHtml += "   <span><strong>" + rsArtigos["ART_TITULO"] + "</strong></span>";
                    divArtigos.InnerHtml += "   <span>Autor: <strong>" + rsArtigos["ADM_NOME"] + "</strong></span>";
                    divArtigos.InnerHtml += "   <span>Data da publicação: <strong>" + rsArtigos["ART_DH_PUBLICACAO"] + "</strong></span>";
                    divArtigos.InnerHtml += "   <img src=\"/images/btn_download.png\" class=\"download_artigo\">";
                    divArtigos.InnerHtml += "   <div class=\"txt\">";
                    divArtigos.InnerHtml += "       " + rsArtigos["ART_DESCRICAO"] + " ";
                    divArtigos.InnerHtml += "   </div>";
                    divArtigos.InnerHtml += "</div>";

                    if (registro == 1)
                    {
                        navPaginacao.InnerHtml += "<ul>";
                        navPaginacao.InnerHtml += " <li><a href=\"javascript:void(0);\" class=\"nav_pg\" title=\"Página anterior\"><img src=\"images/nav_left.png\" />ANTERIORES</a></li>";
                        navPaginacao.InnerHtml += " <li><a href=\"javascript:void(0);\" title=\"Página 01\" class=\"ativo\">01</a></li>";
                        navPaginacao.InnerHtml += " <li><a href=\"#\" title=\"Página 02\">02</a></li>";
                        navPaginacao.InnerHtml += " <li><a href=\"#\" title=\"Página 03\">03</a></li>";
                        navPaginacao.InnerHtml += " <li><a href=\"#\" class=\"nav_pg\" title=\"Próxima Página\">PRÓXIMOS <img src=\"images/nav_right.png \"/></a></li>";
                        navPaginacao.InnerHtml += "</ul> ";
                    }
                    registro++;
                }

            }

            rsArtigos.Close();
            rsArtigos.Dispose();
        }
    }
}