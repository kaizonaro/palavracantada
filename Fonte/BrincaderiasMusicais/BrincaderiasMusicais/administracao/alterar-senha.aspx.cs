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

namespace BrincaderiasMusicais.administracao
{
    public partial class alterar_senha : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            switch (Request["acao"])
            {
                case ("AlterarSenha"):

//                    Response.Write("update Administrador set ADM_SENHA = '" + objUtils.getMD5Hash(Request["senha1"]) + "' where ADM_ID = 505");
 //                   Response.End();

                    objBD.ExecutaSQL("update Administrador set ADM_SENHA = '" + objUtils.getMD5Hash(Request["senha1"]) + "' where ADM_ID = " + Session["id"] + "");
                    Response.Redirect("home.aspx");
                    break;
                default:
                    break;
            }
        }
    }
}