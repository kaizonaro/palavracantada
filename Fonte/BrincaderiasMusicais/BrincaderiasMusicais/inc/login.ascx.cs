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
    public partial class login : System.Web.UI.UserControl
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["nomeUsuario"] != null && Session["nomeUsuario"].ToString().Length > 1)
            {
               //LOGADO
               box_logado.Attributes.Add("class", "box_logado");
               banner_sidebar.Attributes.Add("class", "esconde");
               box_login.Attributes.Add("class", "esconde");
            }
            else
            {
                //DESLOGADO
            }
        }
    }
}