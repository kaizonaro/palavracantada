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
    public partial class headerperfil : System.Web.UI.UserControl
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

             rsUser = objBD.ExecutaSQL("select USU_BIOGRAFIA, USU_FOTO from Usuario where USU_ID = " + Session["usuID"] + " ");
               if (rsUser == null)
               {
                   throw new Exception();
               }
               if (rsUser.HasRows)
               {
                   rsUser.Read();

                   nome_perfil.InnerHtml = Session["nomeUsuario"].ToString();
                   regiao_perfil.InnerHtml = Session["nomeInstituicao"].ToString();
                   txt_perfil.InnerHtml = rsUser["USU_BIOGRAFIA"].ToString();

                   if (rsUser["USU_FOTO"].ToString().Length < 1)
                   {
                       img_perfil.InnerHtml = "<img src='/images/img_perfil.jpg'/>";
                   }
                   else
                   {
                       img_perfil.InnerHtml = "<img src=\"/upload/imagens/usuarios/" + rsUser["USU_FOTO"] + "\" />";
                   }
               }
               rsUser.Dispose();
               rsUser.Close();
        }
    }
}