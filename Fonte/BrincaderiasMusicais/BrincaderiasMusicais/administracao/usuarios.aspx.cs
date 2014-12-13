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
    public partial class usuarios : System.Web.UI.Page
    {

        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsLista;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            try
            {
                switch (Request["acao"])
                {
                    case ("gravarUsuario"):
                        //gravarUsuario();
                        break;
                    case ("excluirUsuario"):
                        //excluirUsuario();
                        break;
                    default:
                        PopulaLista();
                        break;
                }
            }
            catch (Exception)
            {
                Response.Redirect("erro.aspx");
                throw;
            }
        }

        public void PopulaLista()
        {
            divLista.InnerHtml = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("EXEC admin_psUsusarioPorAtivo 1");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divLista.InnerHtml += " <thead>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <th style=\"width:8px;\">ID</th>";
                divLista.InnerHtml += "         <th>Nome</th>";
                divLista.InnerHtml += "         <th>E-Mail</th>";
                divLista.InnerHtml += "         <th>Acessos</th>";
                divLista.InnerHtml += "         <th>Último Acsso</th>";
                divLista.InnerHtml += "         <th>Rede</th>";
                divLista.InnerHtml += "         <th style=\"width:61px;\">Ações</th>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += " </thead>";

                divLista.InnerHtml += " <tbody>";

                while (rsLista.Read())
                {
                    divLista.InnerHtml += " <tr id='tr_" + rsLista["USU_ID"].ToString() + "' class=\"\">";
                    divLista.InnerHtml += "     <td>" + rsLista["USU_ID"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["USU_NOME"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["USU_EMAIL"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["USU_QTD_ACESSO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["USU_DH_ULTIMO_ACESSO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["RED_TITULO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td><ul class=\"icons_table\"><li><a href=\"javascript:void(0)\" id='" + rsLista["USU_ID"].ToString() + "' onclick='popularFormulario(this.id);' class=\"img_edit\"><img src=\"images/editar.png\"></a></li><li><a id='" + rsLista["USU_ID"].ToString() + "' onclick='excluirAta(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
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
    }
}