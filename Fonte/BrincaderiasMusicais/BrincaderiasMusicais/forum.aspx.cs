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
    public partial class forum : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsLista;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            if (Session["nomeUsuario"] != null && Session["nomeUsuario"].ToString().Length > 1)
            {
                PopulaLista();
                Ultimas();
            }

            else
            {
                //DESLOGADO
                Response.Redirect("/");
            }

        }

        public void PopulaLista()
        {
            rsLista = objBD.ExecutaSQL("select FTO_ID, FTO_TITULO from ForumTopicos where FTO_ATIVO = 1");

            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                while (rsLista.Read())
                {
                    listaForum.InnerHtml += " <p class=\"titu_forum2\">";
                    listaForum.InnerHtml += "   <img src=\"images/titu_forum.png\" alt=\"Icone\" />";
                    listaForum.InnerHtml += "   <a href=\"/forum-lista/" + objUtils.GerarURLAmigavel(rsLista["FTO_TITULO"].ToString()) + "/1\" title=\"" + rsLista["FTO_TITULO"] + "\">" + rsLista["FTO_TITULO"] + ":</a>";
                    listaForum.InnerHtml += " </p>";
                }
            }
            rsLista.Close();
            rsLista.Dispose();
        }

        public void Ultimas()
        {
            rsLista = objBD.ExecutaSQL("select top 3  F.FTO_ID, U.USU_NOME, U.USU_USUARIO, FME_MENSAGEM, CONVERT(VARCHAR(10),FME_DH_PUBLICACAO, 103) AS FME_DH_PUBLICACAO, T.FTO_TITULO from ForumMensagem F inner join ForumTopicos T on (T.FTO_ID = F.FTO_ID) inner join Usuario U ON (U.USU_ID = F.USU_ID) where RED_ID = " + Session["redeID"] + " and F.FME_ATIVO = 1 order by F.FME_DH_PUBLICACAO desc");

            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                while (rsLista.Read())
                {
                    ultimasMensagens.InnerHtml += " <div class=\"txt blog_txt txt_forum\">";
                    ultimasMensagens.InnerHtml += "   <div class=\"txt\">";
                    ultimasMensagens.InnerHtml += "       <a href=\"/forum-lista/" + objUtils.GerarURLAmigavel(rsLista["FTO_TITULO"].ToString()) + "/1\" title=\"" + rsLista["FTO_TITULO"] + "\"><p>" + objUtils.CortarString(true, 100, rsLista["FME_MENSAGEM"].ToString()) + "</p></a>";
                    ultimasMensagens.InnerHtml += "       <p class=\"destque_forum\">Mensagem enviada por: <a href='/perfil/" + rsLista["USU_USUARIO"].ToString() + "' title='" + rsLista["USU_NOME"].ToString() + "'>" + rsLista["USU_NOME"].ToString() + "</a></p>";
                    ultimasMensagens.InnerHtml += "       <p class=\"destque_forum\">Enviada em: <b>" + rsLista["FME_DH_PUBLICACAO"].ToString() + "</b></p>";
                    ultimasMensagens.InnerHtml += "       <p class=\"destque_forum\">Tópico: <b><a href=\"/forum-lista/" + objUtils.GerarURLAmigavel(rsLista["FTO_TITULO"].ToString()) + "/1\" title=\"" + rsLista["FTO_TITULO"] + "\">" + rsLista["FTO_TITULO"].ToString() + "</a></b></p><br /><br />";
                    ultimasMensagens.InnerHtml += "   </div>";
                    ultimasMensagens.InnerHtml += " </div>";
                }
            }
            rsLista.Close();
            rsLista.Dispose();
        }
    }
}
