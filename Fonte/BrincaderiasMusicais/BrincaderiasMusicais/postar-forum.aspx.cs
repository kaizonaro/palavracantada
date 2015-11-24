using Etnia.classe;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace BrincaderiasMusicais
{
    public partial class postar_forum : System.Web.UI.Page
    {
        private utils objUtils = new utils();
        private bd objBD = new bd();
        private OleDbDataReader rsMedalhas, rsForum;

        private string url = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            FTO_ID.Value = Request["FTO_ID"];
            REDIRECT.Value = Request["REDIRECT"];

            bd banco = new bd();

           // Response.Write(Request["FTO_ID"] + "<br/>");
            //Response.Write("select FTO_ID, FTO_TITULO from ForumTopicos where FTO_ID = " + Request["FTO_ID"].ToString() + "");
            //Response.End();

            OleDbDataReader rsForum = banco.ExecutaSQL("select FTO_ID, FTO_TITULO from ForumTopicos where FTO_ID = " + Request["FTO_ID"].ToString() + "");

            if (rsForum == null)
            {
                throw new Exception();
            }
            if (rsForum.HasRows)
            {
                rsForum.Read();
                titulobrd.InnerText = rsForum["FTO_TITULO"].ToString();
                titulo.InnerText = rsForum["FTO_TITULO"].ToString();
            }

            // titulo.InnerText = textInfo.ToTitleCase(Request["REDIRECT"].Substring(Request["REDIRECT"].LastIndexOf('/') + 1)).Replace("-", " ");
            //titulobrd.InnerText = textInfo.ToTitleCase(Request["REDIRECT"].Substring(Request["REDIRECT"].LastIndexOf('/') + 1)).Replace("-", " ");
        }


        protected void pub_Click(object sender, EventArgs e)
        {
            string mensagem = Request["FME_MENSAGEM"];
            mensagem = mensagem.Replace(System.Environment.NewLine, "<br />");
            objBD.ExecutaSQL("INSERT INTO ForumMensagem (USU_ID, FME_MENSAGEM, FTO_ID) values ('" + Session["usuID"] + "','" + mensagem + "', '" + Request["FTO_ID"] + "')");

            //Indo para a tela inicial
            Thread env = new Thread(notificacoes);
            env.Start();

            Response.Redirect(Request["REDIRECT"]);
        }

        public void notificacoes()
        {
            bd banco = new bd();
            OleDbDataReader rsNotificar = banco.ExecutaSQL("EXEC admin_psNotificarForum " + Session["usuID"]);
            if (rsNotificar == null)
            {
                throw new Exception();
            }
            if (rsNotificar.HasRows)
            {

                while (rsNotificar.Read())
                {
                    if (objUtils.EnviaEmail(rsNotificar["USU_EMAIL"].ToString(), "Novo post no forum Brincadeiras Musicais", "Nova mensagem no forum da sua região, confira!") == false)
                    {
                        throw new Exception();
                    }
                }


            }
        }
    }
}