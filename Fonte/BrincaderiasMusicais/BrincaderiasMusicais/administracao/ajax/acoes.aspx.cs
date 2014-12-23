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

namespace BrincaderiasMusicais.administracao.ajax
{
    public partial class acoes : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsUsuario;
        private string retorno = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                objUtils = new utils();
                objBD = new bd();

                switch (Request["acao"])
                {

                    case ("populaUsuario"):
                        populaUsuario(Convert.ToInt32(Request["USU_ID"]));
                        break;

                    case("populaVideos"):
                        populaVideos(Convert.ToInt32(Request["GVI_ID"]));
                        break;

                    case ("populaFotos"):
                        populaFotos(Convert.ToInt32(Request["GFO_ID"]));
                        break;

                    default:
                        break;
                }

            }
            catch (Exception)
            {
                
                throw;
            }
        }
        
        /* USUARIO */
        public void populaUsuario(int USU_ID)
        {
            string resultado = "";
            rsUsuario = objBD.ExecutaSQL("EXEC admin_psUsuarioPorId " + USU_ID);

            if (rsUsuario == null)
            {
                throw new Exception();
            }

            if (rsUsuario.HasRows)
            {
                rsUsuario.Read();
                resultado = rsUsuario["USU_ID"] + "|" + rsUsuario["RED_ID"] + "|" + rsUsuario["USU_NOME"] + "|" + rsUsuario["USU_EMAIL"] + "|" + rsUsuario["USU_SENHA"];
            }

            Response.Write(resultado);
            Response.End();
        }

        /* VIDEOS */
        public void populaVideos(int GVI_ID)
        {
            string resultado = "";
            rsUsuario = objBD.ExecutaSQL("EXEC admin_psGaleriaVideosPorId " + GVI_ID);

            if (rsUsuario == null)
            {
                throw new Exception();
            }

            if (rsUsuario.HasRows)
            {
                rsUsuario.Read();
                resultado = GVI_ID + "|" + rsUsuario["RED_ID"] + "|" + rsUsuario["GVI_TITULO"] + "|" + rsUsuario["GVI_LINK"];
            }

            Response.Write(resultado);
            Response.End();
        }

        /* FOTOS */
        public void populaFotos(int GFO_ID)
        {
            string resultado = "";
            rsUsuario = objBD.ExecutaSQL("EXEC admin_psGaleriaFotosPorId " + GFO_ID);

            if (rsUsuario == null)
            {
                throw new Exception();
            }

            if (rsUsuario.HasRows)
            {
                rsUsuario.Read();
                resultado = GFO_ID + "|" + rsUsuario["RED_ID"] + "|" + rsUsuario["GFO_LEGENDA"];
            }

            Response.Write(resultado);
            Response.End();
        } 
    }
}