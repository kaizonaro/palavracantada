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
    public partial class redes_participantes : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsRedes;

        protected void Page_Load(object sender, EventArgs e)
        {
            objBD = new bd();
            objUtils = new utils();

            rsRedes = objBD.ExecutaSQL("SELECT * FROM Rede where RED_ATIVO = 1");
            if (rsRedes == null)
            {
                throw new Exception();
            }
            if (rsRedes.HasRows)
            {
                int contador = 1;
                while (rsRedes.Read())
                {
                    if (contador % 2 == 0)
                    {
                        listadireita.InnerHtml += "<li>" + rsRedes["RED_CIDADE"] + " - " + rsRedes["RED_UF"] + "</li>";
                    }
                    else
                    {
                        listaesquerda.InnerHtml += "<li>" + rsRedes["RED_CIDADE"] + " - " + rsRedes["RED_UF"] + "</li>";
                    }
                    contador++;
                }
            }
        }
    }
}