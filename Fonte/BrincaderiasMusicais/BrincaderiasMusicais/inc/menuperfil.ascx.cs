using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrincaderiasMusicais.inc
{
    public partial class menuperfil : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string urlCompleta = Request.Url.AbsoluteUri;
            string paginaAtual = Request.CurrentExecutionFilePath;
            paginaAtual = paginaAtual.Remove(0, paginaAtual.LastIndexOf("/") + 1);

            switch (paginaAtual)
            {
                case "editar-foto.aspx":
                    editarfoto.Attributes["class"] = "primeiro ativo";
                    editarbiografia.Attributes["class"] = "segundo";
                    configuracoes.Attributes["class"] = "terceiro";
                    break;

                case "editar-biografia.aspx":
                    editarfoto.Attributes["class"] = "primeiro";
                    editarbiografia.Attributes["class"] = "segundo ativo";
                    configuracoes.Attributes["class"] = "terceiro";
                    break;

                case "editar_config.aspx":
                    editarfoto.Attributes["class"] = "primeiro";
                    editarbiografia.Attributes["class"] = "segundo ";
                    configuracoes.Attributes["class"] = "terceiro ativo";
                    break;

                default:
                    editarfoto.Attributes["class"] = "primeiro";
                    editarbiografia.Attributes["class"] = "segundo ";
                    configuracoes.Attributes["class"] = "terceiro ";
                    break;
            }
        }
    }
}