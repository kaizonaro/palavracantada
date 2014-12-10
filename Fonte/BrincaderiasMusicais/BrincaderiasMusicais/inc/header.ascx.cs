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

namespace BrincaderiasMusicais.inc
{
    public partial class header : System.Web.UI.UserControl
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsBanner;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            listarBanner(Convert.ToInt16(Session["redeID"]));
        }

        public void listarBanner(int RED_ID)
        {
            try
            {
                rsBanner = objBD.ExecutaSQL("EXEC site_psBanner "+RED_ID+" ");

                if (rsBanner == null)
                {
                    throw new Exception();
                }
                if (rsBanner.HasRows)
                {
                    while (rsBanner.Read())
                    {
                       banner.InnerHtml += "<div class='banner'>";
                       banner.InnerHtml += "    <a href='" + rsBanner["BAN_LINK"] + "' title='" + rsBanner["BAN_LEGENDA"] + "'><img src='upload/imagens/banners/" + rsBanner["BAN_IMAGEM"] + "' alt='" + rsBanner["BAN_LEGENDA"] + "'/></a>";
                       banner.InnerHtml += "</div>";
                    }
                }
                rsBanner.Close();
                rsBanner.Dispose();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}