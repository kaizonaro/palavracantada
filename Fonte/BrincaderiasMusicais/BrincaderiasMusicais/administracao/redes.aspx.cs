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
                    case("ValidarRede"):
                        ValidarRede();
                        break;
                    case ("gravarRede"):
                        gravarRede();
                        Response.Redirect("redes.aspx", false);

                        break;
                    case ("excluirRede"):

                        objBD.ExecutaSQL("update Rede set RED_ATIVO = 0 where RED_ID ='" + Request["RED_ID"] + "'");
                        PopulaLista();
                        PopulaExcluidos();

                        break;
                    case ("restoreRede"):
                        objBD.ExecutaSQL("update Rede set RED_ATIVO = 1 where RED_ID ='" + Request["RED_ID"] + "'");
                        PopulaLista();
                        PopulaExcluidos();
                        break;
                    case ("editarRede"):
                        rsLista = objBD.ExecutaSQL("select RED_ID, RED_TITULO, RED_CIDADE, RED_UF, (select COUNT(*) from usuario where red_id = " + Request["RED_ID"] + " and USU_ATIVO = 1) as total  from  Rede where RED_ID ='" + Request["RED_ID"] + "'");
                        if (rsLista == null)
                        {
                            throw new Exception();
                        }
                        if (rsLista.HasRows)
                        {
                            rsLista.Read();
                            Response.Write(rsLista["RED_ID"] + "|" + rsLista["RED_TITULO"] + "|" + rsLista["RED_CIDADE"] + "|" + rsLista["RED_UF"] + "|" +rsLista["total"]);
                        }
                        break;
                    default:
                        PopulaLista();
                        PopulaExcluidos();
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
                    divLista.InnerHtml += "     <td><ul class=\"icons_table\"><li><a href=\"javascript:void(0)\" id='" + rsLista["RED_ID"].ToString() + "' onclick='popularFormulario(this.id);' class=\"img_edit\"><img src=\"images/editar.png\"></a></li><li><a id='" + rsLista["RED_ID"].ToString() + "' onclick='excluirRede(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
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

            rsLista = objBD.ExecutaSQL("EXEC admin_psRedesPorAtivo 0");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divExcluidos.InnerHtml += " <thead>";
                divExcluidos.InnerHtml += "     <tr>";
                divExcluidos.InnerHtml += "         <th style=\"width:8px;\">ID</th>";
                divExcluidos.InnerHtml += "         <th>Titulo</th>";
                divExcluidos.InnerHtml += "         <th>Cidade</th>";
                divExcluidos.InnerHtml += "         <th>UF</th>";
                divExcluidos.InnerHtml += "         <th>Data de Criação</th>";
                divExcluidos.InnerHtml += "         <th>Quantidade de Usuários</th>";
                divExcluidos.InnerHtml += "         <th style=\"width:71px;\">Ações</th>";
                divExcluidos.InnerHtml += "     </tr>";
                divExcluidos.InnerHtml += " </thead>";

                divExcluidos.InnerHtml += " <tbody>";

                while (rsLista.Read())
                {
                    divExcluidos.InnerHtml += " <tr id='tr_" + rsLista["RED_ID"].ToString() + "' class=\"\">";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["RED_ID"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["RED_TITULO"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["RED_CIDADE"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["RED_UF"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["RED_DATA_CRIACAO"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["RED_QTD_USUARIO"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td><a href=\"javascript:void(0)\" id='" + rsLista["RED_ID"].ToString() + "' onclick='restoreRede(this.id);' class=\"img_del\"><img src=\"images/restore.png\"></a>";
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
                    UsuarioMassa(Convert.ToInt32(Request["USU_MASSA"]), Convert.ToInt32(rsRedes["RED_ID"].ToString()), Request["RED_TITULO"]);
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

        public void ValidarRede()
        {
            try
            {
                rsRedes = objBD.ExecutaSQL("EXEC admin_VerificaExistenciaRede '" + Request["RED_TITULO"] + "'");

                if (rsRedes == null)
                {
                    throw new Exception();
                }
                 


                if (rsRedes.HasRows)
                {
                    rsRedes.Read();
                   Response.Write(rsRedes["MENSAGEM"] + "|" + rsRedes["VALIDO"]);
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
            if (quantidade > 0)
            {
                string mensagemtokens = "Lista de Tokens da Rede: " + RED_TITULO + "<br><ol>";
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
                        mensagemtokens += "<li><a href=\"http://localhost:5131/default.aspx?&accesstoken=" + accestoken + "\">Token: " + accestoken + " Usuário: usuario_" + i + "<br>";
                    }

                }
                mensagemtokens += "</ol>";
                objUtils.EnviaEmail("zonaro@outlook.com,kaizonaroproject@outlook.com,gabriel.zonaro@misasi.com.br", "Tokens de Acesso: " + RED_TITULO, mensagemtokens);
            }
        }
    }
}