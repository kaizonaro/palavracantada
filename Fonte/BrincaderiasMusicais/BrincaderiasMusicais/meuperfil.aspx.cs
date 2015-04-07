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
    public partial class meuperfil : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            //Verificar se ainda está logado
            if (Session["nomeUsuario"] != null && Session["nomeUsuario"].ToString().Length > 1)
            {
                rsUsuario = objBD.ExecutaSQL("select USU_ID, RED_ID from usuario where USU_USUARIO = '" + Request["usuario"].ToString() + "'");

                if (rsUsuario == null)
                {
                    throw new Exception();
                }
                if (rsUsuario.HasRows)
                {
                    rsUsuario.Read();

                    if (rsUsuario["USU_ID"].ToString() == Session["usuID"].ToString())
                    {
                        Response.Write("é o mesmo");

                    }
                    else if ((rsUsuario["USU_ID"].ToString() != Session["usuID"].ToString()) && rsUsuario["RED_ID"].ToString() == Session["redeID"].ToString())
                    {
                        Response.Redirect("/perfil/" + Request["usuario"].ToString());
                        Response.End();
               
                    }
                    else
                    {
                        Response.Write("outro e rede diferente");
                    }
                }
                else
                {

                }
                rsUsuario.Close();
                rsUsuario.Dispose();
            }
            else
            {
                //DESLOGADO
                Response.Redirect("/");
            }
        }

    }
}