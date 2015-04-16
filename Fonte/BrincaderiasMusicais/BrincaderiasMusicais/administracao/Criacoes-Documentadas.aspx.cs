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
        private OleDbDataReader rsLista, rsRedes, rsGravar;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            switch (Request["acao"])
            {
                case ("editar"):
                    rsLista = objBD.ExecutaSQL("select CDO_ID, RED_ID, CDO_TAREFA, Convert(varchar(10),CDO_DATA, 103) as CDO_DATA, CDO_STATUS from Criacoes_Documentadas where CDO_ID ='" + Request["CDO_ID"] + "'");
                    if (rsLista == null)
                    {
                        throw new Exception();
                    }
                    if (rsLista.HasRows)
                    {
                        rsLista.Read();
                        Response.Write(rsLista["CDO_ID"] + "|" + rsLista["RED_ID"] + "|" + rsLista["CDO_TAREFA"] + "|" + rsLista["CDO_DATA"] + "|" + rsLista["CDO_STATUS"]);
                    }
                    break;
                case ("excluir"):
                    objBD.ExecutaSQL("delete Criacoes_Documentadas where  CDO_ID = '" + Request["CDO_ID"] + "'");
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
                divLista.InnerHtml += "         <th>Data</th>";
                divLista.InnerHtml += "         <th style=\"width:300px;\">Tarefa</th>";
                divLista.InnerHtml += "         <th style=\"width:200px;\">Status</th>";
                divLista.InnerHtml += "         <th style=\"width:85px;\">Ações</th>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += " </thead>";

                divLista.InnerHtml += " <tbody id=\"tbCentral\">";

                while (rsLista.Read())
                {
                    divLista.InnerHtml += " <tr id='tr_" + rsLista["CDO_ID"].ToString() + "' class=\"\">";
                    divLista.InnerHtml += "     <td>" + rsLista["CDO_DATA"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + objUtils.CortarString(true, 90, rsLista["CDO_TAREFA"].ToString()) + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["CDO_STATUS"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td><ul class=\"icons_table\"><li><a href=\"javascript:void(0);\" id='" + rsLista["CDO_ID"].ToString() + "' onclick='popularFormulario(this.id);' class=\"img_edit\"><img src=\"images/editar.png\"></a></li><li><a id='" + rsLista["CDO_ID"].ToString() + "' onclick='excluir(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
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

        public void gravar(object sender, EventArgs e)
        {
            rsGravar = objBD.ExecutaSQL("EXEC admin_piuCriacoesDocumetadas  '" + Request["CDO_ID"] + "', '" + Request["RED_ID"] + "','" + Session["id"] + "','" + Request["CDO_TAREFA"] + "','" + Request["CDO_DATA"] + "','" + Request["CDO_STATUS"] + "','" + Request["CDO_DESCRITIVO"] + "','" + Request["CDO_VIDEO"] + "','" + Request["CDO_DEVOLUTIVA"] + "','" + Request["CDO_VIDEO_DEVOLUTIVA"] + "'");
            Response.Redirect("criacoes-documentadas.aspx");
        }
    }
}