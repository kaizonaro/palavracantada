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

namespace BrincaderiasMusicais.ajax
{
    public partial class acoes : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsLogin, rsCadastro, rsArtigos;
        int registro = 1;
        string conteudoPaginacao = "", retorno = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();
            
            string acao = Request["acao"];

            switch (acao)
            {
                case "FazerLogin":
                    FazerLogin();
                    break;
                
                case "completarCadastro":
                    completarCadastro();
                    break;

                case "logout":
                    logout();
                    break;

                case "paginacaoArtigos":
                    paginacaoArtigos();
                    break;
                
                case "paginacaoBlog":
                    paginacaoBlog();
                    break;

                default:
                    // PopularBlog();
                    // PopularVideos();
                    break;
            }
        }

        public void FazerLogin()
        {

            rsLogin = objBD.ExecutaSQL("EXEC site_psUsuarioPorEmaileSenha '" + objUtils.TrataSQLInjection(Request["email"]) + "','" + objUtils.TrataSQLInjection(objUtils.getMD5Hash(Request["senha"])) + "'");

            if (rsLogin == null)
            {
                throw new Exception();
            }
            if (rsLogin.HasRows)
            {
                rsLogin.Read();
                //Salvar as Session do usuário
                Session["nomeUsuario"] = rsLogin["USU_NOME"].ToString();
                Session["nomeInstituicao"] = rsLogin["RED_TITULO"].ToString();
                Session["redeID"] = rsLogin["RED_ID"].ToString();
                Session["redeTitulo"] = objUtils.GerarURLAmigavel(rsLogin["RED_TITULO"].ToString());

                //Salva no log
                objBD.ExecutaSQL("EXEC psLog '" + rsLogin["USU_ID"] + "',null,'Login efetuado no sistema'");

                Response.Redirect("/rede/" + objUtils.GerarURLAmigavel(rsLogin["RED_TITULO"].ToString()));
                Response.End();
               
            }
            else
            {
                Response.Redirect("/default.aspx?msg=erroLogin");
            }

            rsLogin.Dispose();
            rsLogin.Close();

        }

        public void completarCadastro()
        {
            rsCadastro = objBD.ExecutaSQL("EXEC site_puCastro '" + Request["TOK_TOKEN"] + "','" + Request["USU_NOME"] + "','" + Request["USU_EMAIL"] + "','" + Request["CAR_ID"] + "','" + objUtils.TrataSQLInjection(objUtils.getMD5Hash(Request["USU_SENHA"])) + "'");

            if (rsCadastro == null)
            {
                throw new Exception();
            }
            if (rsCadastro.HasRows)
            {
                rsCadastro.Read();

                //Salvar as Categorias
                foreach (string categoria in Request["CAT_ID"].Split(Convert.ToChar(",")))
                {
                    objBD.ExecutaSQL("EXEC site_piuUsuarioCategoria " + rsCadastro["USU_ID"] + ", " + Convert.ToInt32(objUtils.SimpleSplitter(categoria, 0)));
                }

                //Salvar as Session do usuário
                Session["nomeUsuario"] = rsCadastro["USU_NOME"].ToString();
                Session["nomeInstituicao"] = rsCadastro["RED_TITULO"].ToString();
                Session["redeID"] = rsCadastro["RED_ID"].ToString();
                Session["redeTitulo"] = objUtils.GerarURLAmigavel(rsCadastro["RED_TITULO"].ToString());

                //Salva no log
                objBD.ExecutaSQL("EXEC psLog '" + rsCadastro["USU_ID"] + "',null,'Login efetuado no sistema'");

                Response.Redirect("/rede/" + objUtils.GerarURLAmigavel(rsCadastro["RED_TITULO"].ToString()));
                Response.End();

            }
            else
            {
                Response.Redirect("/");
            }

            rsCadastro.Dispose();
            rsCadastro.Close();
        }

        public void logout()
        {
            Session.Abandon();
            Response.Redirect("/");
        }

        public void paginacaoArtigos()
        {
            int pagina_atual = Convert.ToInt16(Request["pagina"]);

            rsArtigos = objBD.ExecutaSQL("EXEC site_artigo_lis '3','" + pagina_atual + "','1' ");

            if (rsArtigos == null)
            {
                throw new Exception();
            }

            if (rsArtigos.HasRows)
            {
                while (rsArtigos.Read())
                {
                    retorno += "<div class=\"txt artigo_txt\">";
                    retorno += "   <img width='160px' height='90px' src=\"/upload/imagens/artigo/" + rsArtigos["ART_IMAGEM"] + "\" class=\"thumb_artigo\">";
                    retorno += "   <span><strong>" + rsArtigos["ART_TITULO"] + "</strong></span>";
                    retorno += "   <span>Autor: <strong>" + rsArtigos["ADM_NOME"] + "</strong></span>";
                    retorno += "   <span>Data da publicação: <strong>" + rsArtigos["ART_DH_PUBLICACAO"] + "</strong></span>";
                    retorno += "   <img onclick=\"download('" + rsArtigos["ART_PDF"] + "');\" src=\"/images/btn_download.png\" class=\"download_artigo\">";
                    retorno += "   <div class=\"txt\">";
                    retorno += "       " + rsArtigos["ART_DESCRICAO"] + " ";
                    retorno += "   </div>";
                    retorno += "</div>";

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
                        int cont_inicio = pagina_atual-1;
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

                retorno += conteudoPaginacao;
                Response.Write(retorno);
            }

            rsArtigos.Close();
            rsArtigos.Dispose();
        }

        public void paginacaoBlog()
        {
            int pagina_atual = Convert.ToInt16(Request["pagina"]);

            rsArtigos = objBD.ExecutaSQL("EXEC site_blog_lis '3','" + pagina_atual + "','1' ");

            if (rsArtigos == null)
            {
                throw new Exception();
            }

            if (rsArtigos.HasRows)
            {
                while (rsArtigos.Read())
                {
                    retorno += "<div class=\"txt blog_txt\">";
                    retorno += "   <img width='190px' height='80px' src=\"/upload/imagens/blog/" + rsArtigos["POS_IMAGEM"] + "\" class=\"thumb_artigo\">";
                    retorno += "   <span class=\"titu_blog\"><strong>" + rsArtigos["POS_TITULO"] + "</strong></span>";
                    retorno += "   <span>Publicado por: <strong><< " + rsArtigos["ADM_NOME"] + " >></strong></span>";
                    retorno += "   <span>Em: <strong>" + rsArtigos["POS_DATA_PUBLICACAO"] + "</strong>, às <strong>" + rsArtigos["POS_HORA_PUBLICAO"] + "</strong></span>";
                    retorno += "   <div class=\"txt\">";
                    retorno += "       <p>Texto resumido com a descrição do artigo lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse porta neque eget lacus pretium, a imperdiet mauris ullamcorper. Etiam convallis enim a massa dapibus, non posuere massa facilisis.</p>";
                    retorno += "   </div>";
                    retorno += "   <ul class=\"social_blog\">";
                    retorno += "       <li>";
                    retorno += "           <iframe src=\"//www.facebook.com/plugins/like.php?href=https%3A%2F%2Fwww.facebook.com%2Fbrincamusicais%3Ffref%3Dts&amp;width&amp;layout=button_count&amp;action=like&amp;show_faces=false&amp;share=true&amp;height=21&amp;appId=335341063329023\" scrolling=\"no\" frameborder=\"0\" style=\"border: none; overflow: hidden; height: 21px;\" allowtransparency=\"true\"></iframe>";
                    retorno += "       </li>";
                    retorno += "       <li class=\"tw_blog\">";
                    retorno += "           <a href=\"https://twitter.com/share\" class=\"twitter-share-button\" data-lang=\"pt\">Tweetar</a>";
                    retorno += "           <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>";
                    retorno += "       </li>";
                    retorno += "       <li class=\"g_blog\">";
                    retorno += "           <div class=\"g-plus\" data-action=\"share\" data-annotation=\"bubble\" data-href=\"/post/" + objUtils.GerarURLAmigavel(rsArtigos["POS_TITULO"].ToString()) + "\"></div>";
                    retorno += "       </li>";
                    retorno += "   </ul>";
                    retorno += "</div>";

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

                retorno += conteudoPaginacao;
                Response.Write(retorno);
            }

            rsArtigos.Close();
            rsArtigos.Dispose();
        }
    }
}