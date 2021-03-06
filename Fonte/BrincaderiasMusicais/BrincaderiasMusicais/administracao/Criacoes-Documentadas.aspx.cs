﻿using Etnia.classe;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrincaderiasMusicais.administracao
{
    public partial class Criacoes_Documentadas : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        //
        private OleDbDataReader rsLista, rsRedes, rsGravar, rsNotificar, rsEditar;

        protected void Page_Load(object sender, EventArgs e)
        {

            objUtils = new utils();
            objBD = new bd();

            Response.Write(Request["acao"]);

            switch (Request["acao"])
            {
                case ("editar"):
                    rsEditar = objBD.ExecutaSQL("select CDO_ID, RED_ID, CDO_TAREFA, CDO_DATA, CDO_STATUS, CDO_DESCRITIVO, CDO_VIDEO, CDO_DEVOLUTIVA, CDO_VIDEO_DEVOLUTIVA, convert(varchar,CDO_DATA, 103) as CDO_DATA from Criacoes_Documentadas where CDO_ID = '" + Request["CDO_ID"] + "'");
                    if (rsEditar == null)
                    {
                        throw new Exception();
                    }
                    if (rsEditar.HasRows)
                    {
                        rsEditar.Read();
                        Response.Write(rsEditar["CDO_ID"] + "|" + rsEditar["RED_ID"] + "|" + rsEditar["CDO_TAREFA"] + "|" + Convert.ToDateTime(rsEditar["CDO_DATA"]).ToShortDateString() + "|" + rsEditar["CDO_STATUS"] + "|" + rsEditar["CDO_DESCRITIVO"] + "|" + rsEditar["CDO_VIDEO"] + "|" + rsEditar["CDO_DEVOLUTIVA"] + "|" + rsEditar["CDO_VIDEO_DEVOLUTIVA"]);
                    }
                    break;
                case ("arquivar"):
                    objBD.ExecutaSQL("UPDATE Criacoes_Documentadas set CDO_STATUS = '" + Request["CDO_STATUS"] + "' where  CDO_ID = '" + Request["CDO_ID"] + "'");
                    break;
                case ("excluir"):
                    objBD.ExecutaSQL("Exec admin_pudExcluiCriacoesDocumentadas '" + Request["CDO_ID"] + "'");
                    break;
                case ("FiltrarPesquisa"):
                    FiltrarPesquisa(Request["RED_ID"],"");
                    break;
                default:
                    PopulaLista();
                    ListarRedes();
                    break;
            }
        }

        public void ListarRedes()
        {
            rsRedes = objBD.ExecutaSQL("EXEC ADMIN_psRedesPorAtivo 1");
            if (rsRedes == null)
            {
                throw new Exception();
            }
            if (rsRedes.HasRows)
            {

                while (rsRedes.Read())
                {
                    ListItem C = new ListItem();
                    C.Value = rsRedes["RED_ID"].ToString();
                    C.Text = rsRedes["RED_TITULO"].ToString();
                    RED_ID.Items.Add(C);
                    FL_REDE_ID.Items.Add(C);

                }

            }
            rsRedes.Close();
            rsRedes.Dispose();
        }

        public void PopulaLista()
        {
            divLista.InnerHtml = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("EXEC admin_psCriacoesDocumentadas");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divLista.InnerHtml += " <thead>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <th style=\"width:100px;\">Data</th>";
                divLista.InnerHtml += "         <th>Proposta</th>";
                divLista.InnerHtml += "         <th style=\"width:200px;\">Rede</th>";
                divLista.InnerHtml += "         <th style=\"width:170px;\">Status</th>";
                divLista.InnerHtml += "         <th style=\"width:115px;\">Ações</th>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += " </thead>";

                divLista.InnerHtml += " <tbody id=\"tbCentral\">";

                while (rsLista.Read())
                {
                    divLista.InnerHtml += " <tr id='tr_" + rsLista["CDO_ID"].ToString() + "' class=\"\">";
                    divLista.InnerHtml += "     <td>" + rsLista["CDO_DATA"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + objUtils.CortarString(true, 90, rsLista["CDO_TAREFA"].ToString()) + "</td>";
                    divLista.InnerHtml += "     <td>" +  rsLista["RED_NOME"].ToString() + "</td>";
                    if (rsLista["CDO_STATUS"].ToString() == "Ativa")
                    {
                        divLista.InnerHtml += "     <td><select class='input' onchange='arquivar(" + rsLista["CDO_ID"].ToString() + ", this);'><option value='Ativa' selected='selected'>Ativa</option><option value='Arquivada'>Arquivada</option></select></td>";
                    }
                    else
                    {
                        divLista.InnerHtml += "     <td><select class='input' onchange='arquivar(" + rsLista["CDO_ID"].ToString() + ", this);'><option value='Ativa'>Ativa</option><option selected='selected' value='Arquivada'>Arquivada</option></select></td>";
                    }

                    divLista.InnerHtml += "     <td><ul class=\"icons_table\"><li><a id='" + rsLista["CDO_ID"].ToString() + "' onclick=\"popupwindow('relatos.aspx?CDO_ID=" + rsLista["CDO_ID"].ToString() + "', 'Relatos - Criações Documentadas', '920', '550')\" href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/relatos.png\"></a><a id='" + rsLista["CDO_ID"].ToString() + "' onclick='popularFormulario(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/editar.png\"></a></li><li><a id='" + rsLista["CDO_ID"].ToString() + "' onclick='excluir(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
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

        public void notificacoes()
        {
            rsNotificar = objBD.ExecutaSQL("EXEC admin_psNotificarCriacao " + Request["RED_ID"]);
            if (rsNotificar == null)
            {
                throw new Exception();
            }
            if (rsNotificar.HasRows)
            {

                while (rsNotificar.Read())
                {
                    if (objUtils.EnviaEmail(rsNotificar["USU_EMAIL"].ToString(), "Nova Criação Documentada", "Uma nova criação documentada foi postada no <a href='http://projetopalavracantada.net' target='_blank'>portal palavra cantada</a>") == false)
                    {
                       
                    }
                }


            }
        }

        public void FiltrarPesquisa(string RED_ID, string CDO_TAREFA)
        {
            rsLista = objBD.ExecutaSQL("EXEC admin_psCriacaoDocumentadaFiltro '" + RED_ID + "', '" + CDO_TAREFA + "'");
            if (rsLista == null)
            {
                throw new Exception();
            }
            string resposta = "";
            if (rsLista.HasRows)
            {

                resposta += " <thead>";
                resposta += "     <tr>";
                resposta += "         <th>Data</th>";
                resposta += "         <th style=\"width:300px;\">Proposta</th>";
                resposta += "         <th style=\"width:200px;\">Rede</th>";
                resposta += "         <th style=\"width:200px;\">Status</th>";
                resposta += "         <th style=\"width:85px;\">Ações</th>";
                resposta += "     </tr>";
                resposta += " </thead>";

                while (rsLista.Read())
                {
                    resposta += " <tr id='tr_" + rsLista["CDO_ID"].ToString() + "' class=\"\">";
                    resposta += "     <td>" + rsLista["CDO_DATA"].ToString() + "</td>";
                    resposta += "     <td>" + objUtils.CortarString(true, 90, rsLista["CDO_TAREFA"].ToString()) + "</td>";
                    resposta += "     <td>" + rsLista["RED_NOME"].ToString() + "</td>";
                    if (rsLista["CDO_STATUS"].ToString() == "Ativa")
                    {
                        resposta += "     <td><select class='input' onchange='arquivar(" + rsLista["CDO_ID"].ToString() + ", this);'><option value='Ativa' selected='selected'>Ativa</option><option value='Arquivada'>Arquivada</option></select></td>";
                    }
                    else
                    {
                        resposta += "     <td><select class='input' onchange='arquivar(" + rsLista["CDO_ID"].ToString() + ", this);'><option value='Ativa'>Ativa</option><option selected='selected' value='Arquivada'>Arquivada</option></select></td>";
                    }

                    resposta += "     <td><ul class=\"icons_table\"><li><a id='" + rsLista["CDO_ID"].ToString() + "' onclick='popularFormulario(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/editar.png\"></a></li><li><a id='" + rsLista["CDO_ID"].ToString() + "' onclick='excluir(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
                    resposta += " </tr>";
                }
                resposta += " </tbody>";
            }
            else
            {
                resposta += " <thead>";
                resposta += "     <tr>";
                resposta += "         <td colspan=\"5\">Nenhum resultado para esta pesquisa</td>";
                resposta += "     </tr>";
                resposta += " </thead>";
                
            }

            Response.Write(resposta);
            Response.End();

            rsLista.Close();
            rsLista.Dispose();
        }

        public void gravar(object sender, EventArgs e)
        {
            string cmd = "EXEC admin_piuCriacoesDocumetadas  '" + Request["CDO_ID"] + "', '" + Request["RED_ID"] + "','" + Session["id"] + "','" + Request["CDO_TAREFA"] + "','" + Request["CDO_DATA"] + "','" + Request["CDO_STATUS"] + "','" + Request["CDO_DESCRITIVO"] + "','" + objUtils.getYoutubeVideoId(Request["CDO_VIDEO"]) + "','" + Request["CDO_DEVOLUTIVA"] + "','" + objUtils.getYoutubeVideoId(Request["CDO_VIDEO_DEVOLUTIVA"]) + "'";
            rsGravar = objBD.ExecutaSQL(cmd);
            if (rsGravar.HasRows)
            {
                notificacoes();
            }
           
            Response.Redirect("criacoes-documentadas.aspx");
        }
    }
}