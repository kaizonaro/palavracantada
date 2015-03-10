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

namespace BrincaderiasMusicais.administracao.ajax
{
    public partial class acoes : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsUsuario, rsLista, rsBlog;
        private string retorno = "";
        int registro = 1, pagina_atual = 1;
        string conteudoPaginacao = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                objUtils = new utils();
                objBD = new bd();

                switch (Request["acao"])
                {

                    case ("populaUsuario"):
                        populaUsuario(Convert.ToInt32(Request["USU_ID"]));
                        break;

                    case ("populaVideos"):
                        populaVideos(Convert.ToInt32(Request["GVI_ID"]));
                        break;

                    case ("populaFotos"):
                        populaFotos(Convert.ToInt32(Request["GFO_ID"]));
                        break;
                    case ("PesquisaBlog"):
                        PesquisaBlog(Request["POS_DH_CRIACAO"], Request["PCA_ID"], Request["POS_TEXO"]);
                        break;

                    default:
                        break;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void PesquisaBlog(string POS_DATA_CRIACAO = "", string PCA_ID = "", string POS_TEXTO = "")
        {
            string resultado = "";
            rsBlog = objBD.ExecutaSQL("EXEC pesquisa_site_blog_lis '3','" + pagina_atual + "','1', '" + POS_DATA_CRIACAO + "', '" + PCA_ID + "', '" + POS_TEXTO + "'");

            if (rsBlog == null)
            {
                throw new Exception();
            }

            if (rsBlog.HasRows)
            {
                while (rsBlog.Read())
                {
                    resultado += "<div class=\"txt blog_txt\">";
                    resultado += "   <a href=\"/post/" + objUtils.GerarURLAmigavel(rsBlog["POS_TITULO"].ToString()) + "\" title=\"Ver Post\"><img width='190px' height='80px' src=\"/upload/imagens/blog/" + rsBlog["POS_IMAGEM"] + "\" class=\"thumb_artigo\"></a>";
                    resultado += "   <span class=\"titu_blog\"><a href=\"/post/" + objUtils.GerarURLAmigavel(rsBlog["POS_TITULO"].ToString()) + "\" title=\"Ver Post\"><strong>" + rsBlog["POS_TITULO"] + "</strong></a></span>";
                    resultado += "   <span>Publicado por: <strong> " + rsBlog["ADM_NOME"] + " </strong></span>";
                    resultado += "   <span>Em: <strong>" + rsBlog["POS_DATA_PUBLICACAO"] + "</strong>, às <strong>" + rsBlog["POS_HORA_PUBLICAO"] + "</strong></span>";
                    resultado += "   <span>na categoria: <strong>XXXXXXX</strong></span>";
                    resultado += "   <div class=\"txt\">";
                    resultado += "       <p>" + objUtils.CortarString(true, 230, rsBlog["POS_TEXTO"].ToString()) + "</p>";
                    resultado += "   </div>";
                    resultado += "   <a href=\"/post/" + objUtils.GerarURLAmigavel(rsBlog["POS_TITULO"].ToString()) + "\" class=\"btn\">LEIA MAIS</a>";
                    resultado += "   <ul class=\"social_blog\">";
                    resultado += "       <li>";
                    resultado += "             <iframe src=\"//www.facebook.com/plugins/like.php?href=http%3A%2F%2Fprojetopalavracantada.net%2Fpost%2F" + objUtils.GerarURLAmigavel(rsBlog["POS_TITULO"].ToString()) + "&amp;width&amp;layout=button_count&amp;action=like&amp;show_faces=true&amp;share=true&amp;height=21&amp;appId=404437276390840\" scrolling=\"no\" frameborder=\"0\" style=\"border:none; overflow:hidden; height:21px;\" allowTransparency=\"true\"></iframe>";
                    resultado += "       </li>";
                    resultado += "       <li class=\"tw_blog\">";
                    resultado += "           <a href=\"https://twitter.com/intent/tweet?original_referer=http%3A%2F%2Fprojetopalavracantada.net%2Fpost%2F" + objUtils.GerarURLAmigavel(rsBlog["POS_TITULO"].ToString()) + "&amp;tw_p=tweetbutton&amp;url=http%3A%2F%2Fprojetopalavracantada.net%2Fpost%2F" + objUtils.GerarURLAmigavel(rsBlog["POS_TITULO"].ToString()) + "\" class=\"twitter-share-button\" data-lang=\"pt\">Tweetar</a>";
                    resultado += "           <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>";
                    resultado += "       </li>";
                    resultado += "       <li class=\"g_blog\">";
                    resultado += "           <div class=\"g-plus\" data-action=\"share\" data-annotation=\"bubble\" data-href=\"/post/" + objUtils.GerarURLAmigavel(rsBlog["POS_TITULO"].ToString()) + "\"></div>";
                    resultado += "       </li>";
                    resultado += "   </ul>";
                    resultado += "</div>";

                    //PAGINAÇÃO
                    if (registro == 1 && Convert.ToInt16(rsBlog["total_paginas"]) > 1)
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
                        int cont_fim = Convert.ToInt16(rsBlog["total_paginas"]);
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
                        if (pagina_atual < Convert.ToInt16(rsBlog["total_paginas"]))
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

                resultado += conteudoPaginacao;
            }
            rsBlog.Close();
            rsBlog.Dispose();
            Response.Write(resultado);
            Response.End();

        }

        /* USUARIO */
        public void populaUsuario(int USU_ID)
        {
            string resultado = "";
            rsUsuario = objBD.ExecutaSQL("EXEC admin_psUsuarioPorId " + USU_ID);

            if (rsUsuario == null)
            {
                throw new Exception();
            }

            if (rsUsuario.HasRows)
            {
                rsUsuario.Read();
                resultado = rsUsuario["USU_ID"] + "|" + rsUsuario["RED_ID"] + "|" + rsUsuario["USU_NOME"] + "|" + rsUsuario["USU_EMAIL"] + "|" + rsUsuario["USU_SENHA"]+ "|" +rsUsuario["USU_BIOGRAFIA"] + "|" +rsUsuario["USU_FOTO"] + "|" + rsUsuario["USU_DH_CADASTRO"] + "|" + rsUsuario["USU_QTD_ACESSO"] + "|" + rsUsuario["USU_DH_ULTIMO_ACESSO"] + "|" + rsUsuario["USU_ATIVO"];
            }

            Response.Write(resultado);
            Response.End();
        }

        /* VIDEOS */
        public void populaVideos(int GVI_ID)
        {
            string resultado = "";
            rsUsuario = objBD.ExecutaSQL("EXEC admin_psGaleriaVideosPorId " + GVI_ID);

            if (rsUsuario == null)
            {
                throw new Exception();
            }

            if (rsUsuario.HasRows)
            {
                rsUsuario.Read();
                resultado = GVI_ID + "|" + rsUsuario["RED_ID"] + "|" + rsUsuario["GVI_TITULO"] + "|" + rsUsuario["GVI_LINK"];
            }

            Response.Write(resultado);
            Response.End();
        }

        /* FOTOS */
        public void populaFotos(int GFO_ID)
        {
            string resultado = "";
            rsUsuario = objBD.ExecutaSQL("EXEC admin_psGaleriaFotosPorId " + GFO_ID);

            if (rsUsuario == null)
            {
                throw new Exception();
            }

            if (rsUsuario.HasRows)
            {
                rsUsuario.Read();
                resultado = GFO_ID + "|" + rsUsuario["RED_ID"] + "|" + rsUsuario["GFO_LEGENDA"];
            }

            Response.Write(resultado);
            Response.End();
        }
    }
}