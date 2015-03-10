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
    public partial class palavra_cantada : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsLista, rsBanner;
        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            populaBanner();

            rsLista = objBD.ExecutaSQL("SELECT * from Equipe where EQU_MANAGER =  1");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                rsLista.Read();
                paulo.InnerHtml = rsLista["EQU_DESCRICAO"].ToString();
                rsLista.Read();
                sandra.InnerHtml = rsLista["EQU_DESCRICAO"].ToString();
            }
        }

        public void populaBanner()
        {
            rsBanner = objBD.ExecutaSQL("select top 1 * from Banner where PAG_ID  = 2");

            if (rsBanner == null)
            {
                throw new Exception();
            }
            if (rsBanner.HasRows)
            {
                while (rsBanner.Read())
                {
                   banner.Attributes["src"] = "/upload/imagens/banners/" + rsBanner["BAN_IMAGEM"] + "";

                   // banner_sidebar.InnerHtml += "<a href='http://palavracantada.com.br' title='Conmheça o site oficial do palalavra cantada' target='_blank'>";
                   // banner_sidebar.InnerHtml += "    <img src='/upload/imagens/banners/" + rsBanner["BAN_IMAGEM"] + "' alt='Conmheça o site oficial do palalavra cantada' />";
                   // banner_sidebar.InnerHtml += "</a>";
                }
            }
            rsBanner.Close();
            rsBanner.Dispose();
        }
    }
}