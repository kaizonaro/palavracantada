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
        
        protected void Page_Load(object sender, EventArgs e)
        {
          
            //Verificar se ainda está logado
            if (Session["nomeUsuario"] != null && Session["nomeUsuario"].ToString().Length > 1)
            {
                //PopularBlog();
            }
            else
            {
                //DESLOGADO
                Response.Redirect("/");
            }
            
        }

    }
}