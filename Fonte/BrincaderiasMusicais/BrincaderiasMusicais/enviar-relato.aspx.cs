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
    public partial class enviar_relato : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsListar;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            //Verificar se ainda está logado
            if (Session["nomeUsuario"] != null && Session["nomeUsuario"].ToString().Length > 1)
            {
               PopulaTela();
               // Relatos();
            }
            else
            {
                //DESLOGADO
                Response.Redirect("/");
            }
        }

        public void PopulaTela()
        {
            rsListar = objBD.ExecutaSQL("EXEC site_psCriacaoDocumentadasPorID '" + Request["CDO_ID"] + "' ");

            if (rsListar == null)
            {
                throw new Exception();
            }
            if (rsListar.HasRows)
            {
                rsListar.Read();
                CDO_ID.Attributes.Add("value", Request["CDO_ID"].ToString());
                titu_criacoes.InnerHtml = objUtils.RemoveHTML(rsListar["CDO_TAREFA"].ToString());
                criador.InnerHtml = rsListar["ADM_NOME"].ToString();
                data.InnerHtml = rsListar["CDO_DATA"].ToString();
                box_descritivo.InnerHtml = rsListar["CDO_DESCRITIVO"].ToString();
                video_criacoes.Attributes.Add("src", "https://www.youtube.com/embed/" + rsListar["CDO_VIDEO"].ToString());
               // aRelato.Attributes.Add("href", "/enviar-relato.aspx?CDO_ID=" + Request["CDO_ID"] + "");
                relato_detalhe.InnerHtml = "<strong>" + rsListar["TOTAL_RELATOS"].ToString() + " Relatos Enviados</strong>";

                totalComentarios.InnerHtml = rsListar["TOTAL_COMENTARIOS"].ToString() + " Comentário";

                if (Convert.ToInt16(rsListar["TOTAL_COMENTARIOS"]) > 1)
                {
                    totalComentarios.InnerHtml += "s";
                }
            }
            else
            {
                Response.Redirect("/criacoes-documentadas");
            }

            rsListar.Close();
            rsListar.Dispose();
        }

        public void gravar(object sender, EventArgs e)
        {
            objBD.ExecutaSQL("insert into Criacoes_Documentadas_Relatos (CDO_ID, CDR_RELATO,USU_ID,CDR_VIDEO) values ('" + Request["CDO_ID"] + "', '" + Request["CDR_RELATO"] + "', '" + Session["usuID"] + "', '" + objUtils.getYoutubeVideoId(Request["CDR_VIDEO"].ToString()) + "')");
            //Response.Write(Request["CDO_ID"] + "</br>");
            //Response.Write(Request["CDR_RELATO"] + "</br>");
            //Response.Write(objUtils.getYoutubeVideoId(Request["CDR_VIDEO"].ToString()));
            //Response.End();
            Response.Redirect("/tarefa-ativa/" + Request["CDO_ID"] + "");
        }
    }
}