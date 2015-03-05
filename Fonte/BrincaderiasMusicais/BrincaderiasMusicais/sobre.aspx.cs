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
    public partial class sobre : System.Web.UI.Page
    {

        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsTexto;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            Popula();
        }

        public void Popula()
        {
            rsTexto = objBD.ExecutaSQL("select SOB_TEXTO_INICIAL, SOB_TEXTO_FINAL from SobreProjeto where SOB_ATIVO = 1");
            if (rsTexto == null)
            {
                throw new Exception();
            }
            if (rsTexto.HasRows)
            {
                rsTexto.Read();

                central.InnerHtml += rsTexto["SOB_TEXTO_INICIAL"].ToString();
                central.InnerHtml += "<img src='/images/img_sobre.jpg'>";
                central.InnerHtml += rsTexto["SOB_TEXTO_FINAL"].ToString();
            }
        }

    }
}