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
    public partial class blog_lista : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsArtigos;
        int registro = 1, pagina_atual = 1;
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

        public void PopularBlog()
        {

            switch (Request["nomecampo"])
            {

                case ("login_POS_DH_CRIACAO"):
                    bread.InnerHtml = "Arquivos " + Request["POS_DH_CRIACAO"];
                    msg.InnerHtml = "Exibindo resultados do arquivo " + Request["POS_DH_CRIACAO"];
                    rsArtigos = objBD.ExecutaSQL("EXEC pesquisa_site_blog_lis '3','" + pagina_atual + "','1', '" + Request["POS_DH_CRIACAO"] + "'");
                    break;
                case ("login_PCA_ID"):
                    rsArtigos = objBD.ExecutaSQL("EXEC pesquisa_site_blog_lis '3','" + pagina_atual + "','1', '', '" + Request["PCA_ID"] + "'");
                    break;

                default:
                    rsArtigos = objBD.ExecutaSQL("EXEC pesquisa_site_blog_lis '3','" + pagina_atual + "','1', '', '' , '" + Request["POS_TEXTO"] + "'");
                    if (string.IsNullOrWhiteSpace(Request["POS_TEXTO"]) == false)
                    {
                        bread.InnerHtml = "Busca \"" + Request["POS_TEXTO"] + "\"";
                        msg.InnerHtml = "Exibindo resultados da pesquisa por \"" + Request["POS_TEXTO"] + "\"";
                    }
                    else
                    {
                        bread.InnerHtml = "";
                        msg.InnerHtml = "";
                    }

                    break;
            }


            if (rsArtigos == null)
            {
                throw new Exception();
            }

            if (rsArtigos.HasRows)
            {
                while (rsArtigos.Read())
                {
                    if (Request["nomecampo"] == "login_PCA_ID")
                    {
                        bread.InnerHtml = "Categoria " + rsArtigos["POS_CATEGORIA"];
                        msg.InnerHtml = "Exibindo resultados da categoria " + rsArtigos["POS_CATEGORIA"];
                    }

                    divArtigos.InnerHtml += "<div class=\"txt blog_txt\">";
                    divArtigos.InnerHtml += "   <a href=\"/post/" + objUtils.GerarURLAmigavel(rsArtigos["POS_TITULO"].ToString()) + "\" title=\"Ver Post\"><img width='190px' height='80px' src=\"/upload/imagens/blog/" + rsArtigos["POS_IMAGEM"] + "\" class=\"thumb_artigo\"></a>";
                    divArtigos.InnerHtml += "   <span class=\"titu_blog\"><a href=\"/post/" + objUtils.GerarURLAmigavel(rsArtigos["POS_TITULO"].ToString()) + "\" title=\"Ver Post\"><strong>" + rsArtigos["POS_TITULO"] + "</strong></a></span>";
                    divArtigos.InnerHtml += "   <span>Publicado por: <strong> " + rsArtigos["ADM_NOME"] + " </strong></span>";
                    divArtigos.InnerHtml += "   <span>Em: <strong>" + rsArtigos["POS_DATA_PUBLICACAO"] + "</strong>, às <strong>" + rsArtigos["POS_HORA_PUBLICAO"] + "</strong></span>";
                    divArtigos.InnerHtml += "   <span>na categoria: <strong>" + rsArtigos["POS_CATEGORIA"] + "</strong></span>";
                    divArtigos.InnerHtml += "   <div class=\"txt\">";
                    divArtigos.InnerHtml += "       <p>" + objUtils.CortarString(true, 230, rsArtigos["POS_TEXTO"].ToString()) + "</p>";
                    divArtigos.InnerHtml += "   </div>";
                    divArtigos.InnerHtml += "   <a href=\"/post/" + objUtils.GerarURLAmigavel(rsArtigos["POS_TITULO"].ToString()) + "\" class=\"btn\">LEIA MAIS</a>";
                    divArtigos.InnerHtml += "   <ul class=\"social_blog\">";
                    divArtigos.InnerHtml += "       <li>";
                    divArtigos.InnerHtml += "             <iframe src=\"//www.facebook.com/plugins/like.php?href=http%3A%2F%2Fprojetopalavracantada.net%2Fpost%2F" + objUtils.GerarURLAmigavel(rsArtigos["POS_TITULO"].ToString()) + "&amp;width&amp;layout=button_count&amp;action=like&amp;show_faces=true&amp;share=true&amp;height=21&amp;appId=404437276390840\" scrolling=\"no\" frameborder=\"0\" style=\"border:none; overflow:hidden; height:21px;\" allowTransparency=\"true\"></iframe>";
                    divArtigos.InnerHtml += "       </li>";
                    divArtigos.InnerHtml += "       <li class=\"tw_blog\">";
                    divArtigos.InnerHtml += "           <a href=\"https://twitter.com/intent/tweet?original_referer=http%3A%2F%2Fprojetopalavracantada.net%2Fpost%2F" + objUtils.GerarURLAmigavel(rsArtigos["POS_TITULO"].ToString()) + "&amp;tw_p=tweetbutton&amp;url=http%3A%2F%2Fprojetopalavracantada.net%2Fpost%2F" + objUtils.GerarURLAmigavel(rsArtigos["POS_TITULO"].ToString()) + "\" class=\"twitter-share-button\" data-lang=\"pt\">Tweetar</a>";
                    divArtigos.InnerHtml += "           <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>";
                    divArtigos.InnerHtml += "       </li>";
                    divArtigos.InnerHtml += "       <li class=\"g_blog\">";
                    divArtigos.InnerHtml += "           <div class=\"g-plus\" data-action=\"share\" data-annotation=\"bubble\" data-href=\"/post/" + objUtils.GerarURLAmigavel(rsArtigos["POS_TITULO"].ToString()) + "\"></div>";
                    divArtigos.InnerHtml += "       </li>";
                    divArtigos.InnerHtml += "   </ul>";
                    divArtigos.InnerHtml += "</div>";

                    //PAGINAÇÃO
                    if (registro == 1 && Convert.ToInt16(rsArtigos["total_paginas"]) > 1)
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
                        int cont_fim = Convert.ToInt16(rsArtigos["total_paginas"]);
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
                        if (pagina_atual < Convert.ToInt16(rsArtigos["total_paginas"]))
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
                }

                divArtigos.InnerHtml += conteudoPaginacao;
            }
            else
            {
                divArtigos.InnerHtml = ("<br><span class=\"erro_pesquisa\"><strong>Ops! Parece que o que você está procurando não existe aqui no blog!<br> Tente uma busca diferente.</strong></span>");
            }




            rsArtigos.Close();
            rsArtigos.Dispose();
        }
    }
}