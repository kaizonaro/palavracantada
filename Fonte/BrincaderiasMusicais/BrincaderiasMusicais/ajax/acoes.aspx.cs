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
        private OleDbDataReader rsLogin, rsCadastro, rsComentarios;
        int registro = 1, pagina_atual = 1;
        string conteudoPaginacao = "", retorno = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            string acao = Request["acao"];

            if (Request.QueryString["pg"] != null)
            {
                pagina_atual = Convert.ToInt16(Request.QueryString["pg"]);
            }

            switch (acao)
            {
                case ("verComentarios"):
                    verComentarios(Convert.ToInt16(Request["pg"]), Convert.ToInt16(Request["id"]));
                    break;
                case("verComentarios2"):
                    verComentarios2(Convert.ToInt16(Request["pg"]), Convert.ToInt16(Request["id"]));
                    break;
                case "FazerLogin":
                    FazerLogin();
                    break;

                case "EsqueciSenha":
                    EsqueciSenha();
                    break;

                case ("ResetarSenha"):
                    ResetarSenha();
                    break;

                case "completarCadastro":
                    completarCadastro();
                    break;

                case "logout":
                    logout();
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
                Session["usuID"] = rsLogin["USU_ID"].ToString();
                Session["nomeInstituicao"] = rsLogin["RED_TITULO"].ToString();
                Session["redeID"] = rsLogin["RED_ID"].ToString();
                Session["redeTitulo"] = objUtils.GerarURLAmigavel(rsLogin["RED_TITULO"].ToString());
                Session["usuUsuario"] = rsLogin["USU_USUARIO"].ToString();
                
                //Salva no log
                objBD.ExecutaSQL("EXEC psLog '" + rsLogin["USU_ID"] + "',null,'Login efetuado no sistema'");

                //Medalha dedicado
                if (Convert.ToInt16(rsLogin["USU_QTD_ACESSO"]) == 2)
                {
                    objBD.ExecutaSQL("INSERT INTO LOG (USU_ID, ADM_ID, LOG_ACONTECIMENTO, LOG_EXIBIR) VALUES ('" + rsLogin["USU_ID"] + "',null,'Parabéns! Você ganhou a medalha de Dedicado ao se logar pela 3ª vez.', '1') ");
                }

                //Response.Redirect("/rede/" + objUtils.GerarURLAmigavel(rsLogin["RED_TITULO"].ToString()));
                Response.Redirect("/meu-perfil/" + Session["usuUsuario"].ToString());
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
            rsCadastro = objBD.ExecutaSQL("EXEC site_puCastro '" + Request["TOK_TOKEN"] + "','" + Request["USU_NOME"] + "','" + Request["USU_EMAIL"] + "','" + Request["CAR_ID"] + "','" + objUtils.TrataSQLInjection(objUtils.getMD5Hash(Request["USU_SENHA"])) + "','"+Request["USU_USUARIO"]+"'");

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
                Session["usuID"] = rsCadastro["USU_ID"].ToString();
                Session["nomeInstituicao"] = rsCadastro["RED_TITULO"].ToString();
                Session["redeID"] = rsCadastro["RED_ID"].ToString();
                Session["redeTitulo"] = objUtils.GerarURLAmigavel(rsCadastro["RED_TITULO"].ToString());
                Session["usuUsuario"] = rsCadastro["USU_USUARIO"].ToString();

                //Salva no log
                objBD.ExecutaSQL("EXEC psLog '" + rsCadastro["USU_ID"] + "',null,'Login efetuado no sistema'");
                objBD.ExecutaSQL("insert into Log (USU_ID, LOG_ACONTECIMENTO, LOG_EXIBIR) VALUES ('" + Session["usuID"] + "','Parabéns! Você ganhou uma medalha por se cadastrar no site.','1')");
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

        public void verComentarios(int pg, int id)
        {
            retorno += " <div onClick=\"fechar_relato()\" class=\"fechar_relato x\">";
            retorno += "    <img src=\"/images/x.jpg\" />";
            retorno += " </div>";
            retorno += " <p class=\"titu_criacoes\">";
            retorno += "    <img src=\"/images/icon_comente.png\" alt=\"Icone de comentários\" /> COMENTÁRIOS DESTE RELATO";
            retorno += " </p>";
            retorno += " <hr />";

            rsComentarios = objBD.ExecutaSQL("exec site_comentarios_Relato_lis 4," + pg + ",1," + id + ""); // MUDAR PARA PROC COM PAGINAÇÃO

            

            if (rsComentarios == null)
            {
                throw new Exception();
            }
            if (rsComentarios.HasRows)
            {
                while (rsComentarios.Read())
                {
                    retorno +=" <div class=\"box_lista_relato\">";
                    retorno += "     <img class=\"mini_perfil\" src=\"/upload/imagens/usuarios/" + rsComentarios["USU_FOTO"].ToString() + "\" alt=\"Foto do Perfil do Fulano\" />";
                    retorno +="     <p class=\"txt\">";
                    retorno += "     " + rsComentarios["COM_TEXTO"] + "";
                    retorno +="     </p>";
                    retorno += "     <span class=\"tafera_detalhe\">Comentário  enviado por:  <strong>" + rsComentarios["USU_NOME"].ToString() + "</strong></span>";
                    retorno +="</div>";

                    //PAGINAÇÃO
                    if (registro == 1 && Convert.ToInt16(rsComentarios["total_paginas"]) > 1)
                    {
                        conteudoPaginacao += "<nav class=\"paginacao\">";
                        conteudoPaginacao += "   <ul>";

                        //Validações do voltar
                        if (pagina_atual > 1)
                        {
                            int pgVoltar = pagina_atual - 1;
                            conteudoPaginacao += "   <li><a href=\"javascript:void(0);\" onClick=\"verComentarios(" + pgVoltar + "," + id + ")\" class=\"nav_pg\" title=\"Página anterior\"><img src=\"/images/nav_left.png\"/>ANTERIORES</a></li>";
                        }
                        else
                        {
                            conteudoPaginacao += "   <li><a href=\"javascript:void(0);\" class=\"nav_pg\" title=\"Página anterior\"><img src=\"/images/nav_left.png\" />ANTERIORES</a></li>";
                        }

                        //ajuste de primeira página
                        int cont_inicio = pagina_atual - 1;
                        if (cont_inicio <= 0) { cont_inicio = 1; }

                        //ajueste de última página
                        int cont_fim = Convert.ToInt16(rsComentarios["total_paginas"]);
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
                                conteudoPaginacao += "   <li><a href=\"javascript:void(0);\" onClick=\"verComentarios(" + aux + "," + id + ")\" title=\"Página " + aux + "\">" + aux + "</a></li>";
                            }
                        }

                        //Validações do avançar
                        if (pagina_atual < Convert.ToInt16(rsComentarios["total_paginas"]))
                        {
                            int pgAvancar = pagina_atual + 1;
                            conteudoPaginacao += "   <li><a href=\"javascript:void(0);\" onClick=\"verComentarios(" + pgAvancar + "," + id + ")\" class=\"nav_pg\" title=\"Próxima Página\">PRÓXIMOS <img src=\"/images/nav_right.png \"/></a></li>";
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

                //retorno += "<nav class=\"paginacao\">   <ul>   <li><a href=\"javascript:void(0);\" class=\"nav_pg\" title=\"Página anterior\"><img src=\"/images/nav_left.png\">ANTERIORES</a></li>   <li><a href=\"javascript:void(0);\" title=\"Página atual\" class=\"ativo\">1</a></li>   <li><a href=\"javascript:void(0);\" onclick=\"pagina('2')\" title=\"Página 2\">2</a></li>   <li><a href=\"javascript:void(0);\" onclick=\"pagina('3')\" title=\"Página 3\">3</a></li>   <li><a href=\"javascript:void(0);\" onclick=\"pagina('2')\" class=\"nav_pg\" title=\"Próxima Página\">PRÓXIMOS <img src=\"/images/nav_right.png \"></a></li>   </ul>  </nav>";

            }
            retorno += conteudoPaginacao;

            Response.Write(retorno);
            Response.End();
        }

        public void verComentarios2(int pg, int id)
        {
            retorno += " <div onClick=\"fechar_relato()\" class=\"fechar_relato x\">";
            retorno += "    <img src=\"/images/x.jpg\" />";
            retorno += " </div>";
            retorno += " <p class=\"titu_criacoes\">";
            retorno += "    <img src=\"/images/icon_comente.png\" alt=\"Icone de comentários\" /> COMENTÁRIOS DESTA TAREFA";
            retorno += " </p>";
            retorno += " <hr />";

            rsComentarios = objBD.ExecutaSQL("exec site_comentarios_tarefas 4," + pg + ",1," + id + "");

            if (rsComentarios == null)
            {
                throw new Exception();
            }
            if (rsComentarios.HasRows)
            {
                while (rsComentarios.Read())
                {
                    retorno += " <div class=\"box_lista_relato\">";
                    retorno += "     <img class=\"mini_perfil\" src=\"/upload/imagens/usuarios/" + rsComentarios["USU_FOTO"].ToString() + "\" alt=\"" + rsComentarios["USU_NOME"].ToString() + "\" />";
                    retorno += "     <p class=\"txt\">";
                    retorno += "     " + rsComentarios["COM_TEXTO"] + "";
                    retorno += "     </p>";
                    retorno += "     <span class=\"tafera_detalhe\">Comentário  enviado por:  <strong>" + rsComentarios["USU_NOME"].ToString() + "</strong></span>";
                    retorno += "</div>";

                    //PAGINAÇÃO
                    if (registro == 1 && Convert.ToInt16(rsComentarios["total_paginas"]) > 1)
                    {
                        conteudoPaginacao += "<nav class=\"paginacao\">";
                        conteudoPaginacao += "   <ul>";

                        //Validações do voltar
                        if (pagina_atual > 1)
                        {
                            int pgVoltar = pagina_atual - 1;
                            conteudoPaginacao += "   <li><a href=\"javascript:void(0);\" onClick=\"verComentarios2(" + pgVoltar + "," + id + ")\" class=\"nav_pg\" title=\"Página anterior\"><img src=\"/images/nav_left.png\"/>ANTERIORES</a></li>";
                        }
                        else
                        {
                            conteudoPaginacao += "   <li><a href=\"javascript:void(0);\" class=\"nav_pg\" title=\"Página anterior\"><img src=\"/images/nav_left.png\" />ANTERIORES</a></li>";
                        }

                        //ajuste de primeira página
                        int cont_inicio = pagina_atual - 1;
                        if (cont_inicio <= 0) { cont_inicio = 1; }

                        //ajueste de última página
                        int cont_fim = Convert.ToInt16(rsComentarios["total_paginas"]);
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
                                conteudoPaginacao += "   <li><a href=\"javascript:void(0);\" onClick=\"verComentarios2(" + aux + "," + id + ")\" title=\"Página " + aux + "\">" + aux + "</a></li>";
                            }
                        }

                        //Validações do avançar
                        if (pagina_atual < Convert.ToInt16(rsComentarios["total_paginas"]))
                        {
                            int pgAvancar = pagina_atual + 1;
                            conteudoPaginacao += "   <li><a href=\"javascript:void(0);\" onClick=\"verComentarios2(" + pgAvancar + "," + id + ")\" class=\"nav_pg\" title=\"Próxima Página\">PRÓXIMOS <img src=\"/images/nav_right.png \"/></a></li>";
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

            }
            retorno += conteudoPaginacao;

            Response.Write(retorno);
            Response.End();
        }

        public void EsqueciSenha()
        {
            string  msg = "  <table>";
                    msg += "    <tr><td>Recebemos o seu aviso de que esqueceu a senha!</td></tr>";
                    msg += "    <tr><td>Se realmente quer fazer a mudança, <a href=\"http://www.projetopalavracantada.net/ajax/acoes.aspx?acao=ResetarSenha&email=" + Request["email"] + "\">clique aqui</a> e lhe enviaremos outro e-mail com as intruções</td></tr>";
                    msg += "    <tr><td>Se não fez a solicitação, por favor, ignore este e-mail.</td></tr>";
                    msg += " </table>";

                    //ERRO
                    if (objUtils.EnviaEmail("fernando@agenciaetnia.com.br", "Contato Projeto Brincadeiras Musicais da Palavra Cantada", msg, remetente: Request["email"], nome: "Fernando") == false)
                    {
                        Response.Write("<script>alert('Erro ao enviar o email!');</script>");
                    }
                    //SUCESSO
                    else
                    {
                        //objBD = new bd();
                        //objBD.ExecutaSQL("EXEC piContatoSite '" + Request["nome"] + "', '" + Request["email"] + "', '" + Request["mensagem"] + "'");
                        Response.Redirect("/default.aspx?msg=EsqueciSenha");
                    }
        }

        public void ResetarSenha()
        {
            string  msg = "  <table>";
                    msg += "    <tr><td>Mudamos a sua senha</td></tr>";
                    msg += "    <tr><td>A sunha senha foi alterada para: 123456 provisóriamente!</td></tr>";
                    msg += "    <tr><td>Se logue no site e mude através do menu Meu Perfil | Configurações.</td></tr>";
                    msg += " </table>";

                    //ERRO
                    if (objUtils.EnviaEmail("fernando@agenciaetnia.com.br", "Contato Projeto Brincadeiras Musicais da Palavra Cantada", msg, remetente: Request["email"], nome: "Fernando") == false)
                    {
                        Response.Write("<script>alert('Erro ao enviar o email!');</script>");
                    }
                    //SUCESSO
                    else
                    {
                        //objBD = new bd();
                         objBD.ExecutaSQL("update Usuario set usu_senha = 'e10adc3949ba59abbe56e057f20f883e' where usu_email = '" + Request["email"] + "'");

                        //Response.Write("update Usuario set usu_senha = 'e10adc3949ba59abbe56e057f20f883e' where usu_email = '" + Request["email"] + "'");
                        //Response.End();
                        Response.Redirect("/default.aspx?msg=EsqueciSenha");
                    }
        }
    }
}