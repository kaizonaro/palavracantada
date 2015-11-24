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
    public partial class forum_lista : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsResultado, rsDados;
        int registro = 1, pagina_atual = 1;
        string conteudoPaginacao = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nomeUsuario"] != null && Session["nomeUsuario"].ToString().Length > 1)
            {
                objUtils = new utils();
                objBD = new bd();
               // Response.Write("exec site_ForumTopicosPorTitulo '" + Request["titulo"].ToString() + "' ");
                rsDados = objBD.ExecutaSQL("exec site_ForumTopicosPorTitulo '" + Request["titulo"].ToString() + "' ");

                if (rsDados == null)
                {
                    throw new Exception();
                }
                if (rsDados.HasRows)
                {
                    rsDados.Read();
                    //breadcrumb
                    breadcrumb.InnerHtml += "<a href=\"/\" title=\"Home\">Home</a>  &gt;&gt; <a href=\"/forum\" title=\"Fórum\">Fórum</a> &gt;&gt; <strong>" + rsDados["FTO_TITULO"].ToString() + "</strong>";
                    //Título
                    spanTitulo.InnerHtml += "" + rsDados["FTO_TITULO"].ToString() + ":";

                    FTO_ID.Attributes.Add("value", rsDados["FTO_ID"].ToString());
                    REDIRECT.Attributes.Add("value", Request.RawUrl);
                }

                //Verifiar em qual página está
                if (Request.QueryString["pagina"] != null)
                {
                    pagina_atual = Convert.ToInt16(Request.QueryString["pagina"]);
                    //Response.Write(pagina_atual);
                }

                PopulaLista(Convert.ToInt16(rsDados["FTO_ID"]));

                rsDados.Close();
                rsDados.Dispose();

            }

            else
            {
                Response.Redirect("/");
            }

        }

        public void PopulaLista(int FTO_ID)
        {  
            rsResultado = objBD.ExecutaSQL("EXEC site_forum_lis '3','" + pagina_atual + "','1', '" + FTO_ID + "','" + Session["redeID"] + "'");

            if (rsResultado == null)
            {
                throw new Exception();
            }

            if (rsResultado.HasRows)
            {
                while (rsResultado.Read())
                {
                    divLista.InnerHtml += " <div class=\"txt blog_txt txt_forum\">";
                    divLista.InnerHtml += "     <div class=\"txt\">";
                    divLista.InnerHtml += "         <p class=\"destque_forum\">Mensagem enviada por: <a href='/perfil/" + rsResultado["USU_USUARIO"] + "' title='" + rsResultado["USU_NOME"] + "'>" + rsResultado["USU_NOME"] + "</a></p>";
                    divLista.InnerHtml += "         <p class=\"destque_forum\">Enviada em: " + rsResultado["FME_DH_PUBLICACAO"] + "</b></p>";
                    divLista.InnerHtml += "         <br />";
                    divLista.InnerHtml += "         <p>"+rsResultado["FME_MENSAGEM"]+"</p>";
                    divLista.InnerHtml += "     </div>";
                    divLista.InnerHtml += " </div>";

                    //PAGINAÇÃO
                    if (registro == 1 && Convert.ToInt16(rsResultado["total_paginas"]) > 1)
                    {
                        conteudoPaginacao += "<nav class=\"paginacao\">";
                        conteudoPaginacao += "   <ul>";

                        //Validações do voltar
                        if (pagina_atual > 1)
                        {
                            int pgVoltar = pagina_atual - 1;
                            conteudoPaginacao += "   <li><a href=\"/forum-lista/" + Request["titulo"].ToString() + "/" + pgVoltar + "\" class=\"nav_pg\" title=\"Página anterior\"><img src=\"/images/nav_left.png\"/>ANTERIORES</a></li>";
                        }
                        else
                        {
                            conteudoPaginacao += "   <li><a href=\"javascript:void(0);\" class=\"nav_pg\" title=\"Página anterior\"><img src=\"/images/nav_left.png\" />ANTERIORES</a></li>";
                        }

                        //ajuste de primeira página
                        int cont_inicio = pagina_atual - 1;
                        if (cont_inicio <= 0) { cont_inicio = 1; }

                        //ajueste de última página
                        int cont_fim = Convert.ToInt16(rsResultado["total_paginas"]);
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
                                conteudoPaginacao += "   <li><a href=\"/forum-lista/" + Request["titulo"].ToString() + "/" + aux + "\" title=\"Página " + aux + "\">" + aux + "</a></li>";
                            }
                        }

                        //Validações do avançar
                        if (pagina_atual < Convert.ToInt16(rsResultado["total_paginas"]))
                        {
                            int pgAvancar = pagina_atual + 1;
                            conteudoPaginacao += "   <li><a href=\"/forum-lista/"+ Request["titulo"].ToString() +"/" + pgAvancar + "\" class=\"nav_pg\" title=\"Próxima Página\">PRÓXIMOS <img src=\"/images/nav_right.png \"/></a></li>";
                        }
                        else
                        {
                            conteudoPaginacao += "   <li><a href=\"javascript:void(0);\" class=\"nav_pg\" title=\"Próxima Página\">PRÓXIMOS <img src=\"/images/nav_right.png \"/></a></li>";
                        }

                        conteudoPaginacao += "   </ul> ";
                        conteudoPaginacao += " </nav> ";
                    }
                    registro++;
                }

                divLista.InnerHtml += conteudoPaginacao;
            }
            else
            {
                divLista.InnerHtml = ("<br><span class=\"erro_pesquisa\"><strong>Ops! Neste momento não há em uma mensagem neste tópico!<br> Tente em um tópico diferente.</strong></span>");
            }
        }
    }
}