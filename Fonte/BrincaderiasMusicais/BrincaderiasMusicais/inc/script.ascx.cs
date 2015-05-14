using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Etnia.classe;

namespace BrincaderiasMusicais.inc
{
    public partial class script : System.Web.UI.UserControl
    {
        bd objBD = new bd();
        utils objUtils = new utils();
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie cookie = Request.Cookies["palavracantada"];

            if (cookie != null && Session["usuID"] == null)
            {
                OleDbDataReader rsLogin = objBD.ExecutaSQL("EXEC site_psUsuarioPorUsuId " + cookie.Value);
                rsLogin.Read();
                Session["nomeUsuario"] = rsLogin["USU_NOME"].ToString();
                Session["usuID"] = rsLogin["USU_ID"].ToString();
                Session["nomeInstituicao"] = rsLogin["RED_TITULO"].ToString();
                Session["redeID"] = rsLogin["RED_ID"].ToString();
                Session["redeTitulo"] = objUtils.GerarURLAmigavel(rsLogin["RED_TITULO"].ToString());
                Session["usuUsuario"] = rsLogin["USU_USUARIO"].ToString();
                Session["usuEmail"] = Request["email"];

                cookie.Expires = DateTime.Now.AddHours(168); //1 semana
                Response.Cookies.Add(cookie);
            }

             
        }
    }
}