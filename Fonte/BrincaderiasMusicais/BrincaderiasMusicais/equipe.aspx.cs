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

namespace BrincaderiasMusicais
{
	public partial class equipe : System.Web.UI.Page
	{
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsIntegrante;
        string retorno = "";
        
		protected void Page_Load(object sender, EventArgs e)
		{
            objUtils = new utils();
            objBD = new bd();

            string acao = Request["acao"];

            switch (acao)
            {
                case "mudarIntegrante":
                    mudarIntegrante(Convert.ToInt16(Request["id"]));
                    break;
                default:
                    populaIntegrante();
                    break;
            }
		}


        public void populaIntegrante()
        {
            rsIntegrante = objBD.ExecutaSQL("select EQU_ID, EQU_NOME from Equipe where EQU_ATIVO = 1 and EQU_MANAGER = 0 order by EQU_NOME");
            if (rsIntegrante == null)
            {
                throw new Exception();
            }
            if (rsIntegrante.HasRows)
            {
                while (rsIntegrante.Read())
                {
                    System.Web.UI.WebControls.ListItem R = new System.Web.UI.WebControls.ListItem();
                    R.Value = rsIntegrante["EQU_ID"].ToString();
                    R.Text = rsIntegrante["EQU_NOME"].ToString();
                    slIntegrante.Items.Add(R);
                }
            }
            rsIntegrante.Close();
            rsIntegrante.Dispose();
        }

        public void mudarIntegrante(int id)
        {
            rsIntegrante = objBD.ExecutaSQL("select EQU_NOME, EQU_FOTO, EQU_DESCRICAO from EQUIPE where EQU_ID = " + id + "");

            if (rsIntegrante == null)
            {
                throw new Exception();
            }

            if (rsIntegrante.HasRows)
            {
                rsIntegrante.Read();

                retorno += "" + rsIntegrante["EQU_NOME"].ToString() + "|" + rsIntegrante["EQU_DESCRICAO"].ToString() + "|" + rsIntegrante["EQU_FOTO"].ToString() + "|";
            }

            Response.Write(retorno);

            rsIntegrante.Close();
            rsIntegrante.Dispose();
        }
	}
}