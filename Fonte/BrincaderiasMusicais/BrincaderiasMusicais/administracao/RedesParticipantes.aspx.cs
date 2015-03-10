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
    public partial class redes_participantes : System.Web.UI.Page
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
                    case ("ValidarRede"):
                        ValidarRede();
                        break;
                    case ("gravarRede"):
                        gravarRede();
                        Response.Redirect("redesparticipantes.aspx", false);

                        break;
                    case ("excluirRede"):

                        objBD.ExecutaSQL("update RedesParticipantes set REP_ATIVO = 0 where REP_ID ='" + Request["REP_ID"] + "'");
                        PopulaLista();
                        PopulaExcluidos();

                        break;
                    case ("restoreRede"):
                        objBD.ExecutaSQL("update RedesParticipantes set REP_ATIVO = 1 where REP_ID ='" + Request["REP_ID"] + "'");
                        PopulaLista();
                        PopulaExcluidos();
                        break;
                    case ("editarRede"):
                        rsLista = objBD.ExecutaSQL("select REP_ID, REP_TITULO, REP_CIDADE, REP_UF from  RedesParticipantes where REP_ID ='" + Request["REP_ID"] + "'");
                        if (rsLista == null)
                        {
                            throw new Exception();
                        }
                        if (rsLista.HasRows)
                        {
                            rsLista.Read();
                            Response.Write(rsLista["REP_ID"] + "|" + rsLista["REP_TITULO"] + "|" + rsLista["REP_CIDADE"] + "|" + rsLista["REP_UF"]);
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

            rsLista = objBD.ExecutaSQL("EXEC admin_psRedesParticipantesPorAtivo 1");
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
              
                divLista.InnerHtml += "         <th style=\"width:71px;\">Ações</th>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += " </thead>";

                divLista.InnerHtml += " <tbody>";

                while (rsLista.Read())
                {
                    divLista.InnerHtml += " <tr id='tr_" + rsLista["REP_ID"].ToString() + "' class=\"\">";
                    divLista.InnerHtml += "     <td>" + rsLista["REP_ID"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["REP_TITULO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["REP_CIDADE"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["REP_UF"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["REP_DATA_CRIACAO"].ToString() + "</td>";
                    
                    divLista.InnerHtml += "     <td><ul class=\"icons_table\"><li><a href=\"javascript:void(0)\" id='" + rsLista["REP_ID"].ToString() + "' onclick='popularFormulario(this.id);' class=\"img_edit\"><img src=\"images/editar.png\"></a></li><li><a id='" + rsLista["REP_ID"].ToString() + "' onclick='excluirRede(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
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

            rsLista = objBD.ExecutaSQL("EXEC admin_psRedesParticipantesPorAtivo 0");
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
         
                divExcluidos.InnerHtml += "         <th style=\"width:71px;\">Ações</th>";
                divExcluidos.InnerHtml += "     </tr>";
                divExcluidos.InnerHtml += " </thead>";

                divExcluidos.InnerHtml += " <tbody>";

                while (rsLista.Read())
                {
                    divExcluidos.InnerHtml += " <tr id='tr_" + rsLista["REP_ID"].ToString() + "' class=\"\">";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["REP_ID"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["REP_TITULO"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["REP_CIDADE"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["REP_UF"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["REP_DATA_CRIACAO"].ToString() + "</td>";
                   
                    divExcluidos.InnerHtml += "     <td><a href=\"javascript:void(0)\" id='" + rsLista["REP_ID"].ToString() + "' onclick='restoreRede(this.id);' class=\"img_del\"><img src=\"images/restore.png\"></a>";
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
                rsRedes = objBD.ExecutaSQL("EXEC admin_piuRedesParticipantes '" + Request["REP_ID"] + "','" + Request["REP_TITULO"] + "', '" + Request["REP_CIDADE"] + "','" + Request["REP_UF"] + "'");

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
                rsRedes = objBD.ExecutaSQL("EXEC admin_VerificaExistenciaRedeParticipante '" + Request["REP_TITULO"] + "'");

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

    }
}