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

                PopularArtigos();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void PopularArtigos()
        {
            rsArtigos = objBD.ExecutaSQL("EXEC site_artigo_lis '3','" + pagina_atual + "','1' ");

            if (rsArtigos == null)
            {
                throw new Exception();
            }

            if (rsArtigos.HasRows)
            {
                while (rsArtigos.Read())
                {
                    divArtigos.InnerHtml += "<div class=\"txt artigo_txt\">";
                    divArtigos.InnerHtml += "   <img width='160px' height='90px' src=\"/upload/imagens/artigo/" + rsArtigos["ART_IMAGEM"] + "\" class=\"thumb_artigo\">";
                    divArtigos.InnerHtml += "   <span><strong>" + rsArtigos["ART_TITULO"] + "</strong></span>";
                    divArtigos.InnerHtml += "   <span>Autor: <strong>" + rsArtigos["ADM_NOME"] + "</strong></span>";
                    divArtigos.InnerHtml += "   <span>Data da publicação: <strong>" + rsArtigos["ART_DH_PUBLICACAO"] + "</strong></span>";
                    divArtigos.InnerHtml += "   <img onclick=\"download('" + rsArtigos["ART_PDF"] + "');\" src=\"/images/btn_download.png\" class=\"download_artigo\">";
                    divArtigos.InnerHtml += "   <div class=\"txt\">";
                    divArtigos.InnerHtml += "       " + rsArtigos["ART_DESCRICAO"] + " ";
                    divArtigos.InnerHtml += "   </div>";
                    divArtigos.InnerHtml += "   <a href=\"\" class=\"btn\">LEIA MAIS</a>";
                    divArtigos.InnerHtml += "   <ul class=\"social_blog\">";
                    divArtigos.InnerHtml += "       <li>";
                    divArtigos.InnerHtml += "           <iframe src=\"//www.facebook.com/plugins/like.php?href=https%3A%2F%2Fwww.facebook.com%2Fbrincamusicais%3Ffref%3Dts&amp;width&amp;layout=button_count&amp;action=like&amp;show_faces=false&amp;share=true&amp;height=21&amp;appId=335341063329023\" scrolling=\"no\" frameborder=\"0\" style=\"border: none; overflow: hidden; height: 21px;\" allowtransparency=\"true\"></iframe>";
                    divArtigos.InnerHtml += "       </li>";
                    /* divArtigos.InnerHtml += "       <li class=\"tw_blog\">";
                     divArtigos.InnerHtml += "           <a href=\"https://twitter.com/share\" class=\"twitter-share-button\" data-lang=\"pt\">Tweetar</a>";
                     divArtigos.InnerHtml += "           <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>";
                     divArtigos.InnerHtml += "       </li>"; */
                    divArtigos.InnerHtml += "       <li class=\"g_blog\">";
                    divArtigos.InnerHtml += "           <div class=\"g-plus\" data-action=\"share\" data-annotation=\"bubble\" data-href=\"/post/colocarurl\"></div>";//colocar url aki
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

            rsArtigos.Close();
            rsArtigos.Dispose();
        }
    }
}