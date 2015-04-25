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
    public partial class administrador : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsLista, rsRede, rsGrava;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            switch (Request["acao"])
            {
                case ("gravar"):
                    gravar();
                    break;
                case ("excluir"):
                    excluir();
                    break;
                default:
                    PopulaLista();
                    PopularRedes();
                    break;
            }
        }

        public void PopularRedes()
        {
            rsRede = objBD.ExecutaSQL("EXEC admin_psRedesPorAtivo 1");
            if (rsRede == null)
            {
                throw new Exception();
            }
            if (rsRede.HasRows)
            {
                while (rsRede.Read())
                {
                    System.Web.UI.WebControls.ListItem R = new System.Web.UI.WebControls.ListItem();
                    R.Value = rsRede["RED_ID"].ToString();
                    R.Text = rsRede["RED_CIDADE"].ToString() + " | " + rsRede["RED_UF"].ToString();
                    RED_ID.Items.Add(R);
                }
            }
            rsRede.Close();
            rsRede.Dispose();
        }

        public void PopulaLista()
        {
            divLista.InnerHtml = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("EXEC admin_psAdministradorPorAtivo 1");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divLista.InnerHtml += " <thead>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <th style=\"width:8px;\">ID</th>";
                divLista.InnerHtml += "         <th style=\"width:120px;\">Nome</th>";
                divLista.InnerHtml += "         <th>E-Mail</th>";
                divLista.InnerHtml += "         <th style=\"width:80px;\">Último Acesso</th>";
                divLista.InnerHtml += "         <th>Rede</th>";
                divLista.InnerHtml += "         <th style=\"width:61px;\">Ações</th>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += " </thead>";

                divLista.InnerHtml += " <tbody id=\"tbCentral\">";

                while (rsLista.Read())
                {
                    divLista.InnerHtml += " <tr id='tr_" + rsLista["ADM_ID"].ToString() + "' class=\"\">";
                    divLista.InnerHtml += "     <td>" + rsLista["ADM_ID"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["ADM_NOME"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["ADM_EMAIL"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["ADM_DH_ACESSO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["RED_TITULO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td><ul class=\"icons_table\"><li><a id='" + rsLista["ADM_ID"].ToString() + "' onclick='excluir(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
                    divLista.InnerHtml += " </tr>";
                }

                divLista.InnerHtml += " </tbody>";
            }

            else
            {
                divLista.InnerHtml += " <tbody>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <td colspan=\"7\">Nenhum registro cadastrado até o momento!</td>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <td colspan=\"7\">Nenhum registro cadastrado até o momento!</td>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <td colspan=\"7\">Nenhum registro cadastrado até o momento!</td>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <td colspan=\"7\">Nenhum registro cadastrado até o momento!</td>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <td colspan=\"7\">Nenhum registro cadastrado até o momento!</td>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += " </tbody>";
            }
            rsLista.Close();
            rsLista.Dispose();

            divLista.InnerHtml += "</table>";
        }

        protected void Incluir_Click(object sender, EventArgs e)
        {
            gravar();
        }

        public void gravar()
        {
            // Salvar no BD
            objBD.ExecutaSQL("EXEC admin_piuAdministrador '" + Request["ADM_ID"] + "'," + Request["RED_ID"] + ",'" + Request["ADM_NOME"] + "','" + Request["ADM_EMAIL"] + "'");
            Response.Redirect("administrador.aspx");
            Response.End();
        }

        public void excluir()
        {
            objBD.ExecutaSQL("update Administrador set ADM_ATIVO = 0 where ADM_ID ='" + Request["ADM_ID"] + "'");
            PopulaLista();
        }
    }
}