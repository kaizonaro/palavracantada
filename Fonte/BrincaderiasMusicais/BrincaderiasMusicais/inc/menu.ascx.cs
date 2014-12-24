using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrincaderiasMusicais.inc
{
    public partial class menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string urlCompleta = Request.Url.AbsoluteUri;
            string paginaAtual = Request.CurrentExecutionFilePath;
            paginaAtual = paginaAtual.Remove(0, paginaAtual.LastIndexOf("/") + 1);

            Response.Write(paginaAtual);

            switch (paginaAtual)
            {

                case "sobre.aspx":
                    conheca.Attributes["class"] = "menu_ativo";
                    explore.Attributes.Remove("class");
                    blog.Attributes.Remove("class");
                    contato.Attributes.Remove("class");
                    break;

                case "post.aspx":
                    blog.Attributes["class"] = "menu_ativo";
                    explore.Attributes.Remove("class");
                    conheca.Attributes.Remove("class");
                    contato.Attributes.Remove("class");
                    break;

                default:
                    conheca.Attributes.Remove("class");
                    explore.Attributes.Remove("class");
                    blog.Attributes.Remove("class");
                    contato.Attributes.Remove("class");
                    break;
            }
        }
    }
}