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
    public partial class editar_biografia : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsBiografia;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            //Verificar se ainda está logado
            if (Session["nomeUsuario"] != null && Session["nomeUsuario"].ToString().Length > 1)
            {
                switch (Request["acao"])
                {
                    case ("editar"):
                        objBD.ExecutaSQL("update Usuario set USU_BIOGRAFIA = '" + Request["txtTextarea"] + "' where USU_ID = '" + Session["usuID"] + "'");
                        Response.Redirect("meu-perfil");
                        break;
                    default:
                        PopulaBiografia();
                        break;
                }

            }
            else
            {
                //DESLOGADO
                Response.Redirect("/");
            }
        }

        public void PopulaBiografia()
        {
            rsBiografia = objBD.ExecutaSQL("select USU_BIOGRAFIA from Usuario where USU_ID = '" + Session["usuID"] + "' ");

            if (rsBiografia == null)
            {
                throw new Exception();
            }
            if (rsBiografia.HasRows)
            {
                rsBiografia.Read();

                if (rsBiografia["USU_BIOGRAFIA"].ToString().Length < 1)
                {
                    txtTextarea.Attributes.Add("placeholder", "Você ainda não criou a sua mini-biografia.Clique aqui para escrevar uma.(máximo 250 caracteres)");
                }
                else
                {
                    txtTextarea.InnerHtml += rsBiografia["USU_BIOGRAFIA"].ToString();
                }
            }
        }
    }
}