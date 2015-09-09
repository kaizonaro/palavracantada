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
    public partial class posts_forum : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsLista; 

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            switch (Request["acao"])
            {

                case ("excluirPost"):
                    objBD.ExecutaSQL("admin_pudExcluirMensagemForum " + Request["FME_ID"]);
                    break;
                case ("ativarPost"):
                    rsLista = objBD.ExecutaSQL("UPDATE ForumMensagem set FME_ATIVO = 1 where FME_ID ='" + Request["FME_ID"] + "'");
                    break;
                default:
                    PopulaLista();
                    PopulaLista(0);
                    break;
            }
        }


        public void PopulaLista(int ativo = 1)
        {
            string objeto = "";
            objeto = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("EXEC admin_psListaForumMensagem " + ativo);
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                objeto += " <thead>";
                objeto += "     <tr>";
                objeto += "         <th style=\"width:30px;\">ID</th>";
                objeto += "         <th style=\"width:120px;\">Usuário</th>";
                objeto += "         <th style=\"width:115px;\">Mensagem</th>";
                objeto += "         <th style=\"width:120px;\">Rede</th>"; 
                objeto += "         <th style=\"width:115px;\">Data Publicação</th>";
                objeto += "         <th style=\"width:85px;\">Ações</th>";
                objeto += "     </tr>";
                objeto += " </thead>";

                objeto += " <tbody id=\"tbCentral\">";

                while (rsLista.Read())
                {
                    string tr = "tr_";

                    if (ativo == 0)
                    {
                        tr = "xtr_";
                    }

                    objeto += " <tr id='" + tr + rsLista["FME_ID"].ToString() + "' class=\"\">";
                    objeto += "     <td>" + rsLista["FME_ID"].ToString() + "</td>";
                    objeto += "     <td>" + rsLista["USU_NOME"].ToString() + "</td>";
                    objeto += "     <td><textarea class='input' readonly style='width:500px;height:200px;'>" + rsLista["FME_MENSAGEM"].ToString() + "</textarea></td>";
                    objeto += "     <td>" + rsLista["RED_TITULO"] + "</td>";
                    objeto += "     <td>" + rsLista["FME_DATA"].ToString() + "</td>";
                   
                    if (ativo == 1)
                    {
                        objeto += "     <td><ul><li><a id='" + rsLista["FME_ID"].ToString() + "' onclick='excluirPost(this.id,\"desativar\");' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";

                    }
                    else
                    {
                        objeto += "     <td><ul><li><a id='" + rsLista["FME_ID"].ToString() + "' onclick='restorePost(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/restore.png\"></a></li><li><a id='" + rsLista["FME_ID"].ToString() + "' onclick='excluirPost(this.id,\"excluir permanentemente\");' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
                    }
                    objeto += " </tr>";
                }

                objeto += " </tbody>";
            }

            else
            {
                objeto += " <thead>";
                objeto += "     <tr>";
                objeto += "         <th>Nenhum registro cadastrado até o momento!</th>";
                objeto += "     </tr>";
                objeto += " </thead>";
            }
            rsLista.Close();
            rsLista.Dispose();

            objeto += "</table>";
            if (ativo == 1)
            {
                divLista.InnerHtml = objeto;
            }
            else
            {
                divExcluidos.InnerHtml = objeto;
            }
        }


    }
}