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
    public partial class enviar_video : System.Web.UI.Page
    {
        private utils objUtils = new utils();
        private bd objBD = new bd();
        private OleDbDataReader rsGravar, rsMedalhas;
        protected void Page_Load(object sender, EventArgs e)
        {
            objBD = new bd();
            objUtils = new utils();

        }

        protected void gravarVideo(object sender, EventArgs e)
        {
            try
            {
                rsGravar = objBD.ExecutaSQL("EXEC admin_piuUsuarioVideos '" + Request["VID_ID"] + "','" + Session["usuID"] + "', '" + Request["VID_TITULO"] + "','" + Request["VID_LINK"].Replace("http://youtu.be/", "").Replace("https://www.youtube.com/watch?v=", "").Replace("https://youtu.be/", "") + "','" + Request["VID_LINK"].Replace("http://youtu.be/", "http://i.ytimg.com/vi/").Replace("https://www.youtube.com/watch?v=", "http://i.ytimg.com/vi/").Replace("https://youtu.be/", "http://i.ytimg.com/vi/") + "/mqdefault.jpg', '" + Request["VID_DESCRICAO"] + "'");

                if (rsGravar == null)
                {
                    throw new Exception();
                }

                if (rsGravar.HasRows)
                {
                    rsGravar.Read();
                }

                //Libera o BD e Memória
                VerificarMedalhas();
                
                rsGravar.Close();
                rsGravar.Dispose();

                //Retornar para a Listagem
                Response.Redirect("meus-videos.aspx");
                Response.End();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void VerificarMedalhas()
        {
            rsMedalhas = objBD.ExecutaSQL("SELECT COUNT(*) as TOTAL_VIDEOS FROM UsuarioVideos where USU_ID = " + Session["usuID"] + "");

            if (rsMedalhas == null)
            {
                throw new Exception();
            }
            if (rsMedalhas.HasRows)
            {
                rsMedalhas.Read();
                if (Convert.ToInt16(rsMedalhas["TOTAL_VIDEOS"]) == 3)
                {
                    objBD.ExecutaSQL("insert into Log (USU_ID, LOG_ACONTECIMENTO, LOG_EXIBIR) VALUES ('" + Session["usuID"] + "','Você ganhou a medalha PRODUTOR por publicar 3 vídeos em sua galeria pessoal.','1')");
                }
            }
        }
    }


}