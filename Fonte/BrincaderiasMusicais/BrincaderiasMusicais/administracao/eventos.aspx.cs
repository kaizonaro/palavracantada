using Etnia.classe;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrincaderiasMusicais.administracao
{
    public partial class eventos : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsLista, rsRedes, rsGravar;
        private string EVE_DIA = "", EVE_HORA = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            switch (Request["acao"])
            {
                case ("editar"):
                    rsLista = objBD.ExecutaSQL("select EVE_ID, RED_ID, EVE_TITULO, EVE_DESCRICAO, Convert(varchar(10),EVE_DIA, 103) as EVE_DIA, Convert(varchar(5),EVE_HORA,108) as EVE_HORA from Eventos where EVE_ID ='" + Request["EVE_ID"] + "'");
                    if (rsLista == null)
                    {
                        throw new Exception();
                    }
                    if (rsLista.HasRows)
                    {
                        rsLista.Read();
                        Response.Write(rsLista["EVE_ID"] + "|" + rsLista["RED_ID"] + "|" + rsLista["EVE_TITULO"] + "|" + rsLista["EVE_DESCRICAO"] + "|" + rsLista["EVE_DIA"] + "|" + rsLista["EVE_HORA"]);
                    }
                    break;
                case ("excluir"):
                    objBD.ExecutaSQL("delete Eventos where  EVE_ID = '" + Request["EVE_ID"] + "'");
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

            rsLista = objBD.ExecutaSQL("EXEC admin_psEventosPorAtivo 1");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divLista.InnerHtml += " <thead>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <th>Data | Hora</th>";
                divLista.InnerHtml += "         <th style=\"width:200px;\">Rede</th>";
                divLista.InnerHtml += "         <th style=\"width:300px;\">Título</th>";
                divLista.InnerHtml += "         <th style=\"width:85px;\">Ações</th>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += " </thead>";

                divLista.InnerHtml += " <tbody id=\"tbCentral\">";

                while (rsLista.Read())
                {
                    divLista.InnerHtml += " <tr id='tr_" + rsLista["EVE_ID"].ToString() + "' class=\"\">";
                    divLista.InnerHtml += "     <td>" + rsLista["EVE_DIA"].ToString() + " | " + rsLista["EVE_HORA"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["RED_TITULO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["EVE_TITULO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td><ul class=\"icons_table\"><li><a href=\"javascript:void(0);\" id='" + rsLista["EVE_ID"].ToString() + "' onclick='popularFormulario(this.id);' class=\"img_edit\"><img src=\"images/editar.png\"></a></li><li><a id='" + rsLista["EVE_ID"].ToString() + "' onclick='excluir(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
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
            if (Request["EVE_DIA"].Length < 1) {
                EVE_DIA = "null";
            }
            else
            {
                EVE_DIA = "'" + Request["EVE_DIA"] + "'";
            }


            if (Request["EVE_HORA"].Length < 1)
            {
                EVE_HORA = "null";
            }
            else
            {
                EVE_HORA = "'" + Request["EVE_HORA"] + "'";
            }


            //Response.Write("EXEC admin_piuEventos  '" + Request["EVE_ID"] + "', " + Request["RED_ID"] + ",'" + Session["id"] + "','" + Request["EVE_TITULO"] + "','" + Request["EVE_DESCRICAO"] + "'," + EVE_DIA + "," + EVE_HORA + "");
            //Response.End();

            rsGravar = objBD.ExecutaSQL("EXEC admin_piuEventos  '" + Request["EVE_ID"] + "', " + Request["RED_ID"] + ",'" + Session["id"] + "','" + Request["EVE_TITULO"] + "','" + Request["EVE_DESCRICAO"] + "'," + EVE_DIA + "," + EVE_HORA + "");
            Response.Redirect("eventos.aspx");
        }
    }
}