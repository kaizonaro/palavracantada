﻿using Etnia.classe;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrincaderiasMusicais.administracao
{
    public partial class redes : System.Web.UI.Page
    {

        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsLista, rsRedes, rsGravaUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            try
            {
                switch (Request["acao"])
                {
                    case ("GravarRede"):
                        GravarRede();
                        break;

                    case ("ValidarRede"):
                        ValidarRede();
                        break;

                    case ("excluirRede"):

                        objBD.ExecutaSQL("update Rede set RED_ATIVO = 0 where RED_ID ='" + Request["RED_ID"] + "'");
                        PopulaLista();
                        PopulaExcluidos();

                        break;
                    case ("restoreRede"):
                        objBD.ExecutaSQL("update Rede set RED_ATIVO = 1 where RED_ID ='" + Request["RED_ID"] + "'");
                        PopulaLista();
                        PopulaExcluidos();
                        break;
                    case ("editarRede"):
                        rsLista = objBD.ExecutaSQL("select *, (select COUNT(*) from usuario where red_id = " + Request["RED_ID"] + " and USU_ATIVO = 1) as total  from  Rede where RED_ID ='" + Request["RED_ID"] + "'");
                        if (rsLista == null)
                        {
                            throw new Exception();
                        }
                        if (rsLista.HasRows)
                        {
                            rsLista.Read();
                            string resposta = "";
                            resposta += rsLista["RED_ID"];
                            resposta += "|" + rsLista["RED_TITULO"];
                            resposta += "|" + rsLista["RED_CIDADE"];
                            resposta += "|" + rsLista["RED_UF"];
                            resposta += "|" + rsLista["total"];
                            resposta += "|" + rsLista["RED_HORAS_PRESENCIAIS"];
                            resposta += "|" + rsLista["RED_HORAS_DISTANCIA"];
                            resposta += "|" + rsLista["RED_PESO_BLOG"];
                            resposta += "|" + rsLista["RED_PESO_GALERIA"];
                            resposta += "|" + rsLista["RED_PESO_VIDEO"];
                            resposta += "|" + rsLista["RED_PESO_FOTOS"];
                            resposta += "|" + rsLista["RED_PESO_FORUM"];
                            resposta += "|" + rsLista["RED_PESO_CRIACOES"];
                            resposta += "|" + rsLista["RED_LIMITE_BLOG"];
                            resposta += "|" + rsLista["RED_LIMITE_GALERIA"];
                            resposta += "|" + rsLista["RED_LIMITE_VIDEO"];
                            resposta += "|" + rsLista["RED_LIMITE_FOTOS"];
                            resposta += "|" + rsLista["RED_LIMITE_FORUM"];
                            resposta += "|" + rsLista["RED_LIMITE_CRIACOES"];
                            resposta += "|" + rsLista["RED_NOME_DIRETOR"];
                            Response.Write(resposta);
                        }
                        break;
                    default:
                        PopulaLista();
                        PopulaExcluidos();
                        break;
                }
            }
            catch (Exception)
            {
                Response.Redirect("erro.aspx");
                throw;
            }
        }

        public void PopulaLista()
        {
            divLista.InnerHtml = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("EXEC admin_psRedesPorAtivo 1");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divLista.InnerHtml += " <thead>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <th style=\"width:8px;\">ID</th>";
                divLista.InnerHtml += "         <th>Titulo</th>";
                divLista.InnerHtml += "         <th>Cidade</th>";
                divLista.InnerHtml += "         <th>UF</th>";
                divLista.InnerHtml += "         <th>Data de Criação</th>";
                divLista.InnerHtml += "         <th>Quantidade de Usuários</th>";
                divLista.InnerHtml += "         <th style=\"width:71px;\">Ações</th>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += " </thead>";

                divLista.InnerHtml += " <tbody>";

                while (rsLista.Read())
                {
                    divLista.InnerHtml += " <tr id='tr_" + rsLista["RED_ID"].ToString() + "' class=\"\">";
                    divLista.InnerHtml += "     <td>" + rsLista["RED_ID"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["RED_TITULO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["RED_CIDADE"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["RED_UF"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["RED_DATA_CRIACAO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["RED_QTD_USUARIO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td><ul class=\"icons_table\"><li><a href=\"javascript:void(0)\" id='" + rsLista["RED_ID"].ToString() + "' onclick='popularFormulario(this.id);' class=\"img_edit\"><img src=\"images/editar.png\"></a></li><li><a id='" + rsLista["RED_ID"].ToString() + "' onclick='excluirRede(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
                    divLista.InnerHtml += " </tr>";
                }

                divLista.InnerHtml += " </tbody>";
            }

            else
            {
                divLista.InnerHtml += " <thead>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <th>Nenhum registro cadastrado até o momento!</th>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += " </thead>";
            }
            rsLista.Close();
            rsLista.Dispose();

            divLista.InnerHtml += "</table>";
        }

        public void PopulaExcluidos()
        {
            divExcluidos.InnerHtml = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("EXEC admin_psRedesPorAtivo 0");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divExcluidos.InnerHtml += " <thead>";
                divExcluidos.InnerHtml += "     <tr>";
                divExcluidos.InnerHtml += "         <th style=\"width:8px;\">ID</th>";
                divExcluidos.InnerHtml += "         <th>Titulo</th>";
                divExcluidos.InnerHtml += "         <th>Cidade</th>";
                divExcluidos.InnerHtml += "         <th>UF</th>";
                divExcluidos.InnerHtml += "         <th>Data de Criação</th>";
                divExcluidos.InnerHtml += "         <th>Quantidade de Usuários</th>";
                divExcluidos.InnerHtml += "         <th style=\"width:71px;\">Ações</th>";
                divExcluidos.InnerHtml += "     </tr>";
                divExcluidos.InnerHtml += " </thead>";

                divExcluidos.InnerHtml += " <tbody>";

                while (rsLista.Read())
                {
                    divExcluidos.InnerHtml += " <tr id='tr_" + rsLista["RED_ID"].ToString() + "' class=\"\">";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["RED_ID"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["RED_TITULO"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["RED_CIDADE"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["RED_UF"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["RED_DATA_CRIACAO"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["RED_QTD_USUARIO"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td><a href=\"javascript:void(0)\" id='" + rsLista["RED_ID"].ToString() + "' onclick='restoreRede(this.id);' class=\"img_del\"><img src=\"images/restore.png\"></a>";
                    divExcluidos.InnerHtml += " </tr>";
                }

                divExcluidos.InnerHtml += " </tbody>";
            }

            else
            {
                divExcluidos.InnerHtml += " <thead>";
                divExcluidos.InnerHtml += "     <tr>";
                divExcluidos.InnerHtml += "         <th>Nenhum registro cadastrado até o momento!</th>";
                divExcluidos.InnerHtml += "     </tr>";
                divExcluidos.InnerHtml += " </thead>";
            }
            rsLista.Close();
            rsLista.Dispose();

            divExcluidos.InnerHtml += "</table>";
        }



        public void ValidarRede()
        {
            try
            {
                rsRedes = objBD.ExecutaSQL("EXEC admin_VerificaExistenciaRede '" + Request["RED_TITULO"] + "'");

                if (rsRedes == null)
                {
                    throw new Exception();
                }



                if (rsRedes.HasRows)
                {
                    rsRedes.Read();
                    Response.Write(rsRedes["MENSAGEM"] + "|" + rsRedes["VALIDO"]);
                }

                //Libera o BD e Memória
                rsRedes.Close();
                rsRedes.Dispose();





            }
            catch (Exception)
            {
                throw;
            }

        }



        public void UsuarioMassa(int quantidade, int RED_ID, string RED_TITULO, int Presencial)
        {
            if (quantidade > 0)
            {
                string tipousuario;
                if (Presencial == 1) { tipousuario = "presenciais"; } else { tipousuario = "a distancia"; }

                string mensagemtokens = "Lista de Tokens para usuarios " + tipousuario + " da Rede: " + RED_TITULO + "<br><ol>";
                for (int i = 0; i < quantidade; i++)
                {
                    rsGravaUsuario = objBD.ExecutaSQL("EXEC admin_piuUsuario '" + 0 + "','" + RED_ID + "', 'usuario_" + i + "', '', 'e10adc3949ba59abbe56e057f20f883e','',''," + Presencial + ",0,'usuario_" + i + "'");

                    if (rsGravaUsuario == null)
                    {
                        throw new Exception();
                    }

                    if (rsGravaUsuario.HasRows)
                    {
                        rsGravaUsuario.Read();
                        string accestoken = objUtils.getMD5Hash("" + rsGravaUsuario["USU_ID"]);
                        objBD.ExecutaSQL("INSERT INTO TokenUsuario (USU_ID, TOK_TOKEN) values (" + rsGravaUsuario["USU_ID"] + ", '" + accestoken + "')");
                        mensagemtokens += "<li><a href=\"http://projetopalavracantada.net/default.aspx?&accesstoken=" + accestoken + "\">Token: " + accestoken + " Usuário: usuario_" + i + "<br>";
                    }

                }
                mensagemtokens += "</ol>";


                if (objUtils.EnviaEmail(Session["email"].ToString() + ", zonaro@outlook.com", "Tokens de Acesso: " + RED_TITULO, mensagemtokens) == false)
                {
                    throw new Exception();
                }
            }
        }

        protected void GravarRede()
        {

            try
            {

                string assinatura = objUtils.ImageToBase64(Request.Files["RED_ASSINATURA"].InputStream);
                string brasao = objUtils.ImageToBase64(Request.Files["RED_BRASAO"].InputStream);

                rsRedes = objBD.ExecutaSQL("EXEC admin_piuRedes_2 '" + Request["RED_ID"] + "','" + Request["RED_TITULO"] + "', '" + Request["RED_CIDADE"] + "','" + Request["RED_UF"] + "', '" + Request["PES_BLOG"] + "', '" + Request["PES_GALERIA"] + "', '" + Request["PES_VIDEOS"] + "', '" + Request["PES_FOTOS"] + "', '" + Request["PES_CRIACOES"] + "', '" + Request["PES_FORUM"] + "', '" + Request["LIM_BLOG"] + "', '" + Request["LIM_GALERIA"] + "', '" + Request["LIM_VIDEOS"] + "', '" + Request["LIM_FOTOS"] + "', '" + Request["LIM_CRIACOES"] + "', '" + Request["LIM_FORUM"] + "', '" + Request["RED_HORAS_PRESENCIAIS"] + "', '" + Request["RED_HORAS_DISTANCIA"] + "', '" + brasao + "','" + assinatura + "','" + Request["RED_NOME_DIRETOR"] + "'");

                if (rsRedes == null)
                {
                    throw new Exception();
                }

                if (rsRedes.HasRows)
                {
                    rsRedes.Read();

                    if (Request["USU_MASSA_DISTANCIA"] != null && Request["USU_MASSA_DISTANCIA"].ToString() != "")
                    {
                        UsuarioMassa(Convert.ToInt32(Request["USU_MASSA_DISTANCIA"]), Convert.ToInt32(rsRedes["RED_ID"].ToString()), Request["RED_TITULO"], 0);
                    }

                    if (Request["USU_MASSA_PRESENCIAL"] != null && Request["USU_MASSA_PRESENCIAL"].ToString() != "")
                    {
                        UsuarioMassa(Convert.ToInt32(Request["USU_MASSA_PRESENCIAL"]), Convert.ToInt32(rsRedes["RED_ID"].ToString()), Request["RED_TITULO"], 1);
                    }
                }

                //Libera o BD e Memória
                rsRedes.Close();
                rsRedes.Dispose();
                Response.Redirect("redes.aspx", false);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}