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
    public partial class galeria_geral : System.Web.UI.Page
    {
        private bd objBD = new bd();
        private utils objUtils = new utils();
        private OleDbDataReader rsGaleria;
        protected void Page_Load(object sender, EventArgs e)
        {


            rsGaleria = objBD.ExecutaSQL("EXEC psGaleriaColaborativa " + Session["redeID"]);
            if (rsGaleria == null) { throw new Exception(); }
            if (rsGaleria.HasRows)
            {
                while (rsGaleria.Read())
                {
                    ulFotos.InnerHtml += "<li><a href=\"/upload/imagens/galeria/" + rsGaleria["COF_IMAGEM"] + "\">" +
                    "<img src=\"/upload/imagens/galeria/thumb-" + rsGaleria["COF_IMAGEM"] + "\" alt=\" " + rsGaleria["COF_TITULO"] + "\"></a>" +
                    "<p>:: " + rsGaleria["COL_TITULO"] + " ::</p>" +
                    "</li>";

                }
            }

            rsGaleria.NextResult();

            if (rsGaleria.HasRows)
            {

                while (rsGaleria.Read())
                {
                    ulVideos.InnerHtml += "<li class=\"primeiro ativo\" style=\"width: 196px;\"><a href=\"" + rsGaleria["COV_VIDEO_ID"] + "\">" +
                    "<img src=\"http://i.ytimg.com/vi/" + rsGaleria["COV_VIDEO_ID"] + "/mqdefault.jpg\" alt=\"" + rsGaleria["COV_TITULO"] + "\">" +
                    "</a>" +
                    "<p>:: " + rsGaleria["COV_TITULO"] + " ::</p>" +
                    "</li>";
                }
            }

            rsGaleria.NextResult();

            if (rsGaleria.HasRows)
            {

                rsGaleria.Read();
                nomerede1.InnerText = rsGaleria["RED_TITULO"].ToString();
                nomerede2.InnerText = rsGaleria["RED_TITULO"].ToString();
            }

        }

    }
}



