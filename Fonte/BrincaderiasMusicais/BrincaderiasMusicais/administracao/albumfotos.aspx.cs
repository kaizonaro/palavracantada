﻿using System;
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

namespace BrincaderiasMusicais
{
    public partial class albumfotos : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsLista, rsEditar, rsGravar;


        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            switch (Request["acao"])
            {
                case ("excluirFoto"):
                    objBD.ExecutaSQL("exec admin_pudExcluirAlbumFoto " + Request["AFO_ID"]);
                    break;
                case ("restaurarFoto"):
                    objBD.ExecutaSQL("UPDATE AlbumFotos set AFO_ATIVO = 1 where AFO_ID = '" + Request["AFO_ID"] + "'");
                    break;
                case ("populaFotos"):
                    rsEditar = objBD.ExecutaSQL("EXEC psEditarAlbumFotos '" + Request["AFO_ID"] + "'");
                    if (rsEditar == null)
                    {
                        throw new Exception();
                    }
                    if (rsEditar.HasRows)
                    {
                        rsEditar.Read();
                        Response.Write(rsEditar["AFO_ID"] + "|" + rsEditar["AFO_TITULO"] + "|" + rsEditar["AFO_KEY"]);
                        Response.End();
                    }
                    break;

                default:
                    PopulaLista();
                    PopulaListaExcluidos();
                    break;
            }
        }

        public void PopulaLista()
        {
            divLista.InnerHtml = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("EXEC psAlbumFotosPorAtivo 1");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divLista.InnerHtml += " <thead>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <th style=\"width:60px;\">ID</th>";
                divLista.InnerHtml += "         <th style=\"width:300px;\">Titulo</th>";
                divLista.InnerHtml += "         <th style=\"width:175px;\">Data Publicação</th>";
                divLista.InnerHtml += "         <th style=\"width:85px;\">Ações</th>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += " </thead>";

                divLista.InnerHtml += " <tbody id=\"tbCentral\">";

                while (rsLista.Read())
                {
                    divLista.InnerHtml += " <tr id='tr_" + rsLista["AFO_ID"].ToString() + "' class=\"\">";
                    divLista.InnerHtml += "     <td>" + rsLista["AFO_ID"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["AFO_TITULO"].ToString() + "</td>";

                    divLista.InnerHtml += "     <td>" + rsLista["AFO_DH_CADASTRO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td><ul class=\"icons_table\"><li><a href=\"javascript:void(0);\" id='" + rsLista["AFO_ID"].ToString() + "' onclick='popularFormulario(this.id);' class=\"img_edit\"><img src=\"images/editar.png\"></a></li><li><a id='" + rsLista["AFO_ID"].ToString() + "' onclick='excluirFoto(this.id,\"desativar\");' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
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

        public void PopulaListaExcluidos()
        {
            divExcluidos.InnerHtml = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("EXEC psAlbumFotosPorAtivo 0");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divExcluidos.InnerHtml += " <thead>";
                divExcluidos.InnerHtml += "     <tr>";
                divExcluidos.InnerHtml += "         <th style=\"width:60px;\">ID</th>";
                divExcluidos.InnerHtml += "         <th>Titulo</th>";
                divExcluidos.InnerHtml += "         <th style=\"width:175px;\">Data Publicação</th>";
                divExcluidos.InnerHtml += "         <th style=\"width:85px;\">Ações</th>";
                divExcluidos.InnerHtml += "     </tr>";
                divExcluidos.InnerHtml += " </thead>";

                divExcluidos.InnerHtml += " <tbody id=\"tbCentral\">";

                while (rsLista.Read())
                {
                    divExcluidos.InnerHtml += " <tr id='tr_" + rsLista["AFO_ID"].ToString() + "' class=\"\">";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["AFO_ID"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["AFO_TITULO"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["AFO_DH_CADASTRO"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td><ul class=\"icons_table\"><li><a id='" + rsLista["AFO_ID"].ToString() + "' onclick='restaurarFoto(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/restore.png\"></a></li><li><a id='" + rsLista["AFO_ID"].ToString() + "' onclick='excluirFoto(this.id,\"excluir permanentemente\");' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
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

        public void gravar(object sender, EventArgs e)
        {

            rsGravar = objBD.ExecutaSQL("EXEC admin_piuAlbumFotos '" + Request["AFO_ID"] + "','" + Request["AFO_TITULO"] + "', '" + Request["AFO_KEY"] + "'");

            if (rsGravar == null)
            {
                throw new Exception();
            }

            if (rsGravar.HasRows)
            {
                rsGravar.Read();
            }

            //Libera o BD e Memória
            rsGravar.Close();
            rsGravar.Dispose();

            //Retornar para a Listagem
            Response.Redirect("albumfotos.aspx");
            Response.End();




        }
    }
}