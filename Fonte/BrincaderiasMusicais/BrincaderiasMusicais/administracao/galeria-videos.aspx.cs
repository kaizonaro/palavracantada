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

namespace BrincaderiasMusicais.administracao
{
    public partial class Galeria_Videos : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsLista, rsNotificar;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            switch (Request["acao"])
            {
                case ("Aprovar"):
                    OleDbDataReader aprova = objBD.ExecutaSQL("exec AprovaVideo " + Convert.ToInt16(Request["COV_ID"].ToString()));
                    aprova.Read();
                    objUtils.EnviaEmail(aprova["USU_EMAIL"].ToString(), "Video Galeria Colaborativa", "Parabéns, seu video <strong>" + aprova["COV_DESCRICAO"] + "</strong> acabou de ser publicado em nossa Galeria Colaborativa!");
                   // objUtils.NotificacoesGaleria("video", aprova["COV_DESCRICAO"].ToString(), Convert.ToInt16(Request["COV_ID"].ToString()),"COV_ID");
                    break;
                case ("Reprovar"):
                    OleDbDataReader reprova = objBD.ExecutaSQL("EXEC ReprovaVideo " + Convert.ToInt16(Request["COV_ID"].ToString()));
                    reprova.Read();
                    objUtils.EnviaEmail(reprova["USU_EMAIL"].ToString(), "Video Galeria Colaborativa", "Que pena, seu video <strong>" + reprova["COV_DESCRICAO"] + "</strong> não foi aprovado pelos nossos administradores");
                    break;
                default:
                    PopulaLista(Request["STATUS"]);
                    //PopulaExcluidos();
                    break;
            }
        }

       

        public void PopulaLista(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                status = "Aguardando Aprovação";
            }
            divLista.InnerHtml = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("select C.COV_ID, C.COV_TITULO, C.COV_VIDEO_ID, R.RED_TITULO, U.USU_NOME, COV_STATUS from ColaborativaVideos C INNER JOIN Rede R ON (R.RED_ID = C.RED_ID) INNER JOIN Usuario U ON (U.USU_ID = C.USU_ID) where C.COV_STATUS = '"+status+"' ORDER BY C.COV_ID DESC");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divLista.InnerHtml += " <thead>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <th style=\"width:30px;\">ID</th>";
                divLista.InnerHtml += "         <th style=\"width:120px;\">Foto</th>";
                divLista.InnerHtml += "         <th  style=\"width:200px;\">Legenda</th>";
                divLista.InnerHtml += "         <th  style=\"width:200px;\">Rede</th>";
                divLista.InnerHtml += "         <th  style=\"width:200px;\">Usuário</th>";
                divLista.InnerHtml += "         <th  style=\"width:200px;\">Status</th>";
                divLista.InnerHtml += "         <th style=\"width:85px;\">Ações</th>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += " </thead>";

                divLista.InnerHtml += " <tbody id=\"tbCentral\">";

                while (rsLista.Read())
                {
                    divLista.InnerHtml += " <tr id='tr_" + rsLista["COV_ID"].ToString() + "' class=\"\">";
                    divLista.InnerHtml += "     <td>" + rsLista["COV_ID"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td><img width='150px' src=\"http://i.ytimg.com/vi/" + rsLista["COV_VIDEO_ID"].ToString() + "/mqdefault.jpg\"></td>";
                    divLista.InnerHtml += "     <td>" + rsLista["COV_TITULO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["RED_TITULO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["USU_NOME"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["COV_STATUS"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td><ul class=\"icons_table\"><li><a href=\"javascript:void(0);\" id='" + rsLista["COV_ID"].ToString() + "' onclick='Aprovar(this.id);' class=\"img_edit\"><img src=\"images/aprovar.png\"></a></li><li><a id='" + rsLista["COV_ID"].ToString() + "' onclick='Reprovar(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
                    divLista.InnerHtml += " </tr>";
                }

                divLista.InnerHtml += " </tbody>";
            }

            else
            {
                divLista.InnerHtml += " <thead>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <th>Nenhum registro cadastrado até o momento!</th>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += " </thead>";
            }
            rsLista.Close();
            rsLista.Dispose();

            divLista.InnerHtml += "</table>";
        }

        public void gravar(object sender, EventArgs e)
        {
        }
    }
}