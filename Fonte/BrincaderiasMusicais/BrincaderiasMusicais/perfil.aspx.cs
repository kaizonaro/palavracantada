using Etnia.classe;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrincaderiasMusicais
{
    public partial class perfil : System.Web.UI.Page
    {
        private bd objBD = new bd();
        private utils objUtils = new utils();
        private OleDbDataReader rsPerfil;
        protected void Page_Load(object sender, EventArgs e)
        {

            rsPerfil = objBD.ExecutaSQL("EXEC PerfilUsuarioPorUsername " + Request["usuario"]);
            if (rsPerfil == null) { Response.Redirect("./default.aspx"); }
            if (rsPerfil.HasRows)
            {
                rsPerfil.Read();

                if (Session["usuID"].ToString() == rsPerfil["USU_ID"].ToString()) { Response.Redirect("../meu-perfil/" + Request["usuario"]); Response.End(); }

                if (Session["redeID"].ToString() != rsPerfil["RED_ID"].ToString()) { Response.Redirect("../default.aspx"); Response.End(); }
               
                nomeusuario.InnerText = rsPerfil["USU_NOME"].ToString();
                nomeusuario1.InnerText = rsPerfil["USU_NOME"].ToString();
                regiao.InnerText = rsPerfil["USU_REGIAO"].ToString();
                biografia.InnerText = rsPerfil["USU_BIOGRAFIA"].ToString();
                foto.Attributes.Add("src", "upload/imagens/usuarios/" + rsPerfil["USU_FOTO"].ToString());
                foto_outro.Attributes.Add("src", "upload/imagens/galeria/" + rsPerfil["USU_ULTIMAFOTO"].ToString());
                video_outro.Attributes.Add("src", rsPerfil["USU_ULTIMOVIDEO"].ToString());

            }
            rsPerfil.NextResult();
            posts.InnerHtml = "";
            if (rsPerfil.HasRows)
            {
                while (rsPerfil.Read())
                {

                    posts.InnerHtml += "<li>" +
                        "<p class=\"titu_post_home\"><a href=\"post/post-aberto-3\">" + rsPerfil["POS_TITULO"] + "</a></p>" +
                        "<p class=\"desc_post_home\"><a href=\"post/post-aberto-3\">" + objUtils.CortarString(true, 90, rsPerfil["POS_TEXTO"].ToString()) + "</a></p>" +
                        "<a href=\"post/" + objUtils.GerarURLAmigavel(rsPerfil["POS_TITULO"].ToString()) + "\" class=\"btn\">LEIA MAIS</a> </li>";
                }

            }
        }
    }
}