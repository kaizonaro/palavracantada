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
    public partial class meus_videos : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rs;
        int registro = 1, pagina_atual = 1, totalPaginas = 1, aux = 1;
        string conteudoPaginacao = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                objUtils = new utils();
                objBD = new bd();

                

                if (Request.QueryString["pagina"] != null)
                {
                    pagina_atual = Convert.ToInt16(Request.QueryString["pagina"]);
                }

               PopularBlog();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void PopularBlog()
        {
            string USU_ID = objUtils.RetornarUsuarioPorURL(Request["usuario"], "USU_ID");
            string USU_NOME = objUtils.RetornarUsuarioPorURL(Request["usuario"], "USU_NOME");

            rs = objBD.ExecutaSQL("EXEC site_meus_videos_lis '4','" + pagina_atual + "','1', '" + USU_ID + "'");

            if (rs == null)
            {
                throw new Exception();
            }
            if (rs.HasRows)
            {
                divArtigos.InnerHtml += " <div class='titu_galeria'>";
                divArtigos.InnerHtml += "   VÍDEOS - " + USU_NOME.ToUpper() + " ";
                divArtigos.InnerHtml += " </div>";
                divArtigos.InnerHtml += " <ul class='galeria_video_interna'>";

                while (rs.Read())
                {
                    //int totalPaginas = Convert.ToInt16(rs["total_paginas"]);

                    divArtigos.InnerHtml += " <li>";
                    divArtigos.InnerHtml += "   <a href='" + rs["VID_LINK"] + "'>";
                    divArtigos.InnerHtml += "       <img src='" + rs["VID_IMAGEM"] + "' alt='" + rs["VID_TITULO"].ToString() + "'>";
                    divArtigos.InnerHtml += "   </a>";
                    divArtigos.InnerHtml += "   <p>" + rs["VID_TITULO"].ToString() + "</p>";
                    divArtigos.InnerHtml += " </li>";
                    aux++;
                }

                divArtigos.InnerHtml += " </ul>";

                int totalPaginas = 0; // AJUAR ISSO

                //PAGINAÇÃO
                if (registro == 1 && totalPaginas > 1)
                {
                    conteudoPaginacao += "<nav class=\"paginacao\">";
                    conteudoPaginacao += "   <ul>";

                    //Validações do voltar
                    if (pagina_atual > 1)
                    {
                        int pgVoltar = pagina_atual - 1;
                        conteudoPaginacao += "   <li><a href=\"javascript:void(0);\" onClick=\"pagina('" + pgVoltar + "')\" class=\"nav_pg\" title=\"Página anterior\"><img src=\"images/nav_left.png\"/>ANTERIORES</a></li>";
                    }
                    else
                    {
                        conteudoPaginacao += "   <li><a href=\"javascript:void(0);\" class=\"nav_pg\" title=\"Página anterior\"><img src=\"images/nav_left.png\" />ANTERIORES</a></li>";
                    }

                    //ajuste de primeira página
                    int cont_inicio = pagina_atual - 1;
                    if (cont_inicio <= 0) { cont_inicio = 1; }

                    //ajueste de última página
                    int cont_fim = totalPaginas;
                    if ((cont_fim - cont_inicio) >= 2) { cont_fim = (cont_inicio + 2); }

                    for (int aux = cont_inicio; aux < cont_fim + 1; aux++)
                    {
                        //verificar se é a página atual
                        if (pagina_atual == aux)
                        {
                            conteudoPaginacao += "   <li><a href=\"javascript:void(0);\" title=\"Página atual\" class=\"ativo\">" + aux + "</a></li>";
                        }
                        else
                        {
                            conteudoPaginacao += "   <li><a href=\"javascript:void(0);\" onClick=\"pagina('" + aux + "')\" title=\"Página " + aux + "\">" + aux + "</a></li>";
                        }
                    }

                    //Validações do avançar
                    if (pagina_atual < totalPaginas)
                    {
                        int pgAvancar = pagina_atual + 1;
                        conteudoPaginacao += "   <li><a href=\"javascript:void(0);\" onClick=\"pagina('" + pgAvancar + "')\" class=\"nav_pg\" title=\"Próxima Página\">PRÓXIMOS <img src=\"images/nav_right.png \"/></a></li>";
                    }
                    else
                    {
                        conteudoPaginacao += "   <li><a href=\"javascript:void(0);\" class=\"nav_pg\" title=\"Próxima Página\">PRÓXIMOS <img src=\"images/nav_right.png \"/></a></li>";
                    }

                    conteudoPaginacao += "   </ul> ";
                    conteudoPaginacao += " </nav> ";
                }
                registro++;
                divArtigos.InnerHtml += conteudoPaginacao;
            }
        }
    }
}