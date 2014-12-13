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
        private OleDbDataReader rsLista, rsRede, rsGravaUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            switch (Request["acao"])
            {
                case ("gravarUsuario"):
                    gravarUsuario();
                    break;
                case ("excluirUsuario"):
                    excluirUsuario();
                    break;
                case("AtivarUsuario"):
                    AtivarUsuario();
                    break;
                default:
                    PopulaLista();
                    PopularRedes();
                    PopulaExcluidos();
                    break;
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
                divLista.InnerHtml += "         <th style=\"width:120px;\">Nome</th>";
                divLista.InnerHtml += "         <th>E-Mail</th>";
                divLista.InnerHtml += "         <th>Acessos</th>";
                divLista.InnerHtml += "         <th style=\"width:80px;\">Último Acesso</th>";
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
                    divLista.InnerHtml += "     <td><ul class=\"icons_table\"><li><a href=\"javascript:void(0);\" id='" + rsLista["USU_ID"].ToString() + "' onclick='popularFormulario(this.id);' class=\"img_edit\"><img src=\"images/editar.png\"></a></li><li><a id='" + rsLista["USU_ID"].ToString() + "' onclick='excluirUsuario(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
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

        public void PopulaExcluidos()
        {
            divExcluidos.InnerHtml = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("EXEC admin_psUsusarioPorAtivo 0");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divExcluidos.InnerHtml += " <thead>";
                divExcluidos.InnerHtml += "     <tr>";
                divExcluidos.InnerHtml += "         <th style=\"width:8px;\">ID</th>";
                divExcluidos.InnerHtml += "         <th style=\"width:120px;\">Nome</th>";
                divExcluidos.InnerHtml += "         <th>E-Mail</th>";
                divExcluidos.InnerHtml += "         <th>Acessos</th>";
                divExcluidos.InnerHtml += "         <th style=\"width:80px;\">Último Acesso</th>";
                divExcluidos.InnerHtml += "         <th>Rede</th>";
                divExcluidos.InnerHtml += "         <th style=\"width:61px;\">Ações</th>";
                divExcluidos.InnerHtml += "     </tr>";
                divExcluidos.InnerHtml += " </thead>";

                divExcluidos.InnerHtml += " <tbody>";

                while (rsLista.Read())
                {
                    divExcluidos.InnerHtml += " <tr id='tr_" + rsLista["USU_ID"].ToString() + "' class=\"\">";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["USU_ID"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["USU_NOME"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["USU_EMAIL"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["USU_QTD_ACESSO"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["USU_DH_ULTIMO_ACESSO"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["RED_TITULO"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td><a href=\"javascript:void(0)\" id='" + rsLista["USU_ID"].ToString() + "' onclick='restoreUsuario(this.id);' class=\"img_del\"><img src=\"images/restore.png\"></a>";
                    divExcluidos.InnerHtml += " </tr>";
                }

                divExcluidos.InnerHtml += " </tbody>";
            }

            else
            {
                divExcluidos.InnerHtml += " <thead>";
                divExcluidos.InnerHtml += "     <tr>";
                divExcluidos.InnerHtml += "         <th>Nenhum registro cadastrado até o momento!</th>";
                divExcluidos.InnerHtml += "     </tr>";
                divExcluidos.InnerHtml += " </thead>";
            }
            rsLista.Close();
            rsLista.Dispose();

            divExcluidos.InnerHtml += "</table>";
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

        public void gravarUsuario()
        {

            try
            {
                rsGravaUsuario = objBD.ExecutaSQL("EXEC admin_piuUsuario '" + Request["USU_ID"] + "','" + Request["RED_ID"] + "', '" + Request["USU_NOME"] + "','" + Request["USU_EMAIL"] + "','" + objUtils.getMD5Hash(Request["USU_SENHA"]) + "'");

                if (rsGravaUsuario == null)
                {
                    throw new Exception();
                }

                if (rsGravaUsuario.HasRows)
                {
                    rsGravaUsuario.Read();
                }

                //Libera o BD e Memória
                rsGravaUsuario.Close();
                rsGravaUsuario.Dispose();

                //Retornar para a Listagem
                Response.Redirect("usuarios.aspx");
                Response.End();
                
            }
            catch (Exception)
            {                
                throw;
            }

        }

        public void excluirUsuario()
        {
            objBD.ExecutaSQL("update Usuario set USU_ATIVO = 0 where USU_ID ='" + Request["USU_ID"] + "'");
            PopulaLista();
            PopulaExcluidos();
        }

        public void AtivarUsuario()
        {
            objBD.ExecutaSQL("update Usuario set USU_ATIVO = 1 where USU_ID ='" + Request["USU_ID"] + "'");
            PopulaLista();
            PopulaExcluidos();
        }
    }
}