using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Etnia.classe;
using System.Data.OleDb;

namespace BrincaderiasMusicais
{
    public partial class meu_blog : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rs;
        public int registro = 1, pagina_atual = 1, totalPaginas = 1;
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

                breadcrumb.InnerHtml = "<a href=\"/\" title=\"Home\">Home</a> >> <a href=\"/meu-perfil/" + Session["usuUsuario"] + "\" title=\"Home\">Meu Perfil</a> >> <strong>Meu Blog</strong>";

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

            divArtigos.InnerHtml = "";

            rs = objBD.ExecutaSQL("EXEC site_meuBlog_lis '3','" + pagina_atual + "','1', '" + USU_ID + "'");

            if (rs == null)
            {
                throw new Exception();
            }
            if (rs.HasRows)
            {
                divArtigos.InnerHtml += " <div class='titu_galeria'>";
                divArtigos.InnerHtml += "   Blog - " + USU_NOME.ToString().ToUpper() + " ";
                divArtigos.InnerHtml += " </div>";


                while (rs.Read())
                {
                    totalPaginas = Convert.ToInt16(rs["total_paginas"]);
                    divArtigos.InnerHtml += "<div class=\"txt blog_txt mini_blog\">" +
                        "<a href=\"/post/" + objUtils.GerarURLAmigavel(rs["POS_TITULO"].ToString()) + "\" title=\"Ver Post\">" +
                            "<img width=\"190px\" height=\"80px\" src=\"/upload/imagens/blog/thumb-" + rs["POS_IMAGEM"] + "\" class=\"thumb_artigo\"></a>" +
                        "<span class=\"titu_blog\"><a href=\"/post/" + objUtils.GerarURLAmigavel(rs["POS_TITULO"].ToString()) + "\" title=\"Ver Post\"><strong>" + rs["POS_TITULO"] + "</strong></a></span>" +
                        "<span>Em: <strong>" + rs["POS_DATA_PUBLICACAO"] + "</strong>, às <strong>" + rs["POS_HORA_PUBLICAO"] + "</strong></span>" +
                        "<span>" + objUtils.CortarString(true, 30, rs["POS_TEXTO"].ToString()) + "</span>" +
                       " <a href=\"/post/" + objUtils.GerarURLAmigavel(rs["POS_TITULO"].ToString()) + "\" class=\"btn\">LEIA MAIS</a></div>";

                }


                //int totalPaginas = 0; // AJUAR ISSO

                //PAGINAÇÃO
                if (registro == 1 && totalPaginas > 1)
                {
                    conteudoPaginacao += "<nav class=\"paginacao\">";
                    conteudoPaginacao += "   <ul>";

                    //Validações do voltar
                    if (pagina_atual > 1)
                    {
                        int pgVoltar = pagina_atual - 1;
                        conteudoPaginacao += "   <li><a href=\"javascript:void(0);\" onClick=\"pagina('" + pgVoltar + "','" + USU_NOME + "')\" class=\"nav_pg\" title=\"Página anterior\"><img src=\"images/nav_left.png\"/>ANTERIORES</a></li>";
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
                            conteudoPaginacao += "   <li><a href=\"javascript:void(0);\" onClick=\"pagina('" + aux + "','" + USU_NOME + ")\" title=\"Página " + aux + "\">" + aux + "</a></li>";
                        }
                    }

                    //Validações do avançar
                    if (pagina_atual < totalPaginas)
                    {
                        int pgAvancar = pagina_atual + 1;
                        conteudoPaginacao += "   <li><a href=\"javascript:void(0);\" onClick=\"pagina('" + pgAvancar + "','"+USU_NOME+"')\" class=\"nav_pg\" title=\"Próxima Página\">PRÓXIMOS <img src=\"images/nav_right.png \"/></a></li>";
                    }
                    else
                    {
                        conteudoPaginacao += "   <li><a href=\"javascript:void(0);\" class=\"nav_pg\" title=\"Próxima Página\">PRÓXIMOS <img src=\"images/nav_right.png \"/></a></li>";
                    }

                    conteudoPaginacao += "   </ul> ";
                    conteudoPaginacao += " </nav> ";

                    registro++;
                    divArtigos.InnerHtml += conteudoPaginacao;


                }



            }
            else
            {
                divArtigos.InnerHtml = ("<br><span class=\"erro_pesquisa\"><strong>Ops! Parece que o que você está procurando não existe aqui no blog!<br> Tente uma busca diferente.</strong></span>");
            }

            rs.Close();
            rs.Dispose();
        }
    }
}