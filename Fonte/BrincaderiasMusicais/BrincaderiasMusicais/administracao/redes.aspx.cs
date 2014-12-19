using Etnia.classe;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrincaderiasMusicais.administracao
{
    public partial class redes : System.Web.UI.Page
    {

        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsLista, rsRedes, rsGravaUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            try
            {
                switch (Request["acao"])
                {
                    case ("gravarRede"):
                        gravarRede();
                        Response.Redirect("redes.aspx", false);

                        break;
                    case ("excluirRede"):
                        //excluirRede();
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

            rsLista = objBD.ExecutaSQL("EXEC admin_psRedesPorAtivo 1");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divLista.InnerHtml += " <thead>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <th style=\"width:8px;\">ID</th>";
                divLista.InnerHtml += "         <th>Titulo</th>";
                divLista.InnerHtml += "         <th>Cidade</th>";
                divLista.InnerHtml += "         <th>UF</th>";
                divLista.InnerHtml += "         <th>Data de Criação</th>";
                divLista.InnerHtml += "         <th>Quantidade de Usuários</th>";
                divLista.InnerHtml += "         <th style=\"width:71px;\">Ações</th>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += " </thead>";

                divLista.InnerHtml += " <tbody>";

                while (rsLista.Read())
                {
                    divLista.InnerHtml += " <tr id='tr_" + rsLista["RED_ID"].ToString() + "' class=\"\">";
                    divLista.InnerHtml += "     <td>" + rsLista["RED_ID"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["RED_TITULO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["RED_CIDADE"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["RED_UF"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["RED_DATA_CRIACAO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["RED_QTD_USUARIO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td><ul class=\"icons_table\"><li><a href=\"javascript:void(0)\" id='" + rsLista["RED_ID"].ToString() + "' onclick='popularFormulario(this.id);' class=\"img_edit\"><img src=\"images/editar.png\"></a></li><li><a id='" + rsLista["RED_ID"].ToString() + "' onclick='excluirAta(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
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



        public void gravarRede()
        {
            try
            {
                rsRedes = objBD.ExecutaSQL("EXEC admin_piuRedes '" + Request["RED_ID"] + "','" + Request["RED_TITULO"] + "', '" + Request["RED_CIDADE"] + "','" + Request["RED_UF"] + "'");

                if (rsRedes == null)
                {
                    throw new Exception();
                }

                if (rsRedes.HasRows)
                {
                    rsRedes.Read();
                    UsuarioMassa(Convert.ToInt32(Request["USU_MASSA"].ToString()), Convert.ToInt32(rsRedes["RED_ID"].ToString()), Request["RED_TITULO"]);
                }

                //Libera o BD e Memória
                rsRedes.Close();
                rsRedes.Dispose();
                




            }
            catch (Exception)
            {
                throw;
            }

        }



        public void UsuarioMassa(int quantidade, int RED_ID, string RED_TITULO)
        {
            string mensagemtokens = "Lista de Tokens da Rede: " + RED_TITULO +"<br><ol>";
            for (int i = 0; i < quantidade; i++)
            {
                rsGravaUsuario = objBD.ExecutaSQL("EXEC admin_piuUsuario '" + 0 + "','" + RED_ID + "', 'usuario_" + i + "', '', 'e10adc3949ba59abbe56e057f20f883e'");

                if (rsGravaUsuario == null)
                {
                    throw new Exception();
                }

                if (rsGravaUsuario.HasRows)
                {
                    rsGravaUsuario.Read();
                    int accestoken = objUtils.GerarTokenAcesso();
                    objBD.ExecutaSQL("INSERT INTO TokenUsuario (USU_ID, TOK_TOKEN) values (" + rsGravaUsuario["USU_ID"] + ", " + accestoken + ")");
                    mensagemtokens += "<li><a href=\"http://urlficticia/login?user=usuario_" + i + "accesstoken=" + accestoken + "\">Token: " + accestoken + " Usuário: usuario_" + i + "<br>";
                }

            }
            mensagemtokens += "</ol>";
            objUtils.EnviaEmail("zonaro@outlook.com,kaizonaroproject@outlook.com,gabriel.zonaro@misasi.com.br", "Tokens de Acesso: " + RED_TITULO, mensagemtokens);
        }
    }
}