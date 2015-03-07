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
        private OleDbDataReader rsLista;
        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();
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
    }
}