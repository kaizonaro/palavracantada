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
    public partial class usuarios : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsArtigos;
        int registro = 1, pagina_atual = 1;
        string conteudoPaginacao = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                objUtils = new utils();
                objBD = new bd();

                if (Request.QueryString["pagina"] != null)
                {
                    pagina_atual = Convert.ToInt16(Request.QueryString["pagina"]);
                }

                PopularUsuario();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void PopularUsuario()
        {
            rsArtigos = objBD.ExecutaSQL("EXEC site_psListarUsuarios " + Session["redeID"]);

            if (rsArtigos == null)
            {
                throw new Exception();
            }

            if (rsArtigos.HasRows)
            {
                msg.InnerHtml += " Visualizando usuários com perfil público da rede " + Session["nomeInstituicao"] + ", em ordem alfabética. (clique no link “ver perfil” para visualizar o perfil do usuário).";
                while (rsArtigos.Read())
                {

                    divArtigos.InnerHtml += "<div style=\"display:inline-block\" class=\"txt blog_txt\">";
                    divArtigos.InnerHtml += "   <a href=\"/perfil/" + rsArtigos["USU_USUARIO"].ToString() + "\" title=\"Ver usuario\">";

                    string src = !string.IsNullOrWhiteSpace(rsArtigos["USU_FOTO"].ToString()) ? "/upload/imagens/usuarios/" + rsArtigos["USU_FOTO"] : "images/img_perfil.jpg";

                    divArtigos.InnerHtml += "       <img  style=\"width: 80px; height: 80px;\"  src='" + src + "' class='thumb_artigo img_perfil'>";
                    divArtigos.InnerHtml += "   </a>";
                    divArtigos.InnerHtml += "   <span class=\"titu_blog\"><a style=\"float: initial;\" href=\"/usuario/" + rsArtigos["USU_USUARIO"].ToString() + "\" title=\"Ver usuario\"><strong>" + rsArtigos["USU_NOME"] + "</strong></a><br>";
                    divArtigos.InnerHtml += "<a style=\"float: left;\" href=\"/perfil/" + rsArtigos["USU_USUARIO"].ToString() + "\" title=\"Ver usuario\"><img  src='/images/btn_ver_perfil.png'></a></span>";
                    divArtigos.InnerHtml += "</div>";

                }


            }
            else
            {
                msg.InnerHtml += " Não existem usuários com perfil público na rede " + Session["nomeInstituicao"] + ".";
            }

            rsArtigos.Close();
            rsArtigos.Dispose();
        }
    }
}