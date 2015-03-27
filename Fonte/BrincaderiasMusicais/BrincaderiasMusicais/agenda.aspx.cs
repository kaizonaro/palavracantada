using Etnia.classe;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrincaderiasMusicais
{
    public partial class agenda : System.Web.UI.Page
    {
        utils objUtils = new utils();
        bd objBD = new bd();
        OleDbDataReader rsLista;

        protected void Page_Load(object sender, EventArgs e)
        {
            string RED_ID;
            try
            {
                RED_ID = Session["redeID"].ToString();
            }
            catch (Exception)
            {
                RED_ID = "NULL";
            }


            rsLista = objBD.ExecutaSQL("SELECT TOP(3) EVE_DIA, EVE_TITULO, EVE_DESCRICAO from Eventos WHERE EVE_ATIVO =  1 and RED_ID = " + RED_ID + " ORDER BY EVE_DIA DESC");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {

                while (rsLista.Read())
                {
                    topeventos.InnerHtml += "<div class=\"box_eventos\">";
                    topeventos.InnerHtml += "   <p class=\"data_agendada\"><a href=\"#\">" + Convert.ToDateTime(rsLista["EVE_DIA"]).ToShortDateString() + "</a></p>";
                    topeventos.InnerHtml += "   <p class=\"txt txt_menor\">"+ rsLista["EVE_TITULO"]+ " - " + rsLista["EVE_DESCRICAO"] + "</p>";
                    topeventos.InnerHtml += "</div>";


                }
            }
            else
            {
                topeventos.InnerHtml += "<div class=\"box_eventos\">Não há eventos próximos</div>";
            }
        }

        protected void calendario_SelectionChanged(object sender, EventArgs e)
        {
            detalhe_dataevento.InnerText = calendario.SelectedDate.ToShortDateString();
        }
    }
}