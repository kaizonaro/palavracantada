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
        OleDbDataReader rsLista, rsDia;
        string RED_ID;
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                RED_ID = Session["redeID"].ToString();
            }
            catch (Exception)
            {
                RED_ID = "NULL";
            }

           

            if (Page.IsPostBack == false)
            {
                rsLista = objBD.ExecutaSQL("SELECT TOP(3) EVE_DIA, EVE_TITULO, EVE_DESCRICAO from Eventos WHERE EVE_ATIVO =  1 and RED_ID = " + RED_ID + " and EVE_DIA >= getdate() ORDER BY EVE_DIA DESC");
                if (rsLista == null)
                {
                    throw new Exception();
                }
                if (rsLista.HasRows)
                {

                    while (rsLista.Read())
                    {
                        topeventos.InnerHtml += "<div class=\"box_eventos\">";

                        topeventos.InnerHtml += "   <p class=\"data_agendada\">" + Convert.ToDateTime(rsLista["EVE_DIA"]).ToShortDateString() + "</p>";
                        topeventos.InnerHtml += "   <p class=\"txt txt_menor\">" + rsLista["EVE_TITULO"] + " - " + rsLista["EVE_DESCRICAO"] + "</p>";
                        topeventos.InnerHtml += "</div>";


                    }
                }
                else
                {
                    topeventos.InnerHtml += "<div class=\"box_eventos\">Não há eventos próximos</div>";
                }
            }
        }

        protected void calendario_SelectionChanged(object sender, EventArgs e)
        {
            rsLista = objBD.ExecutaSQL("SELECT EVE_DIA, EVE_TITULO, EVE_DESCRICAO from Eventos WHERE EVE_ATIVO =  1 and RED_ID = " + RED_ID + " and EVE_DIA = convert(date,'" + calendario.SelectedDate.Date + "',103)");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {

                while (rsLista.Read())
                {
                    detalhe_dataevento.InnerText = rsLista["EVE_DIA"].ToString();
                    detalhe_descricaoevento.InnerHtml = rsLista["EVE_DESCRICAO"].ToString();
                    detalhe_tituloevento.InnerText = rsLista["EVE_TITULO"].ToString();
                }
            }

        }

        protected void calendario_DayRender(object sender, DayRenderEventArgs e)
        {
            rsLista = objBD.ExecutaSQL("SELECT EVE_DIA from Eventos WHERE EVE_ATIVO =  1 and RED_ID = " + RED_ID + "  ORDER BY EVE_DIA DESC");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {

                while (rsLista.Read())
                {

                    if (e.Day.Date == Convert.ToDateTime(rsLista["EVE_DIA"].ToString()))
                    {
                        e.Day.IsSelectable = true;
                        e.Cell.BackColor = System.Drawing.Color.Orange;
                    }
                    else
                    {
                        e.Day.IsSelectable = false;
                    }
                }
            }
        }

        
         
    }
}