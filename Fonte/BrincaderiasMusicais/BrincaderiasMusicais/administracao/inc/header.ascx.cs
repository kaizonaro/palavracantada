using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrincaderiasMusicais.administracao.inc
{
    public partial class menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario.InnerHtml = "<a href=\"javascript:void(0)\" >" + Session["nome"].ToString() + " &or;<br>Ultimo acesso " + Session["data"] + " as " + Session["hora"] + "</a>";

            if (Session["id"].ToString() == "1" || Session["id"].ToString() == "2")
            {
                liAdm.Attributes.Remove("style");   
            }
        }
    }
}