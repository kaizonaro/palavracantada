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
    public partial class fac : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsFAQ;
        string retorno = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            //Verificar se ainda está logado
            if (Session["nomeUsuario"] != null && Session["nomeUsuario"].ToString().Length > 1)
            {
                string acao = Request["acao"];

                switch (acao)
                {
                    case "mudarFAQ":
                        mudarFAQ(Convert.ToInt16(Request["id"]));
                        break;
                    default:
                        populaIntegrante();
                        break;
                }
            }
            else
            {
                //DESLOGADO
                Response.Redirect("/");
            }            
        }

        public void populaIntegrante()
        {
            rsFAQ = objBD.ExecutaSQL("select FAQ_ID, FAQ_PERGUNTA, RED_ID from Faq where FAQ_ATIVO = 1 AND (RED_ID IS NULL OR RED_ID = " + Session["redeID"] + ")");
            if (rsFAQ == null)
            {
                throw new Exception();
            }
            if (rsFAQ.HasRows)
            {
                while (rsFAQ.Read())
                {
                    System.Web.UI.WebControls.ListItem R = new System.Web.UI.WebControls.ListItem();
                    R.Value = rsFAQ["FAQ_ID"].ToString();
                    R.Text = rsFAQ["FAQ_PERGUNTA"].ToString();
                    pergunta.Items.Add(R);
                }
            }
            rsFAQ.Close();
            rsFAQ.Dispose();
        }

        public void mudarFAQ(int id)
        {
            rsFAQ = objBD.ExecutaSQL("select FAQ_PERGUNTA, FAQ_RESPOSTA from Faq where FAQ_ID = " + id + "");

            if (rsFAQ == null)
            {
                throw new Exception();
            }

            if (rsFAQ.HasRows)
            {
                rsFAQ.Read();

                retorno += "" + rsFAQ["FAQ_PERGUNTA"].ToString() + "|" + rsFAQ["FAQ_RESPOSTA"].ToString() + "|";
            }

            Response.Write(retorno);

            rsFAQ.Close();
            rsFAQ.Dispose();
        }
    }
}