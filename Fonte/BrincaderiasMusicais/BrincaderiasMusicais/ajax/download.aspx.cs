using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrincaderiasMusicais.ajax
{
    public partial class download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string arquivo = Request["arquivo"].ToString();
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=\"" + arquivo.Replace(" ","%20") + "\"");
            // Define um tipo de acordo com a extensão
            if (arquivo.Contains(".pdf"))
                Response.ContentType = "application/pdf";
            else if (arquivo.Contains(".txt"))
                Response.ContentType = "text/plain";
            else if (arquivo.Contains(".mdb"))
                Response.ContentType = "application/x-msaccess";
            else if (arquivo.Contains(".gif"))
                Response.ContentType = "image/gif";
            else if (arquivo.Contains(".jpeg") ||
                     arquivo.Contains(".jpg"))
                Response.ContentType = "image/jpeg";
            else if (arquivo.Contains(".ai"))
                Response.ContentType = "application/postscript";
            else if (arquivo.Contains(".crd"))
                Response.ContentType = "application/cdr";
            Response.WriteFile(MapPath("~/upload/imagens/artigo/pdf/" + arquivo + ""));
        }
    }
}